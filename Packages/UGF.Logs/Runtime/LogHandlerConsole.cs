using System;

namespace UGF.Logs.Runtime
{
    public class LogHandlerConsole : LogHandlerBase
    {
        protected override void OnWrite(string tag, object value)
        {
            Console.WriteLine($"{tag}: {value}");
        }
    }
}
