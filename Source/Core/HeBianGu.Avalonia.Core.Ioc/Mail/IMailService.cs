

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IMailService
    {
        bool Send(MailMessageItem messageItem, bool isBodyHtml, out string message);
    }
}