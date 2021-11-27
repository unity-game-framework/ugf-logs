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
        public static ILog Logger
        {
            get { return m_logger ?? throw new ArgumentException("Value not specified."); }
            [Obsolete("Logger setter is deprecated. Use SetLogger method instead.")]
            set { SetLogger(value); }
        }

        private static ILog m_logger;

        public static void SetLogger(ILog logger)
        {
            m_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public static void ClearLogger()
        {
            m_logger = null;
        }

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
            Logger.Info(message);
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
            Logger.Info(message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_INFO_DEFINE)]
        public static void Info(string message, Exception exception, object arguments = null)
        {
            Logger.Info(message, exception, arguments);
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
            Logger.Debug(message);
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
            Logger.Debug(message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_DEBUG_DEFINE)]
        public static void Debug(string message, Exception exception, object arguments = null)
        {
            Logger.Debug(message, exception, arguments);
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
            Logger.Warning(message);
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
            Logger.Warning(message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_WARNING_DEFINE)]
        public static void Warning(string message, Exception exception, object arguments = null)
        {
            Logger.Warning(message, exception, arguments);
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
            Logger.Error(message);
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
            Logger.Error(message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_ERROR_DEFINE)]
        public static void Error(string message, Exception exception, object arguments = null)
        {
            Logger.Error(message, exception, arguments);
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
            Logger.Exception(exception);
        }

        public static void Message(string tag, string message, object arguments)
        {
            Logger.Message(tag, message, arguments);
        }

        public static void Message(string tag, string message, Exception exception, object arguments = null)
        {
            Logger.Message(tag, message, exception, arguments);
        }

        public static void Message(string tag, object value)
        {
            Logger.Message(tag, value);
        }
    }
}
