using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Templates;
using Avalonia.Data.Converters;
using Avalonia.Logging;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Styling;
using Avalonia.Threading;
using HeBianGu.AvaloniaUI.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeBianGu.AvaloniaUI.Application
{
    public abstract partial class ApplicationBase : Avalonia.Application
    {
        public ApplicationBase()
        {
            ServiceCollection sc = new ServiceCollection();
            this.ConfigureServices(sc);
            System.Ioc.Build(sc);
            ApplicationBuilder bulder = new ApplicationBuilder();
            this.Configure(bulder);
            this.OnCreatePresenterLocator();
        }

        public void OnCreatePresenterLocator()
        {
            this.DataTemplates.Add(new PresenterViewLocator());
        }


        //        public override void Initialize()
        //        {
        //            var assemblies = this.GetAxamlLoaderAssemblies();

        //#if DEBUG
        //            foreach (var item in assemblies)
        //            {
        //                System.Diagnostics.Debug.WriteLine($"GetReferanceAssemblies:{item}");
        //            }
        //#endif
        //            this.LoadDataTemplates(assemblies);
        //            this.LoadResources(assemblies);
        //            this.LoadStyles(assemblies);
        //        }

        protected virtual void LoadStyles(List<Assembly> assemblies)
        {
            this.LoadAxamls<ApplicationStylesLoaderAttribute>(assemblies, x =>
            {
                var s = AvaloniaXamlLoader.Load(new Uri(x));
                if (s is Styles styles)
                    this.Styles.Add(styles);
                System.Diagnostics.Debug.WriteLine($"LoadStyles:{x}");
            });
        }

        protected virtual void LoadResources(List<Assembly> assemblies)
        {
            this.LoadAxamls<ApplicationResourceLoaderAttribute>(assemblies, x =>
            {
                ResourceInclude resourceInclude = new ResourceInclude(new Uri(x));
                resourceInclude.Source = new Uri(x);
                this.Resources.MergedDictionaries.Add(resourceInclude);
                System.Diagnostics.Debug.WriteLine($"LoadResources:{x}");
            });
        }

        protected virtual void OnCatchException()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                try
                {
                    Exception error = (Exception)e.ExceptionObject;
                    Dispatcher.UIThread.Invoke(() => IocMessage.Window.Show("当前应用程序遇到一些问题，该操作已经终止，请进行重试，如果问题继续存在，请联系管理员", x =>
                    {
                        x.Title = "意外的操作";
                    }));
                    IocLog.Instance?.Fatal("当前应用程序遇到一些问题，该操作已经终止，请进行重试，如果问题继续存在，请联系管理员", "意外的操作");
                    IocLog.Instance?.Fatal(error);
                }
                catch (Exception ex)
                {
                    IocLog.Instance?.Fatal(ex);
                }
            };
            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
            {
                System.Ioc.GetService<IOperationService>(false)?.Log<ApplicationBase>("程序退出");
                IocLog.Instance?.Error("程序退出");
            };
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                StringBuilder sb = new StringBuilder();
                foreach (Exception item in e.Exception.InnerExceptions)
                {
                    sb.AppendLine($@"异常类型：{item.GetType()}
异常内容：{item.Message}
来自：{item.Source}
{item.StackTrace}");
                }

                e.SetObserved();

                IocLog.Instance?.Error("Task Exception");
                IocLog.Instance?.Error(sb.ToString());
                Dispatcher.UIThread.Invoke(() =>
                {
                    IocMessage.Window.Show(sb.ToString(), x => x.Title = "系统任务异常");
                    //MessageProxy.Windower.ShowSumit(sb.ToString(), "系统任务异常", false, -1)

                });
            };

        }



        protected virtual List<Assembly> GetAxamlLoaderAssemblies()
        {
            List<Assembly> GetReferanceAssemblies(Func<Assembly, bool> mactch)
            {
                void GetReferanceAssemblies(Assembly assembly, List<Assembly> list)
                {
                    if (assembly.FullName.Contains("Main"))
                    {

                    }
                    var all = assembly.GetReferencedAssemblies();
                    foreach (AssemblyName item in all)
                    {
                        if (list.Any(x => x.FullName == item.FullName))
                            continue;
                        var ass = Assembly.Load(item);
                        if (!list.Contains(ass))
                        {
                            list.Add(ass);
                            GetReferanceAssemblies(ass, list);
                        }
                    }
                }

                var list = new List<Assembly>();
                var all = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetCustomAttribute<ApplicationStylesLoaderAttribute>() != null || x.GetCustomAttribute<ApplicationResourceLoaderAttribute>() != null || x == Assembly.GetEntryAssembly());
                foreach (var item in all)
                {
                    if (!list.Contains(item))
                        list.Add(item);
                    //GetReferanceAssemblies(item, list);
                }
                return list;
            }

            var all = GetReferanceAssemblies(x => x.GetCustomAttribute<ApplicationStylesLoaderAttribute>() != null || x.GetCustomAttribute<ApplicationResourceLoaderAttribute>() != null || x == Assembly.GetEntryAssembly());

            return all.Where(x =>
            x.GetCustomAttribute<ApplicationStylesLoaderAttribute>() != null ||
            x.GetCustomAttribute<ApplicationResourceLoaderAttribute>() != null).ToList();
        }

        private void LoadAxamls<T>(List<Assembly> assemblies, Action<string> action) where T : ApplicationAxamlLoaderAttribute
        {
            var all = assemblies.Where(x => x.GetCustomAttribute<T>() != null);
            foreach (var assembly in all)
            {
                var attribute = assembly.GetCustomAttribute<T>();
                var ts = assembly.ExportedTypes.Where(x => x.Name.Contains($"/{attribute.FolderName}/") && x.Name.EndsWith(".axaml"));
                string assName = assembly.GetName().Name;
                foreach (var t in ts)
                {
                    string uri = t.Name.Replace("NamespaceInfo:", $"avares://{assName}");
                    //var s = AvaloniaXamlLoader.Load(new Uri(uri));
                    action?.Invoke(uri);
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

        protected virtual void LoadAxamls(IApplicationAxamlLoader loader)
        {
            this.LoadAssemblies();
        }

        public override void RegisterServices()
        {
            base.RegisterServices();
        }


        private void LoadAssemblies()
        {
            var assemblies = this.GetAxamlLoaderAssemblies();

#if DEBUG
            foreach (var item in assemblies)
            {
                System.Diagnostics.Debug.WriteLine($"GetReferanceAssemblies:{item}");
            }
#endif
            //this.LoadDataTemplates(assemblies);
            this.LoadResources(assemblies);
            this.LoadStyles(assemblies);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            ApplicationAxamlLoader loader = new ApplicationAxamlLoader();
            this.LoadAxamls(loader);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                Window mainWindow = this.GetMainWindow();
                mainWindow.Content = this.GetMainView();

                Func<IDialog, ISplashScreenViewPresenter, bool?> func = (c, s) =>
                {
                    int sleep = c == null ? 1 : 1000;
                    if (c?.IsCancel != true)
                    {
                        if (s != null)
                            s.Message = "正在加载设置数据...";
                        //  Do ：加载设置参数
                        bool r = SettingDataManager.Instance.Load(x =>
                        {
                            if (s != null)
                                s.Message = $"正在加载设置<{x.Name}>数据...";
                        }, out string message);
                        if (r == false)
                            s.Message = message;
                        Thread.Sleep(sleep);
                    }

                    {
                        int index = 0;
                        var loads = System.Ioc.GetAssignableFromServices<ISplashLoad>().Distinct();
                        foreach (ISplashLoad load in loads)
                        {
                            if (c?.IsCancel == true)
                                return null;

                            if (load == null)
                                continue;
                            index++;
                            if (s != null)
                                s.Message = $"[{index}/{loads.Count()}]正在加载{load.Name}...";
                            bool r = load.Load(out string message);
                            if (s != null && !string.IsNullOrEmpty(message))
                                s.Message = message;
                            if (r == false)
                            {
                                Thread.Sleep(sleep);
                                return false;
                            }
                            Thread.Sleep(sleep);
                        }
                    }

                    if (s != null)
                        s.Message = "加载完成";
                    Thread.Sleep(sleep);
                    return true;
                };
                var splash = System.Ioc.Services.GetService<ISplashScreenWindow>();
                void ShowLogin()
                {
                    var login = System.Ioc.Services.GetService<ILoginWindow>();
                    if (login == null)
                    {
                        desktop.MainWindow = mainWindow;
                        if (splash != null)
                            mainWindow.Show();
                    }
                    else
                    {
                        Window loginWindow = login.GetWindow();
                        desktop.MainWindow = loginWindow;
                        login.Logined += async (l, k) =>
                        {
                            desktop.MainWindow = mainWindow;
                            mainWindow.Show();
                            if (loginWindow is IDialog dialog)
                                await dialog.Close();

                        };
                        if (splash != null)
                            loginWindow.Show();
                    }
                }

                if (splash != null)
                {
                    Window w = splash.GetWindow(func);
                    desktop.MainWindow = w;
                    splash.Successed += (l, k) =>
                    {
                        ShowLogin();
                        if(w is IDialog dialog)
                            dialog.Close();
                    };
                }
                else
                {
                    if (func?.Invoke(null, null) == false)
                        throw new ArgumentException("初始化数据异常，请看日志");
                    ShowLogin();
                }
                System.Ioc.GetService<IOperationService>(false)?.Log<ApplicationBase>(ApplicationProvider.Product, "系统启动");
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = this.GetMainView();
            }

            base.OnFrameworkInitializationCompleted();

            this.OnCatchException();
        }

        private void W_Closed(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected abstract Window GetMainWindow();
        protected abstract Control GetMainView();

    }

}