namespace UGF.Logs.Runtime
{
    public static partial class Log
    {
        static Log()
        {
            m_logger = new LogHandled(new LogHandlerUnity());
        }
    }
}
