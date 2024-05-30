using Avalonia;
using Avalonia.Threading;
using System;
using System.ComponentModel;
using System.Windows;

namespace HeBianGu.AvaloniaUI.Mvvm
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public BindableBase()
        {
            Init();
        }

        protected virtual void Init()
        {

        }

        #region - MVVM -

        private bool _isRefreshing;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
