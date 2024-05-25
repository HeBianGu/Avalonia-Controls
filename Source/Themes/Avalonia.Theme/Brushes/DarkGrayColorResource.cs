using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class DarkGrayColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深灰色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Dark.Gray.axaml");
        }
    }
}
