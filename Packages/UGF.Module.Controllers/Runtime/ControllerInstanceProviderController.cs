using System;
using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerInstanceProviderController : ControllerDescribed<ControllerInstanceProviderControllerDescription>, IControllerInstanceProviderController
    {
        public ControllerInstanceProviderController(ControllerInstanceProviderControllerDescription description, IApplication application) : base(description, application)
        {
        }

        public T Build<T>(string id) where T : IController
        {
            return (T)Build(id);
        }

        public IController Build(string id)
        {
            return TryBuild(id, out IController controller) ? controller : throw new ArgumentException($"Controller builder not found by the specified id: '{id}'.");
        }

        public bool TryBuild<T>(string id, out T controller) where T : IController
        {
            if (TryBuild(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryBuild(string id, out IController controller)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

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
