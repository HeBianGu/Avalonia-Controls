﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using System.Collections;
using System.Windows;

namespace HeBianGu.Avalonia.Core.Ioc
{
    public class DeleteCommand : IocMarkupCommandBase
    {
        public override void Execute(object parameter)
        {
            //if (parameter is Control element)
            //{
            //    if (element.DataContext == null)
            //        return;
            //    ItemsControl items = element.GetParent<ItemsControl>();
            //    if (items.ItemsSource is IList list)
            //        list.Remove(element.DataContext);
            //    else
            //        items.Items.Remove(element.DataContext);
            //}
        }

        //public override bool CanExecute(object parameter)
        //{
        //    if (parameter is Control element)
        //    {
        //        if (element.DataContext == null)
        //            return false;
        //        ItemsControl items = element.GetParent<ItemsControl>();
        //        if (items == null)
        //            return false;
        //        return true;
        //    }
        //    return false;
        //}
    }
}
