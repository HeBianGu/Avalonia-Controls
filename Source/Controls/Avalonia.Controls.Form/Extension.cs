
using Avalonia.Ioc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using Avalonia.Extensions.Application;

namespace System
{
    public static class Extension
    {
        public static IApplicationAxamlLoader UseForm(this IApplicationAxamlLoader builder)
        {
            return builder;
        }
    }
}
