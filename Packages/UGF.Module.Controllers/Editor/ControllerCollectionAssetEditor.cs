using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerCollectionAsset), true)]
    internal class ControllerCollectionAssetEditor : UnityEditor.Editor
    {
        private ControllerCollectionAssetListDrawer m_listControllers;
        private ReorderableListSelectionDrawerByPath m_listControllersSelection;

        private void OnEnable()
        {
            m_listControllers = new ControllerCollectionAssetListDrawer(serializedObject.FindProperty("m_controllers"));

            m_listControllersSelection = new ReorderableListSelectionDrawerByPath(m_listControllers, "m_asset")
            {
                Drawer =
                {
                    DisplayTitlebar = true
                }
            };

            m_listControllers.Enable();
            m_listControllersSelection.Enable();
        }

        private void OnDisable()
        {
            m_listControllersSelection.Disable();
            m_listControllers.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listControllers.DrawGUILayout();
                m_listControllersSelection.DrawGUILayout();
            }

            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                m_listControllers.DisplayAsReplace = GUILayout.Toggle(m_listControllers.DisplayAsReplace, "Replace", EditorStyles.miniButton);
            }
        }
    }
}
