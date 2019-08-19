using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Logs.Editor
{
    /// <summary>
    /// Represents project settings of the logs.
    /// </summary>
    [Serializable]
    public class LogEditorSettings
    {
        [SerializeField] private bool m_logInfo;
        [SerializeField] private bool m_logDebug;
        [SerializeField] private bool m_logWarning;
        [SerializeField] private bool m_logError;
        [SerializeField] private bool m_logException;

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_INFO' define is specified.
        /// </summary>
        public bool LogInfo { get { return m_logInfo; } set { m_logInfo = value; } }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_DEBUG' define is specified.
        /// </summary>
        public bool LogDebug { get { return m_logDebug; } set { m_logDebug = value; } }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_WARNING' define is specified.
        /// </summary>
        public bool LogWarning { get { return m_logWarning; } set { m_logWarning = value; } }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_ERROR' define is specified.
        /// </summary>
        public bool LogError { get { return m_logError; } set { m_logError = value; } }

        /// <summary>
        /// Gets or sets the value that determines whether 'UGF_LOG_EXCEPTION' define is specified.
        /// </summary>
        public bool LogException { get { return m_logException; } set { m_logException = value; } }

        internal void InternalSetSettings(HashSet<string> defines)
        {
            m_logInfo = defines.Contains(LogEditorUtility.DefineLogInfo);
            m_logDebug = defines.Contains(LogEditorUtility.DefineLogDebug);
            m_logWarning = defines.Contains(LogEditorUtility.DefineLogWarning);
            m_logError = defines.Contains(LogEditorUtility.DefineLogError);
            m_logException = defines.Contains(LogEditorUtility.DefineLogException);
        }

        internal void InternalGetDefines(HashSet<string> defines)
        {
            SetupDefine(defines, LogEditorUtility.DefineLogInfo, m_logInfo);
            SetupDefine(defines, LogEditorUtility.DefineLogDebug, m_logDebug);
            SetupDefine(defines, LogEditorUtility.DefineLogWarning, m_logWarning);
            SetupDefine(defines, LogEditorUtility.DefineLogError, m_logError);
            SetupDefine(defines, LogEditorUtility.DefineLogException, m_logException);
        }

        private void SetupDefine(HashSet<string> defines, string define, bool state)
        {
            if (state)
            {
                defines.Add(define);
            }
            else
            {
                defines.Remove(define);
            }
        }
    }
}
