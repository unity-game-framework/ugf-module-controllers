using System;
using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModuleDescription : ApplicationModuleDescription, IControllerModuleDescription
    {
        public Dictionary<string, IControllerBuilder> Controllers { get; } = new Dictionary<string, IControllerBuilder>();
        public bool UseReverseUninitializationOrder { get; set; } = true;

        IReadOnlyDictionary<string, IControllerBuilder> IControllerModuleDescription.Controllers { get { return Controllers; } }

        public ControllerModuleDescription(Type registerType) : base(registerType)
        {
        }
    }
}
