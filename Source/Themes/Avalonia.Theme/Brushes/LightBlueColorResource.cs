using Avalonia.Theme.Provider;

namespace Avalonia.Theme
{
    public class LightBlueColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅蓝色";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Light.Blue.axaml");
        }
    }

    public class LightTransparentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅透明";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Light.Transparent.axaml");
        }
    }

    public class DarkTransparentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深透明";
        protected override Uri GetUri()
        {
            return new Uri("avares://Avalonia.Theme/Brushes/Dark.Transparent.axaml");
        }
    }
}
