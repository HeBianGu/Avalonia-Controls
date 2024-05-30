// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Data;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Modules.Identity
{
    public class RoleEditPresenter : ModelBindable<hi_dd_role>
    {
        public RoleEditPresenter(hi_dd_role model) : base(model)
        {
            this.Authors = System.Ioc.GetService<IStringRepository<hi_dd_author>>().GetList();
        }

        private List<hi_dd_author> _authors = new List<hi_dd_author>();
        public List<hi_dd_author> Authors
        {
            get { return _authors; }
            set
            {
                _authors = value;
                RaisePropertyChanged();
            }
        }
    }
}
