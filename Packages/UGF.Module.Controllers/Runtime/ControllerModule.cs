using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Initialize.Runtime;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModule : ApplicationModuleAsync<ControllerModuleDescription>, IControllerModule, IApplicationLauncherEventHandler
    {
        public Provider<GlobalId, IController> Controllers { get; } = new Provider<GlobalId, IController>();

        IControllerModuleDescription IControllerModule.Description { get { return Description; } }
        IProvider<GlobalId, IController> IControllerModule.Controllers { get { return Controllers; } }

        private readonly InitializeCollection<IController> m_initializeCollection = new InitializeCollection<IController>();

        public ControllerModule(ControllerModuleDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Log.Debug("Controller module initialize", new
            {
                controllers = Description.Controllers.Count
            });

            foreach ((GlobalId key, IControllerBuilder value) in Description.Controllers)
            {
                IController controller = value.Build(Application);

                Controllers.Add(key, controller);

                m_initializeCollection.Add(controller);
            }

            m_initializeCollection.Initialize();
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();
            await m_initializeCollection.InitializeAsync();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Log.Debug("Controller module uninitialize", new
            {
                controllers = Controllers.Entries.Count
            });

            m_initializeCollection.Uninitialize();
            m_initializeCollection.Clear();

            Controllers.Clear();
        }

        void IApplicationLauncherEventHandler.OnLaunched(IApplication application)
        {
            foreach ((_, IController value) in Controllers)
            {
                if (value is IApplicationLauncherEventHandler handler)
                {
                    handler.OnLaunched(application);
                }
            }
        }

        void IApplicationLauncherEventHandler.OnStopped(IApplication application)
        {
            foreach ((_, IController value) in Controllers)
            {
                if (value is IApplicationLauncherEventHandler handler)
                {
                    handler.OnStopped(application);
                }
            }
        }
    }
}
