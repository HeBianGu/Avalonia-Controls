using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class LayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "标准";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Layouts/Default.axaml");
        }
    }
}
