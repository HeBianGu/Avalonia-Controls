﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;

namespace HeBianGu.AvaloniaUI.Form
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class UnitAttribute : Attribute
    {
        public UnitAttribute(string unit)
        {
            this.Unit = unit;
        }
        public string Unit { get; }
    }
}
