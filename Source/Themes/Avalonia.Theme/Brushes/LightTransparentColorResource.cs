using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class LightTransparentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅透明";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Light.Transparent.axaml");
        }
    }
}
