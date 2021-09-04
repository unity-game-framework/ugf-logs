using System;

namespace UGF.Logs.Runtime
{
    public abstract class LogBase : ILog
    {
        public void Message(string tag, object value)
        {
            if (string.IsNullOrEmpty(tag)) throw new ArgumentException("Value cannot be null or empty.", nameof(tag));
            if (value == null) throw new ArgumentNullException(nameof(value));

            OnMessage(tag, value);
        }

        protected abstract void OnMessage(string tag, object value);
    }
}
