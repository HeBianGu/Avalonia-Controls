
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Modules.Login;
using HeBianGu.AvaloniaUI.Mvvm;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Modules.Login
{
    public class LoginViewPresenter : BindableBase, ILoginViewPresenter
    {
        private IOptions<LoginOptions> _options;
        public LoginViewPresenter(IOptions<LoginOptions> options)
        {
            _options = options;
            UserName = options.Value.LastUserName;
            Password = options.Value.LastPassword;
        }

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged();
            }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand LoginCommand => new RelayCommand(async (s, e) =>
        {
            if (e is LoginWindow dialog)
            {
                bool result = await Task.Run(() =>
                {
                    try
                    {
                        s.IsBusy = true;
                        s.IsEnabled = false;
                        s.Message = "正在登录...";
                        Thread.Sleep(1000);
                        bool r = Ioc<ILoginService>.Instance.Login(UserName, Password, out string message);
                        if (!r)
                        {
                            s.Message = message;
                            Thread.Sleep(2000);
                            return false;
                        }

                        if (LoginOptions.Instance.Remember)
                        {
                            LoginOptions.Instance.LastUserName = UserName;
                            LoginOptions.Instance.LastPassword = Password;
                        }
                        else
                        {
                            LoginOptions.Instance.LastUserName = null;
                            LoginOptions.Instance.LastPassword = null;
                        }
                        if (LoginOptions.Instance.Save(out message) == false)
                        {
                            s.Message = message;
                            Thread.Sleep(1000);
                        }
                        s.Message = "登录成功";
                        Thread.Sleep(1000);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        s.Message = ex.Message;
                        IocLog.Instance?.Error(ex);
                        return false;
                    }
                    finally
                    {
                        s.IsBusy = false;
                        s.IsEnabled = true;
                        s.Message = "登录";
                    }
                });
                if (result)
                {
                    if (_options.Value.Remember)
                    {
                        _options.Value.LastUserName = UserName;
                        _options.Value.LastPassword = Password;
                    }
                    else
                    {
                        _options.Value.LastUserName = null;
                        _options.Value.LastPassword = null;
                    }
                    dialog.OnLogined();
                }
            }
        })
        { Message = "登录" };
    }
}
