﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace HeBianGu.AvaloniaUI.Mvvm
{
    public partial class TreeNodeBase<T> : SelectBindable<T>, ITreeNode, ISearchable
    {
        public TreeNodeBase(T t) : base(t)
        {

        }

        public TreeNodeBase<T> TreeNodeEntity { get; set; }


        private bool? _isChecked = false;
        public bool? IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                RaisePropertyChanged();
                RefreshParentCheckState();
                RefreshChildrenCheckState();
            }
        }

        private bool _isCheckable = false;
        public bool IsCheckable
        {
            get { return _isCheckable; }
            set
            {
                _isCheckable = value;
                RaisePropertyChanged();
            }
        }


        private void RefreshParentCheckState()
        {
            if (Parent == null)
                return;

            bool allChecked = Parent.Nodes.All(l => l.IsChecked == true);
            if (allChecked)
            {
                Parent.CheckOnlyCurrent(true);
                Parent.RefreshParentCheckState();
                return;
            }

            bool allUnChecked = Parent.Nodes.All(l => l.IsChecked == false);
            if (allUnChecked)
            {
                Parent.CheckOnlyCurrent(false);
                Parent.RefreshParentCheckState();
                return;
            }

            Parent.CheckOnlyCurrent(null);
            Parent.RefreshParentCheckState();

        }

        private void RefreshChildrenCheckState()
        {
            foreach (TreeNodeBase<T> item in Nodes)
            {
                item.CheckOnlyCurrent(IsChecked);
                item.RefreshChildrenCheckState();
            }
        }

        private void CheckOnlyCurrent(bool? value)
        {
            _isChecked = value;
            RaisePropertyChanged("IsChecked");
        }

        private void SetIsVisible(bool value)
        {
            _visibility = value;
            RaisePropertyChanged("Visibility");
        }

        private void SetParentVisible(bool value)
        {
            if (Parent == null) return;

            if (Visibility)
            {
                //  Do ：递归设置父节点选中
                Parent.SetIsVisible(true);
                Parent.SetParentVisible(true);
            }
            else
            {

                bool isAllFalse = !Parent.Nodes.All(l => !l.Visibility);
                Parent.SetIsVisible(isAllFalse);
                Parent.SetParentVisible(isAllFalse);
            }
        }

        private void SetChildVisible(bool value)
        {
            foreach (TreeNodeBase<T> item in Nodes)
            {
                item.SetIsVisible(value);
                item.SetChildVisible(value);
            }
        }
        private bool _visibility;
        public bool Visibility
        {
            get { return _visibility; }
            set
            {
                _visibility = value;
                RaisePropertyChanged("Visibility");
                //this.SetParentVisible(value == Visibility.Visible);
                //this.SetChildVisible(value == Visibility.Visible);
            }
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                _isExpanded = value;
                RaisePropertyChanged("IsExpanded");
            }
        }

        public bool IsLoaded { get; set; }

        public TreeNodeBase<T> Parent { get; set; }

        private ObservableCollection<TreeNodeBase<T>> _nodes = new ObservableCollection<TreeNodeBase<T>>();

        public ObservableCollection<TreeNodeBase<T>> Nodes
        {
            get { return _nodes; }
            set
            {
                _nodes = value;
                RaisePropertyChanged();
            }
        }

        public void AddNode(TreeNodeBase<T> node)
        {
            node.Parent = this;
            Nodes.Add(node);
        }

        public void Foreach(Action<TreeNodeBase<T>> action)
        {
            foreach (TreeNodeBase<T> node in Nodes)
            {
                action?.Invoke(node);
                node.Foreach(action);
            }
        }

        public IEnumerable<TreeNodeBase<T>> FindAll(Predicate<TreeNodeBase<T>> action = null)
        {
            foreach (TreeNodeBase<T> node in Nodes)
            {
                if (action?.Invoke(node) != false)
                    yield return node;
                IEnumerable<TreeNodeBase<T>> finds = node.FindAll(action);

                foreach (TreeNodeBase<T> item in finds)
                {
                    yield return item;
                }
            }
        }


        public IEnumerable<TreeNodeBase<T>> FindAllParent(Predicate<TreeNodeBase<T>> action = null)
        {
            if (Parent != null)
            {
                if (action?.Invoke(Parent) != false)
                    yield return Parent;
                Parent.FindAllParent(action);
            }
        }

        public override bool Filter(string txt)
        {
            foreach (TreeNodeBase<T> item in Nodes)
            {
                item.Filter(txt);
            }
            bool r = Nodes.Any(x => x.Visibility) || base.Filter(txt);
            Visibility = r;
            return r;
        }
    }
}
