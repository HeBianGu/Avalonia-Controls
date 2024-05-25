// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using Avalonia.Markup.Xaml;

namespace Avalonia.Mvvm
{
    public partial class SelectBindable<T> : ModelBindable<T>, ISelectBindable
    {
        public SelectBindable(T t) : base(t)
        {

        }

        private bool _isSelected;
        [Browsable(false)]
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
            }
        }

    }
}
