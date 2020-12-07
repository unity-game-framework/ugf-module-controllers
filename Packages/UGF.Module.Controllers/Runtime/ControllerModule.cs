using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModule : ApplicationModule<ControllerModuleDescription>, IControllerModule
    {
        public IReadOnlyDictionary<GlobalId, IController> Controllers { get; }

        IControllerModuleDescription IControllerModule.Description { get { return Description; } }

        private readonly Dictionary<GlobalId, IController> m_controllers = new Dictionary<GlobalId, IController>();
        private readonly InitializeCollection<IController> m_initialize;

        public ControllerModule(ControllerModuleDescription description, IApplication application) : base(description, application)
        {
            Controllers = new ReadOnlyDictionary<GlobalId, IController>(m_controllers);

            m_initialize = new InitializeCollection<IController>(description.UseReverseUninitializationOrder);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (KeyValuePair<GlobalId, IControllerBuilder> pair in Description.Controllers)
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
                GlobalId id = m_controllers.First().Key;

                RemoveController(id);
            }
        }

        public void AddController(GlobalId id, IController controller)
        {
            if (id.IsEmpty) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            m_controllers.Add(id, controller);
            m_initialize.Add(controller);
        }

        public bool RemoveController(GlobalId id)
        {
            if (id.IsEmpty) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (TryGetController(id, out IController controller))
            {
                m_controllers.Remove(id);
                m_initialize.Remove(controller);

                return true;
            }

            return false;
        }

        public T GetController<T>(GlobalId id) where T : class, IController
        {
            return (T)GetController(id);
        }

        public IController GetController(GlobalId id)
        {
            return TryGetController(id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public bool TryGetController<T>(GlobalId id, out T controller) where T : class, IController
        {
            if (TryGetController(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGetController(GlobalId id, out IController controller)
        {
            if (id.IsEmpty) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return m_controllers.TryGetValue(id, out controller);
        }
    }
}
