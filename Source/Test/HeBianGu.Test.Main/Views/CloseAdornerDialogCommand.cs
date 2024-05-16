﻿namespace HeBianGu.Test.Main.Views;

public class CloseAdornerDialogCommand : MarkupCommandBase
{
    public override void Execute(object parameter)
    {
        if (parameter is AdornerDialogPresenter presenter)
            presenter.Close();
    }

    public override bool CanExecute(object parameter)
    {
        return parameter is AdornerDialogPresenter;
    }
}
