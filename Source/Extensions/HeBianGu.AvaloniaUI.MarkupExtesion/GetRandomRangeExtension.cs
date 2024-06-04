using System;
using System.Linq;

namespace Avalonia.Extensions.MarkupExtension
{
    public class GetRandomRangeMarkupExtension : Avalonia.Markup.Xaml.MarkupExtension
    {
        public int Count { get; set; } = 100;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enumerable.Range(0, Random.Shared.Next(0, this.Count)).ToList();
        }
    }
}