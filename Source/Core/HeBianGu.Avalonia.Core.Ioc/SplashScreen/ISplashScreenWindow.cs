// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface ISplashScreenWindow
    {
        event EventHandler<RoutedEventArgs> Successed;
        Window GetWindow();
    }
}