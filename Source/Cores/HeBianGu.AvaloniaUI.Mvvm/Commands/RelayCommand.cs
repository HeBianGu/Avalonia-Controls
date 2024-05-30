﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Xml.Serialization;

namespace HeBianGu.AvaloniaUI.Mvvm
{
    public interface IRelayCommand : ICommand
    {
        string Name { get; set; }
        bool IsBusy { get; set; }
        bool IsEnabled { get; set; }
        bool IsIndeterminate { get; set; }
        bool IsVisible { get; set; }
        //ILogService Logger { get; }
        string Message { get; set; }
        double Percent { get; set; }

        string GroupName { get; set; }
    }

    public class RelayCommand<T> : ICommand
    {
        public Action<T> ExecuteCommand { get; private set; }
        public Predicate<T> CanExecuteCommand { get; private set; }

        public RelayCommand(Action<T> executeCommand, Predicate<T> canExecuteCommand)
        {
            ExecuteCommand = executeCommand;
            CanExecuteCommand = canExecuteCommand;
        }

        public RelayCommand(Action<T> executeCommand)
            : this(executeCommand, null) { }

        public void Execute(object parameter)
        {
            if (ExecuteCommand != null) ExecuteCommand((T)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteCommand == null || CanExecuteCommand((T)parameter);
        }


        public event EventHandler CanExecuteChanged;
    }

    public class RelayCommand : ICommand, INotifyPropertyChanged, IRelayCommand
    {
        protected Action<object> _action;
        protected readonly Predicate<object> _canExecute;

        protected Action<IRelayCommand, object> _actionCommand;
        protected readonly Func<IRelayCommand, object, bool> _canExecuteCommand;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        public RelayCommand(Action<IRelayCommand, object> action)
        {
            _actionCommand = action;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) : this(execute)
        {
            _canExecute = canExecute ?? (x => true);
        }

        public RelayCommand(Action<IRelayCommand, object> execute, Func<IRelayCommand, object, bool> canExecute) : this(execute)
        {
            _canExecuteCommand = canExecute ?? ((x, y) => true);
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            if (_canExecuteCommand != null)
                return _canExecuteCommand(this, parameter);
            return true;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary> 执行命令 </summary>
        public virtual void Execute(object parameter)
        {
            //#if DEBUG
            //            if (!string.IsNullOrEmpty(this.Name))
            //                this.Logger?.Debug(this.Name);
            //#endif
            if (_action != null)
                _action(parameter);

            if (_actionCommand != null)
            {
                //  Do ：应用async方式try会直接 finally IsBusy不起作用了
                //try
                //{
                //this.IsBusy = true;
                _actionCommand(this, parameter);
                //}
                //catch (Exception ex)
                //{
                //    System.Diagnostics.Trace.Assert(false);
                //    this.Logger?.Error(ex);
                //}
                //finally
                //{
                //    this.IsBusy = false;
                //}
            }
        }

        public static implicit operator RelayCommand(Action<object> action)
        {
            return new RelayCommand(action);
        }

        public static implicit operator RelayCommand(Action<IRelayCommand, object> action)
        {
            return new RelayCommand(action);
        }

        #region - INotifyPropertyChanged -

        public string Name { get; set; }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                RaisePropertyChanged();
            }
        }

        private bool _isVisible = true;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                RaisePropertyChanged();
            }
        }

        private bool _isIndeterminate = true;
        public bool IsIndeterminate
        {
            get { return _isIndeterminate; }
            set
            {
                _isIndeterminate = value;
                RaisePropertyChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        private double _percent;
        public double Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                RaisePropertyChanged();
            }
        }

        private string _message = "正在运行";
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
        }

        private string _groupName;
        [XmlIgnore]
        [Browsable(false)]
        public string GroupName
        {
            get { return _groupName; }
            set
            {
                _groupName = value;
                RaisePropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        /// <summary> 刷新命令可执行状态 (会调用CanExecute方法) </summary>
        public void Refresh()
        {
            //CommandManager.InvalidateRequerySuggested();
        }
    }
}
