using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerProvider : IProvider<string, IController>
    {
    }
}
