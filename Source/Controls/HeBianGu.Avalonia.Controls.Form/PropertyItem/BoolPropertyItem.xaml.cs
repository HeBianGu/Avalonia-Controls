﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System.Reflection;

namespace HeBianGu.Avalonia.Controls.Form
{
    public class BoolPropertyItem : ObjectPropertyItem<bool>
    {
        public BoolPropertyItem(PropertyInfo property, object obj) : base(property, obj)
        {
        }
    }

    public class BoolNullablePropertyItem : ObjectPropertyItem<bool?>
    {
        public BoolNullablePropertyItem(PropertyInfo property, object obj) : base(property, obj)
        {
        }
    }
}
