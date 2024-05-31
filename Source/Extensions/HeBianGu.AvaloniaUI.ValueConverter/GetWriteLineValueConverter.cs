using System;
using System.Globalization;

namespace HeBianGu.AvaloniaUI.ValueConverter
{
    public class GetWriteLineValueConverter : MarkupValueConverterBase
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            System.Diagnostics.Debug.WriteLine(value);
            return value;
        }
    }
}