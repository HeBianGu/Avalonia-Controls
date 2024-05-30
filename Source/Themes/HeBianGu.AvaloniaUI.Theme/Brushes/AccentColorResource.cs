using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class AccentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "主色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Accent.axaml");
        }
    }
}
