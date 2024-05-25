using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class DarkColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Dark.axaml");
        }
    }
}
