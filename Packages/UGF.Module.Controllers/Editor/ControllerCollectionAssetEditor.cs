using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerCollectionAsset), true)]
    internal class ControllerCollectionAssetEditor : UnityEditor.Editor
    {
        private ControllerModuleControllerListDrawer m_listControllers;

        private void OnEnable()
        {
            m_listControllers = new ControllerModuleControllerListDrawer(serializedObject.FindProperty("m_controllers"));
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
                m_listControllers.DrawSelectedLayout();
            }
        }
    }
}
