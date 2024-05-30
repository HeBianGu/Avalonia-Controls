﻿
using Avalonia.Extensions.Setting;
using Avalonia.Ioc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeBianGu.AvaloniaUI.Modules.Login
{
    [Display(Name = "注册页面设置", GroupName = SettingGroupNames.GroupSystem, Description = "注册页面设置的信息")]
    public class RegistorOptions : IocOptionInstance<RegistorOptions>
    {
        private bool _useMail;
        [DefaultValue(false)]
        [Display(Name = "启用邮箱注册", Description = "启用邮箱注册")]
        public bool UseMail
        {
            get { return _useMail; }
            set
            {
                _useMail = value;
                RaisePropertyChanged();
            }
        }

        private string _serviceAgreementUri;
        [DefaultValue("https://github.com/HeBianGu/WPF-Control")]
        [Display(Name = "应用许可")]
        public string ServiceAgreementUri
        {
            get { return _serviceAgreementUri; }
            set
            {
                _serviceAgreementUri = value;
                RaisePropertyChanged();
            }
        }

        private string _privacypolicyUri;
        [DefaultValue("https://github.com/HeBianGu/WPF-Control")]
        [Display(Name = "隐私策略")]
        public string PrivacypolicyUri
        {
            get { return _privacypolicyUri; }
            set
            {
                _privacypolicyUri = value;
                RaisePropertyChanged();
            }
        }

        private string _mailAccount;
        [Required]
        [DefaultValue("HeBianGu2024@163.com")]
        [Display(Name = "发送验证码的邮箱")]
        [ReadOnly(true)]
        public string MailAccount
        {
            get { return _mailAccount; }
            set
            {
                _mailAccount = value;
                RaisePropertyChanged();
            }
        }

        private string _image;
        [DefaultValue("pack://application:,,,/H.Styles.Default;component/Logo.ico")]
        [Display(Name = "左侧图片")]
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                RaisePropertyChanged();
            }
        }

    }
}
