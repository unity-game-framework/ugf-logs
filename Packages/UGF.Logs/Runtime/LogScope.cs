using System;

namespace UGF.Logs.Runtime
{
    public readonly struct LogScope : IDisposable
    {
        private readonly ILog m_log;

        public LogScope(ILog log)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));

            m_log = Log.Logger;

            Log.Logger = log;
        }

        public void Dispose()
        {
            Log.Logger = m_log;
        }
    }
}
