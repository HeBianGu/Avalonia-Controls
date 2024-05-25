using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class LayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "标准";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Layouts/Default.axaml");
        }
    }
}
