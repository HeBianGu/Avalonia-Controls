// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace Avalonia.Ioc
{
    public class ShowInfoNoticeMessageCommand : ShowNoticeMessageCommandBase
    {
        public override void Execute(object parameter)
        {
            Ioc<INoticeMessageService>.Instance.ShowInfo(this.Message);
        }
    }
}
