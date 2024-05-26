using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using HeBianGu.Test.Main.ViewModels;
using HeBianGu.Test.Main.Views;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using Avalonia.Modules.Login;
using Avalonia.Ioc;
using Avalonia.Extensions.Application;
using Avalonia.Windows.Dialog;
using Avalonia.Modules.Messages.Dialog;
//using MainWindow = Avalonia.Windows.Main.MainWindow;
using Avalonia.Modules.SplashScreen;
using System.Xml;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Theme;

namespace HeBianGu.Test.Main;

public partial class App : ApplicationBase
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        base.Initialize();
    }


    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddSingleton<IMyIoc, MyIoc>();
        //services.AddSingleton<ILoginWindow, LoginWindow>();
        //services.AddLoginViewPresenter();
        services.AddSingleton<IDialogMessageService, AdornerDialogMessageService>();
        services.AddFormMessageService();
        services.AddNoticeMessage();
        services.AddSnackMessage();
        //services.AddSplashScreen();
        services.AddTestLoginService();
    }

    protected override void Configure(IApplicationBuilder app)
    {
        base.Configure(app);
        app.UseSettingDefault();
        app.UseSetting(x => x.Add(SystemSetting.Instance));
        //app.UseStylesExtension();
    }


    protected override Control GetMainView()
    {
        return new MainView
        {
            DataContext = new MainViewModel()
        };
    }

    protected override Window GetMainWindow()
    {
        return new MainWindow
        {
            DataContext = new MainViewModel()
        };



        //return new DialogWindow() { Title = "sss", Content = "44444" };
    }
}

public interface IMyIoc
{

}

public class MyIoc : IMyIoc
{

}

