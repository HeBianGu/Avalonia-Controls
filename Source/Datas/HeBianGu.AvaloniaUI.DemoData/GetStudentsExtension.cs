using Avalonia.Markup.Xaml;
using System;
using System.Linq;
using System.Windows.Markup;

namespace HeBianGu.AvaloniaUI.DemoData
{
    public class GetStudentsExtension : MarkupExtension
    {
        public int Count { get; set; } = 10;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enumerable.Range(0, this.Count).Select(x => new Student()).ToList();
        }
    }
}
