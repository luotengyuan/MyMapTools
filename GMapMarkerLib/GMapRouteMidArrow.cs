using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace GMapMarkerLib
{
    public class GMapRouteMidArrow : GMapRoute
    {
        private bool isArrow = true;
        private Pen pen = new Pen(Color.Black, 2f);
        private Pen pen2 = new Pen(Color.Black, 2f);
        private List<PointLatLng> points;
        private StringFormat TipFormat;
        public Font TipFont { set; get; }
        public Brush TipBrush { set; get; }
        private string tipText;

        // Methods
        public GMapRouteMidArrow(List<PointLatLng> points, string name, string tip = null)
            : base(points, name)
        {
            TipFont = new Font("微软雅黑", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            TipBrush = new SolidBrush(Color.Blue);
            this.points = points;
            this.tipText = tip;

            if (this.isArrow)
            {
                pen.EndCap = LineCap.ArrowAnchor;
                pen.CustomEndCap = new AdjustableArrowCap(3f, 6f, false);
            }
            Stroke = pen;
        }

        /// <summary>
        /// 更改显示文字
        /// </summary>
        /// <param name="tipText"></param>
        public void SetTip(string tipText)
        {
            this.tipText = tipText;
        }
     
        public override void OnRender(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            
            if (tipText != null)
            {
                System.Drawing.Size st = g.MeasureString(tipText, TipFont).ToSize();
                PointLatLng position = points[points.Count/2];
                Point p = new Point((int)LocalPoints[LocalPoints.Count/2].X, (int)LocalPoints[LocalPoints.Count/2].Y);
                g.DrawString(tipText, TipFont, TipBrush, p, TipFormat);
            }

            for (int i = 1; i < LocalPoints.Count; i++)
            {
                GPoint start = LocalPoints[i - 1];
                GPoint end = LocalPoints[i];
                GPoint mid = new GPoint((start.X + end.X) / 2, (start.Y + end.Y) / 2);
                g.DrawLine(pen, new Point((int)start.X, (int)start.Y), new Point((int)mid.X, (int)mid.Y));
                g.DrawLine(pen2, new Point((int)mid.X, (int)mid.Y), new Point((int)end.X, (int)end.Y));
            }

            //base.OnRender(g);
        }

        public override void Dispose()
        {
            if (pen != null)
            {
                pen.Dispose();
                pen = null;
            }

            if (TipFont != null)
            {
                TipFont.Dispose();
                TipFont = null;
            }

            if (TipBrush != null)
            {
                TipBrush.Dispose();
                TipBrush = null;
            }

            base.Dispose();
        }
    }
}
