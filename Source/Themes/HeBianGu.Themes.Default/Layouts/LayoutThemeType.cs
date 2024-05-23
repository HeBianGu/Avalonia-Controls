using System.ComponentModel.DataAnnotations;

namespace HeBianGu.Themes.Default
{
    //[TypeConverter(typeof(DisplayEnumConverter))]
    public enum LayoutThemeType
    {
        [Display(Name = "常规")]
        Default = 0,
        [Display(Name = "宽松")]
        Large,
        [Display(Name = "紧凑")]
        Small
    }
}
