using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class LayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "标准";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Layouts/Default.axaml");
        }
    }
}
