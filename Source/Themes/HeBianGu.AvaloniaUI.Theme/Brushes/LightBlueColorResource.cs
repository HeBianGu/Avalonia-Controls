using HeBianGu.AvaloniaUI.Theme.Provider;
using System;

namespace HeBianGu.AvaloniaUI.Theme
{
    public class LightBlueColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅蓝色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.AvaloniaUI.Theme/Brushes/Light.Blue.axaml");
        }
    }
}
