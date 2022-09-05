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

        PointLatLng lastP = PointLatLng.Empty;
        PointLatLng[] lastPs = new PointLatLng[5] { PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty };

        public RealtimeGeoOverlay()
        {
            isStarted = false;
            isPaused = false;
            Follow = true;
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
            if (lastP != PointLatLng.Empty)
            {
                lastPs[4] = lastPs[3];
                if (lastPs[4] != PointLatLng.Empty)
                {
                    GMapPointMarker pm = new GMapPointMarker(lastPs[4]);
                    this.Markers.Add(pm);
                }
                lastPs[3] = lastPs[2];
                if (lastPs[3] != PointLatLng.Empty)
                {
                    GMapPointMarker pm = new GMapPointMarker(lastPs[3]);
                    this.Markers.Add(pm);
                }
                lastPs[2] = lastPs[1];
                if (lastPs[2] != PointLatLng.Empty)
                {
                    GMapPointMarker pm = new GMapPointMarker(lastPs[2]);
                    this.Markers.Add(pm);
                }
                lastPs[1] = lastPs[0];
                if (lastPs[1] != PointLatLng.Empty)
                {
                    GMapPointMarker pm = new GMapPointMarker(lastPs[1]);
                    this.Markers.Add(pm);
                }
                lastPs[0] = lastP;
                if (lastPs[0] != PointLatLng.Empty)
                {
                    GMapPointMarker pm = new GMapPointMarker(lastPs[0]);
                    this.Markers.Add(pm);
                }
            }
            lastP = p;

            if (Follow && this.Control != null)
            {
                this.Control.Position = p;
            }

        }

        public void Stop()
        {
            isStarted = false;
            isPaused = false;
            lastP = PointLatLng.Empty;
            lastPs = new PointLatLng[5] { PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty };
            geoDataList = new List<GpsRoutePoint>();
        }

        public void Start(CoordType srcCoordType, CoordType distCoordType)
        {
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
    }
}
