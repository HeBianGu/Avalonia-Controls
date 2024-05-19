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

        public static Control GetMainAdornerControl(this Application application)
        {
            if (application?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                return desktop.MainWindow.Content as Control;
            if (application?.ApplicationLifetime is ISingleViewApplicationLifetime singleView)
                return singleView.MainView;
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

        public static void BeginInvoke(this Application application, DispatcherPriority dispatcherPriority, Action action)
        {
            Dispatcher.UIThread.InvokeAsync(action, dispatcherPriority);
        }
    }

    public static class ControlExtension
    {
        public static void Invoke(this Control control, Action action)
        {
            Dispatcher.UIThread.Invoke(action);
        }

        public static void BeginInvoke(this Control control, DispatcherPriority dispatcherPriority, Action action)
        {
            Dispatcher.UIThread.InvokeAsync(action, dispatcherPriority);
        }
    }
}