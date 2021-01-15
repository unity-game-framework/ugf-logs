using System;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    public class LogHandlerUnity : LogHandlerBase, ILogHandlerWithEnable
    {
        public ILogger UnityLogger { get; }
        public bool IsEnabled { get { return UnityLogger.logEnabled; } set { UnityLogger.logEnabled = value; } }

        public LogHandlerUnity(ILogger unityLogger)
        {
            UnityLogger = unityLogger ?? throw new ArgumentNullException(nameof(unityLogger));
        }

        protected override void OnWrite(string tag, object value)
        {
            switch (tag)
            {
                case LogTags.INFO:
                case LogTags.DEBUG:
                case "Log":
                {
                    UnityLogger.Log(LogType.Log, value);
                    break;
                }
                case LogTags.WARNING:
                {
                    UnityLogger.Log(LogType.Warning, value);
                    break;
                }
                case LogTags.ERROR:
                case "Assert":
                {
                    UnityLogger.Log(LogType.Error, value);
                    break;
                }
                case LogTags.EXCEPTION:
                {
                    if (value is Exception exception)
                    {
                        UnityLogger.LogException(exception);
                    }
                    else
                    {
                        UnityLogger.Log(LogType.Exception, value.ToString());
                    }

                    break;
                }
                default:
                {
                    UnityLogger.Log(tag, value);
                    break;
                }
            }
        }
    }
}
