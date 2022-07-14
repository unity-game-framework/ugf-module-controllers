using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerModuleDescription : IApplicationModuleDescription
    {
        IReadOnlyDictionary<GlobalId, IControllerBuilder> Controllers { get; }
    }
}
