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
            get { return Settings.GetData().EditorEnabled; }
            set
            {
                Settings.GetData().EditorEnabled = value;
                Settings.SaveSettings();
            }
        }

        public static PlatformSettings<DefinesSettings> PlatformSettings { get { return Settings.GetData().Settings; } }

        public static CustomSettingsEditorPackage<LogEditorSettingsData> Settings { get; } = new CustomSettingsEditorPackage<LogEditorSettingsData>
        (
            "UGF.Logs",
            "LogEditorSettings"
        );

        static LogEditorSettings()
        {
            if (Settings.Exists())
            {
                LogsUpdateEnable();
            }

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
            LogsUpdateEnable();
        }

        private static void LogsUpdateEnable()
        {
            if (Log.Handler is ILogHandlerWithEnable handler)
            {
                handler.IsEnabled = EditorEnabled;
            }
        }
    }
}
