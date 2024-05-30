using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class LargeLayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "宽松";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Layouts/Large.axaml");
        }
    }
}
