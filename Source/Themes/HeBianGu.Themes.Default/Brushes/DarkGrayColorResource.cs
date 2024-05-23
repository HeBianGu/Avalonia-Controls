using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class DarkGrayColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深灰色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Brushes/Dark.Gray.axaml");
        }
    }
}
