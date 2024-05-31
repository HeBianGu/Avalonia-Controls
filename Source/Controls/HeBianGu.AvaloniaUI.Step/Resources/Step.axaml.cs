// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control
using Avalonia;
using Avalonia.Controls;
using System;

namespace HeBianGu.AvaloniaUI.Step
{
    public class Step : ItemsControl
    {
        public Step()
        {

        }
        protected override Type StyleKeyOverride => typeof(Step);

        public double LineWidth
        {
            get { return (double)GetValue(LineWidthProperty); }
            set { SetValue(LineWidthProperty, value); }
        }

        public static readonly StyledProperty<double> LineWidthProperty =
            AvaloniaProperty.Register<Step, double>("LineWidth");
    }
}
