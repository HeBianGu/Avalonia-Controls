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

namespace Avalonia.Modules.Operation
{
    public class OperationViewPresenter : Avalonia.Mvvm.BindableBase, IOperationViewPresenter
    {
        private IStringRepository<hi_dd_operation> _r;
        public OperationViewPresenter()
        {
            _r = System.Ioc.GetService<IStringRepository<hi_dd_operation>>();
            this.Collection = _r.GetList().ToObservable();

            _r.Insert(new hi_dd_operation());
        }

        ///// <summary> 说明  </summary>
        //public IRepositoryBindable<hi_dd_operation> ViewModel
        //{
        //    get { return _viewModel; }
        //    set
        //    {
        //        _viewModel = value;
        //        RaisePropertyChanged();
        //    }
        //}


        private ObservableCollection<hi_dd_operation> _collection = new ObservableCollection<hi_dd_operation>();
        /// <summary> 说明  </summary>
        public ObservableCollection<hi_dd_operation> Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                RaisePropertyChanged("Collection");
            }
        }


    }
}
