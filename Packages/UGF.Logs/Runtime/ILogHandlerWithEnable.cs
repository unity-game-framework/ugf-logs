namespace UGF.Logs.Runtime
{
    public interface ILogHandlerWithEnable : ILogHandler
    {
        bool IsEnabled { get; set; }
    }
}
