using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UGF.Logs.Editor
{
    internal class LogEditorSettingsProviderEditor : SettingsProvider
    {
        private LogEditorSettings m_settings;

        public LogEditorSettingsProviderEditor() : base("Project/UGF/Logs", SettingsScope.Project, new[] { "Log" })
        {
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            m_settings = LogEditorUtility.GetSettings();
        }

        public override void OnDeactivate()
        {
            if (m_settings != null && m_settings.Changed)
            {
                if (EditorUtility.DisplayDialog("Unapplied settings", "Unapplied settings for 'Logs'.", "Apply", "Revert"))
                {
                    Apply();
                }
                else
                {
                    Revert();
                }
            }
        }

        public override void OnGUI(string searchContext)
        {
            using (new EditorGUI.IndentLevelScope())
            {
                m_settings.LogInfo = EditorGUILayout.Toggle("Info", m_settings.LogInfo);
                m_settings.LogDebug = EditorGUILayout.Toggle("Debug", m_settings.LogDebug);
                m_settings.LogWarning = EditorGUILayout.Toggle("Warning", m_settings.LogWarning);
                m_settings.LogError = EditorGUILayout.Toggle("Error", m_settings.LogError);
                m_settings.LogException = EditorGUILayout.Toggle("Exception", m_settings.LogException);

                using (new EditorGUI.DisabledScope(!m_settings.Changed))
                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.FlexibleSpace();

                    if (GUILayout.Button("Revert"))
                    {
                        Revert();
                    }

                    if (GUILayout.Button("Apply"))
                    {
                        Apply();
                    }

                    EditorGUILayout.Space();
                }

                if (m_settings.Changed)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.HelpBox("Applying settings will trigger recompilation.", MessageType.Info);
                }

                if (EditorUserBuildSettings.development)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.HelpBox("Development Build is active, all setting are ignored and all logs included in build.", MessageType.Info);
                }
            }
        }

        private void Revert()
        {
            m_settings.Revert();
        }

        private void Apply()
        {
            m_settings.Apply();

            LogEditorUtility.SetSettings(m_settings);
        }
    }
}
