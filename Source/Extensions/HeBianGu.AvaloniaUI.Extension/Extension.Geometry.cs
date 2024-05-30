﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control

using Avalonia;
using Avalonia.Media;

namespace System.Windows.Media
{
    public static class GeometryExtension
    {
        ///// <summary>
        /////     获取路径总长度
        ///// </summary>
        ///// <param name="geometry"></param>
        ///// <returns></returns>
        //public static double GetTotalLength(this Geometry geometry)
        //{
        //    if (geometry == null) return 0;

        //    PathGeometry pathGeometry = PathGeometry.CreateFromGeometry(geometry);
        //    pathGeometry.GetPointAtFractionLength(1e-4, out Point point, out _);
        //    double length = (pathGeometry.Figures[0].StartPoint - point).Length * 1e+4;

        //    return length;
        //}

        ///// <summary>
        /////     获取路径总长度
        ///// </summary>
        ///// <param name="geometry"></param>
        ///// <param name="size"></param>
        ///// <param name="strokeThickness"></param>
        ///// <returns></returns>
        //public static double GetTotalLength(this Geometry geometry, Size size, double strokeThickness = 1)
        //{
        //    if (geometry == null) 
        //        return 0;
        //    Predicate<double> match = l =>
        //      {
        //          return Math.Abs(l) < 1E-06;
        //      };

        //    if (match(size.Width) || match(size.Height)) 
        //        return 0;
        //    if(geometry.Bounds.Width==0||geometry.Bounds.Height==0)
        //        return 0;

        //    double length = GetTotalLength(geometry);
        //    double sw = geometry.Bounds.Width / size.Width;
        //    double sh = geometry.Bounds.Height / size.Height;
        //    double min = Math.Min(sw, sh);

        //    if (match(min) || match(strokeThickness)) 
        //        return 0;

        //    length /= min;
        //    return length / strokeThickness;
        //}

        private static GeometryTypeConverter converter = new GeometryTypeConverter();

        public static Geometry GetGeometry(this string data)
        {
            return converter.ConvertFromString(data) as Geometry;
        }
    }
}