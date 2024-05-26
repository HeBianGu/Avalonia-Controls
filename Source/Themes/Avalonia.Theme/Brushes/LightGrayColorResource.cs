using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class LightGrayColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅灰色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Light.Gray.axaml");
        }
    }
}
