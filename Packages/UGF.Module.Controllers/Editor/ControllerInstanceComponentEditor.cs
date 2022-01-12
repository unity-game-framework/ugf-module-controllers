using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerInstanceComponent), true)]
    internal class ControllerInstanceComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyBuildOnAwake;
        private SerializedProperty m_propertyBuildAsSingleton;
        private SerializedProperty m_propertyProvider;
        private SerializedProperty m_propertyController;
        private SerializedProperty m_propertyRelativeToComponent;
        private SerializedProperty m_propertyRelativesProvider;
        private ReorderableListDrawer m_listRelatives;

        private void OnEnable()
        {
            m_propertyBuildOnAwake = serializedObject.FindProperty("m_buildOnAwake");
            m_propertyBuildAsSingleton = serializedObject.FindProperty("m_buildAsSingleton");
            m_propertyProvider = serializedObject.FindProperty("m_provider");
            m_propertyController = serializedObject.FindProperty("m_controller");
            m_propertyRelativeToComponent = serializedObject.FindProperty("m_relativeToComponent");
            m_propertyRelativesProvider = serializedObject.FindProperty("m_relativesProvider");
            m_listRelatives = new ReorderableListDrawer(serializedObject.FindProperty("m_relatives"));
            m_listRelatives.Enable();
        }

        private void OnDisable()
        {
            m_listRelatives.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyBuildOnAwake);
                EditorGUILayout.PropertyField(m_propertyBuildAsSingleton);
                EditorGUILayout.PropertyField(m_propertyProvider);
                EditorGUILayout.PropertyField(m_propertyController);
                EditorGUILayout.PropertyField(m_propertyRelativeToComponent);
                EditorGUILayout.PropertyField(m_propertyRelativesProvider);

                m_listRelatives.DrawGUILayout();
            }
        }
    }
}
