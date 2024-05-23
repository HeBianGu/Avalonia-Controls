using HeBianGu.Avalonia.Core.Ioc;
using System;

namespace Avalonia.Styles
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
