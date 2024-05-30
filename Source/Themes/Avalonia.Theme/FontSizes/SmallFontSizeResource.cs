using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class SmallFontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "小";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/FontSizes/Small.axaml");
        }
    }
}
