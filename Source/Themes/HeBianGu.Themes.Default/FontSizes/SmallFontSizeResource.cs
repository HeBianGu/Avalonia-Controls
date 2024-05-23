using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class SmallFontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "小";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/FontSizes/Small.axaml");
        }
    }
}
