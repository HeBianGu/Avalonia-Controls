using HeBianGu.AvaloniaUI.Mvvm;
using System.Collections.ObjectModel;

namespace Avalonia.App.WeChat.Models
{
    public abstract class TabItemBindableBase<T> : DisplayBindableBase, ITabItem
    {
        private ObservableCollection<T> _collection = new ObservableCollection<T>();
        /// <summary> 说明  </summary>
        public ObservableCollection<T> Collection
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
