// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace HeBianGu.Avalonia.Controls.Form
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class PropertyAttribute : Attribute
    {
        public bool UsePresenter { get; set; }
    }
}
