using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.Platform;
using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Extensions.ApplicationBase;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace Avalonia.Windows.Main
{
    public partial class MainWindow : Window
    {
        protected override Type StyleKeyOverride => typeof(MainWindow);

        public MainWindow()
        {
            this.PointerPressed += OnPointerPressed;

        }

        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.Pointer.Type == PointerType.Mouse)
            {

                this.BeginMoveDrag(e);
            }
        }

        public ControlTemplate BottomTemplate
        {
            get { return (ControlTemplate)GetValue(BottomTemplateProperty); }
            set { SetValue(BottomTemplateProperty, value); }
        }

        public DialogButton DialogButton { get; set; } = DialogButton.Sumit;


        public static readonly StyledProperty<ControlTemplate> BottomTemplateProperty =
            AvaloniaProperty.Register<MainWindow, ControlTemplate>("BottomTemplate");
    }
}
