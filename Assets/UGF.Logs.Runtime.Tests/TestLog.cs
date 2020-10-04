using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace UGF.Logs.Runtime.Tests
{
    public class TestLog
    {
        private class CollectLogs : IDisposable
        {
            public List<string> Logs { get; } = new List<string>();

            public CollectLogs()
            {
                Application.logMessageReceived += OnApplicationLogMessageReceived;
            }

            public void Dispose()
            {
                Application.logMessageReceived -= OnApplicationLogMessageReceived;
            }

            private void OnApplicationLogMessageReceived(string condition, string stacktrace, LogType type)
            {
                Logs.Add(condition);
            }
        }

        [Test]
        public void LogInfo()
        {
            using (var logs = new CollectLogs())
            {
                Log.Info(nameof(LogInfo));

                Assert.Contains(nameof(LogInfo), logs.Logs);
            }
        }

        [Test]
        public void LogDebug()
        {
            using (var logs = new CollectLogs())
            {
                Log.Debug(nameof(LogDebug));

                Assert.Contains(nameof(LogDebug), logs.Logs);
            }
        }

        [Test]
        public void LogWarning()
        {
            using (var logs = new CollectLogs())
            {
                Log.Warning(nameof(LogWarning));

                Assert.Contains(nameof(LogWarning), logs.Logs);
            }
        }

        // [Test]
        // public void LogError()
        // {
        //     using (var logs = new CollectLogs())
        //     {
        //         Log.Error(nameof(LogError));
        //
        //         Assert.Contains(nameof(LogError), logs.Logs);
        //     }
        // }
    }
}
