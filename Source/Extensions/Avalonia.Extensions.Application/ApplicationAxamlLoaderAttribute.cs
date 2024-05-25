using System;

namespace Avalonia.Extensions.Application
{
    public abstract class ApplicationAxamlLoaderAttribute : Attribute
    {
        public abstract string FolderName { get; set; }
    }
}