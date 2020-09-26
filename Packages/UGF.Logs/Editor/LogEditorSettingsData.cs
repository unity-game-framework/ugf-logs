using UnityEngine;

namespace UGF.Logs.Editor.Settings
{
    internal class LogEditorSettingsData : ScriptableObject
    {
        [Header("Log Defines")]
        [Tooltip("Determines whether 'UGF_LOG_INFO' define is specified for selected platform.")]
        [SerializeField] private bool m_info;
        [Tooltip("Determines whether 'UGF_LOG_DEBUG' define is specified for selected platform.")]
        [SerializeField] private bool m_debug;
        [Tooltip("Determines whether 'UGF_LOG_WARNING' define is specified for selected platform.")]
        [SerializeField] private bool m_warning;
        [Tooltip("Determines whether 'UGF_LOG_ERROR' define is specified for selected platform.")]
        [SerializeField] private bool m_error;
        [Tooltip("Determines whether 'UGF_LOG_EXCEPTION' define is specified for selected platform.")]
        [SerializeField] private bool m_exception;

        [Header("Logs per Platform Defines")]
        [Tooltip("Determines whether to always include logs in 'Editor' whatever settings are.")]
        [SerializeField] private bool m_alwaysIncludeInEditor;
        [Tooltip("Determines whether to always include logs in 'Development Build' whatever settings are.")]
        [SerializeField] private bool m_alwaysIncludeInDevelopmentBuild;

        public bool Info { get { return m_info; } set { m_info = value; } }
        public bool Debug { get { return m_debug; } set { m_debug = value; } }
        public bool Warning { get { return m_warning; } set { m_warning = value; } }
        public bool Error { get { return m_error; } set { m_error = value; } }
        public bool Exception { get { return m_exception; } set { m_exception = value; } }
        public bool AlwaysIncludeInEditor { get { return m_alwaysIncludeInEditor; } set { m_alwaysIncludeInEditor = value; } }
        public bool AlwaysIncludeInDevelopmentBuild { get { return m_alwaysIncludeInDevelopmentBuild; } set { m_alwaysIncludeInDevelopmentBuild = value; } }
    }
}
