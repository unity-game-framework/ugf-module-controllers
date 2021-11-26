using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerModuleDescription : IApplicationModuleDescription
    {
        IReadOnlyDictionary<string, IControllerBuilder> Controllers { get; }
    }
}
