using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.ReactiveUI;
using HeBianGu.Test.Main.ViewModels;
using System;

namespace HeBianGu.Test.Main
{
    //ReactiveWindow<MainViewModel>
    public partial class LoginWindow : ReactiveWindow<MainViewModel>
    {
        public LoginWindow()
        {
            InitializeComponent();

            this.PointerPressed+= OnPointerPressed;
            this.btn_close.Click += this.Btn_close_Click;
            this.btn_login.Click += this.Btn_login_Click;
        }

        private void Btn_login_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.Logined?.Invoke();
        }

        private void Btn_close_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var window = ((IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime)
                               .MainWindow;
            window.Close();
        }

        private void OnPointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            if (e.Pointer.Type == PointerType.Mouse)
            {

                this.BeginMoveDrag(e);
            }
        }

        public event Action Logined;

    }
}
