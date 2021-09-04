namespace UGF.Logs.Runtime
{
    public class LogHandled<THandler> : LogHandled where THandler : class, ILogHandler
    {
        public new THandler Handler { get { return (THandler)base.Handler; } }

        public LogHandled(THandler handler) : base(handler)
        {
        }
    }
}
