using System;
using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerDescribed<TDescription> : ControllerBase, IDescribed<TDescription> where TDescription : class, IControllerDescription
    {
        public TDescription Description { get; }

        protected ControllerDescribed(TDescription description, IApplication application) : this(description, application, new InitializeCollection<IInitialize>())
        {
        }

        protected ControllerDescribed(TDescription description, IApplication application, IInitializeCollection children) : base(application, children)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
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
