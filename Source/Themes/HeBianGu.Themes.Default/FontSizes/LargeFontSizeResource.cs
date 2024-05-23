using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class LargeFontSizeResource : ResourceBase, IFontSizeResource
    {
        public override string Name => "大";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/FontSizes/Large.axaml");
        }
    }
}
