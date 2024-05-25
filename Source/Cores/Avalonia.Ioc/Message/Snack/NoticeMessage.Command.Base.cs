﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace Avalonia.Ioc
{
    public abstract class ShowSnackMessageCommandBase : IocMarkupCommandBase
    {
        public string Message { get; set; } = "默认消息";

        public override void Execute(object parameter)
        {
            Ioc<ISnackMessageService>.Instance.ShowInfo(this.Message);
        }
    }
}
