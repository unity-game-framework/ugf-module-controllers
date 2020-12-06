using System;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class Controller<TDescription> : Initializable, IController where TDescription : class, IControllerDescription
    {
        public TDescription Description { get; }
        public IApplication Application { get; }

        protected Controller(TDescription description, IApplication application) : this(description, application, new InitializeCollection<IInitialize>())
        {
        }

        protected Controller(TDescription description, IApplication application, IInitializeCollection children) : base(children)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public T GetDescription<T>() where T : class, IDescription
        {
            return (T)GetDescription();
        }

        public IDescription GetDescription()
        {
            return Description;
        }
    }
}
