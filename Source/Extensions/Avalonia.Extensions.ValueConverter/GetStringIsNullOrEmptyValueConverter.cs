using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Theme;
using System;
using System.Globalization;

namespace Avalonia.Extensions.ValueConverter
{
    public class GetLevelBrushValueConverter : MarkupValueConverterBase
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int v)
            {
                {
                    if (v == 0 && Avalonia.Application.Current.TryFindResource(BrushKeys.Purple, out object result))
                    {
                        if (result is Brush brush)
                            return brush;
                    }
                }
                {
                    if (v == 1 && Avalonia.Application.Current.TryFindResource(BrushKeys.Red, out object result))
                    {
                        if (result is Brush brush)
                            return brush;
                    }
                }
                {
                    if (v == 2 && Avalonia.Application.Current.TryFindResource(BrushKeys.Orange, out object result))
                    {
                        if (result is Brush brush)
                            return brush;
                    }
                }
                {
                    if (v == 3 && Avalonia.Application.Current.TryFindResource(BrushKeys.Blue, out object result))
                    {
                        if (result is Brush brush)
                            return brush;
                    }
                }
                {
                    if (v == 4 && Avalonia.Application.Current.TryFindResource(BrushKeys.Green.ResourceId, out object result))
                    {
                        if (result is Brush brush)
                            return brush;
                    }
                }
            }
            return value;
        }
    }
    public class GetStringIsNullOrEmptyValueConverter : MarkupValueConverterBase
    {
        public object TrueValue { get; set; }
        public object FalseValue { get; set; }
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                if (this.TrueValue?.TryChangeType(targetType, out object result) == true)
                {
                    return result;
                }
            }
            else
            {
                if (this.FalseValue?.TryChangeType(targetType, out object result) == true)
                {
                    return result;
                }
            }
            return value;
        }
    }
}