// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Media;
using System;
using System.Windows;

namespace HeBianGu.AvaloniaUI.Form
{
    public class TextBoxAttribute : Attribute
    {
        //public TextBoxAttribute(TextWrapping textWrapping)
        //{
        //    this.TextWrapping = textWrapping;
        //}
        public TextWrapping TextWrapping { get; set; }
        public bool UseClear { get; set; }
    }
}
