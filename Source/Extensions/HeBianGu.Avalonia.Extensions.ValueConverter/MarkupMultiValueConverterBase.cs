using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace HeBianGu.Avalonia.Extensions.ValueConverter
{
    public abstract class MarkupMultiValueConverterBase : MarkupExtension, IMultiValueConverter
    {
        public abstract object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}