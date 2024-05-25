using Avalonia.Media;
using System;
using System.Windows.Input;

namespace Avalonia.Mvvm
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
    }
}
