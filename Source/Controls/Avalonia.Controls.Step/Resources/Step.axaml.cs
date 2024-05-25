// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control




using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Extensions.Application;
using Avalonia.Interactivity;
using Avalonia.Ioc;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Avalonia.Controls.Step
{
    public class Step : ListBox
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
