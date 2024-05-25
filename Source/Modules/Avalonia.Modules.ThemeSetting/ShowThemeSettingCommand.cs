using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Ioc;
using Avalonia.Mvvm;

namespace Avalonia.Modules.ThemeSetting
{
    public class ShowThemeSettingCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            ThemeSettingViewPresenter setting = new ThemeSettingViewPresenter();
            bool? r = await IocMessage.Dialog.Show(setting, x =>
            {
                //x.Width = 800;
                x.Title = "主题设置";
                x.DialogButton = DialogButton.None;
                x.HorizontalAlignment= HorizontalAlignment.Right;
                x.HorizontalContentAlignment= HorizontalAlignment.Right;
                x.VerticalAlignment= VerticalAlignment.Stretch;
                x.VerticalContentAlignment= VerticalAlignment.Stretch;
                x.MinWidth = 200;
                x.Margin= new Thickness(2);
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