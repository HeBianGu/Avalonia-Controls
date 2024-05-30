using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class DarkPurpleColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深紫色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Dark.Purple.axaml");
        }
    }
}
