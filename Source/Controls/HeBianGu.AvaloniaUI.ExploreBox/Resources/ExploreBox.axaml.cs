using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
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
    [TemplatePart(Name = "PART_NavigatorBox")]
    [TemplatePart(Name = "PART_DataGrid")]
    public class ExploreBox : TemplatedControl
    {
        protected override Type StyleKeyOverride => typeof(ExploreBox);

        //protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        //{
        //    base.OnPropertyChanged(change);
        //    if (change.Property == ExploreNavigatorBox.CurrentProperty)
        //    {
        //        this.RefreshData();
        //    }
        //}

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            this._dataGrid = e.NameScope.Find<DataGrid>("PART_DataGrid");
            this._navigaotrBox = e.NameScope.Find<ExploreNavigatorBox>("PART_NavigatorBox");

            this._navigaotrBox.GetObservable(ExploreNavigatorBox.CurrentProperty).Subscribe(x =>
            {
                this.RefreshData(x);
            });

            this._dataGrid.DoubleTapped += this.DataGrid_DoubleTapped;
        }

        private void DataGrid_DoubleTapped(object sender, Avalonia.Input.TappedEventArgs e)
        {
            if (this._dataGrid.SelectedItem == null)
                return;

            if (_tree.IsFile(this._dataGrid.SelectedItem))
                return;
            this._navigaotrBox.Current = this._dataGrid.SelectedItem;
        }

        private DataGrid _dataGrid;
        private ExploreNavigatorBox _navigaotrBox;

        private IExploreTree _tree = new ExploreTree();

        private void RefreshData(object current)
        {
            var source = _tree.GetChildren(current);
            this._dataGrid.ItemsSource = source;
        }
    }
}
