using System.Collections.Generic;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerCollectionDescription
    {
        IReadOnlyDictionary<string, IControllerBuilder> Controllers { get; }
    }
}
