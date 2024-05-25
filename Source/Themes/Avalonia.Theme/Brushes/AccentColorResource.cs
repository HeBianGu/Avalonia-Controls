using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class AccentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "主色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Accent.axaml");
        }
    }
}
