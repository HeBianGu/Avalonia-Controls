﻿

namespace Avalonia.Ioc
{
    public interface IMailService
    {
        bool Send(MailMessageItem messageItem, bool isBodyHtml, out string message);
    }
}