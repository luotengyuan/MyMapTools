using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Drawing;

namespace MapToolsWinForm
{
    /// <summary>
    /// GPS轨迹信息
    /// </summary>
    public class GpsRoute
    {
        /// <summary>
        /// GPS轨迹点列表
        /// </summary>
        private List<GpsRoutePoint> gpsRouteInfoList;

        internal List<GpsRoutePoint> GpsRouteInfoList
        {
            get { return gpsRouteInfoList; }
            set { gpsRouteInfoList = value; }
        }
        /// <summary>
        /// 轨迹名称
        /// </summary>
        private string routeName;

        public string RouteName
        {
            get { return routeName; }
            set { routeName = value; }
        }
        /// <summary>
        /// 轨迹图
        /// </summary>
        private GMapOverlay overlay;

        public GMapOverlay Overlay
        {
            get { return overlay; }
            set { overlay = value; }
        }
        /// <summary>
        /// 轨迹坐标类型
        /// </summary>
        private CoordType coordType;

        public CoordType CoordType
        {
            get { return coordType; }
            set { coordType = value; }
        }
        /// <summary>
        /// 轨迹点图标
        /// </summary>
        private Bitmap bitmap;

        public Bitmap Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }

        public GpsRoute()
        {

        }

        public override string ToString()
        {
            return routeName;
        }
    }
}
