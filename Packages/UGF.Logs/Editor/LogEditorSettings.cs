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
            get { return Settings.Data.EditorEnabled; }
            set
            {
                Settings.Data.EditorEnabled = value;
                Settings.SaveSettings();
            }
        }

        public static PlatformSettings<DefinesSettings> PlatformSettings { get { return Settings.Data.Settings; } }

        public static CustomSettingsEditorPackage<LogEditorSettingsData> Settings { get; } = new CustomSettingsEditorPackage<LogEditorSettingsData>
        (
            "UGF.Logs",
            "LogEditorSettings"
        );

        static LogEditorSettings()
        {
            Settings.Saved += OnSettingsChanged;
            Settings.Loaded += OnSettingsChanged;
        }

        [SettingsProvider]
        private static SettingsProvider GetProvider()
        {
            return new CustomSettingsProvider<LogEditorSettingsData>("Project/UGF/Logs", Settings, SettingsScope.Project);
        }

        private static void OnSettingsChanged(LogEditorSettingsData data)
        {
            Log.Logger.logEnabled = data.EditorEnabled;
        }
    }
}
