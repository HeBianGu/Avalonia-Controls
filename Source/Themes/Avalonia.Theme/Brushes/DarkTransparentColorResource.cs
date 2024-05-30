using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class DarkTransparentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深透明";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Dark.Transparent.axaml");
        }
    }
}
