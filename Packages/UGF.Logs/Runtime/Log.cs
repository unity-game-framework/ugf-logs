using System;
using System.Diagnostics;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents access to logging using specified logger.
    /// </summary>
    /// <remarks>
    /// Some methods are included in build only when the specific compilation symbol is defined.
    /// Invocation of all methods always included in editor.
    /// </remarks>
    public static class Log
    {
        /// <summary>
        /// Gets or sets logger to use. (Default is Unity Logger)
        /// </summary>
        public static ILogger Logger { get { return m_logger; } set { m_logger = value ?? throw new ArgumentNullException(nameof(Logger)); } }

        private static ILogger m_logger = UnityEngine.Debug.unityLogger;

        /// <summary>
        /// Logs message as info with the specified message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_INFO' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        public static void Info(object message)
        {
            Message(LogType.Log, message);
        }

        /// <summary>
        /// Logs message as info with the specified message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_INFO' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        public static void Info(string message, object arguments)
        {
            Message(LogType.Log, message, arguments);
        }

        /// <summary>
        /// Logs message as debug info with the specified message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_DEBUG' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        [Conditional("UGF_LOG_DEBUG")]
        [Conditional("UNITY_EDITOR")]
        public static void Debug(object message)
        {
            Message(LogType.Log, message);
        }

        /// <summary>
        /// Logs message as debug info with the specified message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_DEBUG' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Conditional("UGF_LOG_DEBUG")]
        [Conditional("UNITY_EDITOR")]
        public static void Debug(string message, object arguments)
        {
            Message(LogType.Log, message, arguments);
        }

        /// <summary>
        /// Logs message as warning info with the specified message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_WARNING' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        [Conditional("UGF_LOG_WARNING")]
        [Conditional("UNITY_EDITOR")]
        public static void Warning(object message)
        {
            Message(LogType.Warning, message);
        }

        /// <summary>
        /// Logs message as warning with the specified message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_WARNING' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Conditional("UGF_LOG_WARNING")]
        [Conditional("UNITY_EDITOR")]
        public static void Warning(string message, object arguments)
        {
            Message(LogType.Warning, message, arguments);
        }

        /// <summary>
        /// Logs message as error info with the specified message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_ERROR' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        [Conditional("UGF_LOG_ERROR")]
        [Conditional("UNITY_EDITOR")]
        public static void Error(object message)
        {
            Message(LogType.Error, message);
        }

        /// <summary>
        /// Logs message as error with the specified message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_ERROR' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Conditional("UGF_LOG_ERROR")]
        [Conditional("UNITY_EDITOR")]
        public static void Error(string message, object arguments)
        {
            Message(LogType.Error, message, arguments);
        }

        /// <summary>
        /// Logs message based on the specified exception.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_EXCEPTION' compilation symbol is defined.
        /// </remarks>
        /// <param name="exception">The exception to log.</param>
        [Conditional("UGF_LOG_EXCEPTION")]
        [Conditional("UNITY_EDITOR")]
        public static void Exception(Exception exception)
        {
            Message(LogType.Exception, exception);
        }

        /// <summary>
        /// Logs message with the specified log type and message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method always included in build.
        /// </remarks>
        /// <param name="logType">The type of the log.</param>
        /// <param name="message">The message.</param>
        public static void Message(LogType logType, object message)
        {
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");
            if (message == null) throw new ArgumentNullException(nameof(message));

            if (logType == LogType.Exception && message is Exception exception)
            {
                Logger.LogException(exception);
            }
            else
            {
                Logger.Log(logType, message);
            }
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
        public static void Message(LogType logType, string message, object arguments)
        {
            message = LogUtility.Format(message, arguments);

            Message(logType, message);
        }
    }
}
