using System;
using Avalonia.Markup.Xaml;
using System.Windows.Input;

namespace HeBianGu.Test.Main.Views;
public abstract class MarkupCommandBase : MarkupExtension, ICommand
{
    public event EventHandler? CanExecuteChanged;

    //public event EventHandler CanExecuteChanged
    //{
    //    add
    //    {
    //        CommandManager.RequerySuggested += value;
    //    }
    //    remove
    //    {
    //        CommandManager.RequerySuggested -= value;
    //    }
    //}
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
