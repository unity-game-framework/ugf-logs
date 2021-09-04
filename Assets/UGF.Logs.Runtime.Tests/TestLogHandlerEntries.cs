using NUnit.Framework;

namespace UGF.Logs.Runtime.Tests
{
    public class TestLogHandlerEntries
    {
        [Test]
        public void Format()
        {
            var log = new LogHandled<LogHandlerEntries>(new LogHandlerEntries());

            log.Info("Message 0", new { test = "Test" });
            log.Warning("Message 1", new { test = "Test" });
            log.Error("Message 2", new { test = "Test" });

            string result = LogUtility.Format(log.Handler.Entries);

            Assert.Pass(result);
        }
    }
}
