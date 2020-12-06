using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModule : ApplicationModule<ControllerModuleDescription>, IControllerModule
    {
        public IReadOnlyDictionary<string, IController> Controllers { get; }

        IControllerModuleDescription IControllerModule.Description { get { return Description; } }

        private readonly Dictionary<string, IController> m_controllers = new Dictionary<string, IController>();
        private readonly InitializeCollection<IController> m_initialize;

        public ControllerModule(ControllerModuleDescription description, IApplication application) : base(description, application)
        {
            Controllers = new ReadOnlyDictionary<string, IController>(m_controllers);

            m_initialize = new InitializeCollection<IController>(description.UseReverseUninitializationOrder);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (KeyValuePair<string, IControllerBuilder> pair in Description.Controllers)
            {
                IController controller = pair.Value.Build(Application);

                AddController(pair.Key, controller);
            }

            m_initialize.Initialize();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_initialize.Uninitialize();

            while (m_controllers.Count > 0)
            {
                string id = m_controllers.First().Key;

                RemoveController(id);
            }
        }

        public void AddController(string id, IController controller)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            m_controllers.Add(id, controller);
            m_initialize.Add(controller);
        }

        public bool RemoveController(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (TryGetController(id, out IController controller))
            {
                m_controllers.Remove(id);
                m_initialize.Remove(controller);

                return true;
            }

            return false;
        }

        public T GetController<T>(string id) where T : class, IController
        {
            return (T)GetController(id);
        }

        public IController GetController(string id)
        {
            return TryGetController(id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public bool TryGetController<T>(string id, out T controller) where T : class, IController
        {
            if (TryGetController(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGetController(string id, out IController controller)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return m_controllers.TryGetValue(id, out controller);
        }
    }
}
