using JetBrains.Annotations;
using UGF.CustomSettings.Editor;
using UnityEditor;

namespace UGF.Logs.Editor.Settings
{
    /// <summary>
    /// Provides settings logging.
    /// </summary>
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
                m_settings.Save();
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
                m_settings.Save();
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
                m_settings.Save();
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
                m_settings.Save();
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
                m_settings.Save();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_NOEDITOR' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool NoInEditor
        {
            get { return m_settings.Data.NoInEditor; }
            set
            {
                m_settings.Data.NoInEditor = value;
                m_settings.Save();
            }
        }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_NODEVBUILD' define is specified.
        /// </summary>
        /// <remarks>
        /// Returns value for the current selected platform and set value for all platforms.
        ///
        /// To setup log defines settings per platform use 'LogDefineSettings' via 'LogEditorUtility'.
        /// </remarks>
        public static bool NoInDevelopmentBuild
        {
            get { return m_settings.Data.NoInDevelopmentBuild; }
            set
            {
                m_settings.Data.NoInDevelopmentBuild = value;
                m_settings.Save();
            }
        }

        private static readonly LogEditorCustomSettings m_settings = new LogEditorCustomSettings();

        [SettingsProvider, UsedImplicitly]
        private static SettingsProvider GetSettingsProvider()
        {
            return new CustomSettingsProvider<LogEditorSettingsData>("Project/UGF/Log", m_settings, SettingsScope.Project);
        }
    }
}
