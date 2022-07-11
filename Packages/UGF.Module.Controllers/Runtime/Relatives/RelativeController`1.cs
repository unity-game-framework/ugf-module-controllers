using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime.Objects;

namespace UGF.Module.Controllers.Runtime.Relatives
{
    public class RelativeController<TRelative> : RelativeController
    {
        public new TRelative Relative { get { return (TRelative)base.Relative; } }

        public RelativeController(IApplication application, object target) : base(application, target, typeof(TRelative))
        {
        }

        public RelativeController(IApplication application, GlobalId objectRelativesControllerId, object target) : base(application, objectRelativesControllerId, target, typeof(TRelative))
        {
        }

        public RelativeController(IApplication application, IObjectRelativesController objectRelativesController, object target) : base(application, objectRelativesController, target, typeof(TRelative))
        {
        }
    }
}
