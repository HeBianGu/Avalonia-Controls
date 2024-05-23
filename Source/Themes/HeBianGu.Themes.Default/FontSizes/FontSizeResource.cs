using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class FontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "标准";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/FontSizes/Default.axaml");
        }
    }
}
