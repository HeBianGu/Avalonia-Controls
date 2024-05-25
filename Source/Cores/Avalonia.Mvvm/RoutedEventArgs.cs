﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Interactivity;
using System.Windows;

namespace Avalonia.Mvvm
{
    public class RoutedEventArgs<T> : RoutedEventArgs
    {
        public RoutedEventArgs(T entity)
        {
            Entity = entity;
        }

        public RoutedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
        public RoutedEventArgs(RoutedEvent routedEvent, object source, T entity) : base(routedEvent, source)
        {
            Entity = entity;
        }


        public T Entity { get; set; }
    }
}
