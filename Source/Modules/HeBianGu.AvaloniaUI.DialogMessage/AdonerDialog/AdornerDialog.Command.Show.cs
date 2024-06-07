
using Avalonia.Controls;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System.Windows;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public class ShowAdornerDialogCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            await AdornerDialog.ShowPresenter(parameter);
        }
    }

    public class ShowBackAdornerDialogCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(parameter);
        }
    }
}
