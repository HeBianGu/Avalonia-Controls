﻿
using Avalonia.Extensions.Repository;
using Avalonia.Ioc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Avalonia.Modules.Operation
{
    internal class OperationService : IOperationService
    {
        public void Log<T>(string title, string message = null, OperationType operationType = OperationType.Default, bool result = true, [CallerMemberName] string methodName = null)
        {
            if (typeof(hi_dd_operation) == typeof(T))
                return;
            IRepositoryBindable<hi_dd_operation> vm = System.Ioc.GetService<IRepositoryBindable<hi_dd_operation>>();
            string typeName = typeof(T).GetCustomAttribute<DisplayAttribute>()?.Name ?? typeof(T).Name;
            vm.UseMessage = false;
            hi_dd_operation operation = new hi_dd_operation()
            {
                Title = title,
                Message = message,
                Method = methodName,
                OperationType = operationType,
                Type = typeName,
                UserID = Ioc<ILoginService>.Instance?.User?.ID,
                UserName = Ioc<ILoginService>.Instance?.User?.Account
            };
            vm.Add(operation);
        }
    }
}
