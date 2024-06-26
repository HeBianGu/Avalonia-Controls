﻿
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Modules;
using HeBianGu.AvaloniaUI.Modules.ThemeSetting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace System
{
    public static class Extension
    {
        public static IApplicationAxamlLoader UseThemeSetting(this IApplicationAxamlLoader builder)
        {
            return builder;
        }

        public static IApplicationBuilder UseThemeSetting(this IApplicationBuilder builder, Action<ThemeSetting> option = null)
        {
            SettingDataManager.Instance.Add(ThemeSetting.Instance);
            option?.Invoke(ThemeSetting.Instance);
            return builder;
        }

        //public static IApplicationBuilder UseSwithTheme(this IApplicationBuilder builder, Action<SwitchThemeOptions> option = null)
        //{
        //    SettingDataManager.Instance.Add(SwitchThemeOptions.Instance);
        //    option?.Invoke(SwitchThemeOptions.Instance);
        //    return builder;
        //}

        //public static IServiceCollection AddSwitchThemeViewPresenter(this IServiceCollection services, Action<SwitchThemeOptions> setupAction = null)
        //{
        //    services.AddOptions();
        //    services.TryAdd(ServiceDescriptor.Singleton<ISwitchThemeViewPresenter, SwitchThemeViewPresenter>());
        //    if (setupAction != null)
        //        services.Configure(setupAction);
        //    return services;
        //}
    }

}