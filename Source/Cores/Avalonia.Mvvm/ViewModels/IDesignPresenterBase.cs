// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Layout;
using Avalonia.Media;
using System.Windows;

namespace Avalonia.Mvvm
{
    public interface IDesignPresenterBase
    {
        IBrush? Background { get; set; }
        IBrush? BorderBrush { get; set; }
        Thickness BorderThickness { get; set; }
        int Column { get; set; }
        int ColumnSpan { get; set; }
        RelayCommand DeleteCommand { get; }
        double Height { get; set; }
        HorizontalAlignment HorizontalAlignment { get; set; }
        HorizontalAlignment HorizontalContentAlignment { get; set; }
        bool IsEnabled { get; set; }
        bool IsMouseOver { get; set; }
        bool IsSelected { get; set; }
        bool IsVisible { get; set; }
        Thickness Margin { get; set; }
        double MinHeight { get; set; }
        double MinWidth { get; set; }
        double Opacity { get; set; }
        Thickness Padding { get; set; }
        int Row { get; set; }
        int RowSpan { get; set; }
        VerticalAlignment VerticalAlignment { get; set; }
        VerticalAlignment VerticalContentAlignment { get; set; }
        double Width { get; set; }
    }
}
