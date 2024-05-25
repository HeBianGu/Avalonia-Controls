using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class AccentLightColorResource : ResourceBase, IColorResource
    {
        public override string Name => "主浅色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Accent.Light.axaml");
        }
    }
}
