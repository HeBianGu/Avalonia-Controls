using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class LightPurpleColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅紫色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Light.Purple.axaml");
        }
    }
}
