using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Windows.Dialog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Avalonia.Modules.SplashScreen
{
    public partial class SplashScreenWindow : DialogWindow, ISplashScreenWindow
    {
        private readonly ISplashScreenViewPresenter _presenter;
        public SplashScreenWindow()
        {
            InitializeComponent();
            //this.btn_success.Click += this.Btn_success_Click;
            _presenter = Ioc.GetService<ISplashScreenViewPresenter>();
            this.Content = _presenter;
            this.Loaded += this.SplashScreenWindow_Loaded;
        }

        private async void SplashScreenWindow_Loaded(object? sender, RoutedEventArgs e)
        {
            int sleep = 3000;
            Func<IDialog, ISplashScreenViewPresenter, bool?> func = (c, s) =>
            {
                if (c?.IsCancel != true)
                {
                    if (s != null)
                        s.Message = "���ڼ�����������...";
                    //  Do ���������ò���
                    bool r = SettingDataManager.Instance.Load(x =>
                    {
                        if (s != null)
                            s.Message = $"���ڼ�������<{x.Name}>����...";
                    }, out string message);
                    if (r == false)
                        s.Message = message;
                    Thread.Sleep(sleep);
                }

                {
                    int index = 0;
                    var loads = Ioc.GetAssignableFromServices<ISplashLoad>().Distinct();
                    foreach (ISplashLoad load in loads)
                    {
                        if (c?.IsCancel == true)
                            return null;

                        if (load == null)
                            continue;
                        index++;
                        if (s != null)
                            s.Message = $"[{index}/{loads.Count()}]���ڼ���{load.Name}...";
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
                    s.Message = "�������";
                Thread.Sleep(sleep);
                return true;
            };

            bool? fr = await Task.Run(() =>
            {
                return func.Invoke(this, _presenter);
            });
            if (fr == true)
            {
                this.OnSuccessed();
            }
            else if (fr == false)
            {
                _presenter.Message = "��ʼ�������쳣���뿴��־";
                Thread.Sleep(5000);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void Btn_success_Click(object? sender, RoutedEventArgs e)
        {
            this.OnSuccessed();
        }

        public Window GetWindow()
        {
            return this;
        }

        protected void OnSuccessed()
        {
            RoutedEventArgs args = new RoutedEventArgs(SuccessedEvent, this);
            this.RaiseEvent(args);
        }

        public event EventHandler<RoutedEventArgs> Successed
        {
            add { this.AddHandler(SuccessedEvent, value); }
            remove { this.RemoveHandler(SuccessedEvent, value); }
        }

        public static readonly RoutedEvent<RoutedEventArgs> SuccessedEvent =
            RoutedEvent.Register<RoutedEventArgs>(
                "Successed", RoutingStrategies.Bubble, typeof(SplashScreenWindow));

    }
}
