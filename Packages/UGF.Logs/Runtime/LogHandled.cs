using System;

namespace UGF.Logs.Runtime
{
    public class LogHandled : LogBase
    {
        public ILogHandler Handler { get; }

        public LogHandled(ILogHandler handler)
        {
            Handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        protected override void OnMessage(string tag, object value)
        {
            Handler.Write(tag, value);
        }
    }
}
