using Avalonia.Controls;
using Avalonia.Media;
using HeBianGu.AvaloniaUI.ResourceKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Styles.Extension
{
    public static class TabControlKeys
    {
        public static StringResourceKey ScrollViewer => new StringResourceKey(typeof(TabControl), nameof(ScrollViewer));
    }
}
