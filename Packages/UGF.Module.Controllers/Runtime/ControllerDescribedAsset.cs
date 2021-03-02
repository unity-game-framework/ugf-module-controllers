using System;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerDescribedAsset<TController, TDescription> : ControllerAsset, IDescribedBuilder<IApplication>, IDescriptionBuilder
        where TController : class, IController
        where TDescription : class, IControllerDescription
    {
        protected override IController OnBuild(IApplication arguments)
        {
            TDescription description = OnBuildDescription();

            if (description == null) throw new ArgumentNullException(nameof(description));

            return OnBuild(description, arguments);
        }

        protected abstract TDescription OnBuildDescription();
        protected abstract TController OnBuild(TDescription description, IApplication application);

        T IBuilder<IApplication, IDescribed>.Build<T>(IApplication arguments)
        {
            return (T)Build(arguments);
        }

        IDescribed IBuilder<IApplication, IDescribed>.Build(IApplication arguments)
        {
            return (IDescribed)Build(arguments);
        }

        T IBuilder<IDescription>.Build<T>()
        {
            return (T)(object)OnBuildDescription();
        }

        IDescription IBuilder<IDescription>.Build()
        {
            return OnBuildDescription();
        }
    }
}
