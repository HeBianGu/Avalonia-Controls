using HeBianGu.AvaloniaUI.Ioc;
using HeBianGu.AvaloniaUI.Setting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace HeBianGu.AvaloniaUI.MainWindow
{
    [Display(Name = "主窗口设置", GroupName = SettingGroupNames.GroupSystem, Description = "设置主窗口参数")]
    public class MainWindowSetting : IocOptionInstance<MainWindowSetting>
    {
        private IVisualTransitionable _visualTransitionable;
        [XmlIgnore]
        [JsonIgnore]
        [Browsable(false)]
        public IVisualTransitionable VisualTransitionable
        {
            get { return _visualTransitionable; }
            set
            {
                _visualTransitionable = value;
                RaisePropertyChanged();
            }
        }
    }
}
