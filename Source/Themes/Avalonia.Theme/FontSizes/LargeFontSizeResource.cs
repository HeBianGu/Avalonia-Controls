using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class LargeFontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "大";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/FontSizes/Large.axaml");
        }
    }
}
