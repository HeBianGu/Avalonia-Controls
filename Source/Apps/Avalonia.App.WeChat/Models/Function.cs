﻿using HeBianGu.AvaloniaUI.DialogMessage;

namespace Avalonia.App.WeChat.Models
{
    public class Function : InfoItemBase
    {
        public override async void ShowInfo(object p)
        {
            await AdornerDialog.ShowPresenter<MobileAdornerDialogPresenter>(new ShowMy(this), x => x.Title = this.Name);
        }
    }
}
