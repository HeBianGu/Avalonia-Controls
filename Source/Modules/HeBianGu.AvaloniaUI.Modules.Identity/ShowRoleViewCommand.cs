// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using Avalonia.Ioc;
using Avalonia.Layout;
using Avalonia.Mvvm;

namespace HeBianGu.AvaloniaUI.Modules.Identity
{
    public class ShowRoleViewCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            RoleViewPresenter setting = new RoleViewPresenter();
            bool? r = await IocMessage.Dialog.Show(setting, x =>
            {
                x.MinHeight = 500;
                x.DialogButton = DialogButton.None;
                x.Margin = new Thickness(20);

                x.Title = "角色管理";
                if (x is Window window)
                {
                    window.SizeToContent = SizeToContent.Manual;
                    window.CanResize = true;
                    window.ShowInTaskbar = true;
                    window.VerticalContentAlignment = VerticalAlignment.Stretch;
                }
            });
            await setting.ViewModel.Save();
        }
    }
}
