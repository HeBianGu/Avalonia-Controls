﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface ISystemNotifyMessage
    {
        void Show(string message, string title = null, NotifyBalloonIcon tipIcon = NotifyBalloonIcon.Info, int timeout = 1000);
    }
}
