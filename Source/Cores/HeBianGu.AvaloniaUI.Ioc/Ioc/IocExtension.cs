using Avalonia.Markup.Xaml;
using System;
using System.Windows.Markup;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public class IocExtension : MarkupExtension
    {
        public Type Type { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return System.Ioc.GetService<object>(this.Type);
        }
    }
}
