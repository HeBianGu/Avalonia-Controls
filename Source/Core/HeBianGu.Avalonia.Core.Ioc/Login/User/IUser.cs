// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IUser
    {
        string ID { get; }
        string Account { get; set; }
        string Password { get; set; }
        string Name { get; set; }
        bool IsValid(string authorId);
    }
}