using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Controls.MultiComboBox
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
}
