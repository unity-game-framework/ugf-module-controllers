using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerInstanceController : ControllerAsync
    {
        public GlobalId Id { get; }
        public IControllerBuilder Builder { get; }
        public IController Controller { get { return m_controller ?? throw new AggregateException("Value not specified."); } }

        private IController m_controller;

        public ControllerInstanceController(IApplication application, IControllerBuilder builder) : this(application, GlobalId.Generate(), builder)
        {
        }

        public ControllerInstanceController(IApplication application, GlobalId id, IControllerBuilder builder) : base(application)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            Id = id;
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            m_controller = Builder.Build(Application);

            Application.AddController(Id, m_controller);

            m_controller.Initialize();
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();

            if (Controller is IControllerAsyncInitialize controller)
            {
                await controller.InitializeAsync();
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_controller.Uninitialize();

            Application.RemoveController(Id);
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
            if (Controller is ControllerCollectionController collection && collection.Controllers.TryGet(out controller))
            {
                return true;
            }

            controller = Controller as T;
            return controller != null;
        }

        public bool TryGet(Type type, out IController controller)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (Controller is ControllerCollectionController collection && collection.Controllers.TryGet(type, out controller))
            {
                return true;
            }

            if (type.IsInstanceOfType(Controller))
            {
                controller = Controller;
                return true;
            }

            controller = default;
            return false;
        }

        public T Get<T>(GlobalId id) where T : class, IController
        {
            return (T)Get(id);
        }

        public IController Get(GlobalId id)
        {
            return TryGet(id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public bool TryGet<T>(GlobalId id, out T controller) where T : class, IController
        {
            if (TryGet(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGet(GlobalId id, out IController controller)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (Id == id)
            {
                controller = Controller;
                return true;
            }

            if (Controller is ControllerCollectionController collection)
            {
                return collection.TryGet(id, out controller);
            }

            controller = default;
            return false;
        }
    }
}
