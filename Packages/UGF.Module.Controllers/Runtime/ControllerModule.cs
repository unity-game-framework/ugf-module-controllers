using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModule : ApplicationModule<ControllerModuleDescription>, IControllerModule, IApplicationModuleAsync, IApplicationLauncherEventHandler
    {
        public ControllerCollection<IController> Controllers { get; } = new ControllerCollection<IController>();

        IControllerModuleDescription IControllerModule.Description { get { return Description; } }
        IProvider<GlobalId, IController> IControllerModule.Controllers { get { return Controllers; } }

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

            foreach ((string key, IControllerBuilder value) in Description.Controllers)
            {
                IController controller = value.Build(Application);

                Add(key, controller);
            }

            Controllers.Initialize();
        }

        public async Task InitializeAsync()
        {
            await Controllers.InitializeAsync();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Log.Debug("Controller module uninitialize", new
            {
                controllers = Controllers.Entries.Count
            });

            Controllers.Uninitialize();
            Controllers.Clear();
        }

        public void Add(GlobalId id, IController controller)
        {
            Controllers.Add(id, controller);
        }

        public bool Remove(GlobalId id)
        {
            return Controllers.Remove(id);
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
