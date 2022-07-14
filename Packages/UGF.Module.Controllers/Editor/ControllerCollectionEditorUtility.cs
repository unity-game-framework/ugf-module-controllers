using System;
using System.Collections.Generic;
using UGF.EditorTools.Editor.FileIds;
using UGF.EditorTools.Runtime.ComponentReferences;
using UGF.EditorTools.Runtime.FileIds;
using UGF.Module.Controllers.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UGF.Module.Controllers.Editor
{
    public static class ControllerCollectionEditorUtility
    {
        public static void GetComponents(ICollection<ComponentIdReference<ControllerComponent>> components, Scene scene)
        {
            if (!scene.IsValid()) throw new ArgumentException("Value should be valid.", nameof(scene));

            GameObject[] gameObjects = scene.GetRootGameObjects();

            for (int i = 0; i < gameObjects.Length; i++)
            {
                GetComponents(components, gameObjects[i]);
            }
        }

        public static void GetComponents(ICollection<ComponentIdReference<ControllerComponent>> components, ControllerComponent component)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));

            var buffer = new List<ControllerComponent>();

            GetComponents(components, component.gameObject, buffer);
            GetComponentsInChildren(components, component.gameObject.transform, buffer);

            buffer.Clear();

            components.Remove(GetReference(component));
        }

        public static void GetComponents(ICollection<ComponentIdReference<ControllerComponent>> components, GameObject gameObject)
        {
            if (components == null) throw new ArgumentNullException(nameof(components));
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));

            if (gameObject.TryGetComponent(out ControllerCollectionControllerComponent collection))
            {
                components.Add(GetReference(collection));
            }
            else
            {
                var buffer = new List<ControllerComponent>();

                GetComponents(components, gameObject, buffer);
                GetComponentsInChildren(components, gameObject.transform, buffer);

                buffer.Clear();
            }
        }

        internal static ComponentIdReference<ControllerComponent> GetReference(ControllerComponent component)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));

            ulong id = FileIdEditorUtility.GetFileId(component);

            return new ComponentIdReference<ControllerComponent>(new FileId(id), component);
        }

        private static void GetComponentsInChildren(ICollection<ComponentIdReference<ControllerComponent>> components, Transform transform, List<ControllerComponent> buffer)
        {
            if (components == null) throw new ArgumentNullException(nameof(components));
            if (transform == null) throw new ArgumentNullException(nameof(transform));
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                GameObject childGameObject = child.gameObject;

                if (childGameObject.TryGetComponent(out ControllerCollectionControllerComponent collection))
                {
                    components.Add(GetReference(collection));
                }
                else
                {
                    GetComponents(components, child.gameObject, buffer);
                    GetComponentsInChildren(components, child, buffer);
                }
            }
        }

        private static void GetComponents(ICollection<ComponentIdReference<ControllerComponent>> components, GameObject gameObject, List<ControllerComponent> buffer)
        {
            if (components == null) throw new ArgumentNullException(nameof(components));
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));

            gameObject.GetComponents(buffer);

            for (int i = 0; i < buffer.Count; i++)
            {
                ControllerComponent component = buffer[i];

                if (component != null)
                {
                    components.Add(GetReference(component));
                }
            }

            buffer.Clear();
        }
    }
}
