using Avalonia.Media;
using Avalonia.Ioc;
using HeBianGu.Avalonia.Extensions.Setting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Styles
{
    [Display(Name = "窗口设置", GroupName = SettingGroupNames.GroupSystem, Description = "设置窗口参数")]
    public class WindowSetting : IocOptionInstance<WindowSetting>
    {
        private string _backImagePath;
        [DefaultValue("avares://Avalonia.Extensions.BackgroundImage/Assets/b13.png")]
        [Display(Name = "窗口背景图片")]
        public string BackImagePath
        {
            get { return _backImagePath; }
            set
            {
                _backImagePath = value;
                RaisePropertyChanged();
            }
        }

        private double _opacity;
        [DefaultValue(0.3)]
        [Display(Name = "图片透明度")]
        public double Opacity
        {
            get { return _opacity; }
            set
            {
                _opacity = value;
                RaisePropertyChanged();
            }
        }


        private Stretch _stretch;
        [DefaultValue(Stretch.UniformToFill)]
        [Display(Name = "图片拉伸")]
        public Stretch Stretch
        {
            get { return _stretch; }
            set
            {
                _stretch = value;
                RaisePropertyChanged();
            }
        }

        private bool _useNoticeOnMainWindowClose;
        [DefaultValue(true)]
        [Display(Name = "主窗口关闭提示", Description = "当主窗口点击关闭时会提示是否关闭窗口")]
        public bool UseNoticeOnMainWindowClose
        {
            get { return _useNoticeOnMainWindowClose; }
            set
            {
                _useNoticeOnMainWindowClose = value;
                RaisePropertyChanged();
            }
        }

    }
}
