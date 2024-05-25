using Avalonia.Styles;
using Avalonia.Ioc;
using System;

namespace System
{
    public static partial class Extension
    {
        public static IApplicationBuilder UseWindowSetting(this IApplicationBuilder builder, Action<WindowSetting> option = null)
        {
            SettingDataManager.Instance.Add(WindowSetting.Instance);
            option?.Invoke(WindowSetting.Instance);
            return builder;
        }
    }
}
