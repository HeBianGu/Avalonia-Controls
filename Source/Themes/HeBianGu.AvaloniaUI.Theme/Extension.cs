using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Ioc;
using System;

namespace System
{
    public static partial class Extension
    {

        public static IApplicationAxamlLoader UseTheme(this IApplicationAxamlLoader builder)
        {
            return builder;
        }
    }
}
