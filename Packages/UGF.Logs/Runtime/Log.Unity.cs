namespace UGF.Logs.Runtime
{
    public static partial class Log
    {
        static Log()
        {
            Handler = new LogHandlerUnity(UnityEngine.Debug.unityLogger);
        }
    }
}
