using UGF.CustomSettings.Editor;
using UGF.Defines.Editor;
using UGF.EditorTools.Runtime.IMGUI.PlatformSettings;
using UGF.Logs.Runtime;
using UnityEditor;

namespace UGF.Logs.Editor
{
    [InitializeOnLoad]
    public static class LogEditorSettings
    {
        public static bool EditorEnabled
        {
            get { return m_settings.Data.EditorEnabled; }
            set
            {
                m_settings.Data.EditorEnabled = value;
                m_settings.SaveSettings();
            }
        }

        public static PlatformSettings<DefinesSettings> Settings { get { return m_settings.Data.Settings; } }

        private static readonly CustomSettingsEditorPackage<LogEditorSettingsData> m_settings = new CustomSettingsEditorPackage<LogEditorSettingsData>
        (
            "UGF.Logs",
            "LogEditorSettings"
        );

        static LogEditorSettings()
        {
            m_settings.Saved += OnSettingsChanged;
            m_settings.Loaded += OnSettingsChanged;
        }

        public static void Save()
        {
            m_settings.SaveSettings();
        }

        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<LogEditorSettingsData>("Project/UGF/Logs", m_settings, SettingsScope.Project);
        }

        private static void OnSettingsChanged(LogEditorSettingsData data)
        {
            Log.Logger.logEnabled = data.EditorEnabled;
        }
    }
}
