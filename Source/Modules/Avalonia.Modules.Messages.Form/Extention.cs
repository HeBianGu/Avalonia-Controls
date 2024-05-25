using Avalonia.Modules.Messages.Form;
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
        public static void AddFormMessageService(this IServiceCollection services)
        {
            services.AddSingleton<IFormMessageService, FormMessageService>();
        }
    }
}
