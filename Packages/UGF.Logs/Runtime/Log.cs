using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace UGF.Logs.Runtime
{
    public static class Log
    {
        public static ILogger Logger { get; set; } = Debug.unityLogger;

        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Info(string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            Message(LogType.Log, message, arg0, arg1, arg2);
        }

        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Info(string message, params object[] args)
        {
            Message(LogType.Log, message, args);
        }

        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Info(string tag, string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            Message(LogType.Log, tag, message, arg0, arg1, arg2);
        }

        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Info(string tag, string message, params object[] args)
        {
            Message(LogType.Log, tag, message, args);
        }

        [Conditional("UGF_LOG_WARNING")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Warning(string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            Message(LogType.Warning, message, arg0, arg1, arg2);
        }

        [Conditional("UGF_LOG_WARNING")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Warning(string message, params object[] args)
        {
            Message(LogType.Warning, message, args);
        }

        [Conditional("UGF_LOG_ERROR")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Error(string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            Message(LogType.Error, message, arg0, arg1, arg2);
        }

        [Conditional("UGF_LOG_ERROR")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Error(string message, params object[] args)
        {
            Message(LogType.Error, message, args);
        }

        [Conditional("UGF_LOG_EXCEPTION")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Exception(Exception exception)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            Logger.LogException(exception);
        }

        public static void Message(LogType logType, string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");

            Logger.Log(logType, string.Format(message, arg0, arg1, arg2));
        }

        public static void Message(LogType logType, string tag, string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");

            Logger.Log(logType, tag, string.Format(message, arg0, arg1, arg2));
        }

        public static void Message(LogType logType, string message, params object[] args)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");

            Logger.Log(logType, string.Format(message, args));
        }

        public static void Message(LogType logType, string tag, string message, params object[] args)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");

            Logger.Log(logType, tag, string.Format(message, args));
        }
    }
}
