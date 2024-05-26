using System;
using System.Globalization;

namespace Avalonia.Extensions.ValueConverter
{
    public class GetTrueToFalseValueConverter : MarkupValueConverterBase
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool b)
                return !b;
            return value;
        }
    }
}