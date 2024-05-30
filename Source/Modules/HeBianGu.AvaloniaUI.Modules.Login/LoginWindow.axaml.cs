using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Ioc;
using Avalonia.Windows.Dialog;
using System;

namespace HeBianGu.AvaloniaUI.Modules.Login
{
    public partial class LoginWindow : DialogWindow, ILoginWindow
    {
        private readonly ILoginViewPresenter _presenter;

        public LoginWindow()
        {
            InitializeComponent();
            //this.Width=double.NaN;
            //this.Height=double.NaN;
            _presenter = System.Ioc.GetService<ILoginViewPresenter>();
            this.Content = _presenter;
        }

        public void OnLogined()
        {
            RoutedEventArgs args = new RoutedEventArgs(LoginedEvent, this);
            this.RaiseEvent(args);
        }

        public event EventHandler<RoutedEventArgs> Logined
        {
            add { this.AddHandler(LoginedEvent, value); }
            remove { this.RemoveHandler(LoginedEvent, value); }
        }

        public static readonly RoutedEvent<RoutedEventArgs> LoginedEvent =
            RoutedEvent.Register<RoutedEventArgs>(
                "Logined", RoutingStrategies.Bubble, typeof(LoginWindow));


        private void Btn_login_Click(object? sender, RoutedEventArgs e)
        {
            this.OnLogined();
        }

        private void Btn_close_Click(object? sender, RoutedEventArgs e)
        {
            var window = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime)
                               .MainWindow;
            window.Close();
        }



        public Window GetWindow()
        {
            return this;
        }
    }
}
