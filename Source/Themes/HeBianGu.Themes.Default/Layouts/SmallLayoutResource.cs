using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class SmallLayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "紧凑";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Layouts/Small.axaml");
        }
    }
}
