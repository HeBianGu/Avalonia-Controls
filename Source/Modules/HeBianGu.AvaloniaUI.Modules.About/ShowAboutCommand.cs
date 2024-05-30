using Avalonia.Controls;
using Avalonia.Ioc;
using Avalonia.Layout;
using Avalonia.Mvvm;
using HeBianGu.AvaloniaUI.Modules.About;

namespace HeBianGu.AvaloniaUI.Modules.About
{
    public class ShowAboutCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            AboutViewPresenter setting = new AboutViewPresenter();
            bool? r = await IocMessage.Dialog.Show(setting, x =>
            {
                x.Title = "关于";
                x.Width = 600;
                x.DialogButton = DialogButton.None;
                if (x is Window window)
                {
                    window.SizeToContent = SizeToContent.Manual;
                    window.CanResize = true;
                    window.ShowInTaskbar = true;
                    window.VerticalContentAlignment = VerticalAlignment.Stretch;
                }
            });
        }
    }

}