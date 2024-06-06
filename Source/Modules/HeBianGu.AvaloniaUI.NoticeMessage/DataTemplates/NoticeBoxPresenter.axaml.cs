
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.NoticeMessage
{
    public class NoticeBoxPresenter : BindableBase, IPresenter
    {
        private ObservableCollection<INoticeItemPresenter> _collection = new ObservableCollection<INoticeItemPresenter>();
        public ObservableCollection<INoticeItemPresenter> Collection
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
