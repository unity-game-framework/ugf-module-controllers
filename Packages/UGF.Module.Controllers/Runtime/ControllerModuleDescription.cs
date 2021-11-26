using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModuleDescription : ApplicationModuleDescription, IControllerModuleDescription
    {
        public bool UseReverseUninitializationOrder { get; set; }
        public Dictionary<string, IControllerBuilder> Controllers { get; } = new Dictionary<string, IControllerBuilder>();

        IReadOnlyDictionary<string, IControllerBuilder> IControllerModuleDescription.Controllers { get { return Controllers; } }
    }
}
