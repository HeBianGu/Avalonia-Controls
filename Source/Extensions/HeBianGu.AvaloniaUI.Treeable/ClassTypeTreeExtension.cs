using Avalonia.Markup.Xaml;
using System;

namespace HeBianGu.AvaloniaUI.Treeable
{
    public class ClassTypeTreeExtension : MarkupExtension
    {
        public Type Type { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new ClassTypeTree(this.Type);
        }
    }

}
