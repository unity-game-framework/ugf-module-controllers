using System;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerBase : Initializable, IController
    {
        public IApplication Application { get; }

        protected ControllerBase(IApplication application) : this(application, new InitializeCollection<IInitialize>())
        {
        }

        protected ControllerBase(IApplication application, IInitializeCollection children) : base(children)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }
    }
}
