using System;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents local scope of the specified logger.
    /// </summary>
    public struct LogScope : IDisposable
    {
        private readonly ILogger m_logger;

        /// <summary>
        /// Creates the scope with the specified logger.
        /// </summary>
        /// <param name="logger">The logger to use inside the scope.</param>
        public LogScope(ILogger logger)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));

            m_logger = Log.Logger;

            Log.Logger = logger;
        }

        public void Dispose()
        {
            Log.Logger = m_logger;
        }
    }
}
