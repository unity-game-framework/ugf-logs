using UGF.Defines.Editor;
using UGF.EditorTools.Editor.IMGUI.PlatformSettings;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.EditorTools.Editor.Platforms;
using UnityEditor;
using UnityEngine;

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
            m_drawer.Enable();

            m_propertyEditorEnabled = serializedObject.FindProperty("m_editorEnabled");
            m_propertyGroups = serializedObject.FindProperty("m_settings.m_groups");
        }

        private void OnDisable()
        {
            m_drawer.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorGUILayout.PropertyField(m_propertyEditorEnabled);

                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Scripting Define Symbols", EditorStyles.boldLabel);

                m_drawer.DrawGUILayout(m_propertyGroups);
            }

            EditorGUILayout.Space();

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Clear"))
                {
                    OnClear();
                }

                if (GUILayout.Button("Apply"))
                {
                    OnApply();
                }

                EditorGUILayout.Space();
            }

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("All Log methods enabled at Editor whether define symbol enabled or not.", MessageType.Info);
        }

        private void OnApply()
        {
            string platformName = m_drawer.GetSelectedPlatformName();
            PlatformInfo platform = PlatformEditorUtility.GetPlatform(platformName);

            if (LogEditorSettings.PlatformSettings.TryGetSettings(platform.BuildTargetGroup, out DefinesSettings settings))
            {
                DefinesBuildEditorUtility.ApplyDefinesAll(platform.BuildTargetGroup, settings);
                AssetDatabase.SaveAssets();
            }
        }

        private void OnClear()
        {
            string platformName = m_drawer.GetSelectedPlatformName();
            PlatformInfo platform = PlatformEditorUtility.GetPlatform(platformName);

            if (LogEditorSettings.PlatformSettings.TryGetSettings(platform.BuildTargetGroup, out DefinesSettings settings))
            {
                DefinesBuildEditorUtility.ClearDefinesAll(platform.BuildTargetGroup, settings);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
