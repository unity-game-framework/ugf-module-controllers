using System.Collections.Generic;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerInstanceProviderControllerDescription : ControllerDescription
    {
        public Dictionary<string, IControllerBuilder> Controllers { get; } = new Dictionary<string, IControllerBuilder>();
    }
}
