using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class LargeFontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "大";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/FontSizes/Large.axaml");
        }
    }
}
