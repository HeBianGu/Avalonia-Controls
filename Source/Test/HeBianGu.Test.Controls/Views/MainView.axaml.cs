﻿using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Linq;

namespace HeBianGu.Test.Controls.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        animals.ItemsSource = new string[]
              {"cat", "camel", "cow", "chameleon", "mouse", "lion", "zebra" }
          .OrderBy(x => x);
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
