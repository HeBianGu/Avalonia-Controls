﻿
using Avalonia.Controls;
using HeBianGu.Avalonia.Core.Mvvm;
using System.Windows;

namespace Avalonia.Modules.Messages.Dialog
{
    public class ShowAdornerDialogCommand : MarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            //Window window = Application.Current.MainWindow;
            //UIElement child = window.Content as UIElement;
            //AdornerLayer layer = AdornerLayer.GetAdornerLayer(child);
            //AdornerDialogPresenter contentDialog = new AdornerDialogPresenter(parameter);
            //PresenterAdorner adorner = new PresenterAdorner(child, contentDialog);
            //layer.Add(adorner);
        }
    }
}
