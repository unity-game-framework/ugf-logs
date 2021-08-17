namespace UGF.Logs.Runtime
{
    public class LogUnity : Log2
    {
        public LogUnity() : this(new LogHandlerUnity())
        {
        }

        public LogUnity(ILogHandler handler) : base(handler)
        {
        }

        protected override void OnMessage(string tag, object message)
        {
        }
    }
}
