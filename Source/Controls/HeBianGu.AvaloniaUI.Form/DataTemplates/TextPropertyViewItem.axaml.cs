// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using System;
using System.Collections;
using System.Reflection;

namespace HeBianGu.AvaloniaUI.Form
{
    public class TextPropertyViewItem : ObjectPropertyItem<string>, IPropertyViewItemPresenter
    {
        public TextPropertyViewItem(PropertyInfo property, object obj) : base(property, obj)
        {

        }

        public override void LoadValue()
        {
            this.Value = this.PropertyInfo.GetValue(Obj)?.TryConvertToString();
        }

        //protected override string GetValue()
        //{
        //    return base.GetValue();
        //    //var value = this.PropertyInfo.GetValue(Obj);
        //    //if (value is bool b)
        //    //    return b ? "是" : "否";
        //    //return this.PropertyInfo.GetValue(Obj)?.ToString();
        //}

        protected override void SetValue(string value)
        {
            base.SetValue(value);
        }
    }

    public class DictionaryPropertyViewItem : ObjectPropertyItem<IDictionary>, IPropertyViewItemPresenter
    {
        public DictionaryPropertyViewItem(PropertyInfo property, object obj) : base(property, obj)
        {

        }

    }
}
