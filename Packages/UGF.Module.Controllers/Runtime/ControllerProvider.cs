using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UGF.EditorTools.Runtime.Ids;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerProvider : InitializeBase, IControllerProvider
    {
        public IReadOnlyDictionary<GlobalId, IController> Controllers { get; }

        private readonly Dictionary<GlobalId, IController> m_controllers = new Dictionary<GlobalId, IController>();
        private readonly InitializeCollection<IController> m_initialize = new InitializeCollection<IController>();

        public ControllerProvider()
        {
            Controllers = new ReadOnlyDictionary<GlobalId, IController>(m_controllers);
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

        public void Add(GlobalId id, IController controller)
        {
            if (id.IsEmpty) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            m_controllers.Add(id, controller);
            m_initialize.Add(controller);
        }

        public bool Remove(GlobalId id)
        {
            if (id.IsEmpty) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

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

        public T Get<T>(GlobalId id) where T : class, IController
        {
            return (T)Get(id);
        }

        public IController Get(GlobalId id)
        {
            return TryGet(id, out IController value) ? value : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public bool TryGet<T>(GlobalId id, out T controller) where T : class, IController
        {
            if (TryGet(id, out IController value))
            {
                controller = (T)value;
                return false;
            }

            controller = default;
            return false;
        }

        public bool TryGet(GlobalId id, out IController controller)
        {
            if (id.IsEmpty) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return m_controllers.TryGetValue(id, out controller);
        }

        public Dictionary<GlobalId, IController>.Enumerator GetEnumerator()
        {
            return m_controllers.GetEnumerator();
        }
    }
}
