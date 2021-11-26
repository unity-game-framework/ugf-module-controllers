using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerAsync : ControllerBase, IControllerAsyncInitialize
    {
        private InitializeState m_state;

        protected ControllerAsync(IApplication application) : base(application)
        {
        }

        protected ControllerAsync(IApplication application, IInitializeCollection children) : base(application, children)
        {
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_state = m_state.Uninitialize();
        }

        public Task InitializeAsync()
        {
            m_state = m_state.Initialize();

            return OnInitializeAsync();
        }

        protected virtual Task OnInitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
