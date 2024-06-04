

using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public class CancelAdornerDialogCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is IAdornerDialogPresenter presenter)
                presenter.Cancel();
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is IAdornerDialogPresenter;
        }
    }
}
