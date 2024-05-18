using System;
using System.Windows.Input;
using Avalonia.Media;

namespace HeBianGu.Avalonia.Core.Mvvm
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
