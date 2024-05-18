﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace HeBianGu.Avalonia.Extensions.Setting
{
    public abstract class IocSettableInstance<Setting, Interface> : SettableBase where Setting : class, Interface, new()
    {
        public static Setting Instance => (Setting)Ioc.GetService<Interface>();
    }
}
