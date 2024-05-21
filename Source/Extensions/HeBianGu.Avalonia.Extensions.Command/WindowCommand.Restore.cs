// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using System.Windows;

namespace HeBianGu.Avalonia.Extensions.Command
{
    public class RestoreWindowCommand : WindowCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Window window)
            {
                window.WindowState = WindowState.Normal;

            }
            //SystemCommands.RestoreWindow(window);
        }
    }

    public class FullScreenWindowCommand : WindowCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Window window)
            {
                window.WindowState = WindowState.FullScreen;

            }
            //SystemCommands.RestoreWindow(window);
        }
    }
}
