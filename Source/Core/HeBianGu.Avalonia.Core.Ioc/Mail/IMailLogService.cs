namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IMailLogService
    {
        bool Send(string subject, string body, out string message);
    }
}