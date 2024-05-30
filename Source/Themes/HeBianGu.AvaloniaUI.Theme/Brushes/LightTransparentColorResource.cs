using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class LightTransparentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅透明";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Light.Transparent.axaml");
        }
    }
}
