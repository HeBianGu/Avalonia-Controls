// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Ioc;
using System.Windows;

namespace Avalonia.Extensions.Command
{
    public class SumitWindowCommand : WindowCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is IDialog window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }
    }
}
