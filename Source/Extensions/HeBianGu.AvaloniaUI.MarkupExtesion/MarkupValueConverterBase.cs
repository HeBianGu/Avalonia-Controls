using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Globalization;

namespace HeBianGu.Avalonia.Extensions.MarkupExtensions
{
    public abstract class MarkupValueConverterBase : MarkupExtension, IValueConverter
    {
        public abstract object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture);

        public virtual object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}