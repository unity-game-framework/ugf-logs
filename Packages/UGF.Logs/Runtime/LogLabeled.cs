using System;

namespace UGF.Logs.Runtime
{
    public class LogLabeled : ILog
    {
        public ILog Log { get; }
        public string Label { get; }
        public string MessageFormat { get; }

        public LogLabeled(ILog log, string label, string messageFormat = "{0}: {1}")
        {
            if (string.IsNullOrEmpty(label)) throw new ArgumentException("Value cannot be null or empty.", nameof(label));
            if (string.IsNullOrEmpty(messageFormat)) throw new ArgumentException("Value cannot be null or empty.", nameof(messageFormat));

            Log = log ?? throw new ArgumentNullException(nameof(log));
            Label = label;
            MessageFormat = messageFormat;
        }

        public void Message(string tag, object value)
        {
            Log.Message(tag, string.Format(MessageFormat, Label, value));
        }
    }
}
