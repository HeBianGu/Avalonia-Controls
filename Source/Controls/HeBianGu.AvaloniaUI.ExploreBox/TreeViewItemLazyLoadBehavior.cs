using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.Xaml.Interactivity;
using HeBianGu.AvaloniaUI.Mvvm;
using HeBianGu.AvaloniaUI.Treeable;
using System;
using System.Linq;

namespace HeBianGu.AvaloniaUI.ExploreBox
{
    public class TreeViewItemLazyLoadBehavior : Behavior<TreeViewItem>
    {
        public ITreeable Tree { get; set; }

        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            this.RefreshData();
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }


        private void RefreshData()
        {
            if (this.Tree == null)
                return;
            foreach (object item in this.AssociatedObject.ItemsSource)
            {
                if (item is TreeNodeBase<object> node)
                {
                    if (node.IsLoaded)
                        continue;
                    if (node.Nodes.Count > 0)
                        continue;

                    node.IsBuzy = true;
                    System.Collections.Generic.IEnumerable<TreeNodeBase<object>> chidren = this.Tree.GetTreeNodes(node.Model, false).ToList();
                    //node.Nodes = new ObservableCollection<TreeNodeBase<object>>(chidren);
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
