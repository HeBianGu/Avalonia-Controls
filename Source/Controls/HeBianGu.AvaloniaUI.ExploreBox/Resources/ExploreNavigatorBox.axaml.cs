using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.Threading;
using HeBianGu.AvaloniaUI.Mvvm;
using HeBianGu.AvaloniaUI.Treeable;
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

        private IParentable _service = new ExploreTree() { Root = "我的电脑" };
        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == ExploreNavigatorBox.CurrentProperty)
            {
                this.RefreshData();
                if (this.HistorySelectedIndex != 0)
                    return;
                this.Historys.Insert(0, this.Current);
                this.Historys = this.Historys.Take(10).ToList();
            }
            if (change.Property == ListBox.SelectedItemProperty)
            {
                if (this.SelectedItem is IModelBindable bindable)
                    this.Current = bindable.GetModel();
                else
                    this.Current = this.SelectedItem;
            }
            if (change.Property == ExploreNavigatorBox.HistorySelectedIndexProperty)
            {
                if (this.Historys.Count > this.HistorySelectedIndex && HistorySelectedIndex > 0)
                    this.Current = this.Historys[this.HistorySelectedIndex];
            }
        }

        public string SearchPattern
        {
            get { return (string)GetValue(SearchPatternProperty); }
            set { SetValue(SearchPatternProperty, value); }
        }
        public static readonly StyledProperty<string> SearchPatternProperty = AvaloniaProperty.Register<ExploreNavigatorBox, string>("SearchPattern");


        public List<object> Historys
        {
            get { return (List<object>)GetValue(HistorysProperty); }
            set { SetValue(HistorysProperty, value); }
        }
        public static readonly StyledProperty<List<object>> HistorysProperty = AvaloniaProperty.Register<ExploreNavigatorBox, List<object>>("Historys", new List<object>());

        public int HistorySelectedIndex
        {
            get { return (int)GetValue(HistorySelectedIndexProperty); }
            set { SetValue(HistorySelectedIndexProperty, value); }
        }
        public static readonly StyledProperty<int> HistorySelectedIndexProperty = AvaloniaProperty.Register<ExploreNavigatorBox, int>("HistorySelectedIndex");

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

        public RelayCommand BackCommand => new RelayCommand((s, e) =>
        {
            if (this.Historys.Count > this.HistorySelectedIndex + 1)
            {
                this.HistorySelectedIndex++;
                this.Current = this.Historys[this.HistorySelectedIndex];
            }
        });
        //, (s, e) =>
        //{
        //    return this.Historys.Count > this.HistorySelectedIndex - 2;
        //}

        public RelayCommand ForwardCommand => new RelayCommand((s, e) =>
            {
                if (this.HistorySelectedIndex > 0)
                {
                    this.HistorySelectedIndex--;
                    this.Current = this.Historys[this.HistorySelectedIndex];

                }
            });
        //, (s, e) =>
        //{
        //    return this.HistorySelectedIndex > 0;
        //}

        public RelayCommand UpCommand => new RelayCommand((s, e) =>
            {
                this.Current = _service.GetParents(this.Current).FirstOrDefault();
            });
        //, (s, e) =>
        //{
        //    return _service.GetParents(this.Current).FirstOrDefault() != null;
        //}

    }
}
