using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerProvider : Provider<string, IController>, IControllerProvider
    {
    }
}
