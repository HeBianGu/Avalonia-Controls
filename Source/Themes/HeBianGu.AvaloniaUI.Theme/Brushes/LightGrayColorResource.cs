using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class LightGrayColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅灰色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Light.Gray.axaml");
        }
    }
}
