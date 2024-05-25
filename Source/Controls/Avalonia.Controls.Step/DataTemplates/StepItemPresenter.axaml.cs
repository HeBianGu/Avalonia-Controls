﻿using Avalonia.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Avalonia.Controls.Step
{
    public class StepItemPresenter : BindableBase, IStepItemPresenter
    {
        private string _displayName;
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                _displayName = value;
                RaisePropertyChanged("DisplayName");
            }
        }

        private double _width = 100;
        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                RaisePropertyChanged();
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged("Message");
            }
        }

        private int _percent;
        public int Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                RaisePropertyChanged("Percent");
            }
        }

        private StepState _state = StepState.Ready;
        /// <summary> -1 错误 0 未开始 1 正在运行 2 运行成功  </summary>
        public StepState State
        {
            get { return _state; }
            set
            {
                _state = value;
                RaisePropertyChanged("State");
            }
        }
    }
}
