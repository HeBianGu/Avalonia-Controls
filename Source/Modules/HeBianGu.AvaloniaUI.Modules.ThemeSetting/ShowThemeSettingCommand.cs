using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using HeBianGu.AvaloniaUI.Animations;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.Modules.ThemeSetting
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
                x.VisualTransitionable = new TranslateXTransitionable();
                if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
                {
                    x.HorizontalAlignment = HorizontalAlignment.Right;
                    x.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    x.VerticalAlignment = VerticalAlignment.Stretch;
                    x.VerticalContentAlignment = VerticalAlignment.Stretch;
                    x.MinWidth = 250;
                    x.Margin = new Thickness(2);

                }
                else
                {
                    //x.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    //x.VerticalContentAlignment = VerticalAlignment.Stretch;
                    x.VerticalAlignment = VerticalAlignment.Stretch;
                    x.HorizontalAlignment = HorizontalAlignment.Stretch;
                    //x.VerticalContentAlignment = VerticalAlignment.Stretch;
                    //x.Margin = new Avalonia.Thickness(10);
                }

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