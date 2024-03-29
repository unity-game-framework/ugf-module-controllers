﻿using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Controllers.Runtime;
using UnityEditor;

namespace UGF.Module.Controllers.Editor
{
    [CustomEditor(typeof(ControllerCollectionControllerAsset), true)]
    internal class ControllerCollectionControllerAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyCombine;
        private AssetIdReferenceListDrawer m_listControllers;
        private ReorderableListSelectionDrawerByPath m_listControllersSelection;

        private void OnEnable()
        {
            m_propertyCombine = serializedObject.FindProperty("m_combine");
            m_listControllers = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_controllers"));

            m_listControllersSelection = new ReorderableListSelectionDrawerByPath(m_listControllers, "m_asset")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listControllers.Enable();
            m_listControllersSelection.Enable();
        }

        private void OnDisable()
        {
            m_listControllersSelection.Disable();
            m_listControllers.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);
                EditorGUILayout.PropertyField(m_propertyCombine);

                m_listControllers.DrawGUILayout();
                m_listControllersSelection.DrawGUILayout();
            }
        }
    }
}
