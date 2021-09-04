using System;
using System.Diagnostics;

namespace UGF.Logs.Runtime
{
    public static class LogExtensions
    {
        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_INFO_DEFINE)]
        public static void Info(this ILog log, object message)
        {
            Message(log, LogTags.INFO, message);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_INFO_DEFINE)]
        public static void Info(this ILog log, string message, object arguments)
        {
            Message(log, LogTags.INFO, message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_INFO_DEFINE)]
        public static void Info(this ILog log, string message, Exception exception, object arguments = null)
        {
            Message(log, LogTags.INFO, message, exception, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_DEBUG_DEFINE)]
        public static void Debug(this ILog log, object message)
        {
            Message(log, LogTags.DEBUG, message);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_DEBUG_DEFINE)]
        public static void Debug(this ILog log, string message, object arguments)
        {
            Message(log, LogTags.DEBUG, message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_DEBUG_DEFINE)]
        public static void Debug(this ILog log, string message, Exception exception, object arguments = null)
        {
            Message(log, LogTags.DEBUG, message, exception, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_WARNING_DEFINE)]
        public static void Warning(this ILog log, object message)
        {
            Message(log, LogTags.WARNING, message);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_WARNING_DEFINE)]
        public static void Warning(this ILog log, string message, object arguments)
        {
            Message(log, LogTags.WARNING, message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_WARNING_DEFINE)]
        public static void Warning(this ILog log, string message, Exception exception, object arguments = null)
        {
            Message(log, LogTags.WARNING, message, exception, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_ERROR_DEFINE)]
        public static void Error(this ILog log, object message)
        {
            Message(log, LogTags.ERROR, message);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_ERROR_DEFINE)]
        public static void Error(this ILog log, string message, object arguments)
        {
            Message(log, LogTags.ERROR, message, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_ERROR_DEFINE)]
        public static void Error(this ILog log, string message, Exception exception, object arguments = null)
        {
            Message(log, LogTags.ERROR, message, exception, arguments);
        }

        [Conditional("UNITY_EDITOR")]
        [Conditional(LogUtility.LOG_EXCEPTION_DEFINE)]
        public static void Exception(this ILog log, Exception exception)
        {
            Message(log, LogTags.EXCEPTION, exception);
        }

        public static void Message(this ILog log, string tag, string message, object arguments)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));

            message = LogUtility.Format(message, arguments);

            log.Message(tag, message);
        }

        public static void Message(this ILog log, string tag, string message, Exception exception, object arguments = null)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));

            if (arguments != null)
            {
                message = LogUtility.Format(message, arguments);
            }

            message = LogUtility.Format(message, exception);

            log.Message(tag, message);
        }

        private static void Message(ILog log, string tag, object message)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));

            log.Message(tag, message);
        }
    }
}
