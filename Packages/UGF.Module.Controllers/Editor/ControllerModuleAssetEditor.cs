using UGF.EditorTools.Editor.IMGUI.AssetReferences;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerModuleAsset), true)]
    internal class ControllerModuleAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyScript;
        private AssetReferenceListDrawer m_listControllers;

        private void OnEnable()
        {
            m_propertyScript = serializedObject.FindProperty("m_Script");
            m_listControllers = new AssetReferenceListDrawer(serializedObject.FindProperty("m_controllers"));

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
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(m_propertyScript);
                }

                m_listControllers.DrawGUILayout();
            }
        }
    }
}
