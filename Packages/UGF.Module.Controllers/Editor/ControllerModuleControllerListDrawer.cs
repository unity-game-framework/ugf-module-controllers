using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.AssetReferences;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    internal class ControllerModuleControllerListDrawer : AssetReferenceListDrawer
    {
        public EditorDrawer Drawer { get; } = new EditorDrawer
        {
            DisplayTitlebar = true
        };

        public ControllerModuleControllerListDrawer(SerializedProperty serializedProperty) : base(serializedProperty)
        {
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            Drawer.Enable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            Drawer.Disable();
        }

        protected override void OnRemove()
        {
            base.OnRemove();

            UpdateSelection();
        }

        protected override void OnSelect()
        {
            base.OnSelect();

            UpdateSelection();
        }

        public void DrawSelectedLayout()
        {
            Drawer.DrawGUILayout();
        }

        private void UpdateSelection()
        {
            if (List.index >= 0 && List.index < List.count)
            {
                SerializedProperty propertyElement = SerializedProperty.GetArrayElementAtIndex(List.index);
                SerializedProperty propertyAsset = propertyElement.FindPropertyRelative("m_asset");

                if (propertyAsset.objectReferenceValue != null)
                {
                    Drawer.Set(propertyAsset.objectReferenceValue);
                }
                else
                {
                    Drawer.Clear();
                }
            }
            else
            {
                Drawer.Clear();
            }
        }
    }
}
