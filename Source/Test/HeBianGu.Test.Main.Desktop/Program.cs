using System;

using Avalonia;
using Avalonia.ReactiveUI;
using HeBianGu.AvaloniaUI.Ioc;

namespace HeBianGu.Test.Main.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        //try
        //{
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        //}
        //catch (Exception ex)
        //{
        //    IocLog.Instance?.Error(ex);
        //    throw ex;
        //    //IocMessage.Window.Show(ex.Message);
           
        //}
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}
