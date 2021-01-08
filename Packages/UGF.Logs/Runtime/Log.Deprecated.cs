using System;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    public static partial class Log
    {
        /// <summary>
        /// Gets or sets logger to use. (Default is Unity Logger wrapper.)
        /// </summary>
        /// <remarks>
        /// By default logger is wrapper around Unity Logger and can be controlled separately from it, such as enabled or filter properties.
        /// </remarks>
        [Obsolete("Logger has been deprecated. Use Handler instead.")]
        public static ILogger Logger { get { return m_logger; } set { m_logger = value ?? throw new ArgumentNullException(nameof(Logger)); } }

        private static ILogger m_logger = new Logger(UnityEngine.Debug.unityLogger);

        /// <summary>
        /// Logs message with the specified log type and message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method always included in build.
        /// </remarks>
        /// <param name="logType">The type of the log.</param>
        /// <param name="message">The message.</param>
        [Obsolete("Message with LogType has been deprecated. Use Message method with tag instead.")]
        public static void Message(LogType logType, object message)
        {
            Message(logType.ToString(), message);
        }

        /// <summary>
        /// Logs message with the specified log type, message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method always included in build.
        /// </remarks>
        /// <param name="logType">The type of the log.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Obsolete("Message with LogType has been deprecated. Use Message method with tag instead.")]
        public static void Message(LogType logType, string message, object arguments)
        {
            Message(logType.ToString(), message, arguments);
        }

        [Obsolete("Message with LogType has been deprecated. Use Message method with tag instead.")]
        public static void Message(LogType logType, string message, Exception exception, object arguments = null)
        {
            Message(logType.ToString(), message, exception, arguments);
        }
    }
}
