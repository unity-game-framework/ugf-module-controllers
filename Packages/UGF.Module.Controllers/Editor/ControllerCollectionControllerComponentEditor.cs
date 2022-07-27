using UGF.EditorTools.Editor.ComponentReferences;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.EditorTools.Runtime.ComponentReferences;
using UGF.Module.Controllers.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerCollectionControllerComponent), true)]
    internal class ControllerCollectionControllerComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyCombine;
        private ComponentIdReferenceListDrawer m_listControllers;

        private void OnEnable()
        {
            m_propertyCombine = serializedObject.FindProperty("m_combine");
            m_listControllers = new ComponentIdReferenceListDrawer(serializedObject.FindProperty("m_controllers"));
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
                EditorGUILayout.PropertyField(m_propertyCombine);

                m_listControllers.DrawGUILayout();
            }

            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Sort"))
                {
                    OnSort();
                }

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

            ControllerCollectionEditorUtility.GetComponents(component.Controllers, component);
            ControllerCollectionEditorUtility.SortByPriority(component.Controllers);

            serializedObject.Update();
        }

        private void OnCollectInScene()
        {
            var component = (ControllerCollectionControllerComponent)target;

            Undo.RegisterCompleteObjectUndo(target, "Controller Collection Collect in Scene");
            EditorUtility.SetDirty(target);

            ControllerCollectionEditorUtility.GetComponents(component.Controllers, component.gameObject.scene);
            ControllerCollectionEditorUtility.SortByPriority(component.Controllers);

            if (ControllerCollectionEditorUtility.TryGetReference(component, out ComponentIdReference<ControllerComponent> reference))
            {
                component.Controllers.Remove(reference);
            }

            serializedObject.Update();
        }

        private void OnClear()
        {
            m_listControllers.SerializedProperty.ClearArray();
            m_listControllers.SerializedProperty.serializedObject.ApplyModifiedProperties();
        }

        private void OnSort()
        {
            var component = (ControllerCollectionControllerComponent)target;

            Undo.RegisterCompleteObjectUndo(target, "Controller Collection Sort");
            EditorUtility.SetDirty(target);

            ControllerCollectionEditorUtility.SortByPriority(component.Controllers);

            serializedObject.Update();
        }
    }
}
