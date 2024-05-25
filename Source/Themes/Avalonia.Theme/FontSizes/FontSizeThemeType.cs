using System.ComponentModel.DataAnnotations;

namespace Avalonia.Theme
{
    //[TypeConverter(typeof(DisplayEnumConverter))]
    public enum FontSizeThemeType
    {
        [Display(Name = "常规")]
        Default = 0,
        [Display(Name = "大")]
        Large,
        [Display(Name = "小")]
        Small
    }
}
