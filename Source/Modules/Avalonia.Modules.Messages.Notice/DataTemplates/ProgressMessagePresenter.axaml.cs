﻿using Avalonia.Extensions.Geometry;
using Avalonia.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Modules.Messages.Notice
{
    public class ProgressMessagePresenter : MessagePresenterBase, IPercentNoticeItem
    {
        public ProgressMessagePresenter()
        {
            this.Geometry = GeometryFactory.Create(Geometrys.Wait);
        }
        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                RaisePropertyChanged();
            }
        }
    }
}