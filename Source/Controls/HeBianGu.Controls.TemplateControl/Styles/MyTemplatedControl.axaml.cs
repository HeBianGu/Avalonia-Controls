using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Interactivity;
using System;
using System.Collections;
using System.Windows.Input;

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

    //    public static readonly RoutedEvent<RoutedEventArgs> TapEvent =
    //RoutedEvent.Register<MyTemplatedControl, RoutedEventArgs>(nameof(Tap), RoutingStrategies.Bubble);

    //    // Provide CLR accessors for the event
    //    public event EventHandler<RoutedEventArgs> Tap
    //    {
    //        add => AddHandler(TapEvent, value);
    //        remove => RemoveHandler(TapEvent, value);
    //    }

        public static readonly RoutedEvent<RoutedEventArgs> SourceChangedEvent = RoutedEvent.Register<MyTemplatedControl, RoutedEventArgs>(nameof(SourceChanged), RoutingStrategies.Bubble);

        public event EventHandler<RoutedEventArgs> SourceChanged
        {
            add => AddHandler(SourceChangedEvent, value);
            remove => RemoveHandler(SourceChangedEvent, value);
        }

        protected void OnSourceChanged()
        {
            RoutedEventArgs args = new RoutedEventArgs(SourceChangedEvent, this);
            this.RaiseEvent(args);
        }

        public static readonly StyledProperty<ICommand> PlayCommandProperty =
AvaloniaProperty.Register<MyTemplatedControl, ICommand>(nameof(PlayCommand));


        public ICommand PlayCommand
        {
            get { return GetValue(PlayCommandProperty); }
            set
            {
                SetValue(PlayCommandProperty, value);
            }
        }


        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == PlayCommandProperty)
            {
                //this.OnSourceChanged(change.NewValue?.ToString());
            }
        }
    }
}
