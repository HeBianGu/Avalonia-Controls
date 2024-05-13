using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HeBianGu.Controls.MultiComboBox
{
    public class MultiComboBox : ComboBox
    {

    }

    public static class MultiComboBoxCommands
    {
        //public static IRelayCommand<object, bool> RemoveCommand => new RelayCommand<object, bool> < object, bool>(x =>
        //{
        //    if (x is ListBoxItem listBoxItem && listBoxItem.Parent is ListBox listBox && listBox.TemplatedParent is MultiComboBox multiComboBox)
        //    {
        //        if (listBox.ItemsSource is IList list)
        //        {
        //            list.Remove(listBoxItem.Content);
        //        }
        //    }
        //    return true;
        //});

        public static IRelayCommand RemoveCommand => null;
    }
}
