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

namespace HeBianGu.Test.Main;

public partial class App : ApplicationBase
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            //desktop.MainWindow = new MainWindow
            //{
            //    DataContext = new MainViewModel()
            //};
            ////desktop.MainWindow.Show();
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            LoginWindow loginWindow = new LoginWindow();
            desktop.MainWindow = loginWindow;
            loginWindow.Logined += () =>
            {
                desktop.MainWindow = mainWindow;
                mainWindow.Show();
                loginWindow.Close();
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);
        services.AddSingleton<IMyIoc, MyIoc>();
    }


}

public interface IMyIoc
{

}

public class MyIoc : IMyIoc
{

}

public partial class ApplicationBase : Application
{
    public ApplicationBase()
    {
        ServiceCollection sc = new ServiceCollection();
        this.ConfigureServices(sc);
        Ioc.Build(sc);
    }
    /// <summary>
    /// 依赖注入注册服务
    /// </summary>
    /// <param name="services"></param>
    protected virtual void ConfigureServices(IServiceCollection services)
    {

    }
    public override void RegisterServices()
    {
        base.RegisterServices();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        base.OnFrameworkInitializationCompleted();
    }
    public override void Initialize()
    {
        base.Initialize();
    }
}

public static class Ioc
{
    private static IServiceProvider _services = null;
    public static IServiceProvider Services => _services;
    private static IServiceCollection _serviceCollection = null;
    public static void Build(IServiceCollection serviceCollection)
    {
        _services = serviceCollection.BuildServiceProvider();
        _serviceCollection = serviceCollection;
    }

    public static T GetService<T>(bool throwIfNone = true)
    {
        if (_services == null)
        {
            if (throwIfNone)
                throw new ArgumentNullException($"请先注册使用ApplicationBase注册<IServiceCollection>接口");
            else
                return default(T);
        }
        T r = (T)_services.GetService(typeof(T));
        if (r == null && throwIfNone)
        {
            System.Diagnostics.Debug.WriteLine(typeof(T));
            throw new ArgumentNullException($"请先注册<{typeof(T)}>接口");
        }
        return r;
    }

    public static T GetService<T>(Type type, bool throwIfNone = true)
    {
        T r = (T)_services.GetService(type);
        if (r == null && throwIfNone)
        {
            System.Diagnostics.Debug.WriteLine(type);
            throw new ArgumentNullException($"请先注册<{type}>接口");
        }
        return r;
    }

    public static bool Exist<T>()
    {
        return GetService<T>(throwIfNone: false) != null;
    }

    public static void ConfigureServices(Action<IServiceCollection> action)
    {
        if (_serviceCollection == null)
            return;
        action?.Invoke(_serviceCollection);
        //Build(_serviceCollection);
    }

    public static IEnumerable<ServiceDescriptor> FindAll(Func<ServiceDescriptor, bool> predicate = null)
    {
        foreach (ServiceDescriptor item in _serviceCollection)
        {
            if (predicate?.Invoke(item) != false)
                yield return item;
        }
    }

    //public static void BuildAll()
    //{
    //    foreach (ServiceDescriptor item in _serviceCollection)
    //    {
    //       Ioc.Services.GetService(item.ServiceType);
    //    }
    //}

    public static IEnumerable<T> GetAssignableFromServices<T>(Func<T, bool> predicate = null)
    {
        foreach (ServiceDescriptor item in _serviceCollection)
        {
            if (typeof(T).IsAssignableFrom(item.ServiceType))
            {
                if (item.ImplementationInstance == null)
                {
                    var instances = Ioc.Services.GetServices(item.ServiceType);
                    foreach (var instance in instances)
                    {
                        if (instance is T it)
                        {
                            if (predicate?.Invoke(it) != false)
                                yield return it;
                        }
                    }

                }
                else
                {
                    if (item.ImplementationInstance is T t)
                    {
                        if (predicate?.Invoke(t) != false)
                            yield return (T)item.ImplementationInstance;
                    }
                }
            }
        }
    }

    //public static IEnumerable<T> GetImplementationInstances<T>(Func<T, bool> predicate = null)
    //{
    //    foreach (ServiceDescriptor item in _serviceCollection)
    //    {
    //        if (item.ImplementationInstance is T t)
    //        {
    //            if (predicate?.Invoke(t) != false)
    //                yield return (T)item.ImplementationInstance;
    //        }
    //    }
    //}
}
