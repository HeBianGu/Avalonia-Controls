﻿// Copyright © 2024 By HeBianGu(QQ:908293466) https://github.com/HeBianGu/WPF-Control
#if NET
#endif
using Avalonia;
using Avalonia.Media;
using System.Globalization;
using System.Linq;

namespace System.Windows.Media
{
    public static class DrawingContextExtension
    {

        private static GeometryTypeConverter converter = new GeometryTypeConverter();
        public static void DrawGeometry(this DrawingContext dc, Brush brush, Pen pen, Geometry geometry, Rect target)
        {
            geometry.Transform = geometry.Bounds.TransformToRect(target);
            dc.DrawGeometry(brush, pen, geometry);
        }

        public static void DrawGeometry(this DrawingContext dc, Brush brush, Pen pen, string geometry, Rect target)
        {

            Geometry geo = converter.ConvertFromString(geometry) as Geometry;
            geo.Transform = geo.Bounds.TransformToRect(target);
            dc.DrawGeometry(brush, pen, geo);
        }

        public static void DrawGeometry(this DrawingContext dc, Brush brush, Pen pen, string geometry)
        {
            //Geometry geo = converter.ConvertFromString(geometry) as Geometry;
            //dc.DrawGeometry(brush, pen, geo);
        }
#if NET
        public static void DrawText(this DrawingContext dc, string text, Point point, Brush foreground, double fontSize = 15)
        {
            dc.DrawText(new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("微软雅黑"), fontSize, foreground), point);
        }
#endif

        public static FormattedText GetFormattedText(string text, double fontSize, Brush foreground)
        {
            if (fontSize > 30000)
                fontSize = 30000;
#if NET
            return new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("微软雅黑"), fontSize, foreground);
#else
            return new FormattedText(text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("微软雅黑"), fontSize, foreground);
#endif
        }
        ///// <summary>
        ///// 像素对齐
        ///// </summary>
        ///// <param name="dc"></param>
        ///// <param name="pen"></param>
        ///// <param name="lineThickness"></param>
        ///// <param name="points"></param>
        //public static void DrawSnappedLinesBetweenPoints(this DrawingContext dc, Pen pen, double lineThickness, params Point[] points)
        //{
        //    GuidelineSet guidelineSet = new GuidelineSet();
        //    foreach (Point point in points)
        //    {
        //        guidelineSet.GuidelinesX.Add(point.X);
        //        guidelineSet.GuidelinesY.Add(point.Y);
        //    }
        //    double half = lineThickness / 2;
        //    points = points.Select(p => new Point(p.X + half, p.Y + half)).ToArray();
        //    dc.PushGuidelineSet(guidelineSet);
        //    for (int i = 0; i < points.Length - 1; i = i + 2)
        //    {
        //        dc.DrawLine(pen, points[i], points[i + 1]);
        //    }
        //    dc.Pop();

        //    //dc.DrawSnappedLinesBetweenPoints(_pen, LineThickness,
        //    //        new Point(0, 0), new Point(320, 0),
        //    //        new Point(0, 40), new Point(320, 40),
        //    //        new Point(0, 80.5), new Point(320, 80.5),
        //    //        new Point(0, 119.7777), new Point(320, 119.7777),
        //    //        new Point(0, 0), new Point(0, 120));
        //}


        public static void DrawTextCenterTo(this DrawingContext dc, FormattedText format, Point from, Point to)
        {
            Vector vector = to - from;
            //var project = vector.ToPerpendicular();
            //project = project / project.Length;
            //var format = GetFormattedText(text, fontSize, foreground);
            Point center = from + (vector / 2) - new Vector(format.Width / 2, format.Height / 2);
            double angle = vector.ToAngle();
            RotateTransform transform = new RotateTransform() { Angle = angle, CenterX = center.X + (format.Width / 2), CenterY = center.Y + (format.Height / 2) };
            //dc.PushTransform(transform);
            dc.DrawText(format, center);
            //dc.Pop();

            double percent = format.Width / vector.Length;

            //Point ft = from + project * 10 / dc.BlueprintDPI;
            //Point tt = to + project * 10 / dc.BlueprintDPI;
            //Vector vt = tt - ft;

            //dc.DrawLine(foreground, from, from + vector / 2 - vector * percent / 2);
            //dc.DrawLine(foreground, to - vector / 2 + vector * percent / 2, to);
        }
    }

    public static class RectExtension
    {
        public static Transform TransformToRect(this Rect src, Rect target)
        {
            ScaleTransform scaleTransform = new ScaleTransform(target.Width / src.Width, target.Height / src.Width);
            TranslateTransform translateTransform = new TranslateTransform(target.Left, target.Top);
            TransformGroup group = new TransformGroup();
            group.Children.Add(scaleTransform);
            group.Children.Add(translateTransform);
            return group;
        }
    }
}