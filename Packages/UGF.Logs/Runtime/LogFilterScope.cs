using System;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents local scope of the log to change filter log type of the current logger specified in <see cref="Log"/>.
    /// </summary>
    public readonly struct LogFilterScope : IDisposable
    {
        private readonly LogHandlerUnity m_handler;
        private readonly LogType m_filterLogType;

        /// <summary>
        /// Creates scope with the specified filter log type.
        /// </summary>
        /// <param name="filterLogType">The type of the filter.</param>
        public LogFilterScope(LogType filterLogType)
        {
            if (Log.Handler is LogHandlerUnity handler)
            {
                m_handler = handler;
                m_filterLogType = handler.UnityLogger.filterLogType;

                handler.UnityLogger.filterLogType = filterLogType;
            }
            else
            {
                m_handler = null;
                m_filterLogType = LogType.Log;
            }
        }

        public void Dispose()
        {
            if (m_handler != null)
            {
                m_handler.UnityLogger.filterLogType = m_filterLogType;
            }
        }
    }
}
