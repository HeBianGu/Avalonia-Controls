using System;

namespace HeBianGu.AvaloniaUI.Application
{
    public abstract class ApplicationAxamlLoaderAttribute : Attribute
    {
        public abstract string FolderName { get; set; }
    }
}