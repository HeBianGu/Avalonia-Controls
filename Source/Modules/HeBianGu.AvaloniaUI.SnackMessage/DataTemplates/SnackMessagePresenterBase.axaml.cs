﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Ioc;
using Avalonia.Media;
using Avalonia.Mvvm;
using System;

namespace HeBianGu.AvaloniaUI.SnackMessage
{
    public abstract class SnackMessagePresenterBase : BindableBase, ISnackItem
    {
        public string Time { get; } = DateTime.Now.ToString("HH:mm:ss");
        public Geometry Geometry { get; set; }
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
        }
        public int Level { get; set; }

        private Brush _iconBrush;
        public Brush IconBrush
        {
            get { return _iconBrush; }
            set
            {
                _iconBrush = value;
                RaisePropertyChanged();
            }
        }
    }
}
