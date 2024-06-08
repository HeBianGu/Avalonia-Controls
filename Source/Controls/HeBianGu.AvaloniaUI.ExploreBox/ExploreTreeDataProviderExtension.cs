using System;
using Avalonia.Markup.Xaml;
using HeBianGu.AvaloniaUI.Mvvm;
using HeBianGu.AvaloniaUI.Tree;

namespace HeBianGu.AvaloniaUI.ExploreBox
{
    public class ExploreTreeDataProviderExtension : MarkupExtension
    {
        public string Root { get; set; }
        public bool IsRecursion { get; set; } = false;

        public bool UseDirectoryOnly { get; set; } = false;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            ExploreTree tree = new ExploreTree()
            {
                Root = Root,
                UseDirectoryOnly = this.UseDirectoryOnly,
            };
            System.Collections.Generic.IEnumerable<ITreeNode> result = tree.GetTreeNodes(IsRecursion);
            return result;
        }
    }

}
