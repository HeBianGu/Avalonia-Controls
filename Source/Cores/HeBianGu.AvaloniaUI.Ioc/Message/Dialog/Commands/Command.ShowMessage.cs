// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace HeBianGu.AvaloniaUI.Ioc
{
    public class ShowMessageCommand : MessageCommandBase
    {
        public string Message { get; set; } = "我是消息";
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
