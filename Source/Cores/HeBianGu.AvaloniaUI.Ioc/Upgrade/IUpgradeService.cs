﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface IUpgradeService
    {
        bool CanUpgrade(out string message);
        bool Upgrade(out string message);
        string UpgradeVersion { get; }
    }
}