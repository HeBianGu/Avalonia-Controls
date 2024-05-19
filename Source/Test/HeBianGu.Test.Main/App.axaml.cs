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
using HeBianGu.Avalonia.Modules.Login;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Extensions.ApplicationBase;
using HeBianGu.Avalonia.Windows.Dialog;
using Avalonia.Modules.Messages.Dialog;

namespace HeBianGu.Test.Main;

public partial class App : ApplicationBase
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }


    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddSingleton<IMyIoc, MyIoc>();
        services.AddSingleton<ILoginWindow, LoginWindow>();
        services.AddSingleton<IDialogMessageService, AdornerDialogMessageService>();
        services.AddFormMessageService();
    }

    protected override void Configure(IApplicationBuilder app)
    {
        base.Configure(app);
        app.UseSettingDefault();
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

