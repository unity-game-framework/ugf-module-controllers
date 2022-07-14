using System;
using UGF.EditorTools.Runtime.FileIds;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public static class ControllerCollectionControllerInstanceExtensions
    {
        public static T Get<T>(this ControllerInstanceController instance) where T : class, IController
        {
            return (T)Get(instance, typeof(T));
        }

        public static IController Get(this ControllerInstanceController instance, Type type)
        {
            return TryGet(instance, type, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified type: '{type}'.");
        }

        public static bool TryGet<T>(this ControllerInstanceController instance, out T controller) where T : class, IController
        {
            if (TryGet(instance, typeof(T), out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public static bool TryGet(this ControllerInstanceController instance, Type type, out IController controller)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (instance.Controller is ControllerCollectionController collection)
            {
                return collection.Controllers.TryGet(type, out controller);
            }

            controller = default;
            return false;
        }

        public static T Get<T>(this ControllerInstanceController instance, GlobalId id) where T : class, IController
        {
            return (T)Get(instance, id);
        }

        public static IController Get(this ControllerInstanceController instance, GlobalId id)
        {
            return TryGet(instance, id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public static bool TryGet<T>(this ControllerInstanceController instance, GlobalId id, out T controller) where T : class, IController
        {
            if (TryGet(instance, id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public static bool TryGet(this ControllerInstanceController instance, GlobalId id, out IController controller)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            if (instance.Controller is ControllerCollectionController collection)
            {
                return collection.Controllers.TryGet(id, out controller);
            }

            controller = default;
            return false;
        }

        public static T Get<T>(this ControllerInstanceController instance, FileId id) where T : class, IController
        {
            return (T)Get(instance, id);
        }

        public static IController Get(this ControllerInstanceController instance, FileId id)
        {
            return TryGet(instance, id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified file id: '{id}'.");
        }

        public static bool TryGet<T>(this ControllerInstanceController instance, FileId id, out T controller) where T : class, IController
        {
            if (TryGet(instance, id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public static bool TryGet(this ControllerInstanceController instance, FileId id, out IController controller)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            if (instance.Controller is ControllerCollectionController collection)
            {
                return collection.TryGet(id, out controller);
            }

            controller = default;
            return false;
        }
    }
}
