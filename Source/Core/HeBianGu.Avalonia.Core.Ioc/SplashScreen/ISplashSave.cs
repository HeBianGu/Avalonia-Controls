﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace HeBianGu.Avalonia.Core.Ioc
{
    /// <summary>
    /// 项目关闭会预保存的接口
    /// </summary>
    public interface ISplashSave : ISaveable
    {
        string Name { get; }
    }
}