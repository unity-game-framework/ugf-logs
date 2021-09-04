using System;

namespace UGF.Logs.Runtime
{
    public static partial class Log
    {
        [Obsolete("Handler has been deprecated. Use Logger property to override logging behaviour.")]
        public static ILogHandler Handler { get { return m_handler; } set { throw new InvalidOperationException("Handler property has been deprecated. Use Logger property to override logging behaviour."); } }

        private static readonly ILogHandler m_handler = new LogHandlerUnity(UnityEngine.Debug.unityLogger);
    }
}
