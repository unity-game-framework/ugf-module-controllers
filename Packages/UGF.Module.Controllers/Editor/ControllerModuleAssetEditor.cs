using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerModuleAsset), true)]
    internal class ControllerModuleAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyScript;
        private ControllerModuleControllerListDrawer m_listControllers;
        private ControllerModuleCollectionListDrawer m_listCollections;

        private void OnEnable()
        {
            m_propertyScript = serializedObject.FindProperty("m_Script");
            m_listControllers = new ControllerModuleControllerListDrawer(serializedObject.FindProperty("m_controllers"));
            m_listCollections = new ControllerModuleCollectionListDrawer(serializedObject.FindProperty("m_collections"));

            m_listControllers.Enable();
            m_listCollections.Enable();
        }

        private void OnDisable()
        {
            m_listControllers.Disable();
            m_listCollections.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(m_propertyScript);
                }

                m_listControllers.DrawGUILayout();
                m_listCollections.DrawGUILayout();

                m_listControllers.DrawSelectedLayout();
                m_listCollections.DrawSelectedLayout();
            }
        }
    }
}
