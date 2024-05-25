using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using HeBianGu.Avalonia.Controls.Form;
using Avalonia.Ioc;
using HeBianGu.Avalonia.Extensions.Setting;
using Avalonia.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Avalonia.Modules.ThemeSetting
{

    [Display(Name = "主题设置", GroupName = SettingGroupNames.GroupSystem, Description = "登录页面设置的信息")]
    public class ThemeSetting : Settable<ThemeSetting>, ILoginedSplashLoad
    {
        public ThemeSetting()
        {
            this.ColorResources.Add(new DarkColorResource());
            this.ColorResources.Add(new DarkGrayColorResource());
            this.ColorResources.Add(new DarkPurpleColorResource());
            this.ColorResources.Add(new DarkBlueColorResource());

            this.ColorResources.Add(new LightColorResource());
            this.ColorResources.Add(new AccentColorResource());
            this.ColorResources.Add(new AccentLightColorResource());
            this.ColorResource = this.ColorResources.FirstOrDefault();

            this.FontSizeResources.Add(new FontSizeResource());
            this.FontSizeResources.Add(new LargeFontSizeResource());
            this.FontSizeResources.Add(new SmallFontSizeResource());
            this.FontSizeResource = this.FontSizeResources.FirstOrDefault();

            this.LayoutResources.Add(new LayoutResource());
            this.LayoutResources.Add(new LargeLayoutResource());
            this.LayoutResources.Add(new SmallLayoutResource());
            this.LayoutResource = this.LayoutResources.FirstOrDefault();
        }

        //[DefaultValue(FontSizeThemeType.Default)]
        //[Display(Name = "字体")]
        //public FontSizeThemeType FontSize { get; set; }

        //[DefaultValue(LayoutThemeType.Default)]
        //[Display(Name = "布局")]
        //public LayoutThemeType Layout { get; set; }

        private IColorResource _colorResource;
        /// <summary> 说明  </summary>
        public IColorResource ColorResource
        {
            get { return _colorResource; }
            set
            {
                _colorResource = value;
                RaisePropertyChanged();
                this.RefreshColorTheme();
            }
        }

        private IFontSizeResource _fontSizeResource;
        /// <summary> 说明  </summary>
        public IFontSizeResource FontSizeResource
        {
            get { return _fontSizeResource; }
            set
            {
                _fontSizeResource = value;
                RaisePropertyChanged();
                this.RefreshFontSizeTheme();
            }
        }

        private ILayoutResource _layoutResource;
        /// <summary> 说明  </summary>
        public ILayoutResource LayoutResource
        {
            get { return _layoutResource; }
            set
            {
                _layoutResource = value;
                RaisePropertyChanged();
                this.RefreshLayoutTheme();
            }
        }

        //[XmlIgnore]
        //[JsonIgnore]
        //[BindingGetSelectSourceProperty(nameof(ColorResources))]
        //[PropertyItemType(typeof(OnlyComboBoxSelectSourcePropertyItem))]
        //[Display(Name = "颜色主题")]
        //public IColorResource ColorResource { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public List<IColorResource> ColorResources { get; } = new List<IColorResource>();

        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public List<IFontSizeResource> FontSizeResources { get; } = new List<IFontSizeResource>();


        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public List<ILayoutResource> LayoutResources { get; } = new List<ILayoutResource>();

        [Browsable(false)]
        public int ColorResourceSelectedIndex { get; set; }

        public void OnColorResourceValueChanged(PropertyInfo property, IColorResource o, IColorResource n)
        {
            //this.Color.ChangeThemeType();
            //this.ChangeColorTheme();
            this.RefreshTheme();
        }
        public void OnFontSizeValueChanged(PropertyInfo property, FontSizeThemeType o, FontSizeThemeType n)
        {
            //this.FontSize.ChangeFontSizeThemeType();
        }
        public void OnLayoutValueChanged(PropertyInfo property, LayoutThemeType o, LayoutThemeType n)
        {
            //this.Layout.ChangeLayoutThemeType();
        }

        public override bool Save(out string message)
        {
            //this.RefreshTheme();
            //{
            //    ResourceDictionary brushResource = new ResourceDictionary() { Source = new Uri("pack://application:,,,/H.Styles.Default;component/ConciseControls.xaml", UriKind.Absolute) };
            //    brushResource.ChangeResourceDictionary(x => x.Source.AbsoluteUri == brushResource.Source.AbsoluteUri, true);
            //}
            this.ColorResourceSelectedIndex = this.ColorResources.IndexOf(this.ColorResource);
            return base.Save(out message);
        }

        public override bool Load(out string message)
        {
            var r = base.Load(out message);
            this.ColorResource = this.ColorResources[this.ColorResourceSelectedIndex];
            this.RefreshTheme();
            return r;
        }

        internal void RefreshTheme()
        {
            this.RefreshColorTheme();
            this.RefreshFontSizeTheme();
            this.RefreshLayoutTheme();
        }

        internal void RefreshColorTheme()
        {
            {
                var find = Application.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source.AbsoluteUri.StartsWith("avares://Avalonia.Theme/Brushes/") || x.Source.AbsoluteUri == "avares://Avalonia.Theme/Resources/Brush.axaml");
                if (find != this.ColorResource.Resource)
                {
                    int index = Application.Current.Resources.MergedDictionaries.IndexOf(find);
                    Application.Current.Resources.MergedDictionaries[index] = this.ColorResource.Resource;
                }
            }
        }

        internal void RefreshFontSizeTheme()
        {
            {
                var find = Application.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source.AbsoluteUri.StartsWith("avares://Avalonia.Theme/FontSizes/") || x.Source.AbsoluteUri == "avares://Avalonia.Theme/Resources/FontSize.axaml");
                if (find != this.FontSizeResource.Resource)
                {
                    int index = Application.Current.Resources.MergedDictionaries.IndexOf(find);
                    Application.Current.Resources.MergedDictionaries[index] = this.FontSizeResource.Resource;
                }
            }
        }

        internal void RefreshLayoutTheme()
        {
            {
                var find = Application.Current.Resources.MergedDictionaries.OfType<ResourceInclude>().FirstOrDefault(x => x.Source.AbsoluteUri.StartsWith("avares://Avalonia.Theme/Layouts/") || x.Source.AbsoluteUri == "avares://Avalonia.Theme/Resources/Layout.axaml");
                if (find != this.LayoutResource.Resource)
                {
                    int index = Application.Current.Resources.MergedDictionaries.IndexOf(find);
                    Application.Current.Resources.MergedDictionaries[index] = this.LayoutResource.Resource;
                }
            }
        }
        protected override string GetDefaultFolder()
        {
            return AppPaths.Instance.UserSetting;
        }

    }

}