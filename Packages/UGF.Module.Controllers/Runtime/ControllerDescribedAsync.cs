using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerDescribedAsync<TDescription> : ControllerDescribed<TDescription>, IControllerAsyncInitialize where TDescription : class, IControllerDescription
    {
        public bool IsInitializedAsync { get { return m_state; } }

        private InitializeState m_state;

        protected ControllerDescribedAsync(TDescription description, IApplication application) : base(description, application)
        {
        }

        protected ControllerDescribedAsync(TDescription description, IApplication application, IInitializeCollection children) : base(description, application, children)
        {
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            if (m_state)
            {
                m_state = m_state.Uninitialize();
            }
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
