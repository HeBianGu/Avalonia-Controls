// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Layout;
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Modules.Setting;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Windows;

namespace HeBianGu.AvaloniaUI.Modules.Setting
{
    public class ShowSettingCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            SettingViewPresenter setting = new SettingViewPresenter();
            bool? r = await IocMessage.Dialog.Show(setting, x =>
            {

                var v = Avalonia.Application.Current.GetMainAdornerControl() as Control;
                if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
                {
                    x.Width = v.Width > 800 ? 800 : double.NaN;
                    x.Height = 500;
                }
                else
                {
                    x.VerticalAlignment = VerticalAlignment.Stretch;
                    //x.Margin = new Avalonia.Thickness(10);
                }

                x.DialogButton = DialogButton.None;
                x.Title = "系统设置";
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

            bool sr = SettingDataManager.Instance.Save(out string error);
            if (sr == false)
            {
                await IocMessage.Dialog.Show(error);
            }
        }
    }

    public class SettingDefaultCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            SettingDataManager.Instance.SetDefault();
        }
    }

    public class CancelSettingCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            SettingDataManager.Instance.Cancel();
        }
    }
}
