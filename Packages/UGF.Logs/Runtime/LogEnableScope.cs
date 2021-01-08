using System;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents local scope of the log to temporarily enable or disable logging of the current logger specified in <see cref="Log"/>.
    /// </summary>
    public readonly struct LogEnableScope : IDisposable
    {
        private readonly ILogHandlerWithEnable m_handler;
        private readonly bool m_enabled;

        /// <summary>
        /// Creates scope with value that determines whether logger will be enabled inside of the scope.
        /// </summary>
        /// <param name="enabled">The value to enable or disable logger.</param>
        public LogEnableScope(bool enabled)
        {
            if (Log.Handler is ILogHandlerWithEnable handler)
            {
                m_handler = handler;
                m_enabled = handler.IsEnabled;

                handler.IsEnabled = enabled;
            }
            else
            {
                m_handler = null;
                m_enabled = false;
            }
        }

        public void Dispose()
        {
            if (m_handler != null)
            {
                m_handler.IsEnabled = m_enabled;
            }
        }
    }
}
