using Avalonia.Theme.Provider;
using System;

namespace Avalonia.Theme
{
    public class LargeLayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "宽松";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Layouts/Large.axaml");
        }
    }
}
