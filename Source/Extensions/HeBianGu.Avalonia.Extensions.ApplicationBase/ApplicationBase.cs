using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Avalonia;
using HeBianGu.Avalonia.Core.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace HeBianGu.Avalonia.Extensions.ApplicationBase
{
    public class ApplicationBuilder : IApplicationBuilder
    {

    }
    public abstract partial class ApplicationBase : Application
    {
        public ApplicationBase()
        {
            ServiceCollection sc = new ServiceCollection();
            this.ConfigureServices(sc);
            Ioc.Build(sc);

            ApplicationBuilder bulder = new ApplicationBuilder();
            this.Configure(bulder);
        }
        /// <summary>
        /// 依赖注入注册服务
        /// </summary>
        /// <param name="services"></param>
        protected virtual void ConfigureServices(IServiceCollection services)
        {

        }

        protected virtual void Configure(IApplicationBuilder app)
        {

        }
        public override void RegisterServices()
        {
            base.RegisterServices();
        }


        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Window mainWindow = this.GetMainWindow();
                var service = Ioc.Services.GetService<ILoginWindow>();
                if (service == null)
                {
                    desktop.MainWindow = mainWindow;
                }
                else
                {
                    Window loginWindow = service.GetWindow();
                    desktop.MainWindow = loginWindow;
                    service.Logined += (l, k) =>
                    {
                        desktop.MainWindow = mainWindow;
                        mainWindow.Show();
                        loginWindow.Close();
                    };
                }
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = this.GetMainView();
            }

            base.OnFrameworkInitializationCompleted();
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        protected abstract Window GetMainWindow();
        protected abstract Control GetMainView();

    }
}