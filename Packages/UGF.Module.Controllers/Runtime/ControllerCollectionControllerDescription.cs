using System.Collections.Generic;
using UGF.EditorTools.Runtime.FileIds;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerCollectionControllerDescription : ControllerDescription
    {
        public Dictionary<GlobalId, IControllerBuilder> Controllers { get; } = new Dictionary<GlobalId, IControllerBuilder>();
        public Dictionary<GlobalId, FileId> FileIds { get; } = new Dictionary<GlobalId, FileId>();
    }
}
