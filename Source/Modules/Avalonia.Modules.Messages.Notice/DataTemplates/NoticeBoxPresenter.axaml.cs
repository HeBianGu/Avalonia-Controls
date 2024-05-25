using Avalonia.Ioc;
using Avalonia.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Modules.Messages.Notice
{
    public class NoticeBoxPresenter : BindableBase
    {
        private ObservableCollection<INoticeItem> _collection = new ObservableCollection<INoticeItem>();
        public ObservableCollection<INoticeItem> Collection
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
