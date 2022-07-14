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
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

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

        public T GetController<T>() where T : class, IController
        {
            return (T)Controller;
        }
    }
}
