using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.Platform;
using Avalonia.Ioc;
using Avalonia.Extensions.Application;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Avalonia.Controls.Primitives;

namespace Avalonia.Windows.Main
{
    public abstract partial class MainWindowBase : Window
    {
        protected override Type StyleKeyOverride => typeof(MainWindowBase);

        public MainWindowBase()
        {

        }
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
    }
}
