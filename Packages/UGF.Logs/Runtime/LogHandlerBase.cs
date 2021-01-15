using System;

namespace UGF.Logs.Runtime
{
    public abstract class LogHandlerBase : ILogHandler
    {
        public void Write(string tag, object value)
        {
            if (string.IsNullOrEmpty(tag)) throw new ArgumentException("Value cannot be null or empty.", nameof(tag));
            if (value == null) throw new ArgumentNullException(nameof(value));

            OnWrite(tag, value);
        }

        protected abstract void OnWrite(string tag, object value);
    }
}
