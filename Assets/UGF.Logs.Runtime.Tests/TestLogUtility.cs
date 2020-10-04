using NUnit.Framework;

namespace UGF.Logs.Runtime.Tests
{
    public class TestLogUtility
    {
        [Test]
        public void Format()
        {
            string result = LogUtility.Format("Message", new { a = "A", b = 10 });

            Assert.AreEqual("Message: a:'A', b:'10'.", result);
        }
    }
}
