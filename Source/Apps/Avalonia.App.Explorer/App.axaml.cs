using Avalonia;
using Avalonia.App.Explorer.ViewModels;
using Avalonia.App.Explorer.Views;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using HeBianGu.AvaloniaUI.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Theme;

namespace Avalonia.App.Explorer;

public partial class App : ApplicationBase
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override void LoadAxamls(IApplicationAxamlLoader loader)
    {
        base.LoadAxamls(loader);
        loader.UseMainWindowBase();
        loader.UseStylesExtension();
        //loader.UseAbout();
        loader.UseTheme();
        //loader.UseForm();
        //loader.UseDataTest();
        loader.UseStyles();
    }


    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddAdornerDialogMessage();
        //services.AddFormMessageService();
        //services.AddNoticeMessage();
        //services.AddSnackMessage();
        //services.AddAbout();
    }

    protected override void Configure(IApplicationBuilder app)
    {
        base.Configure(app);
        //app.UseSettingDefault();
        //app.UseSetting(x => x.Add(SystemThemeSetting.Instance));
        //app.UseMainWindow(x => x.VisualTransitionable = new TranslateXTransitionable() { From = -500, To = 500 });

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
    }
}
