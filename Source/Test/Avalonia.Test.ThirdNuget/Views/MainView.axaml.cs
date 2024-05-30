using Avalonia.Controls;
using Avalonia.Input;
using System;
using Avalonia.Test.ThirdNuget.ViewModels;

namespace Avalonia.Test.ThirdNuget.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void OnDataContextChanged(object sender, EventArgs e)
    {
        //if (DataContext is MainViewModel vm)
        //{
        //    vm.Play();
        //}
    }

    //private void VideoViewOnPointerEntered(object sender, PointerEventArgs e)
    //{
    //    ControlsPanel.IsVisible = true;
    //}

    //private void VideoViewOnPointerExited(object sender, PointerEventArgs e)
    //{
    //    ControlsPanel.IsVisible = false;
    //}

}
