﻿using Avalonia.Controls;
using System;
using System.Windows;

namespace Avalonia.Ioc
{
    public interface IDialog : ILayoutable, ICancelable
    {
        Func<bool> CanSumit { get; set; }
        void Sumit();
        void Close();
        string? Title { get; set; }
        bool? DialogResult { get; set; }
        DialogButton DialogButton { get; set; }
        WindowBase? Owner { get; }
    }
}