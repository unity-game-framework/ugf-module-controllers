using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerModule : IApplicationModule
    {
        new IControllerModuleDescription Description { get; }
        IProvider<GlobalId, IController> Controllers { get; }

        void Add(GlobalId id, IController controller);
        bool Remove(GlobalId id);
    }
}
