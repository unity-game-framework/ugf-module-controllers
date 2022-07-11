using System;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.FileIds;
using UGF.EditorTools.Runtime.Ids;
using UGF.RuntimeTools.Runtime.Containers;

namespace UGF.Module.Controllers.Runtime.Containers
{
    public abstract class ContainerComponentController : ControllerAsync
    {
        public ContainerComponent Container { get { return m_container ? m_container : throw new ArgumentException("Value not specified."); } }
        public ControllerComponent Component { get { return m_component ? m_component : throw new ArgumentException("Value not specified."); } }
        public ControllerInstanceController Instance { get { return m_instance ?? throw new ArgumentException("Value not specified."); } }

        private ContainerComponent m_container;
        private ControllerComponent m_component;
        private ControllerInstanceController m_instance;

        protected ContainerComponentController(IApplication application) : base(application)
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            m_container = OnGetContainer();
            m_component = Container.Get<ControllerComponent>();

            m_instance = new ControllerInstanceController(Application, Component.GetControllerId(), Component);
            m_instance.Initialize();
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();
            await Instance.InitializeAsync();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            OnReleaseContainer();

            m_container = null;
            m_component = null;
            m_instance.Uninitialize();
            m_instance = null;
        }

        protected abstract ContainerComponent OnGetContainer();

        protected virtual void OnReleaseContainer()
        {
        }

        public T Get<T>() where T : class, IController
        {
            return Instance.Get<T>();
        }

        public T Get<T>(GlobalId id) where T : class, IController
        {
            return Instance.Get<T>(id);
        }

        public IController Get(GlobalId id)
        {
            return Instance.Get(id);
        }

        public bool TryGet<T>(GlobalId id, out T controller) where T : class, IController
        {
            return Instance.TryGet(id, out controller);
        }

        public bool TryGet(GlobalId id, out IController controller)
        {
            return Instance.TryGet(id, out controller);
        }

        public T Get<T>(FileId id) where T : class, IController
        {
            return (T)Get(id);
        }

        public IController Get(FileId id)
        {
            return Instance.Get(id);
        }

        public bool TryGet<T>(FileId id, out T controller) where T : class, IController
        {
            return Instance.TryGet(id, out controller);
        }

        public bool TryGet(FileId id, out IController controller)
        {
            return Instance.TryGet(id, out controller);
        }
    }
}
