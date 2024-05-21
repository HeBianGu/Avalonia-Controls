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
using Avalonia.Markup.Xaml.Templates;
using System.Reflection;
using System.Linq;
using Avalonia.Styling;

namespace HeBianGu.Avalonia.Extensions.ApplicationBase
{

    public abstract class ApplicationAxamlLoaderAttribute : Attribute
    {
        public abstract string FolderName { get; set; }
    }

    [System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class ApplicationDataTemplateLoaderAttribute : ApplicationAxamlLoaderAttribute
    {
        public override string FolderName { get; set; } = "DataTemplates";
    }

    [System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class ApplicationStylesLoaderAttribute : ApplicationAxamlLoaderAttribute
    {
        public override string FolderName { get; set; } = "Styles";
    }

    [System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class ApplicationResourceLoaderAttribute : ApplicationAxamlLoaderAttribute
    {
        public override string FolderName { get; set; } = "Resources";
    }

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

        public override void Initialize()
        {
            this.LoadDataTemplates();
            this.LoadResources();
            this.LoadStyles();
        }

        protected virtual void LoadStyles()
        {
            this.LoadAxamls<ApplicationStylesLoaderAttribute>(x =>
            {
                if (x is Styles styles)
                    this.Styles.Add(styles);
            });
        }
        protected virtual void LoadResources()
        {
            this.LoadAxamls<ApplicationResourceLoaderAttribute>(x =>
            {
                if (x is ResourceDictionary resource)
                    this.Resources.MergedDictionaries.Add(resource);
            });
        }

        protected virtual void LoadDataTemplates()
        {
            this.LoadAxamls<ApplicationDataTemplateLoaderAttribute>(x =>
            {
                if (x is DataTemplate dataTemplate)
                    this.DataTemplates.Add(dataTemplate);
            });
        }

        private void LoadAxamls<T>(Action<object> action) where T : ApplicationAxamlLoaderAttribute
        {
            //var all = AppDomain.CurrentDomain.GetAssemblies().Where(x=>x.FullName.Contains("HeBianGu.Controls"));

            var all = AppDomain.CurrentDomain.GetAssemblies();
            var ass = all.Where(x => x.GetCustomAttribute<T>() != null).ToList();
            foreach (var assembly in ass)
            {
                var attribute = assembly.GetCustomAttribute<T>();
                var ts = assembly.ExportedTypes.Where(x => x.Name.Contains($"/{attribute.FolderName}/") && x.Name.EndsWith(".axaml"));
                string assName = assembly.GetName().Name;
                foreach (var t in ts)
                {
                    string uri = t.Name.Replace("NamespaceInfo:", $"avares://{assName}");
                    var s = AvaloniaXamlLoader.Load(new Uri(uri));
                    action?.Invoke(s);
                  
                }
            }

            //var s = AvaloniaXamlLoader.Load(new Uri("avares://HeBianGu.Test.Main/DDD.axaml"));
            //if (s is DataTemplate dataTemplate)
            //    this.DataTemplates.Add(dataTemplate);
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
                mainWindow.Content = this.GetMainView();

                var splash = Ioc.Services.GetService<ISplashScreenWindow>();
                void ShowLogin()
                {
                    var login = Ioc.Services.GetService<ILoginWindow>();
                    if (login == null)
                    {
                        desktop.MainWindow = mainWindow;
                    }
                    else
                    {
                        Window loginWindow = login.GetWindow();
                        desktop.MainWindow = loginWindow;
                        login.Logined += (l, k) =>
                        {
                            desktop.MainWindow = mainWindow;
                            mainWindow.Show();
                            loginWindow.Close();
                        };
                        if (splash != null)
                            loginWindow.Show();
                    }
                }

                if (splash != null)
                {
                    Window w = splash.GetWindow();
                    desktop.MainWindow = w;
                    splash.Successed += (l, k) =>
                    {
                        ShowLogin();
                        w.Close();
                    };
                }
                else
                {
                    ShowLogin();
                }
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = this.GetMainView();
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void W_Closed(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected abstract Window GetMainWindow();
        protected abstract Control GetMainView();

    }
}