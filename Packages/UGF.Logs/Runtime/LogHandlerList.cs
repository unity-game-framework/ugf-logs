using System;
using System.Collections.Generic;

namespace UGF.Logs.Runtime
{
    public class LogHandlerList : LogHandlerBase
    {
        public List<LogEntry> Entries { get; } = new List<LogEntry>();

        public readonly struct LogEntry
        {
            public TimeSpan Time { get; }
            public string Tag { get; }
            public object Message { get; }

            public LogEntry(TimeSpan time, string tag, object message)
            {
                if (string.IsNullOrEmpty(tag)) throw new ArgumentException("Value cannot be null or empty.", nameof(tag));

                Time = time;
                Tag = tag;
                Message = message ?? throw new ArgumentNullException(nameof(message));
            }
        }

        protected override void OnWrite(string tag, object value)
        {
            var entry = new LogEntry(DateTime.Now.TimeOfDay, tag, value);

            Entries.Add(entry);
        }
    }
}
