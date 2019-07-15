using System;
using System.Diagnostics;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace UGF.Logs.Runtime
{
    /// <summary>
    /// Represents access to logging using specified logger.
    /// <para>
    /// Some methods are included in release build only if the specific compilation symbol is defined.
    /// </para>
    /// <para>
    /// All methods are included in development build.
    /// </para>
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Gets or sets logger to use. (Default is Unity Logger)
        /// </summary>
        public static ILogger Logger { get; set; } = Debug.unityLogger;

        /// <summary>
        /// Logs message as info with the specified message and arguments.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_INFO` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="message">The formattable message.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <param name="arg2">The third argument.</param>
        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        [StringFormatMethod("message")]
        public static void Info(string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            Message(LogType.Log, message, arg0, arg1, arg2);
        }

        /// <summary>
        /// Logs message as info with the specified message and arguments.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_INFO` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="message">The formattable message.</param>
        /// <param name="args">The arguments.</param>
        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        [StringFormatMethod("message")]
        public static void Info(string message, params object[] args)
        {
            Message(LogType.Log, message, args);
        }

        /// <summary>
        /// Logs message as info with the specified tag, message and arguments.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_INFO` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="tag">The tag of the log.</param>
        /// <param name="message">The formattable message.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <param name="arg2">The third argument.</param>
        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        [StringFormatMethod("message")]
        public static void Info(string tag, string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            Message(LogType.Log, tag, message, arg0, arg1, arg2);
        }

        /// <summary>
        /// Logs message as info with the specified tag, message and arguments.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_INFO` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="tag">The tag of the log.</param>
        /// <param name="message">The formattable message.</param>
        /// <param name="args">The arguments.</param>
        [Conditional("UGF_LOG_INFO")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        [StringFormatMethod("message")]
        public static void Info(string tag, string message, params object[] args)
        {
            Message(LogType.Log, tag, message, args);
        }

        /// <summary>
        /// Logs message as warning with the specified tag, message and arguments.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_WARNING` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="message">The formattable message.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <param name="arg2">The third argument.</param>
        [Conditional("UGF_LOG_WARNING")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        [StringFormatMethod("message")]
        public static void Warning(string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            Message(LogType.Warning, message, arg0, arg1, arg2);
        }

        /// <summary>
        /// Logs message as warning with the specified tag, message and arguments.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_WARNING` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="message">The formattable message.</param>
        /// <param name="args">The arguments.</param>
        [Conditional("UGF_LOG_WARNING")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        [StringFormatMethod("message")]
        public static void Warning(string message, params object[] args)
        {
            Message(LogType.Warning, message, args);
        }

        /// <summary>
        /// Logs message as error with the specified tag, message and arguments.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_ERROR` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="message">The formattable message.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <param name="arg2">The third argument.</param>
        [Conditional("UGF_LOG_ERROR")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        [StringFormatMethod("message")]
        public static void Error(string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            Message(LogType.Error, message, arg0, arg1, arg2);
        }

        /// <summary>
        /// Logs message as error with the specified tag, message and arguments.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_ERROR` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="message">The formattable message.</param>
        /// <param name="args">The arguments.</param>
        [Conditional("UGF_LOG_ERROR")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        [StringFormatMethod("message")]
        public static void Error(string message, params object[] args)
        {
            Message(LogType.Error, message, args);
        }

        /// <summary>
        /// Logs message based on the specified exception.
        /// <para>
        /// Invocation of this method will be included in release build, only if the `UGF_LOG_EXCEPTION` compilation symbol is defined.
        /// </para>
        /// </summary>
        /// <param name="exception">The exception to log.</param>
        [Conditional("UGF_LOG_EXCEPTION")]
        [Conditional("UNITY_EDITOR")]
        [Conditional("DEVELOPMENT_BUILD")]
        public static void Exception(Exception exception)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));

            Logger.LogException(exception);
        }

        /// <summary>
        /// Logs message with the specified log type, message and arguments.
        /// <para>
        /// Invocation of this method always include in release build.
        /// </para>
        /// </summary>
        /// <param name="logType">The type of the log.</param>
        /// <param name="message">The formattable message.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <param name="arg2">The third argument.</param>
        [StringFormatMethod("message")]
        public static void Message(LogType logType, string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");

            Logger.Log(logType, string.Format(message, arg0, arg1, arg2));
        }

        /// <summary>
        /// Logs message with the specified log type, message and arguments.
        /// <para>
        /// Invocation of this method always include in release build.
        /// </para>
        /// </summary>
        /// <param name="logType">The type of the log.</param>
        /// <param name="tag">The tag of the log.</param>
        /// <param name="message">The formattable message.</param>
        /// <param name="arg0">The first argument.</param>
        /// <param name="arg1">The second argument.</param>
        /// <param name="arg2">The third argument.</param>
        [StringFormatMethod("message")]
        public static void Message(LogType logType, string tag, string message, object arg0 = null, object arg1 = null, object arg2 = null)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");

            Logger.Log(logType, tag, string.Format(message, arg0, arg1, arg2));
        }

        /// <summary>
        /// Logs message with the specified log type, message and arguments.
        /// <para>
        /// Invocation of this method always include in release build.
        /// </para>
        /// </summary>
        /// <param name="logType">The type of the log.</param>
        /// <param name="message">The formattable message.</param>
        /// <param name="args">The arguments.</param>
        [StringFormatMethod("message")]
        public static void Message(LogType logType, string message, params object[] args)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");

            Logger.Log(logType, string.Format(message, args));
        }

        /// <summary>
        /// Logs message with the specified log type, message and arguments.
        /// <para>
        /// Invocation of this method always include in release build.
        /// </para>
        /// </summary>
        /// <param name="logType">The type of the log.</param>
        /// <param name="tag">The tag of the log.</param>
        /// <param name="message">The formattable message.</param>
        /// <param name="args">The arguments.</param>
        [StringFormatMethod("message")]
        public static void Message(LogType logType, string tag, string message, params object[] args)
        {
            if (tag == null) throw new ArgumentNullException(nameof(tag));
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (Logger == null) throw new InvalidOperationException("The logger not specified.");

            Logger.Log(logType, tag, string.Format(message, args));
        }
    }
}
