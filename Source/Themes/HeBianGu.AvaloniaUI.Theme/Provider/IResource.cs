using Avalonia.Markup.Xaml.Styling;

namespace HeBianGu.AvaloniaUI.Theme
{
    public interface IResource
    {
        string Name { get; }
        ResourceInclude Resource { get; }
    }
}
