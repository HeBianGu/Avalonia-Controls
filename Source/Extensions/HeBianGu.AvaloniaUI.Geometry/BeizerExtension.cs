﻿using Avalonia;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BezierCurveSample.View.Utils
{
    //  Do ：https://www.codeproject.com/Articles/769055/Interpolate-2D-Points-Using-Bezier-Curves-in-WPF
    public class BeizerExtension
    {
        public class BeizerCurveSegment
        {
            public Point StartPoint { get; set; }
            public Point EndPoint { get; set; }
            public Point FirstControlPoint { get; set; }
            public Point SecondControlPoint { get; set; }
        }

        public static List<BeizerCurveSegment> GetPointToBeizers(List<Point> points, bool isClosedCurve)
        {
            if (points.Count < 3)
                return null;
            var toRet = new List<BeizerCurveSegment>();

            //if is close curve then add the first point at the end
            if (isClosedCurve)
                points.Add(points.First());

            for (int i = 0; i < points.Count - 1; i++)   //iterate for points but the last one
            {
                // Assume we need to calculate the control
                // points between (x1,y1) and (x2,y2).
                // Then x0,y0 - the previous vertex,
                //      x3,y3 - the next one.
                double x1 = points[i].X;
                double y1 = points[i].Y;

                double x2 = points[i + 1].X;
                double y2 = points[i + 1].Y;

                double x0;
                double y0;

                if (i == 0) //if is first point
                {
                    if (isClosedCurve)
                    {
                        var previousPoint = points[points.Count - 2];    //last Point, but one (due inserted the first at the end)
                        x0 = previousPoint.X;
                        y0 = previousPoint.Y;
                    }
                    else    //Get some previouse point
                    {
                        var previousPoint = points[i];  //if is the first point the previous one will be it self
                        x0 = previousPoint.X;
                        y0 = previousPoint.Y;
                    }
                }
                else
                {
                    x0 = points[i - 1].X;   //Previous Point
                    y0 = points[i - 1].Y;
                }

                double x3, y3;

                if (i == points.Count - 2)    //if is the last point
                {
                    if (isClosedCurve)
                    {
                        var nextPoint = points[1];  //second Point(due inserted the first at the end)
                        x3 = nextPoint.X;
                        y3 = nextPoint.Y;
                    }
                    else    //Get some next point
                    {
                        var nextPoint = points[i + 1];  //if is the last point the next point will be the last one
                        x3 = nextPoint.X;
                        y3 = nextPoint.Y;
                    }
                }
                else
                {
                    x3 = points[i + 2].X;   //Next Point
                    y3 = points[i + 2].Y;
                }

                double xc1 = (x0 + x1) / 2.0;
                double yc1 = (y0 + y1) / 2.0;
                double xc2 = (x1 + x2) / 2.0;
                double yc2 = (y1 + y2) / 2.0;
                double xc3 = (x2 + x3) / 2.0;
                double yc3 = (y2 + y3) / 2.0;

                double len1 = Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
                double len2 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                double len3 = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));

                double k1 = len1 / (len1 + len2);
                double k2 = len2 / (len2 + len3);

                double xm1 = xc1 + (xc2 - xc1) * k1;
                double ym1 = yc1 + (yc2 - yc1) * k1;

                double xm2 = xc2 + (xc3 - xc2) * k2;
                double ym2 = yc2 + (yc3 - yc2) * k2;

                const double smoothValue = 0.8;
                // Resulting control points. Here smooth_value is mentioned
                // above coefficient K whose value should be in range [0...1].
                double ctrl1_x = xm1 + (xc2 - xm1) * smoothValue + x1 - xm1;
                double ctrl1_y = ym1 + (yc2 - ym1) * smoothValue + y1 - ym1;

                double ctrl2_x = xm2 + (xc2 - xm2) * smoothValue + x2 - xm2;
                double ctrl2_y = ym2 + (yc2 - ym2) * smoothValue + y2 - ym2;
                toRet.Add(new BeizerCurveSegment
                {
                    StartPoint = new Point(x1, y1),
                    EndPoint = new Point(x2, y2),
                    FirstControlPoint = i == 0 && !isClosedCurve ? new Point(x1, y1) : new Point(ctrl1_x, ctrl1_y),
                    SecondControlPoint = i == points.Count - 2 && !isClosedCurve ? new Point(x2, y2) : new Point(ctrl2_x, ctrl2_y)
                });
            }

            return toRet;
        }

        //public static PathSegmentCollection GetPointsBeizerSegments(List<Point> points, bool isClosedCurve)
        //{
        //    var myPathSegmentCollection = new PathSegmentCollection();
        //    var beizerSegments = GetPointToBeizers(points, isClosedCurve);
        //    if (beizerSegments == null || beizerSegments.Count < 1)
        //    {
        //        foreach (var point in points.GetRange(1, points.Count - 1))
        //        {

        //            var myLineSegment = new LineSegment { Point = point };
        //            myPathSegmentCollection.Add(myLineSegment);
        //        }
        //    }
        //    else
        //    {
        //        foreach (var beizerCurveSegment in beizerSegments)
        //        {
        //            var segment = new BezierSegment
        //            {
        //                Point1 = beizerCurveSegment.FirstControlPoint,
        //                Point2 = beizerCurveSegment.SecondControlPoint,
        //                Point3 = beizerCurveSegment.EndPoint
        //            };
        //            myPathSegmentCollection.Add(segment);
        //        }
        //    }
        //    return myPathSegmentCollection;
        //}

        //public static Geometry GetPointsToBeizerGeometry(List<Point> points, bool isClosedCurve)
        //{
        //    var myPathFigure = new PathFigure { StartPoint = points.FirstOrDefault() };
        //    myPathFigure.Segments = GetPointsBeizerSegments(points, isClosedCurve);
        //    var myPathFigureCollection = new PathFigureCollection { myPathFigure };
        //    return new PathGeometry { Figures = myPathFigureCollection };
        //}
    }
}
