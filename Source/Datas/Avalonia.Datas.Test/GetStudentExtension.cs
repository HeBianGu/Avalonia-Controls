using Avalonia.Markup.Xaml;
using System;
using System.Windows.Markup;

namespace Avalonia.Datas.Test
{
    public class GetStudentExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Student.Random();
        }
    }
}
