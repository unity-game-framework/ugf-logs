using UGF.CustomSettings.Editor;
using UGF.Defines.Editor;
using UnityEditor;

namespace UGF.Logs.Editor
{
    [CustomEditor(typeof(LogEditorSettingsData), true)]
    internal class LogEditorSettingsDataEditor : CustomSettingsDataEditor
    {
        private readonly DefinesPlatformSettingsDrawer m_drawer = new DefinesPlatformSettingsDrawer();
        private SerializedProperty m_propertyEditorEnabled;
        private SerializedProperty m_propertyGroups;

        private void OnEnable()
        {
            m_drawer.AddPlatformAllAvailable();
            m_drawer.SetupGroupTypes();

            m_propertyEditorEnabled = serializedObject.FindProperty("m_editorEnabled");
            m_propertyGroups = serializedObject.FindProperty("m_settings.m_groups");

            m_drawer.Applied += OnApplied;
            m_drawer.Cleared += OnCleared;
        }

        private void OnDisable()
        {
            m_drawer.Applied -= OnApplied;
            m_drawer.Cleared -= OnCleared;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            EditorGUILayout.PropertyField(m_propertyEditorEnabled);

            m_drawer.DrawGUILayout(m_propertyGroups);

            serializedObject.ApplyModifiedProperties();
        }

        private void OnApplied(string groupName, BuildTargetGroup buildTargetGroup, bool onlyEnabled)
        {
            // DefinesEditorSettings.ApplyAll(buildTargetGroup, onlyEnabled);
            // AssetDatabase.SaveAssets();
        }

        private void OnCleared(string groupName, BuildTargetGroup buildTargetGroup, bool onlyEnabled)
        {
            // DefinesEditorSettings.ClearAll(buildTargetGroup, onlyEnabled);
            // AssetDatabase.SaveAssets();
        }
    }
}
