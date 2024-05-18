using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace HeBianGu.Avalonia.Modules.Login
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent<RoutedEventArgs> LoginedEvent =
            RoutedEvent.Register<RoutedEventArgs>(
                "Logined", RoutingStrategies.Bubble, typeof(LoginWindow));

    }
}
