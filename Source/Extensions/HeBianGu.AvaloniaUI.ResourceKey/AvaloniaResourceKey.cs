using Avalonia.Markup.Xaml;
using System;

namespace HeBianGu.AvaloniaUI.ResourceKey
{
    public class AvaloniaResourceKey : MarkupExtension
    {
        public AvaloniaResourceKey()
        {

        }
        public AvaloniaResourceKey(Type type, string resourceId)
        {
            this.TypeInTargetAssembly = type;
            this.ResourceId = resourceId;
        }

        public string ResourceId { get; set; }
        public Type TypeInTargetAssembly { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return ResourceId;
        }
    }
}