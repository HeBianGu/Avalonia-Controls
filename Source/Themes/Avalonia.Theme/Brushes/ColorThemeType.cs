using System.ComponentModel.DataAnnotations;

namespace Avalonia.Theme
{
    public enum ColorThemeType
    {
        [Display(Name = "常规")]
        Default = 0,
        [Display(Name = "深色")]
        Dark,
        [Display(Name = "浅色")]
        Light
    }
}
