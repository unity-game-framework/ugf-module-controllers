using UGF.Application.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerAsset : DescribedWithDescriptionBuilderAsset<IApplication, IController, IControllerDescription>, IControllerBuilder
    {
    }
}
