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
        [Tooltip("Determines whether to use of the log defines settings in editor.")]
        [SerializeField] private bool m_noInEditor;
        [Tooltip("Determines whether to use of the log defines settings in development build.")]
        [SerializeField] private bool m_noInDevelopmentBuild;

        public bool Info { get { return m_info; } set { m_info = value; } }
        public bool Debug { get { return m_debug; } set { m_debug = value; } }
        public bool Warning { get { return m_warning; } set { m_warning = value; } }
        public bool Error { get { return m_error; } set { m_error = value; } }
        public bool Exception { get { return m_exception; } set { m_exception = value; } }
        public bool NoInEditor { get { return m_noInEditor; } set { m_noInEditor = value; } }
        public bool NoInDevelopmentBuild { get { return m_noInDevelopmentBuild; } set { m_noInDevelopmentBuild = value; } }
    }
}
