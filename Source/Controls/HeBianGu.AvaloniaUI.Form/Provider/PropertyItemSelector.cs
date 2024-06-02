using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using HeBianGu.AvaloniaUI.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HeBianGu.AvaloniaUI.Form.Provider
{
    public class PropertyItemSelector : IDataTemplate
    {
        public IDataTemplate TextPropertyItem { get; set; }
        public Control Build(object param)
        {
            string path = $"avares://HeBianGu.AvaloniaUI.Form/DataTemplates/TextPropertyItem.axaml";
            DataTemplate dataTemplate = AvaloniaXamlLoader.Load(new Uri(path)) as DataTemplate;
            return dataTemplate?.Build(param);
        }

        public bool Match(object data)
        {
            return data != null;
        }
    }

    /// <summary>
    /// 根据数据类型自动查找DataTemplate
    /// </summary>
    public class DataTemplatesSelector : IDataTemplate
    {
        private IDictionary<string, DataTemplate> _catch = new Dictionary<string, DataTemplate>();
        public Control Build(object param)
        {
            var type = param.GetType();
            string assName = type.Assembly.GetName().Name;
            string path = $"avares://{assName}/DataTemplates/{type.Name}.axaml";
            if (_catch.ContainsKey(path))
                return _catch[path].Build(param);
            DataTemplate dataTemplate = AvaloniaXamlLoader.Load(new Uri(path)) as DataTemplate;
            if (dataTemplate != null)
            {
                _catch[path] = dataTemplate;
                return dataTemplate.Build(param);
            }
            return new TextBlock() { Text = param.ToString() };
        }

        public bool Match(object data)
        {
            return data != null;
        }
    }
}
