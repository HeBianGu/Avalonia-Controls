using Avalonia.Controls;
using Avalonia.DataBases.Share;
using Avalonia.Markup.Xaml;
using Avalonia.Test.Sqlite.ViewModels;
using Avalonia.Test.Sqlite.Views;
using Avalonia.Ioc;
using Avalonia.Extensions.Application;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Avalonia.Test.Sqlite;

public partial class App : ApplicationBase
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        //services.AddSetting();
        services.AddDbContextBySetting<MyDataContext>();
        services.AddSingleton<IStringRepository<mbc_dv_image>, DbContextRepository<MyDataContext, mbc_dv_image>>();
        //services.AddLogging(configure =>
        //{

        //});

        //services.AddMemoryCache(x =>
        //{
        //    x.TrackLinkedCacheEntries = true;
        //});
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

    public override void OnFrameworkInitializationCompleted()
    {
        base.OnFrameworkInitializationCompleted();

        var loads = System.Ioc.Services.GetServices<IDbConnectService>();
        foreach (var load in loads)
        {
            load.Load(out string error);
        }
    }
}
