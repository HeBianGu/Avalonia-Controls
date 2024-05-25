using Avalonia.Markup.Xaml.Styling;

namespace Avalonia.Theme
{
    public interface IResource
    {
        string Name { get; }
        ResourceInclude Resource { get; }
    }
}
