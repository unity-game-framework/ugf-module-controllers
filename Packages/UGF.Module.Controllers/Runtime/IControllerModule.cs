using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerModule : IApplicationModule
    {
        new IControllerModuleDescription Description { get; }
        IReadOnlyDictionary<GlobalId, IController> Controllers { get; }

        void AddController(GlobalId id, IController controller);
        bool RemoveController(GlobalId id);
        T GetController<T>(GlobalId id) where T : class, IController;
        IController GetController(GlobalId id);
        bool TryGetController<T>(GlobalId id, out T controller) where T : class, IController;
        bool TryGetController(GlobalId id, out IController controller);
    }
}
