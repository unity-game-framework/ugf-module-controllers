using UGF.Application.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerComponent : DescribedWithDescriptionBuilderComponent<IApplication, IController, IControllerDescription>, IControllerBuilder
    {
    }
}
