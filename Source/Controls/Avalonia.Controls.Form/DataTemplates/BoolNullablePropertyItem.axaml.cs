// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System.Collections;
using System.Reflection;

namespace Avalonia.Controls.Form
{
    public class BoolNullablePropertyItem : ObjectPropertyItem<bool?>
    {
        public BoolNullablePropertyItem(PropertyInfo property, object obj) : base(property, obj)
        {
        }
    }
}
