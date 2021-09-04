using System;
using System.Collections.Generic;
using UnityEngine;

namespace UGF.Logs.Runtime
{
    public class LogHandlerEntries : LogHandlerBase
    {
        public List<LogEntry> Entries { get; } = new List<LogEntry>();
        public bool LogStackTrace { get; set; } = true;

        protected override void OnWrite(string tag, object value)
        {
            LogEntry entry;

            if (LogStackTrace)
            {
                string stackTrace = value is Exception
                    ? StackTraceUtility.ExtractStringFromException(value)
                    : StackTraceUtility.ExtractStackTrace();

                entry = new LogEntry(DateTime.Now.TimeOfDay, tag, value, stackTrace);
            }
            else
            {
                entry = new LogEntry(DateTime.Now.TimeOfDay, tag, value);
            }

            Entries.Add(entry);
        }
    }
}
