using System;

namespace UGF.Logs.Runtime
{
    public readonly struct LogEntry
    {
        public TimeSpan Time { get; }
        public string Tag { get; }
        public object Value { get; }
        public string StackTrace { get { return HasStackTrace ? m_stackTrace : throw new ArgumentException("Value not specified."); } }
        public bool HasStackTrace { get { return !string.IsNullOrEmpty(m_stackTrace); } }

        private readonly string m_stackTrace;

        public LogEntry(TimeSpan time, string tag, object value, string stackTrace = "")
        {
            if (string.IsNullOrEmpty(tag)) throw new ArgumentException("Value cannot be null or empty.", nameof(tag));

            Time = time;
            Tag = tag;
            Value = value ?? throw new ArgumentNullException(nameof(value));
            m_stackTrace = stackTrace ?? string.Empty;
        }
    }
}
