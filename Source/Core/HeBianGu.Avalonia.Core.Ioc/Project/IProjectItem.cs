﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface IProjectItem : ISaveable, ILoadable
    {
        DateTime UpdateTime { get; set; }
        bool IsFixed { get; set; }
        string Title { get; set; }
        string Path { get; set; }
        bool Close(out string message);
        bool Delete(out string message);
    }
}