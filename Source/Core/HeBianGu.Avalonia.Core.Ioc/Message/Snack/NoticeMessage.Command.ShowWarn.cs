﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public class ShowWarnSnackMessageCommand : ShowSnackMessageCommandBase
    {
        public override void Execute(object parameter)
        {
            Ioc<ISnackMessageService>.Instance.ShowWarn(this.Message);
        }
    }
}
