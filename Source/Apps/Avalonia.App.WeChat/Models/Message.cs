using HeBianGu.AvaloniaUI.DialogMessage;

namespace Avalonia.App.WeChat.Models
{
    public class Message : InfoItemBase
    {
        public override async void ShowInfo(object p)
        {
            await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowMessage(this), x => x.Title = this.Name);

        }
    }
}
