﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Extensions.Geometry;
using HeBianGu.Avalonia.Core.Ioc;

namespace Avalonia.Modules.Messages.Snack
{
    public class ProgressMessagePresenter : SnackMessagePresenterBase, IPercentSnackItem
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