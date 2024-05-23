using System.ComponentModel.DataAnnotations;

namespace HeBianGu.Themes.Default
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
