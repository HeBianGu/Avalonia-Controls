// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace HeBianGu.AvaloniaUI.Form
{
    public class TypeCTestModel
    {
        public Thickness Thickness { get; set; }

        [TypeConverter(typeof(Int32Converter))]
        public int[] Int32Converter { get; set; }

        //public DoubleCollection DoubleCollection { get; set; }

        //public Int32Collection Int32Collection { get; set; }

        [DefaultValue(5)]
        [TypeConverter(typeof(Int16Converter))]
        public int Int16Converter { get; set; }

        [TypeConverter(typeof(DoubleConverter))]
        public double DoubleConverter { get; set; }

        [TypeConverter(typeof(BooleanConverter))]
        public bool BooleanConverter { get; set; }


        [TypeConverter(typeof(ByteConverter))]
        public int ByteConverter { get; set; }


        [TypeConverter(typeof(CharConverter))]
        public char CharConverter { get; set; }

        [TypeConverter(typeof(CollectionConverter))]
        public double[] CollectionConverter { get; set; }

        [TypeConverter(typeof(ComponentConverter))]
        public Component ComponentConverter { get; set; }

        [TypeConverter(typeof(CultureInfoConverter))]
        public CultureInfo CultureInfoConverter { get; set; }


        [TypeConverter(typeof(DateTimeConverter))]
        public DateTime DateTimeConverter { get; set; }

        [TypeConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset DateTimeOffsetConverter { get; set; }

        [TypeConverter(typeof(DecimalConverter))]
        public Decimal DecimalConverter { get; set; }

        [TypeConverter(typeof(EnumConverter))]
        public TestType EnumConverter { get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public object ExpandableObjectConverter { get; set; }

        [TypeConverter(typeof(GuidConverter))]
        public Guid GuidConverter { get; set; }

        [TypeConverter(typeof(MultilineStringConverter))]
        public string MultilineStringConverter { get; set; }

        [TypeConverter(typeof(NullableConverter))]
        public int? NullableConverter { get; set; }

        [TypeConverter(typeof(ReferenceConverter))]
        public object ReferenceConverter { get; set; }

        [TypeConverter(typeof(SByteConverter))]
        public sbyte SByteConverter { get; set; }

        [TypeConverter(typeof(SingleConverter))]
        public float SingleConverter { get; set; }

        [TypeConverter(typeof(StringConverter))]
        public string StringConverter { get; set; }

        [TypeConverter(typeof(TimeSpanConverter))]
        public TimeSpan TimeSpanConverter { get; set; }

        [TypeConverter(typeof(TypeConverter))]
        public Type TypeConverter { get; set; }

        [TypeConverter(typeof(TypeListConverter))]
        public List<Type> TypeListConverter { get; set; }

        //[TypeConverter(typeof(LogConverter))]
        //public System.Diagnostics.EventLog LogConverter { get; set; }

        //[TypeConverter(typeof(ColorConverter))]
        //public Color ColorConverter { get; set; }

        //[TypeConverter(typeof(System.Drawing.FontConverter))]
        //public System.Drawing.Font FontConverter { get; set; }


        //[TypeConverter(typeof(System.Drawing.IconConverter))]
        //public System.Drawing.Icon IconConverter { get; set; }

        //[TypeConverter(typeof(System.Drawing.ImageConverter))]
        //public System.Drawing.Image ImageConverter { get; set; }

        //[TypeConverter(typeof(System.Drawing.ImageFormatConverter))]
        //public System.Drawing.Imaging.ImageFormat ImageFormatConverter { get; set; }

        //[TypeConverter(typeof(PointConverter))]
        //public Point PointConverter { get; set; }

        //[TypeConverter(typeof(MarginsConverter))]
        //public Margins MarginsConverter { get; set; }

        [TypeConverter(typeof(UriTypeConverter))]
        public Uri UriTypeConverter { get; set; }
    }
}
