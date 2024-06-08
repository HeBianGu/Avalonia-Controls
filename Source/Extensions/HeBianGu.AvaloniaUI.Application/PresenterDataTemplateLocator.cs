using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Templates;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HeBianGu.AvaloniaUI.Application
{
    public class PresenterDataTemplateLocator : IDataTemplate
    {
        private readonly IDictionary<Type, DataTemplate> _cache = new Dictionary<Type, DataTemplate>();
        public bool SupportsRecycling => false;
        public Control Build(object data)
        {
            var type = data.GetType();
            var dataTemplate = this.GetDataTemplate(type);
            if (dataTemplate != null)
            {
                _cache[type] = dataTemplate;
                return dataTemplate.Build(data);
            }
             
            return new TextBlock { Text = "Not Found: " + data};
        }

        public DataTemplate GetDataTemplate(Type type)
        {
            if (_cache.ContainsKey(type))
                return _cache[type];

            if (!typeof(IPresenter).IsAssignableFrom(type))
                return null;
            try
            {
                string path = $"avares://{type.Assembly.GetName().Name}/DataTemplates/{type.Name}.axaml";
                var obj = AvaloniaXamlLoader.Load(new Uri(path));
                if (obj is DataTemplate dataTemplate)
                    return dataTemplate;
            }
            catch (Exception ex)
            {
                return this.GetDataTemplate(type.BaseType);
            }
            return null;
        }

        public bool Match(object data)
        {
            //if (data is IPresenter)
            //    return true;
            //System.Diagnostics.Debug.WriteLine("定位器：" + data);
            return data is IPresenter;
        }
    }
}