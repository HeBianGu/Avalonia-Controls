
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls;
using Avalonia.Ioc;
using Avalonia.Mvvm;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Avalonia.Layout;
using Avalonia.Extensions.Application;
using System.Collections.ObjectModel;

namespace Avalonia.Modules.Messages.Snack
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
