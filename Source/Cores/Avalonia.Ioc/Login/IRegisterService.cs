﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace Avalonia.Ioc
{
    public interface IRegisterService
    {
        bool Register(string mail, string account, string password, out string message);
        bool ResetPassword(string mail, string account, string password, out string message);
    }
}