using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Xml.Linq;
using HeBianGu.Test.Main.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls.Presenters;
using Avalonia.Layout;
using System.Reactive.Disposables;
using Avalonia.Threading;
using HeBianGu.Avalonia.Windows.Dialog;
using Avalonia;

namespace HeBianGu.Test.Main.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    public void Ioc_Click(object source, RoutedEventArgs args)
    {
        var i = System.Ioc.GetService<IMyIoc>();
        Dispatcher.UIThread.Invoke(() => { });
    }
    public void Adornr_Click(object source, RoutedEventArgs args)
    {
        AdornerLayer layer = AdornerLayer.GetAdornerLayer(this);
        //PresenterAdorner adorner = new PresenterAdorner(child, this);
        //layer.Add(adorner);
        //layer.Children.Add(new Button() { Content = "Adorner" });
        ContentPresenter contentPresenter = new ContentPresenter();
        contentPresenter.Content = new Student();
        //layer.Children.Add(contentPresenter);

        AdornerLayer.SetAdorner(this, contentPresenter);
        //AdornerLayer.SetAdorner(this, new Button() { Content = "Adorner" });
    }
    public void AdornerDialog_Click(object source, RoutedEventArgs args)
    {
        AdornerDialogPresenter adornerDialogPresenter = new AdornerDialogPresenter(new Student());
        adornerDialogPresenter.ShowDialog();
    }

    public async void WindowDialog_Click(object source, RoutedEventArgs args)
    {
        //DialogWindow dialogWindow=new DialogWindow();
        //dialogWindow.Show();

        var r = await DialogWindow.ShowPresenter(Student.Random(), x => x.Padding = new Thickness(10, 6, 10, 6));

        await DialogWindow.ShowPresenter(r);
    }
}
