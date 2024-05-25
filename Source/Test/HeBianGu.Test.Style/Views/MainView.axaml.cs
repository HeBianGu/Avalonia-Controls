using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Linq;

namespace HeBianGu.Test.Style.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        animals.ItemsSource = new string[]
          {"cat", "camel", "cow", "chameleon", "mouse", "lion", "zebra" }
      .OrderBy(x => x);

        //ComboBox ss;
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
