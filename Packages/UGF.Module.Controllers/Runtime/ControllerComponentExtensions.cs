using System;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public static class ControllerComponentExtensions
    {
        public static GlobalId GetControllerId(this ControllerComponent component)
        {
            return ControllerUtility.GetId(component);
        }

        public static T GetController<T>(this ControllerComponent component) where T : class, IController
        {
            return (T)GetController(component);
        }

        public static IController GetController(this ControllerComponent component)
        {
            return TryGetController(component, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified component: '{component}'.");
        }

        public static bool TryGetController<T>(this ControllerComponent component, out T controller) where T : class, IController
        {
            if (TryGetController(component, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public static bool TryGetController(this ControllerComponent component, out IController controller)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));

            GlobalId id = GetControllerId(component);
            return component.gameObject.GetApplication().TryGetController(id, out controller);
        }
    }
}
