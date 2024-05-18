﻿using System.ComponentModel;

namespace HeBianGu.Avalonia.Core.Mvvm
{
    public class DisplayBindable<T> : DisplayBindableBase
    {
        public DisplayBindable(T t)
        {
            Model = t;

        }

        private T _model;
        [Browsable(false)]
        public T Model
        {
            get { return _model; }
            set
            {
                _model = value;
                RaisePropertyChanged("Model");
            }
        }
    }

}
