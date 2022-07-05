using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerCollectionControllerComponent), true)]
    internal class ControllerCollectionControllerComponentEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listControllers;

        private void OnEnable()
        {
            m_listControllers = new ReorderableListDrawer(serializedObject.FindProperty("m_controllers"));
            m_listControllers.Enable();
        }

        private void OnDisable()
        {
            m_listControllers.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listControllers.DrawGUILayout();
            }

            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Clear"))
                {
                    OnClear();
                }

                if (GUILayout.Button("Collect in Scene"))
                {
                    OnCollectInScene();
                }

                if (GUILayout.Button("Collect"))
                {
                    OnCollect();
                }
            }
        }

        private void OnCollect()
        {
            var component = (ControllerCollectionControllerComponent)target;

            Undo.RegisterCompleteObjectUndo(target, "Controller Collection Collect");
            EditorUtility.SetDirty(target);

            ControllerCollectionUtility.GetComponents(component.Controllers, component);

            serializedObject.Update();
        }

        private void OnCollectInScene()
        {
            var component = (ControllerCollectionControllerComponent)target;

            Undo.RegisterCompleteObjectUndo(target, "Controller Collection Collect in Scene");
            EditorUtility.SetDirty(target);

            ControllerCollectionUtility.GetComponents(component.Controllers, component.gameObject.scene);

            component.Controllers.Remove(component);

            serializedObject.Update();
        }

        private void OnClear()
        {
            m_listControllers.SerializedProperty.ClearArray();
            m_listControllers.SerializedProperty.serializedObject.ApplyModifiedProperties();
        }
    }
}
