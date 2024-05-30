// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Modules.Operation;
using HeBianGu.AvaloniaUI.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace System
{
    public static class Extention
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="service"></param>
        public static void AddOperationViewPresenter(this IServiceCollection service)
        {
            service.AddOperationService();
            service.AddSingleton<IRepositoryBindable<hi_dd_operation>, RepositoryBindable<hi_dd_operation>>();
            service.AddSingleton<IOperationViewPresenter, OperationViewPresenter>();
        }

        public static void AddOperationService(this IServiceCollection service)
        {
            service.AddSingleton<IOperationService, OperationService>();
        }
    }
}
