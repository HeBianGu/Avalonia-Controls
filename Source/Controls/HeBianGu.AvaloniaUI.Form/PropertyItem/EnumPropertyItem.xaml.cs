﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Reflection;

namespace HeBianGu.AvaloniaUI.Form
{
    public class EnumPropertyItem : ObjectPropertyItem<Enum>
    {
        public EnumPropertyItem(PropertyInfo property, object obj)
            : base(property, obj)
        {
        }
    }

}
