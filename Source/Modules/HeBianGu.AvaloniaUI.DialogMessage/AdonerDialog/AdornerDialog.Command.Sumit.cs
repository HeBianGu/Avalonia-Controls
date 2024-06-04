
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public class SumitAdornerDialogCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is IDialog presenter)
                presenter.Sumit();
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is IDialog;
        }
    }
}
