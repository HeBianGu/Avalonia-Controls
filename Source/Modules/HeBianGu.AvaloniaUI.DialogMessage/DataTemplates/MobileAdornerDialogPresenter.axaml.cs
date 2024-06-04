
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.AvaloniaUI.DialogMessage
{
    public class MobileAdornerDialogPresenter : AdornerDialogPresenterBase
    {
        public MobileAdornerDialogPresenter()
        {
            this.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.VerticalAlignment = VerticalAlignment.Stretch;
            this.HorizontalContentAlignment = HorizontalAlignment.Stretch;
            this.VerticalContentAlignment = VerticalAlignment.Stretch;
        }
    }
}
