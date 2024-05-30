// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Data;
using Avalonia.Extensions.Repository;
using Avalonia.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HeBianGu.AvaloniaUI.Modules.Operation
{
    public class OperationViewPresenter : RepositoryViewPresenterBase<hi_dd_operation>, IOperationViewPresenter
    {
        public OperationViewPresenter()
        {
            this.ViewModel.RefreshData();
        }
        //private IStringRepository<hi_dd_operation> _r;
        //public OperationViewPresenter()
        //{
        //    _r = System.Ioc.GetService<IStringRepository<hi_dd_operation>>();
        //    this.Collection = _r.GetList().ToObservable();
        //}

        //private ObservableCollection<hi_dd_operation> _collection = new ObservableCollection<hi_dd_operation>();
        ///// <summary> 说明  </summary>
        //public ObservableCollection<hi_dd_operation> Collection
        //{
        //    get { return _collection; }
        //    set
        //    {
        //        _collection = value;
        //        RaisePropertyChanged("Collection");
        //    }
        //}
    }
}
