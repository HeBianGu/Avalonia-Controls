// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Core.Mvvm;
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
