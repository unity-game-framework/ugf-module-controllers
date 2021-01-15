using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerBuilder<TController, TDescription> : DescribedWithDescriptionBuilder<IApplication, TController, TDescription>, IControllerBuilder
        where TController : class, IController
        where TDescription : class, IControllerDescription
    {
        protected override TController OnBuild(IApplication arguments, TDescription description)
        {
            return OnBuild(description, arguments);
        }

        protected abstract TController OnBuild(TDescription description, IApplication application);

        T IBuilder<IApplication, IController>.Build<T>(IApplication arguments)
        {
            return (T)(object)Build(arguments);
        }

        IController IBuilder<IApplication, IController>.Build(IApplication arguments)
        {
            return Build(arguments);
        }
    }
}
