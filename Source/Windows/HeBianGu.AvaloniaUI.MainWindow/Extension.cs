
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.MainWindow;
using System;

namespace System
{
    public static partial class Extension
    {
        public static IApplicationAxamlLoader UseMainWindowBase(this IApplicationAxamlLoader builder)
        {
            return builder;
        }

        public static IApplicationBuilder UseMainWindow(this IApplicationBuilder builder, Action<MainWindowSetting> option = null)
        {
            SettingDataManager.Instance.Add(MainWindowSetting.Instance);
            option?.Invoke(MainWindowSetting.Instance);
            return builder;
        }
    }
}
