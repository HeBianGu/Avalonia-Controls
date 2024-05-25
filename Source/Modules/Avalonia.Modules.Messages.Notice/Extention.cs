using Avalonia.Modules.Messages.Notice;
using Avalonia.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace System
{
    public static class Extention
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="service"></param>
        public static void AddNoticeMessage(this IServiceCollection services)
        {
            services.AddSingleton<INoticeMessageService, NoticeMessageService>();
        }
    }
}
