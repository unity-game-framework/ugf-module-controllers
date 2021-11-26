using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Objects;

namespace UGF.Module.Controllers.Runtime.Objects
{
    public class ObjectRelativesController<TObject> : ControllerBase, IObjectRelativesController where TObject : class
    {
        public ObjectRelativesProvider<TObject> Provider { get; }

        IObjectRelativeProvider IObjectRelativesController.Provider { get { return Provider; } }

        public ObjectRelativesController(IApplication application) : this(application, new ObjectRelativesProvider<TObject>())
        {
        }

        public ObjectRelativesController(IApplication application, ObjectRelativesProvider<TObject> provider) : base(application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }
    }
}
