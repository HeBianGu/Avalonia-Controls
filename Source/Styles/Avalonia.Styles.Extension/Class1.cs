using Avalonia.Extensions.ResourceKey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Styles.Extension
{
    public static class ExtensionDialogKeys
    {
        public static StringResourceKey None => new StringResourceKey(typeof(ExtensionDialogKeys), "S.DialogWindow.None");
        //public static ComponentResourceKey Sumit => new ComponentResourceKey(typeof(DialogKeys), "S.DialogWindow.Sumit");
        //public static ComponentResourceKey Cancel => new ComponentResourceKey(typeof(DialogKeys), "S.DialogWindow.Cancel");
        //public static ComponentResourceKey SumitAndCancel => new ComponentResourceKey(typeof(DialogKeys), "S.DialogWindow.SumitAndCancel");
    }
}
