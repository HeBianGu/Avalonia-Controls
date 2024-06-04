using HeBianGu.AvaloniaUI.DialogMessage;
using HeBianGu.AvaloniaUI.Mvvm;

namespace Avalonia.App.WeChat.Models
{
    public class Function : InfoItemBase
    {
        public override async void ShowInfo(object p)
        {
            await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowMy(this), x => x.Title = this.Name);
        }
    }

    public class FriendGroup : Function
    {
        public override async void ShowInfo(object p)
        {
            await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowFriendGroup(this), x => x.Title = this.Name);
        }
    }

    public class ShowFriendGroup : ModelBindable<FriendGroup>
    {
        public ShowFriendGroup(FriendGroup t) : base(t)
        {
        }
    }
}
