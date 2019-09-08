using UnityEngine;

namespace UGF.Logs.Editor.Settings
{
    internal class LogEditorSettingsData : ScriptableObject
    {
        [Header("Compilation Defines")]
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

        [Header("Mute")]
        [Tooltip("Determines whether to mute 'Debug' logs in editor.")]
        [SerializeField] private bool m_muteDebug;

        public bool Info { get { return m_info; } set { m_info = value; } }
        public bool Debug { get { return m_debug; } set { m_debug = value; } }
        public bool Warning { get { return m_warning; } set { m_warning = value; } }
        public bool Error { get { return m_error; } set { m_error = value; } }
        public bool Exception { get { return m_exception; } set { m_exception = value; } }
        public bool MuteDebug { get { return m_muteDebug; } set { m_muteDebug = value; } }
    }
}
