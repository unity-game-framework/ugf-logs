using System;

namespace UGF.Logs.Runtime
{
    public class Log2 : ILog
    {
        public ILogHandler Handler { get; }

        protected Log2(ILogHandler handler)
        {
            Handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public void Info(object message)
        {
            Message(LogTags.INFO, message);
        }

        public void Debug(object message)
        {
            Message(LogTags.DEBUG, message);
        }

        public void Warning(object message)
        {
            Message(LogTags.WARNING, message);
        }

        public void Error(object message)
        {
            Message(LogTags.ERROR, message);
        }

        public void Message(string tag, object message)
        {
            if (string.IsNullOrEmpty(tag)) throw new ArgumentException("Value cannot be null or empty.", nameof(tag));
            if (message == null) throw new ArgumentNullException(nameof(message));

            OnMessage(tag, message);
        }

        protected virtual void OnMessage(string tag, object message)
        {
            if (message is ILogMessage logMessage)
            {
                message = logMessage.GetMessage();
            }

            Handler.Write(tag, message);
        }
    }
}
