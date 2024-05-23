using Avalonia.Markup.Xaml.Styling;

namespace HeBianGu.Themes.Default
{
    public interface IResource
    {
        string Name { get; }
        ResourceInclude Resource { get; }
    }
}
