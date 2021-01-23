using System;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerDescribedBuilder<TController, TDescription> : ControllerBuilder<TController>, IDescribedBuilder<IApplication>, IDescriptionBuilder
        where TController : class, IControllerDescribed
        where TDescription : class, IControllerDescription
    {
        protected override TController OnBuild(IApplication arguments)
        {
            TDescription description = OnBuildDescription();

            if (description == null) throw new ArgumentNullException(nameof(description));

            return OnBuild(description, arguments);
        }

        protected abstract TDescription OnBuildDescription();
        protected abstract TController OnBuild(TDescription description, IApplication application);

        T IBuilder<IApplication, IDescribed>.Build<T>(IApplication arguments)
        {
            return (T)(object)Build(arguments);
        }

        IDescribed IBuilder<IApplication, IDescribed>.Build(IApplication arguments)
        {
            return Build(arguments);
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
