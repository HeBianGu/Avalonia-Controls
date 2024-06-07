// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;

namespace HeBianGu.AvaloniaUI.Animations
{
    public class TransitionAttach
    {
        public static readonly AttachedProperty<ITransition> TransitionProperty =
AvaloniaProperty.RegisterAttached<TransitionAttach, Control, ITransition>("Transition");

        public static ITransition GetTransition(Control element)
        {
            return element.GetValue(TransitionProperty);
        }

        public static void SetTransition(Control element, ITransition value)
        {
            element.SetValue(TransitionProperty, value);
        }
    }
}
