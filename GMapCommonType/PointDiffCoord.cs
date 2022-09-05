using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET;
using GMapPositionFix;

namespace GMapCommonType
{
    public class PointInDiffCoord
    {
        private PointLatLng wgs84; 
        public PointLatLng WGS84
        {
            get
            {
                double lon, lat;
                if (CoordType == CoordType.WGS84)
                {
                    return wgs84;
                }
                else if (CoordType == CoordType.GCJ02)
                {
                    if (wgs84 == PointLatLng.Empty)
                    {
                        CoordinateTransform.ConvertGcj02ToWgs84(gcj02.Lng, gcj02.Lat, out lon, out lat);
                        wgs84.Lat = lat;
                        wgs84.Lng = lon;
                    }
                    return wgs84;
                }
                else if (CoordType == CoordType.BD09)
                {
                    if (wgs84 == PointLatLng.Empty)
                    {
                        CoordinateTransform.ConvertBd09ToWgs84(bd09.Lng, bd09.Lat, out lon, out lat);
                        wgs84.Lat = lat;
                        wgs84.Lng = lon;
                    }
                    return wgs84;
                }
                else
                {
                    return PointLatLng.Empty;
                }
            }
        }
        private PointLatLng gcj02;
        public PointLatLng GCJ02
        {
            get
            {
                double lon, lat;
                if (CoordType == CoordType.WGS84)
                {
                    if (gcj02 == PointLatLng.Empty)
                    {
                        CoordinateTransform.ConvertWgs84ToGcj02(wgs84.Lng, wgs84.Lat, out lon, out lat);
                        gcj02.Lat = lat;
                        gcj02.Lng = lon;
                    }
                    return gcj02;
                }
                else if (CoordType == CoordType.GCJ02)
                {
                    return gcj02;
                }
                else if (CoordType == CoordType.BD09)
                {
                    if (gcj02 == PointLatLng.Empty)
                    {
                        CoordinateTransform.ConvertBd09ToGcj02(bd09.Lng, bd09.Lat, out lon, out lat);
                        gcj02.Lat = lat;
                        gcj02.Lng = lon;
                    }
                    return gcj02;
                }
                else
                {
                    return PointLatLng.Empty;
                }
            }
        }
        private PointLatLng bd09;
        public PointLatLng BD09
        {
            get
            {
                double lon, lat;
                if (CoordType == CoordType.WGS84)
                {
                    if (bd09 == PointLatLng.Empty)
                    {
                        CoordinateTransform.ConvertWgs84ToBd09(wgs84.Lng, wgs84.Lat, out lon, out lat);
                        bd09.Lat = lat;
                        bd09.Lng = lon;
                    }
                    return bd09;
                }
                else if (CoordType == CoordType.GCJ02)
                {
                    if (bd09 == PointLatLng.Empty)
                    {
                        CoordinateTransform.ConvertGcj02ToBd09(gcj02.Lng, gcj02.Lat, out lon, out lat);
                        bd09.Lat = lat;
                        bd09.Lng = lon;
                    }
                    return bd09;
                }
                else if (CoordType == CoordType.BD09)
                {
                    return bd09;
                }
                else
                {
                    return PointLatLng.Empty;
                }
            }
        }
        public CoordType CoordType;
        public PointInDiffCoord()
        {
            wgs84 = PointLatLng.Empty;
            gcj02 = PointLatLng.Empty;
            bd09 = PointLatLng.Empty;
            CoordType = CoordType.UNKNOW;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="p"></param>
        public PointInDiffCoord(PointLatLng p)
        {
            if (p.Type == CoordType.WGS84)
            {
                wgs84 = p;
                gcj02 = PointLatLng.Empty;
                bd09 = PointLatLng.Empty;
                CoordType = CoordType.WGS84;
            }
            else if (p.Type == CoordType.GCJ02)
            {
                wgs84 = PointLatLng.Empty;
                gcj02 = p;
                bd09 = PointLatLng.Empty;
                CoordType = CoordType.GCJ02;
            }
            else if (p.Type == CoordType.BD09)
            {
                wgs84 = PointLatLng.Empty;
                gcj02 = PointLatLng.Empty;
                bd09 = p;
                CoordType = CoordType.BD09;
            }
            else
            {
                wgs84 = PointLatLng.Empty;
                gcj02 = PointLatLng.Empty;
                bd09 = PointLatLng.Empty;
                CoordType = CoordType.UNKNOW;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        public PointInDiffCoord(double lat, double lon)
            : this(new PointLatLng(lat, lon))
        {
            
        }

        public static PointLatLng GetWGS84Point(PointLatLng p)
        {
            double lon, lat;
            if (p != PointLatLng.Empty)
            {
                if (p.Type == CoordType.WGS84)
                {
                    return p;
                }
                else if (p.Type == CoordType.GCJ02)
                {
                    CoordinateTransform.ConvertGcj02ToWgs84(p.Lng, p.Lat, out lon, out lat);
                    return new PointLatLng(lat, lon, CoordType.WGS84);
                }
                else if (p.Type == CoordType.BD09)
                {
                    CoordinateTransform.ConvertBd09ToWgs84(p.Lng, p.Lat, out lon, out lat);
                    return new PointLatLng(lat, lon, CoordType.WGS84);
                }
                else
                {
                    return PointLatLng.Empty;
                }
            }
            else
            {
                return PointLatLng.Empty;
            }
        }

        public static PointLatLng GetGCJ02Point(PointLatLng p)
        {
            double lon, lat;
            if (p != PointLatLng.Empty)
            {
                if (p.Type == CoordType.WGS84)
                {
                    CoordinateTransform.ConvertWgs84ToGcj02(p.Lng, p.Lat, out lon, out lat);
                    return new PointLatLng(lat, lon, CoordType.GCJ02);
                }
                else if (p.Type == CoordType.GCJ02)
                {
                    return p;
                }
                else if (p.Type == CoordType.BD09)
                {
                    CoordinateTransform.ConvertBd09ToGcj02(p.Lng, p.Lat, out lon, out lat);
                    return new PointLatLng(lat, lon, CoordType.GCJ02);
                }
                else
                {
                    return PointLatLng.Empty;
                }
            }
            else
            {
                return PointLatLng.Empty;
            }
        }

        public static PointLatLng GetBD09Point(PointLatLng p)
        {
            double lon, lat;
            if (p != PointLatLng.Empty)
            {
                if (p.Type == CoordType.WGS84)
                {
                    CoordinateTransform.ConvertWgs84ToBd09(p.Lng, p.Lat, out lon, out lat);
                    return new PointLatLng(lat, lon, CoordType.BD09);
                }
                else if (p.Type == CoordType.GCJ02)
                {
                    CoordinateTransform.ConvertGcj02ToBd09(p.Lng, p.Lat, out lon, out lat);
                    return new PointLatLng(lat, lon, CoordType.BD09);
                }
                else if (p.Type == CoordType.BD09)
                {
                    return p;
                }
                else
                {
                    return PointLatLng.Empty;
                }
            }
            else
            {
                return PointLatLng.Empty;
            }
        }

        public static PointLatLng GetPointInCoordType(PointLatLng p, CoordType destType)
        {
            if (destType == CoordType.WGS84)
            {
                return GetWGS84Point(p);
            }
            else if (destType == CoordType.GCJ02)
            {
                return GetGCJ02Point(p);
            }
            else if (destType == CoordType.BD09)
            {
                return GetBD09Point(p);
            }
            else
            {
                return p;
            }
        }

        public static PointLatLng GetPointInCoordType(PointLatLng p, CoordType srcType, CoordType destType)
        {
            p.Type = srcType;
            if (destType == CoordType.WGS84)
            {
                return GetWGS84Point(p);
            }
            else if (destType == CoordType.GCJ02)
            {
                return GetGCJ02Point(p);
            }
            else if (destType == CoordType.BD09)
            {
                return GetBD09Point(p);
            }
            else
            {
                return p;
            }
        }

        public static PointLatLng GetPointInCoordType(double lat, double lon, CoordType srcType, CoordType destType)
        {
            PointLatLng p = new PointLatLng(lat, lon, srcType);
            if (destType == CoordType.WGS84)
            {
                return GetWGS84Point(p);
            }
            else if (destType == CoordType.GCJ02)
            {
                return GetGCJ02Point(p);
            }
            else if (destType == CoordType.BD09)
            {
                return GetBD09Point(p);
            }
            else
            {
                return p;
            }
        }

        public static List<PointLatLng> GetPointListInCoordType(List<PointLatLng> pList, CoordType srcType, CoordType destType)
        {
            if (srcType == destType)
            {
                return pList;
            }
            List<PointLatLng> retList = new List<PointLatLng>();
            foreach (var item in pList)
            {
                retList.Add(GetPointInCoordType(item, srcType, destType));
            }
            return retList;
        }
    }
}
