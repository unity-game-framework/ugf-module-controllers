using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerModule : IApplicationModule
    {
        new IControllerModuleDescription Description { get; }
        IControllerProvider Provider { get; }
    }
}
