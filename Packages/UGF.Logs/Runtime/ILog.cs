namespace UGF.Logs.Runtime
{
    public interface ILog
    {
        void Message(string tag, object value);
    }
}
