﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System.Windows.Threading
{
    public static partial class DispatcherExtension
    {
        private static bool _isRefreshing;
        [Obsolete]
        public static void DelayInvoke(this Dispatcher dispatcher, DispatcherPriority priority, Action action)
        {
            if (_isRefreshing)
                return;
            _isRefreshing = true;
            dispatcher.BeginInvoke(priority, new Action(() =>
             {
                 _isRefreshing = false;
                 action?.Invoke();
             }));
        }

        public static void BeginInvoke(this Dispatcher dispatcher, DispatcherPriority priority, Action action)
        {
            dispatcher.InvokeAsync(new Action(() =>
            {
                action?.Invoke();
            }), priority);
        }

        //public static R GetDispatcherValue<T, R>(this T dispatcher, Func<T, R> func) where T : DispatcherObject
        //{
        //    if (dispatcher.CheckAccess())
        //    {
        //        return func(dispatcher);
        //    }
        //    else
        //    {
        //        return dispatcher.Dispatcher.Invoke(() => func(dispatcher));
        //    }
        //}

        //public static void InvokeDispatcher<T>(this T dispatcher, Action<T> func) where T : DispatcherObject
        //{
        //    if (dispatcher.CheckAccess())
        //    {
        //        func(dispatcher);
        //    }
        //    else
        //    {
        //        dispatcher.Dispatcher.Invoke(() => func(dispatcher));
        //    }
        //}
    }

    public static partial class DispatcherExtension
    {
        private static readonly Dictionary<object, bool> _isRefreshings = new Dictionary<object, bool>();

        public static void DelayInvoke(this object obj, Action action, DispatcherPriority priority)
        {
            if (!_isRefreshings.ContainsKey(obj))
            {
                _isRefreshings.Add(obj, false);
            }
            bool isRefreshing = _isRefreshings[obj];

            if (isRefreshing)
                return;
            _isRefreshings[obj] = true;

            Dispatcher.UIThread.BeginInvoke(priority, new Action(() =>
            {
                _isRefreshings[obj] = false;
                action?.Invoke();
            }));
        }

        public static void DelayInvoke(this object obj, IList target, Func<IList> getSrc, DispatcherPriority priority, Action end = null)
        {
            if (!_isRefreshings.ContainsKey(obj))
            {
                _isRefreshings.Add(obj, false);
            }
            bool isRefreshing = _isRefreshings[obj];

            if (_isRefreshings[obj])
                return;
            _isRefreshings[obj] = true;

            Dispatcher.UIThread.BeginInvoke(priority, new Action(() =>
            {
                _isRefreshings[obj] = false;
                target.Clear();

                IList src = getSrc.Invoke();
                foreach (object item in src)
                {
                    Dispatcher.UIThread.BeginInvoke(priority, new Action(() =>
                    {
                        if (_isRefreshings[obj])
                            return;
                        target.Add(item);
                        if (target.Count == src.Count)
                        {
                            end?.Invoke();
                        }
                    }));
                }
            }));
        }

        [Obsolete("DelayInvokeList<T>")]
        public static void DelayInvoke(this object obj, IList src, Action<object> invokeItem, DispatcherPriority priority, Action end = null)
        {
            if (!_isRefreshings.ContainsKey(obj))
            {
                _isRefreshings.Add(obj, false);
            }
            bool isRefreshing = _isRefreshings[obj];

            if (_isRefreshings[obj])
                return;
            _isRefreshings[obj] = true;

            Dispatcher.UIThread.BeginInvoke(priority, new Action(() =>
            {
                System.Diagnostics.Debug.WriteLine("DelayInvoke:" + DateTime.Now);
                _isRefreshings[obj] = false;
                foreach (object item in src)
                {
                    Dispatcher.UIThread.BeginInvoke(priority, new Action(() =>
                    {
                        if (_isRefreshings[obj])
                            return;
                        invokeItem?.Invoke(item);
                        if (src.IndexOf(item) == src.Count - 1)
                        {
                            end?.Invoke();
                        }
                        System.Diagnostics.Debug.WriteLine("DelayInvokeItem:" + DateTime.Now);

                    }));
                }
            }));
        }

        public static void DelayInvokeItem<T>(this IEnumerable<T> src, Action<T> invokeItem, DispatcherPriority priority, Action end = null)
        {
            if (!_isRefreshings.ContainsKey(src))
            {
                _isRefreshings.Add(src, false);
            }
            bool isRefreshing = _isRefreshings[src];

            if (_isRefreshings[src])
                return;
            _isRefreshings[src] = true;

            Dispatcher.UIThread.BeginInvoke(priority, new Action(() =>
            {
                //System.Diagnostics.Debug.WriteLine("DelayInvoke:" + DateTime.Now);
                _isRefreshings[src] = false;
                foreach (T item in src)
                {
                    Dispatcher.UIThread.BeginInvoke(priority, new Action(() =>
                    {
                        if (_isRefreshings[src])
                            return;
                        invokeItem?.Invoke(item);
                        if (item.Equals(src.LastOrDefault()))
                        {
                            end?.Invoke();
                        }
                        //System.Diagnostics.Debug.WriteLine("DelayInvokeItem:" + DateTime.Now);

                    }));
                }
            }));
        }

    }
}
