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

            Log.SetLogger(log);
        }

        public void Dispose()
        {
            Log.SetLogger(m_log);
        }
    }
}
