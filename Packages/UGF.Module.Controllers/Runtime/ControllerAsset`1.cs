namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerAsset<TController> : ControllerAsset<TController, ControllerDescription> where TController : class, IController
    {
        protected override IControllerDescription OnBuildDescription()
        {
            return new ControllerDescription();
        }
    }
}
