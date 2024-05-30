using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class DarkPurpleColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深紫色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Dark.Purple.axaml");
        }
    }
}
