
using Avalonia.Modules.SplashScreen;
using Avalonia.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace System
{
    public static class Extension
    {
        public static IServiceCollection AddSplashScreen(this IServiceCollection services, Action<SplashScreenOption> setupAction = null)
        {
            services.AddOptions();
            services.TryAdd(ServiceDescriptor.Singleton<ISplashScreenViewPresenter, SplashScreenViewPresenter>());
            if (setupAction != null)
                services.Configure(setupAction);
            services.AddSingleton<ISplashScreenWindow, SplashScreenWindow>();
            return services;
        }

        public static IApplicationBuilder UseSplashScreen(this IApplicationBuilder builder, Action<SplashScreenOption> option = null)
        {
            SettingDataManager.Instance.Add(SplashScreenOption.Instance);
            option?.Invoke(SplashScreenOption.Instance);
            return builder;
        }
    }
}
