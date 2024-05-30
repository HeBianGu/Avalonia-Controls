using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.Platform;
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.AvaloniaUI.DialogWindow
{
    public partial class DialogWindow : Window, IDialog
    {
        protected override Type StyleKeyOverride => typeof(DialogWindow);

        public DialogWindow()
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
        protected override void OnClosing(WindowClosingEventArgs e)
        {
            if (this.CanSumit?.Invoke() == false)
            {
                e.Cancel = true;
                return;
            }
            base.OnClosing(e);
        }
        public bool? DialogResult { get; set; }

        public void Sumit()
        {
            this.DialogResult = true;
            this.Close();
        }

        public Func<bool> CanSumit { get; set; }

        public bool IsCancel => this.DialogResult == false;

        public ControlTemplate BottomTemplate
        {
            get { return (ControlTemplate)GetValue(BottomTemplateProperty); }
            set { SetValue(BottomTemplateProperty, value); }
        }

        public DialogButton DialogButton { get; set; } = DialogButton.Sumit;


        public static readonly StyledProperty<ControlTemplate> BottomTemplateProperty =
            AvaloniaProperty.Register<DialogWindow, ControlTemplate>("BottomTemplate");

        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    if (SizeToContent == SizeToContent.WidthAndHeight && System.Windows.Shell.WindowChrome.GetWindowChrome(this) != null)
        //    {
        //        InvalidateMeasure();
        //    }
        //}
    }

    public partial class DialogWindow : Window
    {
        //public static ResourceKey GetResourceKey(DialogButton dialogButton)
        //{
        //    switch (dialogButton)
        //    {
        //        case DialogButton.Sumit:
        //            return DialogKeys.Sumit;
        //        case DialogButton.None:
        //            return DialogKeys.None;
        //        case DialogButton.Cancel:
        //            return DialogKeys.Cancel;
        //        case DialogButton.SumitAndCancel:
        //            return DialogKeys.SumitAndCancel;
        //        default:
        //            return DialogKeys.Sumit;
        //    }
        //}

        public static async Task<bool?> ShowPresenter(object presenter, Action<IDialog> action = null, Func<bool> canSumit = null)
        {
            DialogWindow dialog = new DialogWindow();
            dialog.Content = presenter;
            dialog.Width = 400;
            dialog.SizeToContent = SizeToContent.Height;
            dialog.CanSumit = canSumit;
            action?.Invoke(dialog);
            dialog.Title = dialog.Title ?? presenter.GetType().GetCustomAttribute<DisplayAttribute>()?.Name ?? "提示";
            //ResourceKey key = GetResourceKey(dialog.DialogButton);
            //dialog.Style = Application.Current.FindResource(key) as Style;
            var owner = dialog.Owner as Window ?? Avalonia.Application.Current.GetMainWindow();
            if (owner?.IsLoaded == true)
            {
                dialog.Owner = owner;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else
            {
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            await dialog.ShowDialog(owner);
            return dialog.DialogResult;
        }

        public static T ShowAction<P, T>(P presenter, Func<IDialog, P, T> func, Action<IDialog> action = null)
        {
            DialogWindow dialog = new DialogWindow();
            dialog.Content = presenter;
            dialog.Width = 500;
            dialog.MinHeight = 150;
            dialog.SizeToContent = SizeToContent.Height;
            action?.Invoke(dialog);
            dialog.Title = dialog.Title ?? presenter.GetType().GetCustomAttribute<DisplayAttribute>()?.Name ?? "提示";
            //dialog.Style = Application.Current.FindResource(GetResourceKey(dialog.DialogButton)) as Style;
            var owner = dialog.Owner ?? Avalonia.Application.Current.GetMainWindow();
            if (owner?.IsLoaded == true)
            {
                dialog.Owner = owner;
                dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }
            else
            {
                dialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            T result = default;
            dialog.Loaded += (l, k) =>
            {
                if (func != null)
                {
                    Task.Run(() =>
                    {
                        result = func.Invoke(dialog, presenter);
                        if (dialog.DialogResult == null)
                            dialog.DialogResult = true;
                    });
                }
            };
            //dialog.ShowDialog();
            return result;
        }
    }
}
