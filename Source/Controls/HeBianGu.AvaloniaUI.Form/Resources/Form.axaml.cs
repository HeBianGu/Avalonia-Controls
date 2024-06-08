// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Threading;
using HeBianGu.AvaloniaUI.Application;
using HeBianGu.AvaloniaUI.Ioc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace HeBianGu.AvaloniaUI.Form
{
    public partial class Form : ItemsControl, IFormOption
    {
        protected override Type StyleKeyOverride => typeof(Form);

        public Form()
        {
            this.RefreshMapper();
            this.RefreshObject();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == Form.SearchTextProperty|| change.Property == Form.UseOrderByNameProperty)
            {
                this.RefreshObject();
            }
        }

        private void RefreshMapper()
        {
            this.Mapper = (l, k) =>
            {
                if (l.PropertyType.IsClass && l.PropertyType != typeof(string))
                {
                    bool? current = l.GetCustomAttribute<PropertyAttribute>()?.UsePresenter;
                    if (this.UsePresenter && current != false)
                    {
                        return new PresenterPropertyItem(l, k);
                    }
                    else
                    {
                        if (current == true)
                        {
                            return new PresenterPropertyItem(l, k);
                        }
                    }
                }
                return this.UsePropertyView ? l.CreateView(k) : l.Create(k);
            };
        }

        public IDataTemplate ItemHeaderTemplate
        {
            get { return (IDataTemplate)GetValue(ItemHeaderTemplateProperty); }
            set { SetValue(ItemHeaderTemplateProperty, value); }
        }

        public static readonly StyledProperty<IDataTemplate> ItemHeaderTemplateProperty =
            AvaloniaProperty.Register<Form, IDataTemplate>("ItemHeaderTemplate");

        public object SelectObject
        {
            get { return GetValue(SelectObjectProperty); }
            set { SetValue(SelectObjectProperty, value); }
        }

        public static readonly StyledProperty<object> SelectObjectProperty =
            AvaloniaProperty.Register<Form, object>("SelectObject");

        public Predicate<PropertyInfo> Filter
        {
            get { return (Predicate<PropertyInfo>)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly StyledProperty<Predicate<PropertyInfo>> FilterProperty =
            AvaloniaProperty.Register<Form, Predicate<PropertyInfo>>("Filter");


        public bool UseDisplayOnly
        {
            get { return (bool)GetValue(UseDisplayOnlyProperty); }
            set { SetValue(UseDisplayOnlyProperty, value); }
        }

        public static readonly StyledProperty<bool> UseDisplayOnlyProperty =
            AvaloniaProperty.Register<Form, bool>("UseDisplayOnly");


        public bool UseDeclaredOnly
        {
            get { return (bool)GetValue(UseDeclaredOnlyProperty); }
            set { SetValue(UseDeclaredOnlyProperty, value); }
        }


        public static readonly StyledProperty<bool> UseDeclaredOnlyProperty =
            AvaloniaProperty.Register<Form, bool>("UseDeclaredOnly");


        public string ExceptPropertyNames
        {
            get { return (string)GetValue(ExceptPropertyNamesProperty); }
            set { SetValue(ExceptPropertyNamesProperty, value); }
        }


        public static readonly StyledProperty<string> ExceptPropertyNamesProperty =
            AvaloniaProperty.Register<Form, string>("ExceptPropertyNames");



        public string UsePropertyNames
        {
            get { return (string)GetValue(UsePropertyNamesProperty); }
            set { SetValue(UsePropertyNamesProperty, value); }
        }


        public static readonly StyledProperty<string> UsePropertyNamesProperty =
            AvaloniaProperty.Register<Form, string>("UsePropertyNames");

        public bool UsePropertyView
        {
            get { return (bool)GetValue(UsePropertyViewProperty); }
            set { SetValue(UsePropertyViewProperty, value); }
        }


        public static readonly StyledProperty<bool> UsePropertyViewProperty =
            AvaloniaProperty.Register<Form, bool>("UsePropertyView");


        public bool UsePresenter
        {
            get { return (bool)GetValue(UsePresenterProperty); }
            set { SetValue(UsePresenterProperty, value); }
        }


        public static readonly StyledProperty<bool> UsePresenterProperty =
            AvaloniaProperty.Register<Form, bool>("UsePresenter");



        public bool UseEnumerator
        {
            get { return (bool)GetValue(UseEnumeratorProperty); }
            set { SetValue(UseEnumeratorProperty, value); }
        }

        public static readonly StyledProperty<bool> UseEnumeratorProperty =
            AvaloniaProperty.Register<Form, bool>("UseEnumerator");


        public bool UseTypeConverterOnly
        {
            get { return (bool)GetValue(UseTypeConverterOnlyProperty); }
            set { SetValue(UseTypeConverterOnlyProperty, value); }
        }


        public static readonly StyledProperty<bool> UseTypeConverterOnlyProperty =
            AvaloniaProperty.Register<Form, bool>("UseTypeConverterOnly");

        public bool UseTypeConverter
        {
            get { return (bool)GetValue(UseTypeConverterProperty); }
            set { SetValue(UseTypeConverterProperty, value); }
        }

        public static readonly StyledProperty<bool> UseTypeConverterProperty =
            AvaloniaProperty.Register<Form, bool>("UseTypeConverter", true);

        public bool UseNull
        {
            get { return (bool)GetValue(UseNullProperty); }
            set { SetValue(UseNullProperty, value); }
        }

        public static readonly StyledProperty<bool> UseNullProperty =
            AvaloniaProperty.Register<Form, bool>("UseNull", true);


        public bool UseBoolen
        {
            get { return (bool)GetValue(UseBoolenProperty); }
            set { SetValue(UseBoolenProperty, value); }
        }


        public static readonly StyledProperty<bool> UseBoolenProperty =
            AvaloniaProperty.Register<Form, bool>("UseBoolen", true);

        public bool UseOrderByAz
        {
            get { return (bool)GetValue(UseOrderByAzProperty); }
            set { SetValue(UseOrderByAzProperty, value); }
        }


        public static readonly StyledProperty<bool> UseOrderByAzProperty =
            AvaloniaProperty.Register<Form, bool>("UseOrderByAz");


        public bool UseOrderByType
        {
            get { return (bool)GetValue(UseOrderByTypeProperty); }
            set { SetValue(UseOrderByTypeProperty, value); }
        }


        public static readonly StyledProperty<bool> UseOrderByTypeProperty =
            AvaloniaProperty.Register<Form, bool>("UseOrderByType");


        public bool UseOrderByName
        {
            get { return (bool)GetValue(UseOrderByNameProperty); }
            set { SetValue(UseOrderByNameProperty, value); }
        }


        public static readonly StyledProperty<bool> UseOrderByNameProperty =
            AvaloniaProperty.Register<Form, bool>("UseOrderByName");


        public bool UseOrder
        {
            get { return (bool)GetValue(UseOrderProperty); }
            set { SetValue(UseOrderProperty, value); }
        }


        public static readonly StyledProperty<bool> UseOrderProperty =
            AvaloniaProperty.Register<Form, bool>("UseOrder");


        public bool UseEnum
        {
            get { return (bool)GetValue(UseEnumProperty); }
            set { SetValue(UseEnumProperty, value); }
        }


        public static readonly StyledProperty<bool> UseEnumProperty =
            AvaloniaProperty.Register<Form, bool>("UseEnum", true);

        public bool UseString
        {
            get { return (bool)GetValue(UseStringProperty); }
            set { SetValue(UseStringProperty, value); }
        }


        public static readonly StyledProperty<bool> UseStringProperty =
            AvaloniaProperty.Register<Form, bool>("UseString", true);

        public bool UseDateTime
        {
            get { return (bool)GetValue(UseDateTimeProperty); }
            set { SetValue(UseDateTimeProperty, value); }
        }


        public static readonly StyledProperty<bool> UseDateTimeProperty =
            AvaloniaProperty.Register<Form, bool>("UseDateTime", true);

        public bool UseCommandOnly
        {
            get { return (bool)GetValue(UseCommandOnlyProperty); }
            set { SetValue(UseCommandOnlyProperty, value); }
        }


        public static readonly StyledProperty<bool> UseCommandOnlyProperty =
            AvaloniaProperty.Register<Form, bool>("UseCommandOnly");


        public bool UseCommand
        {
            get { return (bool)GetValue(UseCommandProperty); }
            set { SetValue(UseCommandProperty, value); }
        }


        public static readonly StyledProperty<bool> UseCommandProperty =
            AvaloniaProperty.Register<Form, bool>("UseCommand");


        public bool UseClass
        {
            get { return (bool)GetValue(UseClassProperty); }
            set { SetValue(UseClassProperty, value); }
        }


        public static readonly StyledProperty<bool> UseClassProperty =
            AvaloniaProperty.Register<Form, bool>("UseClass", true);


        public bool UseArray
        {
            get { return (bool)GetValue(UseArrayProperty); }
            set { SetValue(UseArrayProperty, value); }
        }


        public static readonly StyledProperty<bool> UseArrayProperty =
            AvaloniaProperty.Register<Form, bool>("UseArray");


        public bool UseInterface
        {
            get { return (bool)GetValue(UseInterfaceProperty); }
            set { SetValue(UseInterfaceProperty, value); }
        }


        public static readonly StyledProperty<bool> UseInterfaceProperty =
            AvaloniaProperty.Register<Form, bool>("UseInterface");

        public bool UsePrimitive
        {
            get { return (bool)GetValue(UsePrimitiveProperty); }
            set { SetValue(UsePrimitiveProperty, value); }
        }


        public static readonly StyledProperty<bool> UsePrimitiveProperty =
            AvaloniaProperty.Register<Form, bool>("UsePrimitive", true);

        public Func<PropertyInfo, object, IPropertyItemPresenter> Mapper
        {
            get { return (Func<PropertyInfo, object, IPropertyItemPresenter>)GetValue(MapperProperty); }
            set { SetValue(MapperProperty, value); }
        }


        public static readonly StyledProperty<Func<PropertyInfo, object, IPropertyItemPresenter>> MapperProperty =
            AvaloniaProperty.Register<Form, Func<PropertyInfo, object, IPropertyItemPresenter>>("Mapper");


        public bool UseGroup
        {
            get { return (bool)GetValue(UseGroupProperty); }
            set { SetValue(UseGroupProperty, value); }
        }


        public static readonly StyledProperty<bool> UseGroupProperty =
            AvaloniaProperty.Register<Form, bool>("UseGroup");

        public string UseGroupNames
        {
            get { return (string)GetValue(UseGroupNamesProperty); }
            set { SetValue(UseGroupNamesProperty, value); }
        }


        public static readonly StyledProperty<string> UseGroupNamesProperty =
            AvaloniaProperty.Register<Form, string>("UseGroupNames");

        public bool ModelState(out List<string> errors)
        {
            return this.SelectObject.ModelState(out errors);
        }

        public static readonly RoutedEvent<RoutedEventArgs> ValueChangedRoutedEvent =
            RoutedEvent.Register<RoutedEventArgs>("ValueChanged", RoutingStrategies.Bubble, typeof(Form));

        public event EventHandler ValueChanged
        {
            add { this.AddHandler(ValueChangedRoutedEvent, value); }
            remove { this.RemoveHandler(ValueChangedRoutedEvent, value); }
        }

        protected void OnValueChanged(Tuple<IPropertyItemPresenter, object> tuple)
        {
            RoutedEventArgs args = new RoutedEventArgs(ValueChangedRoutedEvent, this);
            args.Source = tuple;
            if (this.CheckAccess())
            {
                this.RaiseEvent(args);
            }
            else
            {
                this.Invoke(() => this.RaiseEvent(args));
            }
        }
    }

    public partial class Form
    {
        private bool _isRefreshing;
        public virtual void RefreshObject()
        {
            if (_isRefreshing)
                return;
            _isRefreshing = true;

            Dispatcher.UIThread.InvokeAsync(new Action(() =>
            {
                _isRefreshing = false;
                this.RefreshObjectinternal();
            }), DispatcherPriority.Input);
        }

        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        public static readonly StyledProperty<string> SearchTextProperty =
            AvaloniaProperty.Register<Form, string>("SearchText");

        public bool UseAsync
        {
            get { return (bool)GetValue(UseAsyncProperty); }
            set { SetValue(UseAsyncProperty, value); }
        }


        public static readonly StyledProperty<bool> UseAsyncProperty =
            AvaloniaProperty.Register<Form, bool>("UseAsync");


        protected void RefreshObjectinternal()
        {
            object o = this.SelectObject;
            if (o == null)
            {
                this.ItemsSource = null;
                return;
            }
            Type type = o.GetType();
            if (type.IsPrimitive || type == typeof(DateTime) || type == typeof(string))
            {
                this.ItemsSource = null;
                return;
            }

            List<PropertyInfo> propertys = new List<PropertyInfo>();
            Action<Type> action = null;
            action = l =>
            {
                if (l == null)
                    return;

                if (l.BaseType != typeof(object))
                {
                    action(l.BaseType);
                }

                PropertyInfo[] ps = l.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (ps != null)
                    propertys.AddRange(ps);


            };

            if (this.UseDeclaredOnly)
            {
                PropertyInfo[] ps = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (ps != null)
                    propertys.AddRange(ps);
            }
            else
            {
                action.Invoke(type);
            }
            List<IPropertyItemPresenter> items = new List<IPropertyItemPresenter>();

            var ss = propertys.Distinct();
            foreach (PropertyInfo item in propertys.Distinct())
            {
                if (this.UseCommandOnly && !typeof(ICommand).IsAssignableFrom(item.PropertyType))
                    continue;

                if (!this.UseEnumerator)
                {
                    if (typeof(IEnumerator).IsAssignableFrom(item.PropertyType) || typeof(IEnumerable).IsAssignableFrom(item.PropertyType))
                    {
                        if (item.PropertyType != typeof(string))
                            continue;
                    }
                }

                if (!this.UseEnum && item.PropertyType.IsEnum) continue;
                if (!this.UseDateTime && item.PropertyType == typeof(DateTime)) continue;
                if (!this.UseClass && item.PropertyType.IsClass)
                {
                    if (item.PropertyType != typeof(string))
                        continue;
                }
                if (!this.UseArray && item.PropertyType.IsArray) continue;
                if (!this.UseInterface && item.PropertyType.IsInterface) continue;
                if (!this.UsePrimitive && item.PropertyType.IsPrimitive) continue;
                if (!this.UseString && item.PropertyType == typeof(string)) continue;
                if (!this.UseBoolen && item.PropertyType == typeof(bool)) continue;
                if (!this.UseCommand && typeof(ICommand).IsAssignableFrom(item.PropertyType)) continue;

                if (!this.UseNull)
                {
                    if (item.Name != "Item")
                        if (item.GetValue(o) == null) continue;
                }

                //  Do ：筛选条件
                if (this.Filter != null && !this.Filter.Invoke(item))
                {
                    continue;
                }

                if (this.UseTypeConverterOnly)
                {
                    if (item.GetCustomAttribute<TypeConverterAttribute>() == null)
                    {
                        if (item.PropertyType?.GetCustomAttribute<TypeConverterAttribute>() == null)
                            continue;
                    }
                }

                if (!item.CanRead) continue;
                if (item.GetMethod?.Name == "get_Item") continue;
                if (item.Name == "System.Collections.IList.Item") continue;
                BrowsableAttribute browsable = item.GetCustomAttribute<BrowsableAttribute>();
                if (browsable != null && browsable.Browsable == false) continue;
                if (!string.IsNullOrEmpty(this.UseGroupNames))
                {
                    DisplayAttribute display = item.GetCustomAttribute<DisplayAttribute>();
                    string[] array = this.UseGroupNames.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] array1 = display?.GroupName?.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (array1 == null)
                    {
                        DisplayAttribute displayer = item.GetCustomAttribute<DisplayAttribute>();
                        array1 = displayer?.GroupName?.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    }

                    if (array1 == null)
                        continue;

                    if (array1.Count() > 1)
                    {

                    }

                    if (array.Intersect(array1).Count() == 0)
                    {
                        continue;
                        //var displayer = item.GetCustomAttribute<DisplayerAttribute>();
                        //if (!array.Contains(displayer?.GroupName))
                        //{
                        //    continue;
                        //}
                    }
                }

                if (this.UseDisplayOnly)
                {
                    if (item.GetCustomAttribute<DisplayAttribute>() == null)
                        continue;
                }

                if (!string.IsNullOrEmpty(this.UsePropertyNames))
                {
                    string[] array = this.UsePropertyNames.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (!array.Contains(item.Name))
                    {
                        continue;
                    }
                }

                if (!string.IsNullOrEmpty(this.ExceptPropertyNames))
                {
                    string[] array = this.ExceptPropertyNames.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (array.Contains(item.Name))
                    {
                        continue;
                    }
                }

                //System.Diagnostics.Debug.WriteLine($"PropertyGrid {o.GetType()} - {item.Name} - {item.PropertyType} - {item.GetValue(o)}");

                IPropertyItemPresenter from = this.Mapper?.Invoke(item, o);

                if (!string.IsNullOrEmpty(this.SearchText) && !from.Name.Contains(this.SearchText))
                    continue;
                if (from is ObjectPropertyItem obj)
                {
                    obj.ValueChanged = l =>
                    {
                        this.OnValueChanged(Tuple.Create(from, l));
                    };
                }
                items.Add(from);
            }

            IEnumerable<IPropertyItemPresenter> result;

            if (this.UseOrder)
            {
                result = items.OrderBy(x => x.Order);
            }
            else if (this.UseOrderByName)
            {
                result = items.OrderBy(x => x.Name);
            }
            else if (this.UseOrderByType)
            {
                result = items.OrderBy(x => x.GetType().Name);
            }
            else
            {
                result = items;
            }

            if (this.UseAsync)
            {
                ObservableCollection<IPropertyItemPresenter> observable = new ObservableCollection<IPropertyItemPresenter>();
                this.ItemsSource = observable;

                foreach (IPropertyItemPresenter item in result)
                {
                    Avalonia.Application.Current.BeginInvoke(DispatcherPriority.Input, new Action(() =>
                                {
                                    observable.Add(item);
                                }));
                }
            }
            else
            {
                this.ItemsSource = result;
            }

            if (this.UseGroup)
            {
                //ICollectionView view = CollectionViewSource.GetDefaultView(this.ItemsSource);
                //view.GroupDescriptions.Add(new PropertyGroupDescription("GroupName"));
            }
        }
    }

    public class StaticForm : Form
    {
        public override void RefreshObject()
        {
            this.RefreshObjectinternal();
        }
    }
}
