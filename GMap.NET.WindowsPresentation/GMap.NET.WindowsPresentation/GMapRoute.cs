﻿
namespace GMap.NET.WindowsPresentation
{
   using System;
   using System.Collections.Generic;
   using System.Windows;
   using System.Windows.Media;
   using System.Windows.Media.Effects;
   using System.Windows.Shapes;

   public interface IShapable
   {
      List<PointLatLng> Points
      {
         get; set;
      }

      Path CreatePath(List<System.Windows.Point> localPath, bool addBlurEffect);
   }

   public class GMapRoute : GMapMarker, IShapable
   {
      public GMapRoute(IEnumerable<PointLatLng> points)
      {
         Points = new List<PointLatLng>(points);
      }

      public List<PointLatLng> Points
      {
         get;
         set;
      }

      public override void Clear()
      {
         base.Clear();
         Points.Clear();
      }

      /// <summary>
      /// creates path from list of points, for performance set addBlurEffect to false
      /// </summary>
      /// <param name="pl"></param>
      /// <returns></returns>
      public virtual Path CreatePath(List<System.Windows.Point> localPath, bool addBlurEffect)
      {
         // Create a StreamGeometry to use to specify myPath.
         StreamGeometry geometry = new StreamGeometry();

         using(StreamGeometryContext ctx = geometry.Open())
         {
            ctx.BeginFigure(localPath[0], false, false);

            // Draw a line to the next specified point.
            ctx.PolyLineTo(localPath, true, true);
         }

         // Freeze the geometry (make it unmodifiable)
         // for additional performance benefits.
         geometry.Freeze();

         // Create a path to draw a geometry with.
         Path myPath = new Path();
         {
            // Specify the shape of the Path using the StreamGeometry.
            myPath.Data = geometry;

            if(addBlurEffect)
            {
               BlurEffect ef = new BlurEffect();
               {
                  ef.KernelType = KernelType.Gaussian;
                  ef.Radius = 3.0;
                  ef.RenderingBias = RenderingBias.Performance;
               }

               myPath.Effect = ef;
            }

            myPath.Stroke = Brushes.Navy;
            myPath.StrokeThickness = 5;
            myPath.StrokeLineJoin = PenLineJoin.Round;
            myPath.StrokeStartLineCap = PenLineCap.Triangle;
            myPath.StrokeEndLineCap = PenLineCap.Square;

            myPath.Opacity = 0.6;
            myPath.IsHitTestVisible = false;
         }
         return myPath;
      }
   }
}
