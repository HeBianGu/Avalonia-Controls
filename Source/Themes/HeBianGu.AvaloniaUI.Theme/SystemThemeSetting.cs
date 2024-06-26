﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Setting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HeBianGu.AvaloniaUI.Theme
{
    [Display(Name = "系统设置", GroupName = SettingGroupNames.GroupSystem, Description = "设置系统设置")]
    public class SystemThemeSetting : Settable<SystemThemeSetting>
    {
        public SystemThemeSetting()
        {
            //_fontFamily = FontFamily.Default;
            _fontFamily = new FontFamily("微软雅黑");
        }
        private FontFamily _fontFamily;

        [JsonIgnore]
        [Display(Name = "字体类型")]
        [TypeConverter(typeof(FontFamilyTypeConverter))]
        public FontFamily FontFamily
        {
            get { return _fontFamily; }
            set
            {
                _fontFamily = value;
                RaisePropertyChanged();
            }
        }

        //private double _opacity;
        //[DefaultValue(0.3)]
        //[Display(Name = "图片透明度")]
        //public double Opacity
        //{
        //    get { return _opacity; }
        //    set
        //    {
        //        _opacity = value;
        //        RaisePropertyChanged();
        //    }
        //}


        //private Stretch _stretch;
        //[DefaultValue(Stretch.UniformToFill)]
        //[Display(Name = "图片拉伸")]
        //public Stretch Stretch
        //{
        //    get { return _stretch; }
        //    set
        //    {
        //        _stretch = value;
        //        RaisePropertyChanged();
        //    }
        //}

        //private bool _useNoticeOnMainWindowClose;
        //[DefaultValue(true)]
        //[Display(Name = "主窗口关闭提示", Description = "当主窗口点击关闭时会提示是否关闭窗口")]
        //public bool UseNoticeOnMainWindowClose
        //{
        //    get { return _useNoticeOnMainWindowClose; }
        //    set
        //    {
        //        _useNoticeOnMainWindowClose = value;
        //        RaisePropertyChanged();
        //    }
        //}

    }
}