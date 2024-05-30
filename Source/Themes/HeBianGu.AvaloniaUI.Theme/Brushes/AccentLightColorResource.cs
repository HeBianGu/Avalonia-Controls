using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class AccentLightColorResource : ResourceBase, IColorResource
    {
        public override string Name => "主浅色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Accent.Light.axaml");
        }
    }
}
