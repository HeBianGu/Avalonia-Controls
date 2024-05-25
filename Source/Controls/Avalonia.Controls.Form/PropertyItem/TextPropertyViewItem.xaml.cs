﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System.Collections;
using System.Reflection;

namespace Avalonia.Controls.Form
{
    public class TextPropertyViewItem : TextPropertyItem, IPropertyViewItem
    {
        public TextPropertyViewItem(PropertyInfo property, object obj) : base(property, obj)
        {

        }
    }

    public class DictionaryPropertyViewItem : ObjectPropertyItem<IDictionary>, IPropertyViewItem
    {
        public DictionaryPropertyViewItem(PropertyInfo property, object obj) : base(property, obj)
        {

        }

    }
}
