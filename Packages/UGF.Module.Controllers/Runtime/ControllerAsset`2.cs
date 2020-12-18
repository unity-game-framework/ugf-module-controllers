using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerAsset<TController, TDescription> : ControllerAsset
        where TController : class, IController
        where TDescription : class, IControllerDescription
    {
        protected override IController OnBuild(IApplication arguments, IControllerDescription description)
        {
            return OnBuild((TDescription)description, arguments);
        }

        protected abstract TController OnBuild(TDescription description, IApplication application);
    }
}
