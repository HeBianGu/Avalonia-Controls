// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;

namespace HeBianGu.AvaloniaUI.Repository
{
    public abstract class RepositoryViewPresenterBase<T> : BindableBase where T : StringEntityBase, new()
    {
        private IRepositoryBindable<T> _vm;
        public RepositoryViewPresenterBase()
        {
            _vm = System.Ioc.GetService<IRepositoryBindable<T>>();
            _vm.RefreshData();
        }
        /// <summary> 说明  </summary>
        public IRepositoryBindable<T> ViewModel
        {
            get { return _vm; }
            set
            {
                _vm = value;
                RaisePropertyChanged();
            }
        }
    }
}
