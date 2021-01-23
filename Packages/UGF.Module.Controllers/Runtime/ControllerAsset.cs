using UGF.Application.Runtime;
using UGF.Builder.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerAsset : BuilderAsset<IApplication, IController>, IControllerBuilder
    {
    }
}
