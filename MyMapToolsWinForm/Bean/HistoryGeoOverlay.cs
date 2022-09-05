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
    public class HistoryGeoOverlay:GMapOverlay
    {
        private Timer timer = new Timer();

        public bool Follow { get; set; }
        public bool Repeat { get; set; }

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

        private int index = 0;
        private bool isStarted;

        public bool IsStarted
        {
            get { return isStarted; }
        }
        private bool isPaused;

        private int start_idx = 0;
        private int end_idx = 0;
        //private PointLatLng lastPoint = PointLatLng.Empty;

        public HistoryGeoOverlay()
        {
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);
            isStarted = false;
            isPaused = false;
            Follow = true;
            Repeat = false;
        }

        PointLatLng lastP = PointLatLng.Empty;
        PointLatLng[] lastPs = new PointLatLng[5] { PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty };

        private void timer_Tick(object sender, EventArgs e)
        {
            if (geoDataList != null)
            {
                int len = geoDataList.Count;
                if (index < len && index <= end_idx)
                {
                    var historyGeoData = geoDataList[index];
                    PointLatLng wgsP = PointInDiffCoord.GetPointInCoordType(historyGeoData.Latitude, historyGeoData.Longitude, srcCoordType, CoordType.WGS84);
                    if (namePipeServer != null)
                    {
                        namePipeServer.sendCanData(string.Format("{0},{1},{2},{3},{4}", wgsP.Lng, wgsP.Lat, historyGeoData.Direction, historyGeoData.Speed, historyGeoData.Altitude));
                    }

                    PointLatLng p = PointInDiffCoord.GetPointInCoordType(historyGeoData.Latitude, historyGeoData.Longitude, srcCoordType, distCoordType); 
                    //GMapPointMarker point = new GMapPointMarker(p);
                    //this.Markers.Add(point);

                    //if (lastPoint != PointLatLng.Empty)
                    //{
                    //    GMapLineArrowMarker line = new GMapLineArrowMarker(lastPoint, p,true);
                    //    this.Markers.Add(line);
                    //}
                    //lastPoint = p;
                    this.Markers.Clear();
                    GMapDirectionMarker dm = new GMapDirectionMarker(p, Properties.Resources.arrow_up, (float)historyGeoData.Direction);
                    this.Markers.Add(dm);
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

                    ++index;
                }
                else
                {
                    if (Repeat)
                    {
                        index = start_idx;
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
            else
            {
                Stop();
            }
        }

        public void Stop()
        {
            timer.Stop();
            index = 0;
            isStarted = false;
            isPaused = false;
            lastP = PointLatLng.Empty;
            lastPs = new PointLatLng[5] { PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty, PointLatLng.Empty };
            if (namePipeServer != null)
            {
                namePipeServer.Close();
            }
            namePipeServer = null;
        }

        NamedPipeServer namePipeServer;
        public void Start(GpsRoute simulateGpsRoute, CoordType distCoordType, int start_idx, int end_idx)
        {
            Stop();
            if (simulateGpsRoute == null || simulateGpsRoute.GpsRouteInfoList == null || simulateGpsRoute.GpsRouteInfoList.Count <= 0)
            {
                return;
            }
            if (start_idx < 0)
	        {
                start_idx = 0;
	        }
            if (end_idx < 0)
	        {
		        end_idx = simulateGpsRoute.GpsRouteInfoList.Count - 1;
	        }
            if (start_idx >= end_idx)
	        {
		        return;
	        }
            this.start_idx = start_idx;
            this.end_idx = end_idx;
            this.geoDataList = simulateGpsRoute.GpsRouteInfoList;
            index = start_idx;
            this.Markers.Clear();
            this.srcCoordType = simulateGpsRoute.CoordType;
            this.distCoordType = distCoordType;
            namePipeServer = new NamedPipeServer("com.lois.pipe.gps.string");
            StartTimer();

        }

        public void StartTimer()
        {
            timer.Start();
            isStarted = true;
        }

        public void SetTimerInterval(int span)
        {
            if (isStarted)
            {
                timer.Stop();
            }
            timer.Interval = span;

            if (isStarted)
            {
                timer.Start();
            }
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
            timer.Stop();
            isPaused = true;
        }

        public void Resume()
        {
            if (!isStarted)
            {
                return;
            }
            if (isPaused)
            {
                timer.Start();
            }
            isPaused = false;
        }

        public void Back()
        {
            if (!isStarted)
            {
                return;
            }
            int tempInx = index;
            tempInx -= 100;
            if (tempInx < start_idx)
            {
                index = start_idx;
            }
            else
            {
                index = tempInx;
            }
        }

        public void Forward()
        {
            if (!isStarted)
            {
                return;
            }
            int tempInx = index;
            tempInx += 100;
            if (tempInx > end_idx)
            {
                index = end_idx;
            }
            else
            {
                index = tempInx;
            }
        }
    }
}
