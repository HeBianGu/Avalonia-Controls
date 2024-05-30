// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.Windows;
using System.Xml.Linq;

namespace HeBianGu.AvaloniaUI.Command
{
    public class CloseWindowCommand : WindowCommandBase
    {
        public bool UseDialog { get; set; } = false;
        public string Message { get; set; } = "确认退出系统?";
        public override async void Execute(object parameter)
        {
            if (parameter is Window window && Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                bool isMain = desktop.MainWindow == window;// && WindowSetting.Instance.UseNoticeOnMainWindowClose;
                if (isMain && this.UseDialog)
                {
                    var r = await IocMessage.ShowDialogMessage(this.Message, "提示", DialogButton.SumitAndCancel);
                    if (r != true)
                        return;
                }
                window.Close();
            }
        }
    }
}
