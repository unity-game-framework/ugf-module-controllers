using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerIdCollectionListAsset), true)]
    internal class ControllerIdCollectionListAssetEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listControllers;
        private ReorderableListSelectionDrawerByElementGlobalId m_listControllersSelection;

        private void OnEnable()
        {
            m_listControllers = new ReorderableListDrawer(serializedObject.FindProperty("m_controllers"))
            {
                DisplayAsSingleLine = true
            };

            m_listControllersSelection = new ReorderableListSelectionDrawerByElementGlobalId(m_listControllers)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listControllers.Enable();
            m_listControllersSelection.Enable();
        }

        private void OnDisable()
        {
            m_listControllers.Disable();
            m_listControllersSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listControllers.DrawGUILayout();
                m_listControllersSelection.DrawGUILayout();
            }
        }
    }
}
