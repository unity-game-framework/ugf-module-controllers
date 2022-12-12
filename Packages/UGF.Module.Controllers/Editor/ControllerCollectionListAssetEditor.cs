using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerCollectionListAsset), true)]
    internal class ControllerCollectionListAssetEditor : UnityEditor.Editor
    {
        private AssetIdReferenceListDrawer m_listControllers;
        private ReorderableListSelectionDrawerByPath m_listControllersSelection;
        private ReorderableListDrawer m_listCollections;
        private ReorderableListSelectionDrawerByElement m_listCollectionsSelection;

        private void OnEnable()
        {
            m_listControllers = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_controllers"));

            m_listControllersSelection = new ReorderableListSelectionDrawerByPath(m_listControllers, "m_asset")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listCollections = new ReorderableListDrawer(serializedObject.FindProperty("m_collections"));

            m_listCollectionsSelection = new ReorderableListSelectionDrawerByElement(m_listCollections)
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listControllers.Enable();
            m_listControllersSelection.Enable();
            m_listCollections.Enable();
            m_listCollectionsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listControllersSelection.Disable();
            m_listControllers.Disable();
            m_listCollections.Disable();
            m_listCollectionsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listControllers.DrawGUILayout();
                m_listCollections.DrawGUILayout();

                m_listControllersSelection.DrawGUILayout();
                m_listCollectionsSelection.DrawGUILayout();
            }
        }
    }
}
