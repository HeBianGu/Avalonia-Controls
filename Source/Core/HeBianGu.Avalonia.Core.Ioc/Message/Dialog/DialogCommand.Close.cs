// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

namespace HeBianGu.Avalonia.Core.Ioc
{
    public class CloseDialogCommand : DialogCommandBase
    {
        public override void Execute(object parameter)
        {
            IDialog dialog = this.GetDialog(parameter);
            dialog.Close();
        }
    }
}
