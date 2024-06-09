using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Markup.Xaml;
using HeBianGu.AvaloniaUI.Mvvm;
using HeBianGu.AvaloniaUI.Treeable;

namespace HeBianGu.AvaloniaUI.ExploreBox
{
    public class ExploreTreeDataProviderExtension : MarkupExtension
    {
        public string Root { get; set; } = "我的电脑";

        public bool IsRecursion { get; set; } = false;

        public bool UseDirectoryOnly { get; set; } = false;

        public bool UseMyComputer { get; set; } = true;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.GetTreeNodes();
        }

        public IEnumerable<ITreeNode> GetTreeNodes()
        {
            ExploreTree tree = new ExploreTree()
            {
                Root = Root,
                UseDirectoryOnly = this.UseDirectoryOnly,
            };
            System.Collections.Generic.IEnumerable<ITreeNode> result = tree.GetTreeNodes(IsRecursion);
            if (this.UseMyComputer)
            {
                var computer = new TreeNodeBase<object>(new CustomPath() { Name = "我的电脑" });
                foreach (var item in result)
                {
                    computer.Nodes = result.OfType<TreeNodeBase<object>>().ToObservable();
                }
                computer.IsExpanded = true;
                yield return computer;

            }
            else
            {
                foreach (var item in result)
                {
                    yield return item;
                }
            }
        }

    }
}
