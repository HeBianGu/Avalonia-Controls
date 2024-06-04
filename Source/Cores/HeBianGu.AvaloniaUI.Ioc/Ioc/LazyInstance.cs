using System;

namespace HeBianGu.AvaloniaUI.Ioc
{
    public class LazyInstance<T> where T : new()
    {
        //public static T Instance = new Lazy<T>(() => new T()).Value;
        public static T Instance = new T();

    }
}
