using System;
using System.Globalization;

namespace HeBianGu.AvaloniaUI.ValueConverter
{
    public class GetTimeSpanFromMillisecondsValueConverter : MarkupValueConverterBase
    {
        public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value?.TryChangeType<double>(out double d) == true)
            {
                return TimeSpan.FromMilliseconds(d).ToString().Split('.')[0];
            }
            return value;
        }
    }
}