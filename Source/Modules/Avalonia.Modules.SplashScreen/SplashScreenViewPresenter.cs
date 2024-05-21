using HeBianGu.Avalonia.Core.Ioc;
using HeBianGu.Avalonia.Core.Mvvm;

namespace Avalonia.Modules.SplashScreen
{
    public class SplashScreenViewPresenter : BindableBase, ISplashScreenViewPresenter
    {
        private string _message;
        /// <summary> 说明  </summary>
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
        }
    }
}
