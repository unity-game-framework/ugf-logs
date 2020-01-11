using System;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents local scope of the log to change filter log type of the current logger specified in <see cref="Log"/>.
    /// </summary>
    /// <remarks>
    /// See also: https://docs.unity3d.com/2019.3/Documentation/ScriptReference/Logger-filterLogType.html.
    /// </remarks>
    public struct LogFilterScope : IDisposable
    {
        private readonly LogType m_filterLogType;

        /// <summary>
        /// Creates scope with the specified filter log type.
        /// </summary>
        /// <param name="filterLogType">The type of the filter.</param>
        public LogFilterScope(LogType filterLogType)
        {
            m_filterLogType = Log.Logger.filterLogType;

            Log.Logger.filterLogType = filterLogType;
        }

        public void Dispose()
        {
            Log.Logger.filterLogType = m_filterLogType;
        }
    }
}
