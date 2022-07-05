using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.AssetReferences;
using UGF.EditorTools.Editor.IMGUI.Attributes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Module.Controllers.Editor
{
    internal class ControllerCollectionAssetListDrawer : ReorderableListKeyAndValueDrawer
    {
        public bool DisplayAsReplace { get; set; }

        public ControllerCollectionAssetListDrawer(SerializedProperty serializedProperty) : base(serializedProperty, "m_guid", "m_asset")
        {
        }

        protected override void OnDrawElementContent(Rect position, SerializedProperty serializedProperty, int index, bool isActive, bool isFocused)
        {
            SerializedProperty propertyKey = serializedProperty.FindPropertyRelative(PropertyKeyName);
            SerializedProperty propertyValue = serializedProperty.FindPropertyRelative(PropertyValueName);
            string guid = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(propertyValue.objectReferenceValue));

            if (propertyKey.stringValue != guid || DisplayAsReplace)
            {
                base.OnDrawElementContent(position, serializedProperty, index, isActive, isFocused);
            }
            else
            {
                AssetReferenceEditorGUIUtility.AssetReference(position, GUIContent.none, serializedProperty);
            }
        }

        protected override void OnDrawKey(Rect position, SerializedProperty serializedProperty)
        {
            AttributeEditorGUIUtility.DrawAssetGuidField(position, serializedProperty, GUIContent.none, typeof(ControllerAsset));
        }
    }
}
