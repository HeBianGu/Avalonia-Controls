using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace HeBianGu.Avalonia.Extensions.MarkupExtensions
{
    public class GetRangeExtension : MarkupExtension
    {
        public int Start { get; set; }

        public int Count { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enumerable.Range(this.Start, this.Count).ToList();
        }
    }
}