namespace UGF.Logs.Runtime
{
    public interface ILog
    {
        ILogHandler Handler { get; }

        void Info(object message);
        void Debug(object message);
        void Warning(object message);
        void Error(object message);
        void Message(string tag, object message);
    }
}
