using HeBianGu.AvaloniaUI.DialogMessage;

namespace Avalonia.App.WeChat.Models
{
    public class Address : InfoItemBase
    {
        public override async void ShowInfo(object p)
        {
            await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowMy(new Function()), x => x.Title = this.Name);
        }
    }
}
