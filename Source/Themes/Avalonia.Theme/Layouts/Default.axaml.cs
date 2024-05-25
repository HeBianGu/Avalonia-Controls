using Avalonia.Extensions.ResourceKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Theme
{
    public static class LayoutKeys
    {
        public static StringResourceKey RowHeight => new StringResourceKey(typeof(LayoutKeys), "S.Layout.RowHeight");
        public static StringResourceKey ItemHeight => new StringResourceKey(typeof(LayoutKeys), "S.Layout.ItemHeight");
        public static StringResourceKey WindowCaptionHeight => new StringResourceKey(typeof(LayoutKeys), "S.Layout.WindowCaptionHeight");
        public static StringResourceKey CornerRadius => new StringResourceKey(typeof(LayoutKeys), "S.Layout.CornerRadius");

        public static StringResourceKey Disabled => new StringResourceKey(typeof(LayoutKeys), "S.Layout.Disabled");
        public static StringResourceKey Pressed => new StringResourceKey(typeof(LayoutKeys), "S.Layout.Pressed");
        public static StringResourceKey BorderThickness => new StringResourceKey(typeof(LayoutKeys), "S.Layout.BorderThickness");
        public static StringResourceKey Padding => new StringResourceKey(typeof(LayoutKeys), "S.Layout.Padding");
    }
}
