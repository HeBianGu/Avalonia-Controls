using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
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
    [TemplatePart(Name = "PART_Tree")]
    [TemplatePart(Name = "PART_NavigatorBox")]
    [TemplatePart(Name = "PART_DataGrid")]
    public class ExploreBox : TemplatedControl
    {
        private IExploreTree _tree = new ExploreTree();
        private ExploreTreeView _treeView;
        private DataGrid _dataGrid;
        private ExploreNavigatorBox _navigaotrBox;
        protected override Type StyleKeyOverride => typeof(ExploreBox);
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            this._dataGrid = e.NameScope.Find<DataGrid>("PART_DataGrid");
            this._navigaotrBox = e.NameScope.Find<ExploreNavigatorBox>("PART_NavigatorBox");
            this._treeView = e.NameScope.Find<ExploreTreeView>("PART_Tree");
            this._navigaotrBox.GetObservable(ExploreNavigatorBox.CurrentProperty).Subscribe(x =>
            {
                this.RefreshData(x);
            });
            this._navigaotrBox.GetObservable(ExploreNavigatorBox.SearchPatternProperty).Subscribe(x =>
            {
                this._tree.SearchPattern = $"*{x}*";
                this.RefreshData(this._navigaotrBox.Current);
            });
            this._treeView.SelectionChanged += this._treeView_SelectionChanged;
            this._dataGrid.DoubleTapped += this.DataGrid_DoubleTapped;
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == ExploreBox.SearchPatternProperty)
            {
                this.RefreshData(this._navigaotrBox.Current);
            }
        }

        private void _treeView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this._treeView.SelectedItem is IModelBindable bindable)
                this._navigaotrBox.Current = bindable.GetModel();
            else
                this._navigaotrBox.Current = this._treeView.SelectedItem;
            this._navigaotrBox.HistorySelectedIndex = 0;
        }

        private void DataGrid_DoubleTapped(object sender, Avalonia.Input.TappedEventArgs e)
        {
            if (this._dataGrid.SelectedItem == null)
                return;

            if (_tree.IsFile(this._dataGrid.SelectedItem))
                return;
            this._navigaotrBox.Current = this._dataGrid.SelectedItem;
            this._navigaotrBox.HistorySelectedIndex = 0;
        }

        private void RefreshData(object current)
        {
            var source = _tree.GetChildren(current);
            this._dataGrid.ItemsSource = source;
        }

        public string SearchPattern
        {
            get { return (string)GetValue(SearchPatternProperty); }
            set { SetValue(SearchPatternProperty, value); }
        }
        public static readonly StyledProperty<string> SearchPatternProperty = AvaloniaProperty.Register<ExploreBox, string>("SearchPattern");
    }
}
