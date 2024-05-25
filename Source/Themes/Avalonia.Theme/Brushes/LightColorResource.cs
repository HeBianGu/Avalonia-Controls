using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class LightColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Light.axaml");
        }
    }
}
