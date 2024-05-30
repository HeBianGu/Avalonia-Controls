using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class LightBlueColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅蓝色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Light.Blue.axaml");
        }
    }
}
