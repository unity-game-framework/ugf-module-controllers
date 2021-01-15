using System.Collections.Generic;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerProvider : IInitialize
    {
        IReadOnlyDictionary<string, IController> Controllers { get; }

        void Add(string id, IController controller);
        bool Remove(string id);
        void Clear();
        T Get<T>(string id) where T : class, IController;
        IController Get(string id);
        bool TryGet<T>(string id, out T controller) where T : class, IController;
        bool TryGet(string id, out IController controller);
    }
}
