using UGF.EditorTools.Editor.IMGUI;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    internal class ControllerModuleCollectionListDrawer : ReorderableListDrawer
    {
        public EditorDrawer Drawer { get; } = new EditorDrawer
        {
            DisplayTitlebar = true
        };

        public ControllerModuleCollectionListDrawer(SerializedProperty serializedProperty) : base(serializedProperty)
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

                if (propertyElement.objectReferenceValue != null)
                {
                    Drawer.Set(propertyElement.objectReferenceValue);
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
