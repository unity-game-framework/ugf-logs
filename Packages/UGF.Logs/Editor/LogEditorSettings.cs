using UGF.CustomSettings.Editor;
using UGF.EditorTools.Editor.Defines;
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

        public static bool BuildEnabled
        {
            get { return m_settings.Data.BuildEnabled; }
            set
            {
                m_settings.Data.BuildEnabled = value;
                m_settings.SaveSettings();
            }
        }

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

        public static void SetBuildSettings(BuildTargetGroup buildTargetGroup, LogBuildSettings settings)
        {
            if (!TryUpdateBuildSettings(buildTargetGroup, settings))
            {
                LogEditorSettingsData data = m_settings.Data;

                var platform = new LogEditorSettingsData.Platform
                {
                    Group = buildTargetGroup,
                    Settings = settings
                };

                data.Platforms.Add(platform);
                m_settings.SaveSettings();
            }
        }

        public static LogBuildSettings GetBuildSettings(BuildTargetGroup buildTargetGroup)
        {
            if (!TryGetBuildSettings(buildTargetGroup, out LogBuildSettings settings))
            {
                settings = new LogBuildSettings();

                SetBuildSettings(buildTargetGroup, settings);
            }

            return settings;
        }

        public static bool TryGetBuildSettings(BuildTargetGroup buildTargetGroup, out LogBuildSettings settings)
        {
            LogEditorSettingsData data = m_settings.Data;

            for (int i = 0; i < data.Platforms.Count; i++)
            {
                LogEditorSettingsData.Platform platform = data.Platforms[i];

                if (platform.Group == buildTargetGroup)
                {
                    settings = platform.Settings;
                    return true;
                }
            }

            settings = default;
            return false;
        }

        public static void ApplyBuildSettings(BuildTargetGroup buildTargetGroup, LogBuildSettings settings)
        {
            EnableDefine(buildTargetGroup, LogUtility.LOG_INFO_DEFINE, settings.Info);
            EnableDefine(buildTargetGroup, LogUtility.LOG_DEBUG_DEFINE, settings.Debug);
            EnableDefine(buildTargetGroup, LogUtility.LOG_WARNING_DEFINE, settings.Warning);
            EnableDefine(buildTargetGroup, LogUtility.LOG_ERROR_DEFINE, settings.Error);
            EnableDefine(buildTargetGroup, LogUtility.LOG_EXCEPTION_DEFINE, settings.Exception);
        }

        public static void ClearBuildSettings(BuildTargetGroup buildTargetGroup)
        {
            EnableDefine(buildTargetGroup, LogUtility.LOG_INFO_DEFINE, false);
            EnableDefine(buildTargetGroup, LogUtility.LOG_DEBUG_DEFINE, false);
            EnableDefine(buildTargetGroup, LogUtility.LOG_WARNING_DEFINE, false);
            EnableDefine(buildTargetGroup, LogUtility.LOG_ERROR_DEFINE, false);
            EnableDefine(buildTargetGroup, LogUtility.LOG_EXCEPTION_DEFINE, false);
        }

        [SettingsProvider]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<LogEditorSettingsData>("Project/UGF/Logs", m_settings, SettingsScope.Project);
        }

        private static bool TryUpdateBuildSettings(BuildTargetGroup buildTargetGroup, LogBuildSettings settings)
        {
            LogEditorSettingsData data = m_settings.Data;

            for (int i = 0; i < data.Platforms.Count; i++)
            {
                LogEditorSettingsData.Platform platform = data.Platforms[i];

                if (platform.Group == buildTargetGroup)
                {
                    platform.Settings = settings;
                    return true;
                }
            }

            return false;
        }

        private static void EnableDefine(BuildTargetGroup buildTargetGroup, string define, bool value)
        {
            if (value)
            {
                DefinesEditorUtility.SetDefine(define, buildTargetGroup);
            }
            else
            {
                DefinesEditorUtility.RemoveDefine(define, buildTargetGroup);
            }
        }

        private static void OnSettingsChanged(LogEditorSettingsData data)
        {
            Log.Logger.logEnabled = data.EditorEnabled;
        }
    }
}
