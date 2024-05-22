// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using Avalonia.Controls;
using Avalonia.Layout;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Core.Mvvm;
using HeBianGu.Avalonia.Modules.Setting;
using System.Windows;

namespace HeBianGu.Avalonia.Modules.Setting
{
    public class ShowSettingCommand : MarkupCommandBase
    {
        public override async void Execute(object parameter)
        {
            SettingViewPresenter setting = new SettingViewPresenter();
            bool? r = await IocMessage.Dialog.Show(setting, x =>
            {
                x.Width = 800;
                x.Height = 500;
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
