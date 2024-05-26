using System;
using System.Globalization;

namespace Avalonia.Extensions.ValueConverter
{
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