﻿
using HeBianGu.AvaloniaUI.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace System
{
    public static class Extension
    {
        public static IApplicationAxamlLoader UseDrawerBox(this IApplicationAxamlLoader builder)
        {
            return builder;
        }
    }
}
