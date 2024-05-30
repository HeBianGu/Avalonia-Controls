using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Avalonia.Extensions.MarkupExtension
{
    public class GetRangeExtension : Avalonia.Markup.Xaml.MarkupExtension
    {
        public int Start { get; set; }

        public int Count { get; set; } = 100;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enumerable.Range(this.Start, this.Count).ToList();
        }
    }
}