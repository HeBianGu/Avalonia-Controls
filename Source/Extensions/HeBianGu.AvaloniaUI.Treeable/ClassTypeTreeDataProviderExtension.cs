﻿using Avalonia.Markup.Xaml;
using HeBianGu.AvaloniaUI.Mvvm;
using System;

namespace HeBianGu.AvaloniaUI.Treeable
{
    public class ClassTypeTreeDataProviderExtension : MarkupExtension
    {
        public Type Type { get; set; }
        public bool IsRecursion { get; set; } = false;
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            ClassTypeTree tree = new ClassTypeTree(this.Type);
            System.Collections.Generic.IEnumerable<ITreeNode> result = tree.GetTreeNodes(this.IsRecursion);
            return result;
        }
    }

}
