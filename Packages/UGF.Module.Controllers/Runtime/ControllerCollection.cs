using System;
using UGF.Initialize.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerCollection<TController> : Provider<string, TController>, IInitialize where TController : class, IController
    {
        public bool IsInitialized { get { return m_state; } }

        public event InitializeHandler Initialized;
        public event InitializeHandler Uninitialized;

        private readonly InitializeCollection<IController> m_initializeCollection = new InitializeCollection<IController>();
        private InitializeState m_state;

        public void Initialize()
        {
            m_state = m_state.Initialize();
            m_initializeCollection.Initialize();

            Initialized?.Invoke(this);
        }

        public void Uninitialize()
        {
            m_state = m_state.Uninitialize();
            m_initializeCollection.Uninitialize();

            Uninitialized?.Invoke(this);
        }

        public T Get<T>() where T : class, IController
        {
            return (T)Get(typeof(T));
        }

        public IController Get(Type type)
        {
            return TryGet(type, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified type: '{type}'.");
        }

        public bool TryGet<T>(out T controller) where T : class, IController
        {
            if (TryGet(typeof(T), out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGet(Type type, out IController controller)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            foreach ((_, TController value) in this)
            {
                if (type.IsInstanceOfType(value))
                {
                    controller = value;
                    return true;
                }

                if (value is ControllerCollectionController collection && collection.Controllers.TryGet(type, out controller))
                {
                    return true;
                }
            }

            controller = default;
            return false;
        }

        protected override void OnAdd(string id, TController entry)
        {
            base.OnAdd(id, entry);

            m_initializeCollection.Add(entry);
        }

        protected override bool OnRemove(string id, TController entry)
        {
            m_initializeCollection.Remove(entry);

            return base.OnRemove(id, entry);
        }

        protected override void OnClear()
        {
            base.OnClear();

            m_initializeCollection.Clear();
        }
    }
}
