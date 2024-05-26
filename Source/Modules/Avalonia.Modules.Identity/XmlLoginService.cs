﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control




using Avalonia.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Avalonia.Modules.Identity
{
    internal class XmlLoginService : ILoginService
    {
        public string Path { get; } = System.IO.Path.Combine(AppPaths.Instance.Default, nameof(XmlLoginService) + ".xml");

        private List<IdentityData> _datas = new List<IdentityData>();

        public XmlLoginService()
        {
            _datas = IocSerializer.Instance.Load<List<IdentityData>>(this.Path);
        }

        public IUser User { get; private set; }


        public bool Login(string name, string password, out string message)
        {
            if (string.IsNullOrEmpty(name))
            {
                message = "用户名不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                message = "密码不能为空";
                return false;
            }

            IdentityData user = this._datas?.FirstOrDefault(l => l.UserName == name);

            if (user == null)
            {
                message = "用户名不存在，请先注册";
                return false;
            }

            user = this._datas.FirstOrDefault(l => l.UserName == name && l.Password == password);

            if (user == null)
            {
                message = "密码不正确";
                return false;
            }

            Thread.Sleep(1000);
            message = "登录成功";
            this.User = new User() { Account = name };
            //Operationner.Instance?.Log("用户登录成功", message);
            //OparationViewPresenterProxy.Instance?.Log(message);
            return true;
        }

        public bool Logout(out string message)
        {
            message = null;
            this.User = null;
            return true;
        }
    }

    internal class XmlRegisterService : IRegisterService
    {
        public string Path { get; } = System.IO.Path.Combine(AppPaths.Instance.Config, nameof(XmlLoginService) + ".xml");

        private List<IdentityData> _datas = new List<IdentityData>();

        public XmlRegisterService()
        {
            _datas = IocSerializer.Instance.Load<List<IdentityData>>(this.Path);
        }

        private Random random = new Random();
        public bool Register(string mail, string phone, string password, out string message)
        {
            if (string.IsNullOrEmpty(phone))
            {
                message = "用户名不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                message = "密码不能为空";
                return false;
            }

            IdentityData user = this._datas?.FirstOrDefault(l => l.UserName == phone);

            if (user != null)
            {
                message = "用户名已经注册";
                return false;
            }

            if (this._datas == null)
                this._datas = new List<IdentityData>();

            IdentityData data = new IdentityData() { UserName = phone, Password = password };

            this._datas.Add(data);
            IocSerializer.Instance.Save(this.Path, this._datas);

            Thread.Sleep(1000);
            message = "注册成功，请重新登录";
            //Operationner.Instance?.Log("注册用户成功", message);
            //OparationViewPresenterProxy.Instance?.Log(message);

            return true;
        }

        public bool ResetPassword(string mail, string phone, string password, out string message)
        {
            Thread.Sleep(2000);
            message = "操作超时";
            //OparationViewPresenterProxy.Instance?.Log("修改成功");
            return true;
        }

        public string GetPhoneVerificationCode(string phone, out string message)
        {
            message = "操作超时";
            return random.Next(100000, 999999).ToString();
        }

        public string GetVerificationCode(out string message)
        {
            message = "操作超时";
            return random.Next(1000, 9999).ToString();
        }
    }

    public class IdentityData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
