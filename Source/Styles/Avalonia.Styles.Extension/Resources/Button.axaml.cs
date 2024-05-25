using Avalonia.Controls;
using Avalonia.Extensions.ResourceKey;
using Avalonia.Media;
using Avalonia.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Styles.Extension
{
    public static class ButtonKeys
    {
        public static StringResourceKey Geometry => new StringResourceKey(typeof(Button), nameof(Geometry));
    }
}
