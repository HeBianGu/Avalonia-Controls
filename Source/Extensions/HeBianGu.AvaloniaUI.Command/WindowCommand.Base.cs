// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace HeBianGu.AvaloniaUI.Command
{
    public abstract class WindowCommandBase : MarkupExtension, ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return parameter is Window;
        }

        public abstract void Execute(object parameter);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
