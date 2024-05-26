﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using Avalonia.Controls.Form;
using Avalonia.Ioc;
using Avalonia.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Avalonia.Modules.Identity
{
    public class User : SelectBindable<hi_dd_user>, IUser
    {
        public User() : base(new hi_dd_user())
        {

        }
        public User(hi_dd_user model) : base(model)
        {
            Role = new Role(model.Role);
        }

        [Browsable(false)]
        public string ID => Model.ID;

        [Required]
        [Display(Name = "用户名称")]
        public string Name
        {
            get { return Model.Name; }
            set
            {
                Model.Name = value;
                RaisePropertyChanged();
            }
        }

        //private string _name;
        [Required]
        [Display(Name = "登录名称")]
        public string Account
        {
            get { return Model.Account; }
            set
            {
                Model.Account = value;
                RaisePropertyChanged();
            }
        }


        [Required]
        [Display(Name = "登录密码")]
        public string Password
        {
            get { return Model.Password; }
            set
            {
                Model.Password = value;
                RaisePropertyChanged();
            }
        }

        //[Browsable(false)]
        //public string RoleID { get; set; }

        private Role _role;
        [XmlIgnore]
        [Required]
        [Display(Name = "用户角色")]
        [PropertyItemType(Type = typeof(RoleComboBoxPropertyItem))]
        public Role Role
        {
            get { return _role; }
            set
            {
                _role = value;
                //this.RoleID = value?.ID;
                Model.Role = value?.Model;
                Model.RoleID = value?.Model?.ID;
                RaisePropertyChanged();
            }
        }

        public virtual bool IsValid(string authorId)
        {
            if (Role == null) return false;
            return Role.IsValid(authorId);
        }
    }
}
