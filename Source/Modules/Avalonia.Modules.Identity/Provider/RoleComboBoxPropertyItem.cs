// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control


using Avalonia.Controls.Form;
using System.Reflection;

namespace Avalonia.Modules.Identity
{
    public class RoleComboBoxPropertyItem : ComboBoxSelectSourcePropertyItem
    {
        public RoleComboBoxPropertyItem(PropertyInfo property, object obj) : base(property, obj)
        {

        }

        //protected override IEnumerable<object> CreateSource()
        //{
        //    return RoleViewPresenterProxy.Instance?.GetRoles();
        //}
    }
}
