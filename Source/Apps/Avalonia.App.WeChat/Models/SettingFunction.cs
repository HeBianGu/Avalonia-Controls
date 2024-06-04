using HeBianGu.AvaloniaUI.DialogMessage;

namespace Avalonia.App.WeChat.Models
{
    public class SettingFunction : Function
    {
        public override async void ShowInfo(object p)
        {
            await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowSetting(this), x => x.Title = this.Name);
        }
    }
}
