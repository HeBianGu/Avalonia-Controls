using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class SmallLayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "紧凑";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Layouts/Small.axaml");
        }
    }
}
