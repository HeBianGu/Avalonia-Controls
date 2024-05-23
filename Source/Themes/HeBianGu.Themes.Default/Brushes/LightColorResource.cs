using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class LightColorResource : ResourceBase, IColorResource
    {
        public override string Name => "浅色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Brushes/Light.axaml");
        }
    }
}
