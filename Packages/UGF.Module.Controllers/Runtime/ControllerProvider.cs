using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerProvider : InitializeBase, IControllerProvider
    {
        public IReadOnlyDictionary<string, IController> Controllers { get; }

        private readonly Dictionary<string, IController> m_controllers = new Dictionary<string, IController>();
        private readonly InitializeCollection<IController> m_initialize = new InitializeCollection<IController>();

        public ControllerProvider()
        {
            Controllers = new ReadOnlyDictionary<string, IController>(m_controllers);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            m_initialize.Initialize();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_initialize.Uninitialize();
        }

        public void Add(string id, IController controller)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            m_controllers.Add(id, controller);
            m_initialize.Add(controller);
        }

        public bool Remove(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (TryGet(id, out IController controller))
            {
                m_controllers.Remove(id);
                m_initialize.Remove(controller);
                return true;
            }

            return false;
        }

        public void Clear()
        {
            m_controllers.Clear();
            m_initialize.Clear();
        }

        public T Get<T>(string id) where T : class, IController
        {
            return (T)Get(id);
        }

        public IController Get(string id)
        {
            return TryGet(id, out IController value) ? value : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public bool TryGet<T>(string id, out T controller) where T : class, IController
        {
            if (TryGet(id, out IController value))
            {
                controller = (T)value;
                return false;
            }

            controller = default;
            return false;
        }

        public bool TryGet(string id, out IController controller)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return m_controllers.TryGetValue(id, out controller);
        }

        public Dictionary<string, IController>.Enumerator GetEnumerator()
        {
            return m_controllers.GetEnumerator();
        }
    }
}
