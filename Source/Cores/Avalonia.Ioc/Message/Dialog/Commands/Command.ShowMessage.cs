﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace Avalonia.Ioc
{
    public class ShowMessageCommand : MessageCommandBase
    {
        public string Message { get; set; }
        public override void Execute(object parameter)
        {
            IocMessage.Dialog.Show(Message, x =>
            {
                x.DialogButton = this.DialogButton;
                x.Title = this.Title;
            });
        }
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(Message);
        }
    }
}