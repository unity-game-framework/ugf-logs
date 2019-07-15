using System;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents local scope of the log to temporarily enable or disable logging of the current logger specified in <see cref="Log"/>.
    /// </summary>
    public struct LogEnableScope : IDisposable
    {
        private readonly bool m_enabled;

        /// <summary>
        /// Creates scope with value that determines whether logger will be enabled inside of the scope.
        /// </summary>
        /// <param name="enabled">The value to enable or disable logger.</param>
        public LogEnableScope(bool enabled)
        {
            m_enabled = false;

            ILogger logger = Log.Logger;

            if (logger != null)
            {
                m_enabled = logger.logEnabled;

                logger.logEnabled = enabled;
            }
        }

        public void Dispose()
        {
            ILogger logger = Log.Logger;

            if (logger != null)
            {
                logger.logEnabled = m_enabled;
            }
        }
    }
}
