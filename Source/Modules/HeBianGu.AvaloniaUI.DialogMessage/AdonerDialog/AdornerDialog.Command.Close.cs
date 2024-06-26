﻿
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public class CloseAdornerDialogCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is IAdornerDialogPresenter presenter)
                presenter.Close();
        }

        public override bool CanExecute(object parameter)
        {
            return parameter is IAdornerDialogPresenter;
        }
    }
}
