﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using HeBianGu.AvaloniaUI.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Windows.Input;
using System.Xml.Serialization;

namespace HeBianGu.AvaloniaUI.Repository
{
    public class RepositoryBindableBase : Bindable
    {
        public RepositoryBindableBase()
        {
            System.Collections.Generic.IEnumerable<PropertyInfo> cmdps = GetType().GetProperties().Where(x => typeof(ICommand).IsAssignableFrom(x.PropertyType));
            foreach (PropertyInfo cmdp in cmdps)
            {
                if (cmdp.CanRead == false)
                    continue;
                if (cmdp.GetCustomAttribute<BrowsableAttribute>()?.Browsable == false)
                    continue;
                ICommand command = cmdp.GetValue(this) as ICommand;
                if (command is IRelayCommand relay)
                {
                    if (relay.Name == null || relay.GroupName == null)
                    {
                        var display = cmdp.GetCustomAttribute<DisplayAttribute>();
                        relay.Name = relay.Name ?? display?.Name ?? cmdp.Name;
                        relay.GroupName = relay.GroupName ?? display?.GroupName;
                    }
                }
                Commands.Add(command);
            }
        }

        [Browsable(false)]
        [JsonIgnore]
        [XmlIgnore]
        public ObservableCollection<ICommand> Commands { get; } = new ObservableCollection<ICommand>();

    }
}
