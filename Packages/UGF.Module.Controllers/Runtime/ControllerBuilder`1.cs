namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerBuilder<TController> : ControllerBuilder<TController, ControllerDescription> where TController : class, IController
    {
        protected override ControllerDescription OnBuildDescription()
        {
            return new ControllerDescription();
        }
    }
}
