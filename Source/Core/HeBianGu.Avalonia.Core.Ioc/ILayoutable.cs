﻿using Avalonia;
using Avalonia.Layout;
using Avalonia.Media;
using System.Windows;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public interface ILayoutable
    {
        Brush Background { get; set; }
        Brush BorderBrush { get; set; }
        Thickness BorderThickness { get; set; }
        double Height { get; set; }
        HorizontalAlignment HorizontalAlignment { get; set; }
        HorizontalAlignment HorizontalContentAlignment { get; set; }
        bool IsEnabled { get; set; }
        Thickness Margin { get; set; }
        double MinHeight { get; set; }
        double MinWidth { get; set; }
        double Opacity { get; set; }
        Thickness Padding { get; set; }
        VerticalAlignment VerticalAlignment { get; set; }
        VerticalAlignment VerticalContentAlignment { get; set; }
        double Width { get; set; }
    }
}
