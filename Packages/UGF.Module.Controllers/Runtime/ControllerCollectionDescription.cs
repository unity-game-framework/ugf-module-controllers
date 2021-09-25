using System.Collections.Generic;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerCollectionDescription : IControllerCollectionDescription
    {
        public Dictionary<string, IControllerBuilder> Controllers { get; } = new Dictionary<string, IControllerBuilder>();

        IReadOnlyDictionary<string, IControllerBuilder> IControllerCollectionDescription.Controllers { get { return Controllers; } }
    }
}
