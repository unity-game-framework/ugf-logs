using UGF.Defines.Editor;
using UnityEditor;

namespace UGF.Logs.Editor
{
    [CustomEditor(typeof(LogEditorSettingsData), true)]
    internal class LogEditorSettingsDataEditor : UnityEditor.Editor
    {
        private readonly LogEditorSettingsDrawer m_drawer = new LogEditorSettingsDrawer();
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

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Define Symbols Settings", EditorStyles.boldLabel);

            m_drawer.DrawGUILayout(m_propertyGroups);

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("All Log methods enabled at Editor whether define symbol enabled or not.", MessageType.Info);

            serializedObject.ApplyModifiedProperties();
        }

        private void OnApplied(string groupName, BuildTargetGroup buildTargetGroup, bool onlyEnabled)
        {
            DefinesBuildEditorUtility.ApplyAll(buildTargetGroup, LogEditorSettings.Settings, onlyEnabled);
            AssetDatabase.SaveAssets();
        }

        private void OnCleared(string groupName, BuildTargetGroup buildTargetGroup, bool onlyEnabled)
        {
            DefinesBuildEditorUtility.ClearAll(buildTargetGroup, LogEditorSettings.Settings, onlyEnabled);
            AssetDatabase.SaveAssets();
        }
    }
}
