using Avalonia.Markup.Xaml;
using System;
using System.Windows.Input;
using System.Windows.Markup;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public abstract class IocMarkupCommandBase : MarkupExtension, ICommand
    {
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
    }

}
