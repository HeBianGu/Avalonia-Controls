using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Interactivity;
using HeBianGu.Avalonia.Core.Ioc;
using System;

namespace HeBianGu.Avalonia.Modules.Login
{



    public partial class LoginWindow : Window, ILoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.PointerPressed += OnPointerPressed;
            this.btn_close.Click += this.Btn_close_Click;
            this.btn_login.Click += this.Btn_login_Click;
        }

        protected void OnLogined()
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

        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.Pointer.Type == PointerType.Mouse)
            {

                this.BeginMoveDrag(e);
            }
        }

        public Window GetWindow()
        {
            return this;
        }
    }
}
