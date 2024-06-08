
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Setting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace HeBianGu.AvaloniaUI.Modules.SplashScreen
{
    [Display(Name = "启动页面", GroupName = SettingGroupNames.GroupSystem, Description = "启动页面设置信息")]
    public class SplashScreenOption : IocOptionInstance<SplashScreenOption>
    {
        public override void LoadDefault()
        {
            base.LoadDefault();
            this.Product = ApplicationProvider.Product;
            this.Copyright = ApplicationProvider.Copyright;
            this.Title = ApplicationProvider.Version;
        }

        private string _title;
        [Display(Name = "窗口标题")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        private string _product;
        [Display(Name = "登录标题")]
        public string Product
        {
            get { return _product; }
            set
            {
                _product = value;
                RaisePropertyChanged();
            }
        }

        private string _copyright;
        [Display(Name = "版权信息")]
        public string Copyright
        {
            get { return _copyright; }
            set
            {
                _copyright = value;
                RaisePropertyChanged();
            }
        }

        private double _productFontSize;
        [DefaultValue(50)]
        [Display(Name = "字体大小")]
        public double ProductFontSize
        {
            get { return _productFontSize; }
            set
            {
                _productFontSize = value;
                RaisePropertyChanged();
            }
        }
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public IVisualTransitionable VisualTransitionable { get; set; }
    }
}
