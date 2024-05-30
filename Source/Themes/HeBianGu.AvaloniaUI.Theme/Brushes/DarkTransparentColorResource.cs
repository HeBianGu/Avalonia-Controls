using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class DarkTransparentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深透明";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Dark.Transparent.axaml");
        }
    }
}
