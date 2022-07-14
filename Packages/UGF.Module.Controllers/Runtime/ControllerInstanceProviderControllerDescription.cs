using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerInstanceProviderControllerDescription : ControllerDescription
    {
        public Dictionary<GlobalId, IControllerBuilder> Controllers { get; } = new Dictionary<GlobalId, IControllerBuilder>();
    }
}
