// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using System.Windows;

namespace HeBianGu.AvaloniaUI.Command
{
    public class MaximizeWindowCommand : WindowCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Window window)
            {
                window.WindowState = WindowState.Maximized;
            }
        }
    }
}
