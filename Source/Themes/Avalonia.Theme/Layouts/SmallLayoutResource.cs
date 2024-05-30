using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class SmallLayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "紧凑";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Layouts/Small.axaml");
        }
    }
}
