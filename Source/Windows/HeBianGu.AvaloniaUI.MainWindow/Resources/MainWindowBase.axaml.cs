using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.AvaloniaUI.MainWindow
{

    public abstract partial class MainWindowBase : Window,IVisualTransitionableHost
    {
        protected override Type StyleKeyOverride => typeof(MainWindowBase);

        public IVisualTransitionable VisualTransitionable
        {
            get { return (IVisualTransitionable)GetValue(VisualTransitionableProperty); }
            set { SetValue(VisualTransitionableProperty, value); }
        }
        public static readonly StyledProperty<IVisualTransitionable> VisualTransitionableProperty = AvaloniaProperty.Register<MainWindowBase, IVisualTransitionable>("VisualTransitionable");

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            DockPanel dockPanel = e.NameScope.Find<DockPanel>("PART_HeaderDockPanel");
            if (dockPanel == null)
                return;
            dockPanel.PointerPressed += OnPointerPressed;
            dockPanel.DoubleTapped += this.DockPanel_DoubleTapped;

            //dockPanel.AddHandler(DockPanel.DoubleTappedEvent, DockPanel_DoubleTapped, Interactivity.RoutingStrategies.Bubble, true);
        }

        private void DockPanel_DoubleTapped(object? sender, TappedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.Pointer.Type == PointerType.Mouse)
                BeginMoveDrag(e);
        }
        public override async void Show()
        {
            if (this.VisualTransitionable != null)
            {
                //this.IsVisible = false;
                //this.Opacity = 0;
                base.Show();
                if (this is IVisualTransitionableHost host)
                    await host.Show(this);
            }
            else
            {
                base.Show();
            }
        }
    }
}
