// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;

namespace HeBianGu.AvaloniaUI.Extension
{
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
