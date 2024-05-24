using System;

namespace HeBianGu.Avalonia.Extensions.ApplicationBase
{
    public abstract class ApplicationAxamlLoaderAttribute : Attribute
    {
        public abstract string FolderName { get; set; }
    }
}