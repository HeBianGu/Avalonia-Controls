using Avalonia.Controls.Templates;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Markup.Xaml.Templates;

namespace HeBianGu.Test.Main
{
    internal class Data : IDataTemplate
    {
        DataTemplate DataTemplate { get; set; }
        public Control? Build(object param)
        {
            // TODO: build and return the control which represents your data
            // Sample: 
             //return new Textblock(){ Text = param.ToString() };
            //return DataTemplate;
            throw new NotImplementedException();
        }

        public bool Match(object data)
        {
            // TODO: Check if the provided data matches or not. Return true if matches, otherwise false.
            // Sample: 
            // return data is string;
            throw new NotImplementedException();
        }
    }
}