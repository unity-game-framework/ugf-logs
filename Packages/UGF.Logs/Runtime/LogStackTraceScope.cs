using System;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents log stacktrace scope to control type of the stacktrace logging inside the scope.
    /// </summary>
    public readonly struct LogStackTraceScope : IDisposable
    {
        private readonly LogType m_logType;
        private readonly StackTraceLogType m_stackTraceType;

        /// <summary>
        /// Creates scope with the specified type of the log and stacktrace logging.
        /// </summary>
        /// <param name="logType">The type of the log.</param>
        /// <param name="stackTraceType">The type of the stacktrace logging.</param>
        public LogStackTraceScope(LogType logType, StackTraceLogType stackTraceType)
        {
            m_logType = logType;
            m_stackTraceType = Application.GetStackTraceLogType(logType);

            Application.SetStackTraceLogType(logType, stackTraceType);
        }

        public void Dispose()
        {
            Application.SetStackTraceLogType(m_logType, m_stackTraceType);
        }
    }
}
