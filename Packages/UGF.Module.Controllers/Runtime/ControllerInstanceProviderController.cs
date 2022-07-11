using System;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerInstanceProviderController : ControllerDescribed<ControllerInstanceProviderControllerDescription>, IControllerInstanceProviderController
    {
        public ControllerInstanceProviderController(ControllerInstanceProviderControllerDescription description, IApplication application) : base(description, application)
        {
        }

        public T Build<T>(GlobalId id) where T : IController
        {
            return (T)Build(id);
        }

        public IController Build(GlobalId id)
        {
            return TryBuild(id, out IController controller) ? controller : throw new ArgumentException($"Controller builder not found by the specified id: '{id}'.");
        }

        public bool TryBuild<T>(GlobalId id, out T controller) where T : IController
        {
            if (TryBuild(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryBuild(GlobalId id, out IController controller)
        {
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            if (Description.Controllers.TryGetValue(id, out IControllerBuilder builder))
            {
                controller = builder.Build(Application);
                return true;
            }

            controller = default;
            return false;
        }
    }
}
