﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeBianGu.AvaloniaUI.Modules.Identity
{
    public class Role : SelectBindable<hi_dd_role>, IRole
    {
        public Role() : base(new hi_dd_role())
        {

        }
        public Role(hi_dd_role model) : base(model)
        {

        }


        [Browsable(false)]
        public string ID => Model.ID;
        //private string _name;
        [Required]
        [Display(Name = "角色名称")]
        public string Name
        {
            get { return Model.Name; }
            set
            {
                Model.Name = value;
                RaisePropertyChanged();
            }
        }

        //private ObservableCollection<IAuthor> _authors = new ObservableCollection<IAuthor>();
        //[Browsable(false)]
        //public ObservableCollection<IAuthor> Authors
        //{
        //    get { return _authors; }
        //    set
        //    {
        //        _authors = value;
        //        RaisePropertyChanged();
        //    }
        //}

        public virtual bool IsValid(string authorId)
        {
            return true;
            //return Model.Authors.Any(x => x.AuthorCode == authorId);
        }
    }
}
