// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Cache;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace HeBianGu.AvaloniaUI.Form
{

    public class ControlTypeConverterModel
    {
        //[TypeConverter(typeof(DataGridLengthConverter))]
        //public DataGridLength DataGridLengthConverter { get; set; }

        //[TypeConverter(typeof(StringCollectionConverter))]
        //public Uri StringCollectionConverter { get; set; }

        //[TypeConverter(typeof(VirtualizationCacheLengthConverter))]
        //public VirtualizationCacheLength VirtualizationCacheLengthConverter { get; set; }

        //[TypeConverter(typeof(CornerRadiusConverter))]
        //public CornerRadius CornerRadiusConverter { get; set; }

        //[TypeConverter(typeof(CultureInfoIetfLanguageTagConverter))]
        //public CultureInfo CultureInfoIetfLanguageTagConverter { get; set; }

        //[TypeConverter(typeof(DeferrableContentConverter))]
        //public DeferrableContent DeferrableContentConverter { get; set; }

        //[TypeConverter(typeof(DialogResultConverter))]
        //public bool? DialogResultConverter { get; set; }

        //[TypeConverter(typeof(DurationConverter))]
        //public Duration DurationConverter { get; set; }

        //[TypeConverter(typeof(DynamicResourceExtensionConverter))]
        //public DynamicResourceExtension DynamicResourceExtensionConverter { get; set; }

        //[TypeConverter(typeof(ExpressionConverter))]
        //public Expression ExpressionConverter { get; set; }

        //[TypeConverter(typeof(FigureLengthConverter))]
        //public FigureLength FigureLengthConverter { get; set; }

        //[TypeConverter(typeof(FontSizeConverter))]
        //public string FontSizeConverter { get; set; }

        //[TypeConverter(typeof(FontStretchConverter))]
        //public FontStretch FontStretchConverter { get; set; }

        //[TypeConverter(typeof(FontStyleConverter))]
        //public FontStyle FontStyleConverter { get; set; }

        //[TypeConverter(typeof(FontWeightConverter))]
        //public FontWeight FontWeightConverter { get; set; }

        //[TypeConverter(typeof(GridLengthConverter))]
        //public GridLength GridLengthConverter { get; set; }

        //[TypeConverter(typeof(CommandConverter))]
        //public ICommand CommandConverter { get; set; }

        //[TypeConverter(typeof(CursorConverter))]
        //public Cursor CursorConverter { get; set; }

        //[TypeConverter(typeof(InputScopeConverter))]
        //public InputScope InputScopeConverter { get; set; }

        //[TypeConverter(typeof(InputScopeNameConverter))]
        //public InputScopeName InputScopeNameConverter { get; set; }

        //[TypeConverter(typeof(KeyConverter))]
        //public Key KeyConverter { get; set; }

        //[TypeConverter(typeof(ModifierKeysConverter))]
        //public ModifierKeys ModifierKeysConverter { get; set; }

        //[TypeConverter(typeof(MouseActionConverter))]
        //public MouseAction MouseActionConverter { get; set; }

        //[TypeConverter(typeof(MouseGestureConverter))]
        //public MouseGesture MouseGestureConverter { get; set; }

        //[TypeConverter(typeof(Int32RectConverter))]
        //public Int32Rect Int32RectConverter { get; set; }

        //[TypeConverter(typeof(KeySplineConverter))]
        //public KeySpline KeySplineConverter { get; set; }

        //[TypeConverter(typeof(KeyTimeConverter))]
        //public KeyTime KeyTimeConverter { get; set; }

        ///// <summary>
        ///// * ATUO 等支持
        ///// </summary>
        //[TypeConverter(typeof(LengthConverter))]
        //public double LengthConverter { get; set; }

        //[TypeConverter(typeof(ComponentResourceKeyConverter))]
        //public ComponentResourceKey ComponentResourceKeyConverter { get; set; }

        //[TypeConverter(typeof(StyledPropertyConverter))]
        //public StyledProperty StyledPropertyConverter { get; set; }

        //[TypeConverter(typeof(EventSetterHandlerConverter))]
        //public EventSetter EventSetterHandlerConverter { get; set; }

        ////[TypeConverter(typeof(NameReferenceConverter))]
        ////public NameReference NameReferenceConverter { get; set; }

        ////[TypeConverter(typeof(ResourceReferenceExpressionConverter))]
        ////public ResourceReferenceExpression ResourceReferenceExpressionConverter { get; set; }

        //[TypeConverter(typeof(RoutedEventConverter))]
        //public RoutedEvent RoutedEventConverter { get; set; }

        //[TypeConverter(typeof(SetterTriggerConditionValueConverter))]
        //public Setter SetterTriggerConditionValueConverter { get; set; }

        //[TypeConverter(typeof(TemplateKeyConverter))]
        //public TemplateKey TemplateKeyConverter { get; set; }

        //[TypeConverter(typeof(XmlLanguageConverter))]
        //public XmlLanguage XmlLanguageConverter { get; set; }

        //[TypeConverter(typeof(RepeatBehaviorConverter))]
        //public RepeatBehavior RepeatBehaviorConverter { get; set; }

        [TypeConverter(typeof(BrushConverter))]
        public Brush BrushConverter { get; set; }

        //[TypeConverter(typeof(CacheModeConverter))]
        //public CacheMode CacheModeConverter { get; set; }

        //[TypeConverter(typeof(BoolIListConverter))]
        //public List<bool> BoolIListConverter { get; set; }

        //[TypeConverter(typeof(CharIListConverter))]
        //public List<char> CharIListConverter { get; set; }


        //[TypeConverter(typeof(DoubleIListConverter))]
        //public List<double> DoubleIListConverter { get; set; }

        [TypeConverter(typeof(PointsListTypeConverter))]
        public List<Point> PointIListConverter { get; set; }

        //[TypeConverter(typeof(UShortIListConverter))]
        //public List<ushort> UShortIListConverter { get; set; }

        [TypeConverter(typeof(FontFamilyTypeConverter))]
        public FontFamily FontFamilyConverter { get; set; }

        [TypeConverter(typeof(UriTypeConverter))]
        public Uri UriTypeConverter { get; set; }

        /// <summary>
        /// 重点看下
        /// </summary>
        [TypeConverter(typeof(GeometryTypeConverter))]
        public Geometry GeometryConverter { get; set; } = new EllipseGeometry(new Rect(0, 0, 100, 200));

        //[TypeConverter(typeof(ImageSourceConverter))]
        //public ImageSource ImageSourceConverter { get; set; }

        //[TypeConverter(typeof(MatrixConverter))]
        //public Matrix MatrixConverter { get; set; }

        //[TypeConverter(typeof(Matrix3DConverter))]
        //public Matrix3D Matrix3DConverter { get; set; }

        //[TypeConverter(typeof(Point3DCollectionConverter))]
        //public Point3DCollection Point3DCollectionConverter { get; set; }

        //[TypeConverter(typeof(Point3DConverter))]
        //public Point3D Point3DConverter { get; set; }

        //[TypeConverter(typeof(Point4DConverter))]
        //public Point4D Point4DConverter { get; set; }

        //[TypeConverter(typeof(QuaternionConverter))]
        //public Quaternion QuaternionConverter { get; set; }

        //[TypeConverter(typeof(Rect3DConverter))]
        //public Rect3D Rect3DConverter { get; set; }

        //[TypeConverter(typeof(Size3DConverter))]
        //public Size3D Size3DConverter { get; set; }

        //[TypeConverter(typeof(Vector3DCollectionConverter))]
        //public Vector3DCollection Vector3DCollectionConverter { get; set; }

        //[TypeConverter(typeof(Vector3DConverter))]
        //public Vector3D Vector3DConverter { get; set; }

        //[TypeConverter(typeof(PathFigureCollectionConverter))]
        //public PathFigureCollection PathFigureCollectionConverter { get; set; }

        //[TypeConverter(typeof(PixelFormatConverter))]
        //public PixelFormat PixelFormatConverter { get; set; }

        //[TypeConverter(typeof(PointCollectionConverter))]
        //public PointCollection PointCollectionConverter { get; set; }

        //[TypeConverter(typeof(RequestCachePolicyConverter))]
        //public RequestCachePolicy RequestCachePolicyConverter { get; set; }

        [TypeConverter(typeof(TransformConverter))]
        public Transform TransformConverter { get; set; }

        //[TypeConverter(typeof(VectorCollectionConverter))]
        //public VectorCollection VectorCollectionConverter { get; set; }

        //[TypeConverter(typeof(NullableBoolConverter))]
        //public bool? NullableBoolConverter { get; set; }

        //[TypeConverter(typeof(PointConverter))]
        //public Point PointConverter { get; set; }

        //[TypeConverter(typeof(PropertyPathConverter))]
        //public PropertyPath PropertyPathConverter { get; set; }

        //[TypeConverter(typeof(RectConverter))]
        //public Rect RectConverter { get; set; }

        //[TypeConverter(typeof(SizeConverter))]
        //public Size SizeConverter { get; set; }

        //[TypeConverter(typeof(StrokeCollectionConverter))]
        //public StrokeCollection StrokeCollectionConverter { get; set; }

        //[TypeConverter(typeof(TemplateBindingExpressionConverter))]
        //public TemplateBindingExpression TemplateBindingExpressionConverter { get; set; }

        //[TypeConverter(typeof(TemplateBindingExtensionConverter))]
        //public TemplateBindingExtension TemplateBindingExtensionConverter { get; set; }

        //[TypeConverter(typeof(TextDecorationCollectionConverter))]
        //public TextDecoration TextDecorationCollectionConverter { get; set; }

        //[TypeConverter(typeof(ThicknessConverter))]
        //public Thickness ThicknessConverter { get; set; }

        //[TypeConverter(typeof(VectorConverter))]
        //public Vector VectorConverter { get; set; }

        //[TypeConverter(typeof(XamlTypeTypeConverter))]
        //public XamlType XamlTypeTypeConverter { get; set; }
    }

    public enum TestType
    {
        Default = 0, X, Y, Z
    }
}
