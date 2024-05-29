using Avalonia.Controls;
using Avalonia.Extensions.ResourceKey;
using Avalonia.Media;
using Avalonia.Mvvm;
using Avalonia.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Styles.Extension
{
    public class MultiComboBox : ComboBox
    {
        protected override Type StyleKeyOverride => typeof(MultiComboBox);

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
