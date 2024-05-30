using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using Avalonia.VisualTree;
using System;
using System.Linq;

namespace HeBianGu.AvaloniaUI.Application
{
    public static class ApplicationExtension
    {
        public static Window GetMainWindow(this Avalonia.Application application)
        {
            if (application?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                return desktop.MainWindow;
            return null;
        }

        public static Visual GetMainAdornerControl(this Avalonia.Application application)
        {
            if (application?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                return Dispatcher.UIThread.Invoke(() => desktop.MainWindow.Content as Visual);

            if (application?.ApplicationLifetime is ISingleViewApplicationLifetime singleView)
                return Dispatcher.UIThread.Invoke(() => singleView.MainView);
            return null;
        }

        public static void ShutDown(this Avalonia.Application application, int exitCode)
        {
            if (application.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                desktop.Shutdown(exitCode);
        }

        public static void Invoke(this Avalonia.Application application, Action action)
        {
            Dispatcher.UIThread.Invoke(action);
        }

        public static void BeginInvoke(this Avalonia.Application application, DispatcherPriority dispatcherPriority, Action action)
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