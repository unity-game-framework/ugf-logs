using System;
using System.Diagnostics;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents access to logging using specified logger.
    /// </summary>
    /// <remarks>
    /// Some methods are included in build only when the specific compilation symbol is defined.
    /// Invocation of all methods always included in editor.
    /// </remarks>
    public static partial class Log
    {
        public static ILogHandler Handler { get { return m_handler; } set { m_handler = value ?? throw new ArgumentNullException(nameof(value)); } }

        private static ILogHandler m_handler = new LogHandlerConsole();

        /// <summary>
        /// Logs message as info with the specified message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_INFO' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_INFO_DEFINE)]
        public static void Info(object message)
        {
            Message(LogTags.INFO, message);
        }

        /// <summary>
        /// Logs message as info with the specified message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_INFO' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_INFO_DEFINE)]
        public static void Info(string message, object arguments)
        {
            Message(LogTags.INFO, message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_INFO_DEFINE)]
        public static void Info(string message, Exception exception, object arguments = null)
        {
            Message(LogTags.INFO, message, exception, arguments);
        }

        /// <summary>
        /// Logs message as debug info with the specified message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_DEBUG' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_DEBUG_DEFINE)]
        public static void Debug(object message)
        {
            Message(LogTags.DEBUG, message);
        }

        /// <summary>
        /// Logs message as debug info with the specified message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_DEBUG' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_DEBUG_DEFINE)]
        public static void Debug(string message, object arguments)
        {
            Message(LogTags.DEBUG, message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_DEBUG_DEFINE)]
        public static void Debug(string message, Exception exception, object arguments = null)
        {
            Message(LogTags.DEBUG, message, exception, arguments);
        }

        /// <summary>
        /// Logs message as warning info with the specified message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_WARNING' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_WARNING_DEFINE)]
        public static void Warning(object message)
        {
            Message(LogTags.WARNING, message);
        }

        /// <summary>
        /// Logs message as warning with the specified message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_WARNING' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_WARNING_DEFINE)]
        public static void Warning(string message, object arguments)
        {
            Message(LogTags.WARNING, message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_WARNING_DEFINE)]
        public static void Warning(string message, Exception exception, object arguments = null)
        {
            Message(LogTags.WARNING, message, exception, arguments);
        }

        /// <summary>
        /// Logs message as error info with the specified message.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_ERROR' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_ERROR_DEFINE)]
        public static void Error(object message)
        {
            Message(LogTags.ERROR, message);
        }

        /// <summary>
        /// Logs message as error with the specified message and arguments.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_ERROR' compilation symbol is defined.
        /// </remarks>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The dynamic arguments used to format with message.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_ERROR_DEFINE)]
        public static void Error(string message, object arguments)
        {
            Message(LogTags.ERROR, message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_ERROR_DEFINE)]
        public static void Error(string message, Exception exception, object arguments = null)
        {
            Message(LogTags.ERROR, message, exception, arguments);
        }

        /// <summary>
        /// Logs message based on the specified exception.
        /// </summary>
        /// <remarks>
        /// Invocation of this method will be included in build only when the 'UGF_LOG_EXCEPTION' compilation symbol is defined.
        /// </remarks>
        /// <param name="exception">The exception to log.</param>
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_EXCEPTION_DEFINE)]
        public static void Exception(Exception exception)
        {
            Message(LogTags.EXCEPTION, exception);
        }

        public static void Message(string tag, string message, object arguments)
        {
            message = LogUtility.Format(message, arguments);

            Message(tag, message);
        }

        public static void Message(string tag, string message, Exception exception, object arguments = null)
        {
            if (arguments != null)
            {
                message = LogUtility.Format(message, arguments);
            }

            message = LogUtility.Format(message, exception);

            Message(tag, message);
        }

        public static void Message(string tag, object value)
        {
            Handler.Write(tag, value);
        }
    }
}
