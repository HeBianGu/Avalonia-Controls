﻿using Avalonia.Extensions.Application;
using Avalonia.Ioc;
using System;

namespace System
{
    public static partial class Extension
    {
        public static IApplicationAxamlLoader UseStylesExtension(this IApplicationAxamlLoader builder)
        {
            return builder;
        }
    }
}
