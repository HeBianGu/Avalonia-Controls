
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI;
using Avalonia.Layout;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HeBianGu.AvaloniaUI.SnackMessage
{
    public class SnackBoxPresenter : BindableBase
    {
        private ObservableCollection<ISnackItem> _collection = new ObservableCollection<ISnackItem>();
        public ObservableCollection<ISnackItem> Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                RaisePropertyChanged();
            }
        }
    }
}
