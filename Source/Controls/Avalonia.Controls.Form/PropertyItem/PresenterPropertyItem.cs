﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System.Reflection;

namespace Avalonia.Controls.Form
{
    public class PresenterPropertyItem : ObjectPropertyItem<object>
    {
        public PresenterPropertyItem(PropertyInfo property, object obj) : base(property, obj)
        {

        }
    }
}