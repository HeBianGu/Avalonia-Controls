using HeBianGu.AvaloniaUI;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.SnackMessage;
using Microsoft.Extensions.DependencyInjection;

namespace System
{
    public static class Extention
    {

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="service"></param>
        public static void AddSnackMessage(this IServiceCollection services)
        {
            services.AddSingleton<ISnackMessageService, SnackMessageService>();
        }
    }
}
