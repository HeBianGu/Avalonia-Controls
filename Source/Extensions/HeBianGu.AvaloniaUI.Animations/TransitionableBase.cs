// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Animations
{
    public abstract class TransitionableBase : IVisualTransitionable
    {
        public TimeSpan ShowDuration { get; set; } = TimeSpan.FromMilliseconds(500);
        public TimeSpan CloseDuration { get; set; } = TimeSpan.FromMilliseconds(500);
        public double From { get; set; } = 0d;
        public double To { get; set; } = 1d;

        public abstract Task Close(Visual visual);

        public abstract Task Show(Visual visual);
    }
}
