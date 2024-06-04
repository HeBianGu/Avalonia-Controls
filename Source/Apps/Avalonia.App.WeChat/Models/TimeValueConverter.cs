using HeBianGu.AvaloniaUI.ValueConverter;
using System;
using System.Globalization;

namespace Avalonia.App.WeChat.Models
{
    public class TimeValueConverter : MarkupValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime time)
                return time.ToString("MM月dd日");
            return value;
        }
    }
}
