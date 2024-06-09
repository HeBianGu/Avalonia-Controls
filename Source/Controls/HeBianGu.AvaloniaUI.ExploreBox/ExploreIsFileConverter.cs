using System;
using HeBianGu.AvaloniaUI.ValueConverter;
using System.Globalization;

namespace HeBianGu.AvaloniaUI.ExploreBox
{
    public class ExploreIsFileConverter : MarkupValueConverterBase
    {
        private IExploreTree _exploreTree = new ExploreTree();
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _exploreTree.IsFile(value);
        }
    }

}
