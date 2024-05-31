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
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using HeBianGu.AvaloniaUI.DialogWindow;
using HeBianGu.AvaloniaUI.DemoData;
using HeBianGu.AvaloniaUI.DialogMessage;
using HeBianGu.AvaloniaUI.Modules.Setting;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using HeBianGu.AvaloniaUI.Step;

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

    public async void Setting_Click(object source, RoutedEventArgs args)
    {
        //DialogWindow dialogWindow=new DialogWindow();
        //dialogWindow.Show();

        SettingViewPresenter settingViewPresenter = new SettingViewPresenter();

        //var r = await DialogWindow.ShowPresenter(settingViewPresenter, x =>
        //{
        //    x.Padding = new Thickness(10, 6, 10, 6);
        //    x.Width = double.NaN;
        //});

        //await DialogWindow.ShowPresenter(r);


        AdornerDialogPresenter adornerDialogPresenter = new AdornerDialogPresenter(settingViewPresenter);
        adornerDialogPresenter.ShowDialog();
    }


}


public class StepItemDataTemplateSelector : IDataTemplate
{
    public IDataTemplate Unkown { get; set; }
    public IDataTemplate Error { get; set; }

    public IDataTemplate Success { get; set; }

    public IDataTemplate Running { get; set; }
    public Control? Build(object? param)
    {
        if (param is IStepItemPresenter item)
        {
            if (item.State == StepState.Error)
            {
                return Error.Build(param);

            }
            if (item.State == StepState.Success)
            {
                return Success.Build(param);

            }
            if (item.State == StepState.Running)
            {
                return Running.Build(param);

            }
            if (item.State == StepState.Ready)
            {
                return Unkown.Build(param);

            }

        }
        return new Control();
    }

    public bool Match(object? data)
    {
        return data is IStepItemPresenter;
    }
}
