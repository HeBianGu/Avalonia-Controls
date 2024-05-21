using Avalonia.Controls;
using Avalonia.Interactivity;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Windows.Dialog;
using System;

namespace Avalonia.Modules.SplashScreen
{
    public partial class SplashScreenWindow : DialogWindow, ISplashScreenWindow
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
            this.btn_success.Click += this.Btn_success_Click;
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
