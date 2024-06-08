using Avalonia.Threading;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HeBianGu.AvaloniaUI.Tree
{
    public static class TreeExtension
    {
        public static IEnumerable<ITreeNode> GetTreeNodes(this ITreeable tree, bool isRecursion = true)
        {
            System.Collections.IEnumerable roots = tree.GetChildren(null);
            foreach (object root in roots)
            {
                TreeNodeBase<object> rootNode = new TreeNodeBase<object>(root);
                IEnumerable<TreeNodeBase<object>> childrenNodes = tree.GetTreeNodes(root, isRecursion);
                rootNode.Nodes = new ObservableCollection<TreeNodeBase<object>>(childrenNodes);
                yield return rootNode;
            }
        }

        public static IEnumerable<TreeNodeBase<object>> GetTreeNodes(this ITreeable tree, object parent, bool isRecursion = true)
        {
            foreach (object item in tree.GetChildren(parent))
            {
                TreeNodeBase<object> rootNode = new TreeNodeBase<object>(item);
                if (isRecursion)
                {
                    IEnumerable<TreeNodeBase<object>> childrenNodes = tree.GetTreeNodes(item);
                    rootNode.Nodes.Clear();
                    foreach (var childrenNode in childrenNodes)
                    {
                        Dispatcher.UIThread.InvokeAsync(new Action(() =>
                        {
                            rootNode.Nodes.Add(childrenNode);
                        }), DispatcherPriority.Input);

                    }
                    //rootNode.Nodes = new ObservableCollection<TreeNodeBase<object>>(childrenNodes);
                }
                yield return rootNode;
            }
        }

        public static IEnumerable<TreeNodeBase<object>> Where<T>(this IEnumerable<ITreeNode> treeNodes, Func<T, bool> func)
        {
            foreach (var item in treeNodes)
            {
                if (item is TreeNodeBase<object> node)
                {
                    if (node.Model is T c)
                    {
                        var wheres = node.FindAll(x =>
                        {
                            if (x.Model is T t)
                            {
                                return func?.Invoke(t) != false;
                            }
                            return false;
                        });
                        if (func?.Invoke(c) != false)
                            yield return node;
                        foreach (var where in wheres)
                            yield return where;
                    }
                }
            }
        }
    }

}
