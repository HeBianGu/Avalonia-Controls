
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Step;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace System
{
    public static class Extension
    {
        //public static IServiceCollection AddAbout(this IServiceCollection services, Action<AboutOption> setupAction = null)
        //{
        //    services.AddOptions();
        //    services.TryAdd(ServiceDescriptor.Singleton<IAboutViewPresenter, AboutViewPresenter>());
        //    if (setupAction != null)
        //        services.Configure(setupAction);
        //    return services;
        //}

        //public static IApplicationBuilder UseSplashScreen(this IApplicationBuilder builder, Action<AboutOption> option = null)
        //{
        //    SettingDataManager.Instance.Add(AboutOption.Instance);
        //    option?.Invoke(AboutOption.Instance);
        //    return builder;
        //}

        public static IApplicationAxamlLoader UseStep(this IApplicationAxamlLoader builder)
        {
            return builder;
        }
    }
}
