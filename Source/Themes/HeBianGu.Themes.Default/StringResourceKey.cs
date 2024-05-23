using Avalonia.Markup.Xaml;
using System;

namespace HeBianGu.Themes.Default
{
    public class StringResourceKey : MarkupExtension
    {
        public StringResourceKey()
        {
                
        }
        public StringResourceKey(Type type, string resourceId)
        {
            this.TypeInTargetAssembly = type;
            this.ResourceId = resourceId;
        }

        public string ResourceId { get; set; }
        public Type TypeInTargetAssembly { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return $"S.{this.TypeInTargetAssembly.Name}.{ResourceId}";
        }
    }
}