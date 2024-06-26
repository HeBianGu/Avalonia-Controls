﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using HeBianGu.AvaloniaUI.Ioc;
using System;

namespace HeBianGu.AvaloniaUI.Modules.Login
{
    internal class RegisterService : IRegisterService
    {
        public bool Register(string mail, string account, string password, out string message)
        {
            message = string.Empty;
            return true;
        }

        public bool ResetPassword(string mail, string account, string password, out string message)
        {
            message = string.Empty;
            return true;
        }
    }
}
