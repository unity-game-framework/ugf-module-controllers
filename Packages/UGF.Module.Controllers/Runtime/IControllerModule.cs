using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerModule : IApplicationModule
    {
        new IControllerModuleDescription Description { get; }
        IReadOnlyDictionary<string, IController> Controllers { get; }

        void AddController(string id, IController controller);
        bool RemoveController(string id);
        T GetController<T>(string id) where T : class, IController;
        IController GetController(string id);
        bool TryGetController<T>(string id, out T controller) where T : class, IController;
        bool TryGetController(string id, out IController controller);
    }
}
