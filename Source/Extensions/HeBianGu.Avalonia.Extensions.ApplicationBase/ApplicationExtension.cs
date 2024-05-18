using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using System;
using Avalonia;
using Avalonia.Threading;

namespace HeBianGu.Avalonia.Extensions.ApplicationBase
{
    public static class ApplicationExtension
    {
        public static Window GetMainWindow(this Application application)
        {
            if (application?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                return desktop.MainWindow;
            return null;
        }

        public static void ShutDown(this Application application, int exitCode)
        {
            if (application.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                desktop.Shutdown(exitCode);
        }

        public static void Invoke(this Application application, Action action)
        {
            Dispatcher.UIThread.Invoke(action);
        }
    }
}