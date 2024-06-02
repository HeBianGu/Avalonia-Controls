using Avalonia.Media;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeBianGu.AvaloniaUI.Form
{
    public class DateTimePropertyItem : ObjectPropertyItem<DateTime>
    {
        public DateTimePropertyItem(PropertyInfo property, object obj) : base(property, obj)
        {
        }
    }
}
