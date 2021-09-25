using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModuleDescription : ApplicationModuleDescription, IControllerModuleDescription
    {
        public Dictionary<string, IControllerBuilder> Controllers { get; } = new Dictionary<string, IControllerBuilder>();
        public List<IControllerCollectionDescription> Collections { get; } = new List<IControllerCollectionDescription>();

        IReadOnlyDictionary<string, IControllerBuilder> IControllerModuleDescription.Controllers { get { return Controllers; } }
        IReadOnlyList<IControllerCollectionDescription> IControllerModuleDescription.Collections { get { return Collections; } }
    }
}
