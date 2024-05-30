using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Interactivity;
using System.Collections;

namespace HeBianGu.Controls.TemplateControl
{
    public class MyTemplatedControl : TemplatedControl
    {
        private ListBox _listBox = null;
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            _listBox = e.NameScope.Find<ListBox>("PART_ListBox");
            //this._listBox.SelectionChanged += ListBox_SelectionChanged;
        }
        public IList BindingSelectedItems
        {
            get { return (IList)GetValue(BindingSelectedItemsProperty); }
            set { SetValue(BindingSelectedItemsProperty, value); }
        }

        public static readonly StyledProperty<IList> BindingSelectedItemsProperty =
            AvaloniaProperty.Register<MyTemplatedControl, IList>("BindingSelectedItems", null, false, BindingMode.Default, x =>
            {
                return true;
            }, (x, y) =>
            {
                if (x is MyTemplatedControl control && control._listBox != null && y is IList list)
                {
                    control._listBox.SelectedItems.Clear();
                    //control._listBox.SelectionChanged -= control.ListBox_SelectionChanged;
                    foreach (var item in list)
                    {
                        control._listBox.SelectedItems.Add(item);
                    }
                    //control._listBox.SelectionChanged += control.ListBox_SelectionChanged;
                }
                return y;
            });

    }
}
