using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class AccentLightColorResource : ResourceBase, IColorResource
    {
        public override string Name => "主浅色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Brushes/Accent.Light.axaml");
        }
    }
}
