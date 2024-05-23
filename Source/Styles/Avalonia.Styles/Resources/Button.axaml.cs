using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Styles
{
    public static class ButtonKeys
    {
        //public static AvaloniaResourceKey Geometry => new AvaloniaResourceKey(typeof(ButtonKeys), "S.Button.Geometry");
        public static StringResourceKey Geometry => new StringResourceKey(typeof(Button), nameof(Geometry));
    }
}
