// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using HeBianGu.Avalonia.Core.Ioc;

namespace HeBianGu.Avalonia.Extensions.Command
{
    public class CancelWindowCommand : WindowCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is IDialog window)
            {
                window.DialogResult = false;
                window.Close();
            }
        }
    }
}
