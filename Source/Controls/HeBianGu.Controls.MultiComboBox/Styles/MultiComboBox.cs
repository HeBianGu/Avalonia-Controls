using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

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
