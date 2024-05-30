using Avalonia;
using Avalonia.Layout;
using Avalonia.Media;
using System.Windows;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public interface ILayoutable
    {
        IBrush? Background { get; set; }
        IBrush? BorderBrush { get; set; }
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
