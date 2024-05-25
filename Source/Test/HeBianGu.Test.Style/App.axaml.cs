using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Extensions.Application;
using Avalonia.Markup.Xaml;

using HeBianGu.Test.Style.ViewModels;
using HeBianGu.Test.Style.Views;

namespace HeBianGu.Test.Style;

public partial class App : ApplicationBase
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override Control GetMainView()
    {
      return  new MainView
        {
            DataContext = new MainViewModel()
        };
    }

    protected override Window GetMainWindow()
    {
       return new MainWindow
       {
           DataContext = new MainViewModel()
       };
    }

    //public override void OnFrameworkInitializationCompleted()
    //{
    //    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    //    {
    //        desktop.MainWindow = new MainWindow
    //        {
    //            DataContext = new MainViewModel()
    //        };
    //    }
    //    else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
    //    {
    //        singleViewPlatform.MainView = new MainView
    //        {
    //            DataContext = new MainViewModel()
    //        };
    //    }

    //    base.OnFrameworkInitializationCompleted();
    //}
}
