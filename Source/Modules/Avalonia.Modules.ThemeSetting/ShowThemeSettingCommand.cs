using Avalonia.Controls;
using Avalonia.Layout;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Core.Mvvm;

namespace Avalonia.Modules.ThemeSetting
{
    public class ShowThemeSettingCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            ThemeSettingViewPresenter setting = new ThemeSettingViewPresenter();
            bool? r = await IocMessage.Dialog.Show(setting, x =>
            {
                x.Width = 800;
                x.DialogButton = DialogButton.None;
                if (x is Window window)
                {
                    window.SizeToContent = SizeToContent.Manual;
                    window.CanResize = true;
                    window.ShowInTaskbar = true;
                    window.VerticalContentAlignment = VerticalAlignment.Stretch;
                }
            });
            if (r != true)
                return;
            ThemeSetting.Instance.RefreshTheme();

            //bool sr = SettingDataManager.Instance.Save(out string error);
            //if (sr == false)
            //{
            //    await IocMessage.Dialog.Show(error);
            //}
        }
    }

}