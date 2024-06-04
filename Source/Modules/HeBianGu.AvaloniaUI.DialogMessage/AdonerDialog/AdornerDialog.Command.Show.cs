
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
            //Window window = Application.Current.MainWindow;
            //UIElement child = window.Content as UIElement;
            //AdornerLayer layer = AdornerLayer.GetAdornerLayer(child);
            //AdornerDialogPresenter contentDialog = new AdornerDialogPresenter(parameter);
            //PresenterAdorner adorner = new PresenterAdorner(child, contentDialog);
            //layer.Add(adorner);

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
