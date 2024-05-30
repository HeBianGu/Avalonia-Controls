using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class DarkGrayColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深灰色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Dark.Gray.axaml");
        }
    }
}
