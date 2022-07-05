using System.Threading.Tasks;
using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerCollectionController : ControllerDescribedAsync<ControllerCollectionControllerDescription>
    {
        public ControllerCollection<IController> Controllers { get; } = new ControllerCollection<IController>();

        public ControllerCollectionController(ControllerCollectionControllerDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach ((string key, IControllerBuilder value) in Description.Controllers)
            {
                IController controller = value.Build(Application);

                Controllers.Add(key, controller);
                Application.AddController(key, controller);
            }

            Controllers.Initialize();
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();

            foreach ((_, IController value) in Controllers)
            {
                if (value is IControllerAsyncInitialize controller)
                {
                    await controller.InitializeAsync();
                }
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Controllers.Uninitialize();

            foreach ((string key, _) in Controllers)
            {
                Application.RemoveController(key);
            }

            Controllers.Clear();
        }
    }
}
