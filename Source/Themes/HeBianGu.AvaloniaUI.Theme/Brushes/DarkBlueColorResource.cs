using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class DarkBlueColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深蓝色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Dark.Blue.axaml");
        }
    }
}
