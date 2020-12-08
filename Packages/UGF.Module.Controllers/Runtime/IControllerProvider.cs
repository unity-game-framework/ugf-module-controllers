using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerProvider : IInitialize
    {
        IReadOnlyDictionary<GlobalId, IController> Controllers { get; }

        void Add(GlobalId id, IController controller);
        bool Remove(GlobalId id);
        void Clear();
        T Get<T>(GlobalId id) where T : class, IController;
        IController Get(GlobalId id);
        bool TryGet<T>(GlobalId id, out T controller) where T : class, IController;
        bool TryGet(GlobalId id, out IController controller);
    }
}
