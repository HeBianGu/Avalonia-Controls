using System;

namespace Avalonia.Extensions.Application
{
    [System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class ApplicationDataTemplateLoaderAttribute : ApplicationAxamlLoaderAttribute
    {
        public override string FolderName { get; set; } = "DataTemplates";
    }
}