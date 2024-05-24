using System;

namespace HeBianGu.Avalonia.Extensions.ApplicationBase
{
    [System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public sealed class ApplicationResourceLoaderAttribute : ApplicationAxamlLoaderAttribute
    {
        public override string FolderName { get; set; } = "Resources";
    }
}