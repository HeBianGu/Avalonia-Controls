
using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Setting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.AvaloniaUI.Styles
{
    [Display(Name = "窗口设置", GroupName = SettingGroupNames.GroupSystem, Description = "设置窗口参数")]
    public class WindowSetting : IocOptionInstance<WindowSetting>
    {
        public WindowSetting()
        {
            this.BackImage = new Bitmap(AssetLoader.Open(new Uri("avares://HeBianGu.AvaloniaUI.BackgroundImage/Assets/Star.png")));
            //BitmapTypeConverter
            //ImageDrawing imageDrawing=new ImageDrawing();
            //imageDrawing.ImageSource
        }
        private Bitmap _backImage;
        [Display(Name = "窗口背景图片")]
        public Bitmap BackImage
        {
            get { return _backImage; }
            set
            {
                _backImage = value;
                RaisePropertyChanged();
            }


        }

        public override void LoadDefault()
        {
            base.LoadDefault();
            this.BackImagePath = new Uri("avares://HeBianGu.AvaloniaUI.BackgroundImage/Assets/Star.png", UriKind.RelativeOrAbsolute);
        }
        private Uri _backImagePath;
        //[DefaultValue("avares://HeBianGu.AvaloniaUI.BackgroundImage/Assets/Star.png")]
        [Display(Name = "窗口背景图片")]
        public Uri BackImagePath
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
