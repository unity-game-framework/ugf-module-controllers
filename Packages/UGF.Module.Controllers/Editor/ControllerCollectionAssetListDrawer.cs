using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.Ids;
using UGF.EditorTools.Editor.IMGUI;
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
            string value = GlobalIdEditorUtility.GetGuidFromProperty(propertyKey);

            if (value != guid || DisplayAsReplace)
            {
                base.OnDrawElementContent(position, serializedProperty, index, isActive, isFocused);
            }
            else
            {
                AssetIdReferenceEditorGUIUtility.AssetIdReferenceField(position, GUIContent.none, SerializedProperty);
            }
        }

        protected override void OnDrawKey(Rect position, SerializedProperty serializedProperty)
        {
            string guid = GlobalIdEditorUtility.GetGuidFromProperty(serializedProperty);

            guid = AttributeEditorGUIUtility.DrawAssetGuidField(position, guid, GUIContent.none, typeof(ControllerAsset));

            GlobalIdEditorUtility.SetGuidToProperty(serializedProperty, guid);
        }
    }
}
