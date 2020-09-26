#undef DEVELOPMENT_BUILD

using System;
using NUnit.Framework;
using UnityEngine;

namespace UGF.Logs.Runtime.Tests
{
    public class TestLog
    {
        private class CatchLog : IDisposable
        {
            public bool Received { get; private set; }

            public CatchLog()
            {
                Application.logMessageReceived += OnLogMessageReceived;
            }

            public void Dispose()
            {
                Application.logMessageReceived -= OnLogMessageReceived;
            }

            private void OnLogMessageReceived(string condition, string stacktrace, LogType type)
            {
                Received = true;
            }
        }

        [Test]
        public void Test2()
        {
            Log.Info("Log: TEST");
            Debug.Log("Debug: TEST");
        }

        [Test]
        public void Test()
        {
            Log.Info("");

#if TEST2
            Assert.Pass("Has TEST defined.");
#else
            Assert.Fail("No TEST defined.");
#endif
        }

        //         [Test]
        //         public void Info()
        //         {
        //             using (new LogEnableScope(false))
        //             {
        //                 Assert.DoesNotThrow(() => Log.Info("Info"));
        //             }
        //         }
        //
        //         [Test]
        //         public void Info2()
        //         {
        // #if !UNITY_EDITOR
        //             bool result;
        //
        //             using (var scope = new CatchLog())
        //             {
        //                 Log.Info("Info2");
        //
        //                 result = scope.Received;
        //             }
        //
        //             Assert.False(result);
        // #endif
        //         }
        //
        //         [Test]
        //         public void Debug()
        //         {
        //             Log.Debug("Debug");
        //         }
        //
        //         [Test]
        //         public void Warning()
        //         {
        //             using (new LogEnableScope(false))
        //             {
        //                 Assert.DoesNotThrow(() => Log.Warning("Warning"));
        //             }
        //         }
        //
        //         [Test]
        //         public void Warning2()
        //         {
        //             bool result;
        //
        //             using (var scope = new CatchLog())
        //             {
        //                 Log.Warning("Warning2");
        //
        //                 result = scope.Received;
        //             }
        //
        //             Assert.True(result);
        //         }
        //
        //         [Test]
        //         public void Error()
        //         {
        //             using (new LogEnableScope(false))
        //             {
        //                 Assert.DoesNotThrow(() => Log.Error("Error"));
        //             }
        //         }
        //
        //         [Test]
        //         public void Exception()
        //         {
        //             using (new LogEnableScope(false))
        //             {
        //                 Assert.DoesNotThrow(() => Log.Exception(new Exception()));
        //             }
        //         }
    }
}
