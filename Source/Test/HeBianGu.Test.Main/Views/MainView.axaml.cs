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

namespace HeBianGu.Test.Main.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    public void Ioc_Click(object source, RoutedEventArgs args)
    {
        var i = Ioc.GetService<IMyIoc>();
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
    public void Dialog_Click(object source, RoutedEventArgs args)
    {
        AdornerDialogPresenter adornerDialogPresenter = new AdornerDialogPresenter(new Student());
        adornerDialogPresenter.ShowDialog();
    }
    
}
