using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModuleDescription : ApplicationModuleDescription, IControllerModuleDescription
    {
        public Dictionary<GlobalId, IControllerBuilder> Controllers { get; } = new Dictionary<GlobalId, IControllerBuilder>();

        IReadOnlyDictionary<GlobalId, IControllerBuilder> IControllerModuleDescription.Controllers { get { return Controllers; } }

        public ControllerModuleDescription(Type registerType) : base(registerType)
        {
        }
    }
}
