using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Modules.About;
using HeBianGu.AvaloniaUI.Mvvm;

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
                if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
                {
                    x.Width = 600;
                    x.HorizontalContentAlignment = HorizontalAlignment.Center;
                }
                else
                {
                    x.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                }
                   
               
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