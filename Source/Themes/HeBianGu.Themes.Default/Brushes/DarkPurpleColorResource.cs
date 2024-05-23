using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class DarkPurpleColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深紫色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Brushes/Dark.Purple.axaml");
        }
    }
}
