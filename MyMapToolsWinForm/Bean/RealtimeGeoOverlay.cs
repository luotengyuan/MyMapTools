using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMapMarkerLib;
using GMapCommonType;

namespace MapToolsWinForm
{
    class RealtimeGeoOverlay : GMapOverlay
    {
        public bool Follow { get; set; }

        private List<GpsRoutePoint> geoDataList = new List<GpsRoutePoint>();
        private CoordType srcCoordType;

        public CoordType SrcCoordType
        {
            get { return srcCoordType; }
            set { srcCoordType = value; }
        }

        private CoordType distCoordType;

        public CoordType DistCoordType
        {
            get { return distCoordType; }
            set { distCoordType = value; }
        }

        private bool isStarted;

        public bool IsStarted
        {
            get { return isStarted; }
            set { isStarted = value; }
        }
        private bool isPaused;

        public bool IsPaused
        {
            get { return isPaused; }
            set { isPaused = value; }
        }

        PointLatLng lastPoint = PointLatLng.Empty;
        private Queue<PointLatLng> lastPointQueue;
        public int TailSize
        {
            get { return tailSize; }
            set
            {
                if (value < 0)
                {
                    tailSize = 0;
                }
                else
                {
                    tailSize = value;
                }
            }
        }
        private int tailSize = 5;
        

        public RealtimeGeoOverlay()
        {
            isStarted = false;
            isPaused = false;
            Follow = true;
            lastPointQueue = new Queue<PointLatLng>();
        }

        public void Update(GpsRoutePoint point)
        {
            if (point == null || !isStarted || isPaused)
            {
                return;
            }
            if (geoDataList != null)
            {
                geoDataList.Add(point);
            }
            else
            {
                geoDataList = new List<GpsRoutePoint>();
            }
            this.Markers.Clear();
            PointLatLng p = PointInDiffCoord.GetPointInCoordType(point.Latitude, point.Longitude, srcCoordType, distCoordType);
            GMapDirectionMarker hm = new GMapDirectionMarker(p, Properties.Resources.arrow_up, (float)point.Direction);
            this.Markers.Add(hm);
            if (lastPoint != PointLatLng.Empty)
            {
                lastPointQueue.Enqueue(lastPoint);
                while (lastPointQueue.Count > tailSize)
                {
                    lastPointQueue.Dequeue();
                }
                foreach (var item in lastPointQueue)
                {
                    GMapPointMarker pm = new GMapPointMarker(item);
                    this.Markers.Add(pm);
                }
            }
            lastPoint = p;
            if (onProgressChanged != null)
            {
                onProgressChanged(geoDataList.Count, geoDataList.Count);
            }

            if (Follow && this.Control != null)
            {
                this.Control.Position = p;
            }

        }

        // 声明回调函数原型，即函数委托了
        public delegate void OnProgressChanged(int cur, int total);
        public OnProgressChanged onProgressChanged = null;

        public void Stop()
        {
            isStarted = false;
            isPaused = false;
            lastPoint = PointLatLng.Empty;
            lastPointQueue.Clear();
            geoDataList = new List<GpsRoutePoint>();
        }

        public void Start(CoordType srcCoordType, CoordType distCoordType, OnProgressChanged progressChanged)
        {
            onProgressChanged = progressChanged;
            Stop();
            this.Markers.Clear();
            this.srcCoordType = srcCoordType;
            this.distCoordType = distCoordType;
            isStarted = true;

        }

        public void Pause()
        {
            if (!isStarted)
            {
                return;
            }
            if (isPaused)
            {
                return;
            }
            isPaused = true;
        }

        public void Resume()
        {
            if (!isStarted)
            {
                return;
            }
            if (!isPaused)
            {
                return;
            }
            isPaused = false;
        }

        public GpsRoute GetGpsRoute()
        {
            if (geoDataList == null || geoDataList.Count <= 0)
            {
                return null;
            }
            GpsRoute gpsRoute = new GpsRoute();
            gpsRoute.GpsRouteInfoList = geoDataList;
            gpsRoute.RouteName = "实时轨迹接收";
            gpsRoute.CoordType = srcCoordType;
            return gpsRoute;
        }
    }
}
