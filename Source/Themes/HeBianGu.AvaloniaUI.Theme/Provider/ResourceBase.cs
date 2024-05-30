using Avalonia.Markup.Xaml.Styling;
using System;

namespace HeBianGu.AvaloniaUI.Theme.Provider
{
    public abstract class ResourceBase : IResource
    {
        public abstract string Name { get; }

        public ResourceInclude Resource => new ResourceInclude(GetUri()) { Source = GetUri() };

        protected abstract Uri GetUri();

        public override string ToString()
        {
            return Name;
        }

    }
}
