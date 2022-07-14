using System;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public static class ControllerApplicationExtensions
    {
        public static void AddController(this IApplication application, GlobalId id, IController controller)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            application.GetModule<IControllerModule>().Controllers.Add(id, controller);
        }

        public static bool RemoveController(this IApplication application, GlobalId id)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            return application.GetModule<IControllerModule>().Controllers.Remove(id);
        }

        public static T GetController<T>(this IApplication application) where T : IController
        {
            return (T)GetController(application, typeof(T));
        }

        public static IController GetController(this IApplication application, Type type)
        {
            return TryGetController(application, type, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified type: '{type}'.");
        }

        public static T GetController<T>(this IApplication application, GlobalId id) where T : IController
        {
            return (T)GetController(application, id);
        }

        public static IController GetController(this IApplication application, GlobalId id)
        {
            return TryGetController(application, id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public static bool TryGetController<T>(this IApplication application, GlobalId id, out T controller) where T : IController
        {
            if (TryGetController(application, id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public static bool TryGetController(this IApplication application, GlobalId id, out IController controller)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            return application.GetModule<IControllerModule>().Controllers.TryGet(id, out controller);
        }

        public static bool TryGetController<T>(this IApplication application, out T controller) where T : IController
        {
            if (TryGetController(application, typeof(T), out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public static bool TryGetController(this IApplication application, Type type, out IController controller)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (application.GetModule<IControllerModule>().Controllers.TryGet(type, out object value))
            {
                controller = (IController)value;
                return true;
            }

            controller = default;
            return false;
        }
    }
}
