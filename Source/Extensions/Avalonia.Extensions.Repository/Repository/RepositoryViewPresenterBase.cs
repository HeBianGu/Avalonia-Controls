// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using Avalonia.Ioc;

namespace Avalonia.Extensions.Repository
{
    public abstract class RepositoryViewPresenterBase<T> : Avalonia.Mvvm.BindableBase where T : StringEntityBase, new()
    {
        private IRepositoryBindable<T> _vm;
        public RepositoryViewPresenterBase()
        {
            _vm = System.Ioc.GetService<IRepositoryBindable<T>>();
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
