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
    public class ExploreTreeView : TreeView
    {
        protected override Type StyleKeyOverride => typeof(ExploreTreeView);

        protected override Control CreateContainerForItemOverride(object item, int index, object recycleKey)
        {
            return new ExploreTreeViewItem();
        }
    }

    public class ExploreTreeViewItem : TreeViewItem
    {
        protected override Type StyleKeyOverride => typeof(TreeViewItem);
        public ExploreTreeViewItem()
        {
            this.Loaded += (l, k) =>
            {
                this.RefreshData();
            };

        }
        public ITreeable Tree { get; set; } = new ExploreTree() { UseDirectoryOnly = true };
        private void RefreshData()
        {
            if (this.Tree == null)
                return;
            foreach (object item in this.ItemsSource)
            {
                if (item is TreeNodeBase<object> node)
                {
                    if (node.IsLoaded)
                        continue;
                    if (node.Nodes.Count > 0)
                        continue;

                    node.IsBuzy = true;
                    System.Collections.Generic.IEnumerable<TreeNodeBase<object>> chidren = this.Tree.GetTreeNodes(node.Model, false).ToList();
                    node.Nodes.Clear();
                    foreach (var child in chidren)
                    {
                        Dispatcher.UIThread.InvokeAsync(new Action(() =>
                        {
                            node.Nodes.Add(child);
                        }), DispatcherPriority.Input);

                    }
                    System.Diagnostics.Debug.WriteLine(node.Nodes.Count);
                    node.IsLoaded = true;
                }
            }
        }
    }
}
