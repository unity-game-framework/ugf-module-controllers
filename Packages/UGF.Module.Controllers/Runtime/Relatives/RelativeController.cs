using System;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;
using UGF.Module.Controllers.Runtime.Objects;

namespace UGF.Module.Controllers.Runtime.Relatives
{
    public class RelativeController : ControllerBase
    {
        public IObjectRelativesController ObjectRelativesController { get; }
        public object Target { get; }
        public Type RelativeType { get; }
        public object Relative { get { return m_relative ?? throw new InitializeStateException(); } }

        private object m_relative;

        public RelativeController(IApplication application, object target, Type relativeType) : this(application, application.GetController<IObjectRelativesController>(), target, relativeType)
        {
        }

        public RelativeController(IApplication application, string objectRelativesControllerId, object target, Type relativeType) : this(application, application.GetController<IObjectRelativesController>(objectRelativesControllerId), target, relativeType)
        {
        }

        public RelativeController(IApplication application, IObjectRelativesController objectRelativesController, object target, Type relativeType) : base(application)
        {
            ObjectRelativesController = objectRelativesController ?? throw new ArgumentNullException(nameof(objectRelativesController));
            Target = target ?? throw new ArgumentNullException(nameof(target));
            RelativeType = relativeType ?? throw new ArgumentNullException(nameof(relativeType));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            m_relative = ObjectRelativesController.Provider.Get(Target).Get(RelativeType);
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_relative = null;
        }
    }
}
