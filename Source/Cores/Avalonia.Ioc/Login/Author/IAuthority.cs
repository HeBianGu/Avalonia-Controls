﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace Avalonia.Ioc
{
    public interface IAuthority
    {
        string ID { get; }
        string Name { get; }
        string GroupName { get; }
        bool IsAuthority { get; }
    }
}