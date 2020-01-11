using JetBrains.Annotations;
using UGF.CustomSettings.Editor;
using UnityEditor;

namespace UGF.Logs.Editor.Settings
{
    /// <summary>
    /// Provides settings logging.
    /// </summary>
    [InitializeOnLoad]
    public static class LogEditorSettings
    {
        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_INFO' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool LogInfo
        {
            get { return m_settings.Data.Info; }
            set
            {
                m_settings.Data.Info = value;
                m_settings.SaveSettings();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_DEBUG' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool LogDebug
        {
            get { return m_settings.Data.Debug; }
            set
            {
                m_settings.Data.Debug = value;
                m_settings.SaveSettings();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_WARNING' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool LogWarning
        {
            get { return m_settings.Data.Warning; }
            set
            {
                m_settings.Data.Warning = value;
                m_settings.SaveSettings();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_ERROR' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool LogError
        {
            get { return m_settings.Data.Error; }
            set
            {
                m_settings.Data.Error = value;
                m_settings.SaveSettings();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_EXCEPTION' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool LogException
        {
            get { return m_settings.Data.Exception; }
            set
            {
                m_settings.Data.Exception = value;
                m_settings.SaveSettings();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_INCLUDE_EDITOR' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool AlwaysIncludeInEditor
        {
            get { return m_settings.Data.AlwaysIncludeInEditor; }
            set
            {
                m_settings.Data.AlwaysIncludeInEditor = value;
                m_settings.SaveSettings();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_INCLUDE_DEVBUILD' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool AlwaysIncludeInDevelopmentBuild
        {
            get { return m_settings.Data.AlwaysIncludeInDevelopmentBuild; }
            set
            {
                m_settings.Data.AlwaysIncludeInDevelopmentBuild = value;
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
            m_settings.Saved += OnSettingsSaved;
            m_settings.Loaded += OnSettingsLoaded;
        }

        private static void OnSettingsSaved()
        {
            var settings = new LogDefineSettings
            {
                Info = m_settings.Data.Info,
                Debug = m_settings.Data.Debug,
                Warning = m_settings.Data.Warning,
                Error = m_settings.Data.Error,
                Exception = m_settings.Data.Exception,
                IncludeEditor = m_settings.Data.AlwaysIncludeInEditor,
                IncludeDevelopmentBuild = m_settings.Data.AlwaysIncludeInDevelopmentBuild
            };

            LogEditorUtility.SetSettingsAll(settings);
        }

        private static void OnSettingsLoaded()
        {
            LogDefineSettings settings = LogEditorUtility.GetSettings();

            m_settings.Data.Info = settings.Info;
            m_settings.Data.Debug = settings.Debug;
            m_settings.Data.Warning = settings.Warning;
            m_settings.Data.Error = settings.Error;
            m_settings.Data.Exception = settings.Exception;
            m_settings.Data.AlwaysIncludeInEditor = settings.IncludeEditor;
            m_settings.Data.AlwaysIncludeInDevelopmentBuild = settings.IncludeDevelopmentBuild;
        }

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<LogEditorSettingsData>("Project/UGF/Logs", m_settings, SettingsScope.Project);
        }
    }
}
