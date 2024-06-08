using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform;
using HeBianGu.AvaloniaUI.DialogWindow;
using HeBianGu.AvaloniaUI.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Modules.SplashScreen
{
    public partial class SplashScreenWindow : HeBianGu.AvaloniaUI.DialogWindow.DialogWindow, ISplashScreenWindow
    {
        private readonly ISplashScreenViewPresenter _presenter;
        public SplashScreenWindow()
        {
            InitializeComponent();
            //this.btn_success.Click += this.Btn_success_Click;
            _presenter = System.Ioc.GetService<ISplashScreenViewPresenter>();
            this.Content = _presenter;
            this.Loaded += this.SplashScreenWindow_Loaded;
            this.VisualTransitionable = SplashScreenOption.Instance.VisualTransitionable;
        }

        private async void SplashScreenWindow_Loaded(object? sender, RoutedEventArgs e)
        {
            bool? fr = await Task.Run(() =>
            {
                return this._action?.Invoke(this, _presenter);
            });
            if (fr == true)
            {
                this.OnSuccessed();
            }
            else if (fr == false)
            {
                _presenter.Message = "初始化数据异常，请看日志";
                Thread.Sleep(5000);
                await this.Close();
            }
            else
            {
                await this.Close();
            }
        }

        private Func<IDialog, ISplashScreenViewPresenter, bool?> _action { get; set; }

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

        public Window GetWindow(Func<IDialog, ISplashScreenViewPresenter, bool?> func)
        {
            _action = func;
            return this;
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
