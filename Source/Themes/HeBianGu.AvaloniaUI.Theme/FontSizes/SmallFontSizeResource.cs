using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class SmallFontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "小";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/FontSizes/Small.axaml");
        }
    }
}
