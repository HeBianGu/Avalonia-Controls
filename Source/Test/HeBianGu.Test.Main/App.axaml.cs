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
using System.Xml;
using Avalonia.Markup.Xaml.Templates;
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Modules.Identity;
using HeBianGu.AvaloniaUI.DataBase.Share;
using HeBianGu.AvaloniaUI.Modules.Operation;
using HeBianGu.AvaloniaUI.Theme;
using Avalonia.Controls.Templates;
using HeBianGu.AvaloniaUI.Step;
using ReactiveUI;

namespace HeBianGu.Test.Main;

public partial class App : ApplicationBase
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override void LoadAxamls(IApplicationAxamlLoader loader)
    {
        base.LoadAxamls(loader);
        loader.UseStylesExtension();
        loader.UseMainWindowBase();
        //loader.UseAbout();
        //loader.UseTheme();
        loader.UseForm();
        //loader.UseDataTest();
        loader.UseMultiComboBox();
        loader.UseStep();
    }

    protected override void OnCatchException()
    {
        base.OnCatchException();
        //RxApp.DefaultExceptionHandler.
    }


    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddSingleton<IMyIoc, MyIoc>();
        services.AddSplashScreen();
        services.AddLoginWindow().AddLoginViewPresenter(x => x.Product = "登陆页面").AddTestLoginService();
        services.AddAdornerDialogMessage();
        services.AddFormMessageService();
        services.AddWindowMessage();
        services.AddNoticeMessage();
        services.AddSnackMessage();
        services.AddAbout();

        //  Do ：操作日志
        services.AddDbContextBySetting<OperationDataContext>();
        services.AddSingleton<IStringRepository<hi_dd_operation>, DbContextRepository<OperationDataContext, hi_dd_operation>>();
        services.AddOperationViewPresenter();

        //  Do ：身份认证
        services.AddDbContextBySetting<IdentifyDataContext>();
        services.AddSingleton<IStringRepository<hi_dd_user>, DbContextRepository<IdentifyDataContext, hi_dd_user>>();
        services.AddUserViewPresenter();

        services.AddSingleton<IStringRepository<hi_dd_role>, DbContextRepository<IdentifyDataContext, hi_dd_role>>();
        services.AddRoleViewPresenter();

        services.AddSingleton<IStringRepository<hi_dd_author>, DbContextRepository<IdentifyDataContext, hi_dd_author>>();
        services.AddAuthorityViewPresenter();
    }

    protected override void Configure(IApplicationBuilder app)
    {
        base.Configure(app);
        app.UseSettingDefault();
        app.UseSetting(x => x.Add(SystemThemeSetting.Instance));
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


