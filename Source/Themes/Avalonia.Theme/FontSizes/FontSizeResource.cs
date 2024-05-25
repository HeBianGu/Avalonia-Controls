using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class FontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "标准";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/FontSizes/Default.axaml");
        }
    }
}
