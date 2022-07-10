using System.Collections.Generic;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerCollectionControllerDescription : ControllerDescription
    {
        public Dictionary<string, IControllerBuilder> Controllers { get; } = new Dictionary<string, IControllerBuilder>();
        public Dictionary<string, string> FileIds { get; } = new Dictionary<string, string>();
    }
}
