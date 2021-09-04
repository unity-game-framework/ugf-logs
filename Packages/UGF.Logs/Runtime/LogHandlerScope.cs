using System;

namespace UGF.Logs.Runtime
{
    [Obsolete("LogHandlerScope has been deprecated. Use LogScope instead.")]
    public readonly struct LogHandlerScope : IDisposable
    {
        private readonly ILogHandler m_handler;

        public LogHandlerScope(ILogHandler handler)
        {
            m_handler = Log.Handler;

            Log.Handler = handler;
        }

        public void Dispose()
        {
            Log.Handler = m_handler;
        }
    }
}
