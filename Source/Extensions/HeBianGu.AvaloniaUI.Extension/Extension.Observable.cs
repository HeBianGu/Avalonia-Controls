﻿using Avalonia.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace System
{
    public static class ObservableExtension
    {
        public static void OrderBy<TSource, TKey>(this Collection<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TSource> sortedList = Enumerable.OrderBy(source, keySelector).ToList();
            source.Clear();
            foreach (TSource sortedItem in sortedList)
                source.Add(sortedItem);
        }

        public static void OrderBy<TSource, TKey>(this Collection<TSource> source, Func<TSource, TKey> keySelector, bool isdesc)
        {
            List<TSource> sortedList = isdesc ? source.OrderByDescending(keySelector).ToList() : Enumerable.OrderBy(source, keySelector).ToList();
            source.Clear();
            foreach (TSource sortedItem in sortedList)
                source.Add(sortedItem);
        }


        public static void OrderByDesc<TSource, TKey>(this Collection<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TSource> sortedList = source.OrderByDescending(keySelector).ToList();
            source.Clear();
            foreach (TSource sortedItem in sortedList)
                source.Add(sortedItem);
        }

        /// <summary> 排序 </summary>
        public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
        {
            List<T> sortedList = Enumerable.OrderBy(collection, x => x).ToList();
            for (int i = 0; i < sortedList.Count(); i++)
            {
                collection.Move(collection.IndexOf(sortedList[i]), i);
            }
        }

        public static ObservableCollection<T> Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison)
        {
            List<T> sort = collection.ToList();
            sort.Sort(comparison);
            return sort.ToObservable();
        }

        /// <summary> 转成 ObservableCollection 集合 </summary>
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);

        }
        /// <summary> 调用主线程执行Action </summary>
        public static void Invoke<T>(this ObservableCollection<T> collection, Action<ObservableCollection<T>> action)
        {
            Dispatcher.UIThread.Invoke(() => action(collection));

        }
        /// <summary> 调用主线程执行Action </summary>
        public static void BeginInvoke<T>(this ObservableCollection<T> collection, Action<ObservableCollection<T>> action)
        {
            Dispatcher.UIThread.BeginInvoke(DispatcherPriority.SystemIdle, new Action(() => action(collection)));

        }

        /// <summary> 更新集合 通知UI </summary>
        public static void Refresh<T>(this ObservableCollection<T> collection)
        {

            //ObservableCollection<T> result = new ObservableCollection<T>();

            //foreach (var item in collection)
            //{
            //    result.Add(item);
            //}

            //collection = result;

            collection = new ObservableCollection<T>(collection);
        }

        /// <summary> 对集合中的 每一项执行Action </summary>
        public static void Foreach<T>(this ObservableCollection<T> collection, Action<T> action)
        {
            foreach (T item in collection)
            {
                action(item);
            }
        }
        /// <summary> 随机排序 </summary>
        public static ObservableCollection<T> Random<T>(this ObservableCollection<T> collection)
        {
            Random random = new Random();
            T temp;

            for (int i = 0; i < collection.Count; i++)
            {
                int index = random.Next(i, collection.Count - 1);
                temp = collection[i];
                collection[i] = collection[index];
                collection[index] = temp;
            }
            return collection;
        }

        public static void RemoveAll<T>(this ObservableCollection<T> collection, Func<T, bool> predicate, bool useDispatcher = true)
        {
            List<T> finds = collection.Where(predicate).ToList();
            if (useDispatcher)
            {
                foreach (T item in finds)
                {
                    Dispatcher.UIThread.Invoke(() =>
                    {
                        collection.Remove(item);
                    });
                }
            }
            else
            {
                foreach (T item in finds)
                {
                    collection.Remove(item);
                }
            }
        }

        public static T CreateObservableCollection<T>(this Type t) where T : IEnumerable
        {
            if (t == null) return default(T);
            Type type = typeof(ObservableCollection<>);
            type = type.MakeGenericType(t);
            return (T)Activator.CreateInstance(type);
        }

        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> ts)
        {
            foreach (T item in ts)
            {
                collection.Add(item);
            }
        }

        public static void Replace<T>(this ObservableCollection<T> collection, T t, Predicate<T> predicate)
        {
            T find = collection.FirstOrDefault(l => predicate(l));
            if (find == null)
                return;
            int index = collection.IndexOf(find);
            collection.Remove(find);
            collection.Insert(index, t);
        }


        public static T GetNext<T>(this ObservableCollection<T> collection, T item, bool circulation = true)
        {
            if (collection == null)
                return default(T);
            int index = collection.IndexOf(item);
            if (index < 0)
                return circulation ? collection[0] : default(T);
            if (index == collection.Count - 1)
                return circulation ? collection[0] : default(T);
            return collection[index + 1];
        }


        public static T GetProvious<T>(this ObservableCollection<T> collection, T item, bool circulation = true)
        {
            if (collection == null)
                return default(T);
            int index = collection.IndexOf(item);
            if (index < 0)
                return circulation ? collection.LastOrDefault() : default(T);
            if (index == 0)
                return circulation ? collection.LastOrDefault() : default(T);
            return collection[index - 1];
        }
    }
}
