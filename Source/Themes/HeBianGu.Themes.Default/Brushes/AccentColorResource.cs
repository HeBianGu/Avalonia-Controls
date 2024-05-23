using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class AccentColorResource : ResourceBase, IColorResource
    {
        public override string Name => "主色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Brushes/Accent.axaml");
        }
    }
}
