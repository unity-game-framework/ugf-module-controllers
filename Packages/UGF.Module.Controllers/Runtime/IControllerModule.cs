using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerModule : IApplicationModule
    {
        new IControllerModuleDescription Description { get; }
        IProvider<string, IController> Controllers { get; }

        void Add(string id, IController controller);
        bool Remove(string id);
    }
}
