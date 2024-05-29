
using Avalonia.Modules.About;
using Avalonia.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using Avalonia.Extensions.Application;

namespace System
{
    public static class Extension
    {
        public static IApplicationAxamlLoader UseAbout(this IApplicationAxamlLoader builder)
        {
            return builder;
        }
        public static IServiceCollection AddAbout(this IServiceCollection services, Action<AboutOption> setupAction = null)
        {
            services.AddOptions();
            services.TryAdd(ServiceDescriptor.Singleton<IAboutViewPresenter, AboutViewPresenter>());
            if (setupAction != null)
                services.Configure(setupAction);
            return services;
        }

        public static IApplicationBuilder UseSplashScreen(this IApplicationBuilder builder, Action<AboutOption> option = null)
        {
            SettingDataManager.Instance.Add(AboutOption.Instance);
            option?.Invoke(AboutOption.Instance);
            return builder;
        }
    }
}
