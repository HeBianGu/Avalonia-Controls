using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.Threading;
using HeBianGu.AvaloniaUI.Mvvm;
using HeBianGu.AvaloniaUI.Tree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.ExploreBox
{
    public class ExploreNavigatorBox : ListBox
    {
        protected override Type StyleKeyOverride => typeof(ExploreNavigatorBox);

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == ExploreNavigatorBox.CurrentProperty)
            {
                this.RefreshData();
                this.Historys.Add(this.Current);
                this.Historys = this.Historys.TakeLast(10).ToList();
            }
            if (change.Property == ListBox.SelectedItemProperty)
            {
                if (this.SelectedItem is IModelBindable bindable)
                    this.Current = bindable.GetModel();
                else
                    this.Current = this.SelectedItem;
            }
        }

        private IParentable _service = new ExploreTree();

        public List<object> Historys
        {
            get { return (List<object>)GetValue(HistorysProperty); }
            set { SetValue(HistorysProperty, value); }
        }
        public static readonly StyledProperty<List<object>> HistorysProperty = AvaloniaProperty.Register<ExploreNavigatorBox, List<object>>("Historys", new List<object>());

        public object Current
        {
            get { return (object)GetValue(CurrentProperty); }
            set { SetValue(CurrentProperty, value); }
        }
        public static readonly StyledProperty<object> CurrentProperty = AvaloniaProperty.Register<ExploreNavigatorBox, object>("Current");

        private void RefreshData()
        {
            var source = _service.GetParents(this.Current).ToList();
            source.Reverse();
            source.Add(this.Current);
            source.Remove(null);
            this.ItemsSource = source;
        }
    }
}
