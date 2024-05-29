using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Extensions.ResourceKey;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.Mvvm;
using Avalonia.Theme;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Styles.Extension
{
    public class MultiComboBox : ComboBox
    {
        protected override Type StyleKeyOverride => typeof(MultiComboBox);

        public IList BindingSelectedItems
        {
            get { return (IList)GetValue(BindingSelectedItemsProperty); }
            set { SetValue(BindingSelectedItemsProperty, value); }
        }


        public static readonly StyledProperty<IList> BindingSelectedItemsProperty =
            AvaloniaProperty.Register<MultiComboBox, IList>("BindingSelectedItems", null, false, BindingMode.Default, x =>
            {
                return true;
            }, (x, y) =>
            {
                if (x is MultiComboBox control && control._listBox != null && y is IList list)
                {
                    control._listBox.SelectedItems.Clear();
                    control._listBox.SelectionChanged -= control.ListBox_SelectionChanged;
                    foreach (var item in list)
                    {
                        control._listBox.SelectedItems.Add(item);
                    }
                    control._listBox.SelectionChanged += control.ListBox_SelectionChanged;
                }
                return y;
            });

        private ListBox _listBox = null;
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            _listBox = e.NameScope.Find<ListBox>("PART_ListBox");
            this._listBox.SelectionChanged += ListBox_SelectionChanged;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.BindingSelectedItems?.Clear();
            if (this._listBox.SelectedItems == null)
                return;

            if (this.BindingSelectedItems == null)
                return;
            foreach (var item in this._listBox.SelectedItems)
            {
                this.BindingSelectedItems.Add(item);
            }
        }

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
