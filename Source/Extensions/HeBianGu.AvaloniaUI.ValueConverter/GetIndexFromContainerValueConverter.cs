using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using System;
using System.Globalization;

namespace HeBianGu.AvaloniaUI.ValueConverter
{
    public class GetIndexFromContainerValueConverter : MarkupValueConverterBase
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Control control)
            {
                if (control.Parent is ItemsControl items)
                {
                    var i = items.IndexFromContainer(control);
                    return i;
                }
            }
            return value;
        }
    }
}