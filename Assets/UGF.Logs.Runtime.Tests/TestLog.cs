using System;
using NUnit.Framework;

namespace UGF.Logs.Runtime.Tests
{
    public class TestLog
    {
        [Test]
        public void Info()
        {
            using (new LogScope(false))
            {
                Assert.DoesNotThrow(() => Log.Info("Info"));
            }
        }

        [Test]
        public void InfoTag()
        {
            using (new LogScope(false))
            {
                Assert.DoesNotThrow(() => Log.Info("Tag", "Info"));
            }
        }

        [Test]
        public void Warning()
        {
            using (new LogScope(false))
            {
                Assert.DoesNotThrow(() => Log.Warning("Warning"));
            }
        }

        [Test]
        public void Error()
        {
            using (new LogScope(false))
            {
                Assert.DoesNotThrow(() => Log.Error("Error"));
            }
        }

        [Test]
        public void Exception()
        {
            using (new LogScope(false))
            {
                Assert.DoesNotThrow(() => Log.Exception(new Exception()));
            }
        }
    }
}
