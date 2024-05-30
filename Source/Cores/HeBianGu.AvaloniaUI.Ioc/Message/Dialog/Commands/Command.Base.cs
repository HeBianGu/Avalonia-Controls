// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Windows.Input;
using System.Windows.Markup;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public abstract class MessageCommandBase : MarkupExtension, ICommand
    {
        public string Title { get; set; }
        public int Width { get; set; } = 500;
        public int Height { get; set; } = 300;
        public DialogButton DialogButton { get; set; }

        public event EventHandler CanExecuteChanged;
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        protected void Build(IDialog w)
        {
            if (w is Control c)
            {
                c.Width = Width;
                c.Height = Height;
            }
        }
    }
}
