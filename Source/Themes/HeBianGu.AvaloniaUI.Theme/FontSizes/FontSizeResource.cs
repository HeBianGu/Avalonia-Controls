using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class FontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "标准";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/FontSizes/Default.axaml");
        }
    }
}
