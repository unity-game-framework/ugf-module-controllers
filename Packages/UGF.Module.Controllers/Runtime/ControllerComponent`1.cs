namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerComponent<TController> : ControllerComponent<TController, ControllerDescription> where TController : class, IController
    {
        protected override IControllerDescription OnBuildDescription()
        {
            return new ControllerDescription();
        }
    }
}
