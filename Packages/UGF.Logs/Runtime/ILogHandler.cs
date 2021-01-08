namespace UGF.Logs.Runtime
{
    public interface ILogHandler
    {
        void Write(string tag, object value);
    }
}
