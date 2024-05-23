using HeBianGu.Themes.Default.Provider;

namespace HeBianGu.Themes.Default
{
    public class DarkBlueColorResource : ResourceBase, IColorResource
    {
        public override string Name => "深蓝色";
        protected override Uri GetUri()
        {
            return new Uri("avares://HeBianGu.Themes.Default/Brushes/Dark.Blue.axaml");
        }
    }
}
