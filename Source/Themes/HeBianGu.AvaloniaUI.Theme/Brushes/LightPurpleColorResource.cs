using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class LightPurpleColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅紫色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Light.Purple.axaml");
        }
    }
}
