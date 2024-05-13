using Avalonia.Controls;
using Avalonia.Interactivity;

namespace HeBianGu.Test.Controls.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
    public void Next(object source, RoutedEventArgs args)
    {
        slides.Next();
    }
    public void Previous(object source, RoutedEventArgs args)
    {
        slides.Previous();
    }
}
