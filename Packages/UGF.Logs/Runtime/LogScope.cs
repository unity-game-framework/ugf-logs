using System;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    public struct LogScope : IDisposable
    {
        private readonly bool m_enabled;

        public LogScope(bool enabled)
        {
            m_enabled = false;

            ILogger logger = Log.Logger;

            if (logger != null)
            {
                logger.logEnabled = enabled;

                m_enabled = logger.logEnabled;
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
