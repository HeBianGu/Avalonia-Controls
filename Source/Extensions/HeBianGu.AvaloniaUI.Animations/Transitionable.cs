// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;

namespace HeBianGu.AvaloniaUI.Animations
{
    public class Transitionable
    {
        public static readonly AttachedProperty<ITransition> TransitionableProperty =
AvaloniaProperty.RegisterAttached<Transitionable, Control, ITransition>("Transitionable");

        public static ITransition GetTransitionable(Control element)
        {
            return element.GetValue(TransitionableProperty);
        }

        public static void SetTransitionable(Control element, ITransition value)
        {
            element.SetValue(TransitionableProperty, value);
        }
    }
}
