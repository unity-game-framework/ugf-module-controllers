using UGF.Application.Runtime;
using UGF.Builder.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerBuilder<TController> : Builder<IApplication, TController>, IControllerBuilder where TController : class, IController
    {
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
