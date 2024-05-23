using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class DarkColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Brushes/Dark.axaml");
        }
    }
}
