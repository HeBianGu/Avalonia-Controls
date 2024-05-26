﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Extensions.Repository;
using Avalonia.Ioc;
using Avalonia.Modules.Operation;
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
