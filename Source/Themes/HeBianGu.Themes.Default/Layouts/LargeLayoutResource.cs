using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class LargeLayoutResource : ResourceBase, ILayoutResource
    {
        public override string Name => "宽松";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Layouts/Large.axaml");
        }
    }
}
