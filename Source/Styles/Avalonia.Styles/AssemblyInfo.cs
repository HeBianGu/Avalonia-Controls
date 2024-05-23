using Avalonia.Metadata;
using HeBianGu.Avalonia.Extensions.ApplicationBase;
using System.Windows;
using System.Windows.Markup;

[assembly: ApplicationStylesLoader]
[assembly: ApplicationResourceLoader]
[assembly: ApplicationDataTemplateLoader]

[assembly: XmlnsDefinition("QQ:908293466", "Avalonia.Styles")]
[assembly: XmlnsPrefix("QQ:908293466", "h")]

[assembly: XmlnsDefinition("https://github.com/HeBianGu", "Avalonia.Styles")]
[assembly: XmlnsPrefix("https://github.com/HeBianGu", "h")]

[assembly: XmlnsDefinition("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "Avalonia.Styles")]
[assembly: XmlnsPrefix("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "h")]