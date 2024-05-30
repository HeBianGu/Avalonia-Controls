using Avalonia.Extensions.ResourceKey;
using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class DarkColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Dark.axaml");
        }
    }
}
