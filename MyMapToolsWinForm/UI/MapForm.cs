using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Drawing.Drawing2D;
using Microsoft.SqlServer.Server;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMapMarkerLib;
using GMapChinaRegion;
using GMapDrawTools;
using GMapTools;
using NetUtil;
using GMapCommonType;
using CommonTools;
using GMapPositionFix;
using log4net;
using System.Net;
using GMap.NET.CacheProviders;
using GMapUtil;
using GMapPolygonLib;
using GMapProvidersExt;
using GMapProvidersExt.Tencent;
using GMapProvidersExt.AMap;
using GMapProvidersExt.Baidu;
using GMapExport;
using GMapHeat;
using GMapDownload;
using GMapPOI;
using System.Threading;
using System.IO.Ports;
using TerminalMapLib;

namespace MapToolsWinForm
{
    public partial class MapForm : Form
    {
        /// <summary>
        /// log4net日志记录
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(MapForm));

        public MapForm()
        {
            InitializeComponent();
            // 初始化地图提供者
            MapProviderSet.InitMapProviderSet();
            InitMap();
            InitUI();
            InitPOISearch();
            InitSerialUI();
        }

        /// <summary>
        /// 初始化地图参数
        /// </summary>
        private void InitMap()
        {
            mapControl.CacheLocation = Environment.CurrentDirectory + "\\GMapCache\\"; //缓存位置
            mapControl.MinZoom = 2;  //最小比例
            mapControl.MaxZoom = 24; //最大比例
            mapControl.Zoom = 12;     //当前比例
            mapControl.ShowCenter = false; //不显示中心十字点
            mapControl.DragButton = System.Windows.Forms.MouseButtons.Left; //左键拖拽地图
            // 中心坐标
            mapControl.Position = new PointLatLng(24.4987084, 118.1377029);
            mapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            // 更新地图中心
            mapControl_OnPositionChanged(mapControl.Position);

            mapControl.MouseClick += new MouseEventHandler(mapControl_MouseClick);
            mapControl.MouseDown += new MouseEventHandler(mapControl_MouseDown);
            mapControl.MouseUp += new MouseEventHandler(mapControl_MouseUp);
            mapControl.MouseMove += new MouseEventHandler(mapControl_MouseMove);
            mapControl.MouseDoubleClick += new MouseEventHandler(mapControl_MouseDoubleClick);

            mapControl.OnMarkerClick += new MarkerClick(mapControl_OnMarkerClick);
            mapControl.OnMarkerEnter += new MarkerEnter(mapControl_OnMarkerEnter);
            mapControl.OnMarkerLeave += new MarkerLeave(mapControl_OnMarkerLeave);

            mapControl.OnRouteClick += new RouteClick(mapControl_OnRouteClick);
            mapControl.OnRouteDoubleClick += new RouteDoubleClick(mapControl_OnRouteDoubleClick);
            mapControl.OnRouteEnter += new RouteEnter(mapControl_OnRouteEnter);
            mapControl.OnRouteLeave += new RouteLeave(mapControl_OnRouteLeave);

            mapControl.OnPolygonEnter += new PolygonEnter(mapControl_OnPolygonEnter);
            mapControl.OnPolygonLeave += new PolygonLeave(mapControl_OnPolygonLeave);
            mapControl.OnPolygonClick += new PolygonClick(mapControl_OnPolygonClick);
            mapControl.OnPolygonDoubleClick += new PolygonDoubleClick(mapControl_OnPolygonDoubleClick);

            mapControl.OnPositionChanged += new PositionChanged(mapControl_OnPositionChanged);
            this.mapControl.OnMapZoomChanged += new MapZoomChanged(mapControl_OnMapZoomChanged);

            mapControl.Overlays.Add(regionOverlay);
            mapControl.Overlays.Add(coordinatePickOverlay);
            mapControl.Overlays.Add(poiQueryOverlay);
            mapControl.Overlays.Add(routeOverlay);
            mapControl.Overlays.Add(demoOverlay);
            mapControl.Overlays.Add(gridOverlay);

            GMapProvider.Language = LanguageType.ChineseSimplified; //使用的语言，默认是英文

            draw_download = new Draw(this.mapControl);
            draw_download.DrawComplete += new EventHandler<DrawEventArgs>(draw_download_DrawComplete);

            draw_demo = new Draw(this.mapControl);
            draw_demo.DrawComplete += new EventHandler<DrawEventArgs>(draw_demo_DrawComplete);

            drawDistance = new DrawDistance(this.mapControl);
            drawDistance.DrawComplete += new EventHandler<DrawDistanceEventArgs>(drawDistance_DrawComplete);

            // 刷新比例尺
            pb_scale.Parent = mapControl;
            pb_compass.Parent = mapControl;
            lb_scale_min.Parent = mapControl;
            lb_scale_max.Parent = mapControl;
            RefreshScale();
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitUI()
        {
            this.Text += " V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ShowDownloadTip(false);
            this.toolStripStatusPOIDownload.Visible = false;
            this.toolStripStatusExport.Visible = false;
            this.在线和缓存ToolStripMenuItem.Checked = true;

            int slt_search_engine = Properties.Settings.Default.Setting_slt_search_engine;
            if (slt_search_engine == 0)
            {
                this.高德地图ToolStripMenuItem_search.Checked = true;
                this.百度地图ToolStripMenuItem_search.Checked = false;
                this.腾讯地图ToolStripMenuItem_search.Checked = false;
            }
            else if (slt_search_engine == 1)
            {
                this.高德地图ToolStripMenuItem_search.Checked = false;
                this.百度地图ToolStripMenuItem_search.Checked = true;
                this.腾讯地图ToolStripMenuItem_search.Checked = false;
            }
            else if (slt_search_engine == 2)
            {
                this.高德地图ToolStripMenuItem_search.Checked = false;
                this.百度地图ToolStripMenuItem_search.Checked = false;
                this.腾讯地图ToolStripMenuItem_search.Checked = true;
            }
            else
            {
                this.高德地图ToolStripMenuItem_search.Checked = true;
                this.百度地图ToolStripMenuItem_search.Checked = false;
                this.腾讯地图ToolStripMenuItem_search.Checked = false;
            }

            TerminalMapLib.TerminalMapTool.Chack(Properties.Settings.Default.Setting_key_word);

            // 初始化地图Key
            string mapKey = Properties.Settings.Default.Setting_amap_key;
            if (mapKey == null || "".Equals(mapKey.Trim()))
            {
                AMapProvider.Instance.SetKey(Properties.Settings.Default.Defult_amap_key);
            }
            else
            {
                AMapProvider.Instance.SetKey(mapKey);
            }
            mapKey = Properties.Settings.Default.Setting_baidu_map_key;
            if (mapKey == null || "".Equals(mapKey.Trim()))
            {
                BaiduMapProvider.Instance.SetKey(Properties.Settings.Default.Defult_baidu_map_key);
            }
            else
            {
                BaiduMapProvider.Instance.SetKey(mapKey);
            }
            mapKey = Properties.Settings.Default.Setting_tencent_map_key;
            if (mapKey == null || "".Equals(mapKey.Trim()))
            {
                TencentMapProvider.Instance.SetKey(Properties.Settings.Default.Defult_tencent_map_key);
            }
            else
            {
                TencentMapProvider.Instance.SetKey(mapKey);
            }

            comboBoxPoiSave.SelectedIndex = 0;
            comboBoxZoom.SelectedIndex = 9;
            comboBoxStore.SelectedIndex = 0;
            comboBoxTimeSpan.SelectedIndex = 2;

            this.dataGridViewGpsRoute.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cb_coord_view_type.SelectedIndex = 0;

            this.buttonMapType.Image = Properties.Resources.weixing;
            this.buttonMapType.Click += new EventHandler(buttonMapType_Click);

            curMapProviderInfoArray = MapProviderSet.AMapProviderArray;
            curMapProviderInfoIdx = 0;
            RefreshMapLayer();

            # region Map Providers test
            //mapControl.MapProvider = GMapProviders.ArcGIS_DarbAE_Q2_2011_NAVTQ_Eng_V5_Map;//NO
            //mapControl.MapProvider = GMapProviders.ArcGIS_Imagery_World_2D_Map;//OK 卫星
            //mapControl.MapProvider = GMapProviders.ArcGIS_ShadedRelief_World_2D_Map;//NO
            //mapControl.MapProvider = GMapProviders.ArcGIS_StreetMap_World_2D_Map;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.ArcGIS_Topo_US_2D_Map;//NO
            //mapControl.MapProvider = GMapProviders.ArcGIS_World_Physical_Map;//NO
            //mapControl.MapProvider = GMapProviders.ArcGIS_World_Shaded_Relief_Map;//OK 地貌渲染
            //mapControl.MapProvider = GMapProviders.ArcGIS_World_Street_Map;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.ArcGIS_World_Terrain_Base_Map;//NO
            //mapControl.MapProvider = GMapProviders.ArcGIS_World_Topo_Map;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.BingHybridMap;//OK 卫星+路网 英文
            //mapControl.MapProvider = GMapProviders.BingMap;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.BingOSMap;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.BingSatelliteMap;//OK 卫星
            //mapControl.MapProvider = GMapProviders.CloudMadeMap;//NO
            //mapControl.MapProvider = GMapProviders.CzechGeographicMap;//OK 渲染+路网
            //mapControl.MapProvider = GMapProviders.CzechHistoryMap;//NO
            //mapControl.MapProvider = GMapProviders.CzechHistoryOldMap;//NO
            //mapControl.MapProvider = GMapProviders.CzechHybridMap;//OK 卫星
            //mapControl.MapProvider = GMapProviders.CzechHybridOldMap;//NO
            //mapControl.MapProvider = GMapProviders.CzechMap;//OK 路网
            //mapControl.MapProvider = GMapProviders.CzechOldMap;//NO
            //mapControl.MapProvider = GMapProviders.CzechSatelliteMap;//OK 卫星
            //mapControl.MapProvider = GMapProviders.CzechSatelliteOldMap;//NO
            //mapControl.MapProvider = GMapProviders.CzechTuristMap;//NO
            //mapControl.MapProvider = GMapProviders.CzechTuristOldMap;//NO
            //mapControl.MapProvider = GMapProviders.CzechTuristWinterMap;//OK 路网
            //mapControl.MapProvider = GMapProviders.EmptyProvider;//OK 空
            //mapControl.MapProvider = GMapProviders.GoogleChinaHybridMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleChinaMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleChinaSatelliteMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleChinaTerrainMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleHybridMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleKoreaHybridMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleKoreaMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleKoreaSatelliteMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleSatelliteMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleTerrainMap;//NO
            //mapControl.MapProvider = GMapProviders.LatviaMap;//NO
            //mapControl.MapProvider = GMapProviders.Lithuania3dMap;//NO
            //mapControl.MapProvider = GMapProviders.LithuaniaHybridMap;//NO
            //mapControl.MapProvider = GMapProviders.LithuaniaHybridOldMap;//NO
            //mapControl.MapProvider = GMapProviders.LithuaniaMap;//NO
            //mapControl.MapProvider = GMapProviders.LithuaniaOrtoFotoMap;//NO
            //mapControl.MapProvider = GMapProviders.LithuaniaOrtoFotoOldMap;//NO
            //mapControl.MapProvider = GMapProviders.LithuaniaReliefMap;//NO
            //mapControl.MapProvider = GMapProviders.LithuaniaTOP50Map;//NO
            //mapControl.MapProvider = GMapProviders.MapBenderWMSdemoMap;//NO
            //mapControl.MapProvider = GMapProviders.NearHybridMap;//NO
            //mapControl.MapProvider = GMapProviders.NearMap;//NO
            //mapControl.MapProvider = GMapProviders.NearSatelliteMap;//NO
            //mapControl.MapProvider = GMapProviders.OpenCycleLandscapeMap;//OK 路网
            //mapControl.MapProvider = GMapProviders.OpenCycleMap;//OK 路网
            //mapControl.MapProvider = GMapProviders.OpenCycleTransportMap;//OK 路网
            //mapControl.MapProvider = GMapProviders.OpenSeaMapHybrid;//NO
            //mapControl.MapProvider = GMapProviders.OpenStreet4UMap;//NO
            //mapControl.MapProvider = GMapProviders.OpenStreetMap;//NO
            //mapControl.MapProvider = GMapProviders.OpenStreetMapQuest;//NO
            //mapControl.MapProvider = GMapProviders.OpenStreetMapQuestHybrid;//NO
            //mapControl.MapProvider = GMapProviders.OpenStreetMapQuestSatelite;//NO
            //mapControl.MapProvider = GMapProviders.OviHybridMap;//NO
            //mapControl.MapProvider = GMapProviders.OviMap;//NO
            //mapControl.MapProvider = GMapProviders.OviSatelliteMap;//NO
            //mapControl.MapProvider = GMapProviders.OviTerrainMap;//NO
            //mapControl.MapProvider = GMapProviders.SpainMap;//NO
            //mapControl.MapProvider = GMapProviders.SwedenMap;//NO
            //mapControl.MapProvider = GMapProviders.TurkeyMap;//NO
            //mapControl.MapProvider = GMapProviders.WikiMapiaMap;//NO
            //mapControl.MapProvider = GMapProviders.YahooHybridMap;//NO
            //mapControl.MapProvider = GMapProviders.YahooMap;//NO
            //mapControl.MapProvider = GMapProviders.YahooSatelliteMap;//NO
            //mapControl.MapProvider = GMapProviders.YandexHybridMap;//NO
            //mapControl.MapProvider = GMapProviders.YandexMap;//NO
            //mapControl.MapProvider = GMapProviders.YandexSatelliteMap;//NO
            //mapControl.MapProvider = GMapProvidersExt.AMap.AMapHybirdProvider.Instance;//OK 卫星+路网
            //mapControl.MapProvider = GMapProvidersExt.AMap.AMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.AMap.AMapSateliteProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISColdMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISGrayMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISMapProviderNoPoi.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISSatelliteMapProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISWarmMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.Baidu.BaiduHybridMapProvider.Instance;//OK 路网+卫星
            //mapControl.MapProvider = GMapProvidersExt.Baidu.BaiduMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.Baidu.BaiduMapProviderJS.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.Baidu.BaiduSatelliteMapProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.Bing.BingChinaMapProvider.Instance;//OK 路网
            ////mapControl.MapProvider = GMapProvidersExt.Bing.BingMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.Here.NokiaHybridMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.Here.NokiaMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.Here.NokiaSatelliteMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.Ship.ShipMapProvider.Instance;//OK 渲染
            //mapControl.MapProvider = GMapProvidersExt.Ship.ShipMapTileProvider.Instance;//OK 渲染
            //mapControl.MapProvider = GMapProvidersExt.Sogou.SogouMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.SoSo.SosoMapHybridProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.SoSo.SosoMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.SoSo.SosoMapSateliteProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentMapHybridProvider.Instance;//OK 路网+卫星
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentMapSateliteProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentTerrainMapAnnoProvider.Instance;//OK 路网+渲染
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentTerrainMapProvider.Instance;//OK 渲染
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.Fujian.TiandituFujianMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.Fujian.TiandituFujianMapProviderWithAnno.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.Fujian.TiandituFujianSatelliteMapProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.Fujian.TiandituFujianSatelliteMapProviderWithAnno.Instance;//OK 路网+卫星
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.TiandituMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.TiandituMapProvider4326.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.TiandituMapProviderWithAnno.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.TiandituMapProviderWithAnno4326.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.TiandituSatelliteMapProvider.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.TiandituSatelliteMapProvider4326.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.TiandituSatelliteMapProviderWithAnno.Instance;//NO
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.TiandituSatelliteMapProviderWithAnno4326.Instance;//NO

            #endregion

            this.panelMap.SizeChanged += new EventHandler(panelMap_SizeChanged);

            InitHistoryLayerUI();

            this.checkBoxFollow.CheckedChanged += new EventHandler(checkBoxFollow_CheckedChanged);
            this.treeViewTerminalMap.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeViewTerminalMap_NodeMouseClick);
        }

        private void MapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (historyGeoOverlay != null && historyGeoOverlay.IsStarted)
            {
                historyGeoOverlay.Stop();
            }
            //Application.Exit();
            System.Environment.Exit(0); 
        }

        #region Polygon Operation Event

        void mapControl_OnPolygonLeave(GMapPolygon item)
        {
            item.Stroke.Color = Color.Blue;
            if (item is GMapAreaPolygon)
            {
                GMapAreaPolygon areaPolygon = item as GMapAreaPolygon;
                if (currentAreaPolygon != null && currentAreaPolygon == areaPolygon)
                {
                    currentAreaPolygon = item as GMapAreaPolygon;
                    currentAreaPolygon.Stroke.Color = Color.Blue;
                }
            }
        }

        void mapControl_OnPolygonEnter(GMapPolygon item)
        {
            item.Stroke.Color = Color.Red;
            if (item is GMapAreaPolygon)
            {
                GMapAreaPolygon areaPolygon = item as GMapAreaPolygon;
                if (currentAreaPolygon != null && currentAreaPolygon == areaPolygon)
                {
                    currentAreaPolygon = item as GMapAreaPolygon;
                    currentAreaPolygon.Stroke.Color = Color.Red;
                }
            }
        }

        void mapControl_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (item is GMapAreaPolygon && currentAreaPolygon != null)
                {
                    this.contextMenuStripSelectedArea.Show(Cursor.Position);
                }
            }
        }

        // Double click to download the map
        void mapControl_OnPolygonDoubleClick(GMapPolygon item, MouseEventArgs e)
        {
            if (item is GMapAreaPolygon)
            {
                if (currentAreaPolygon != null)
                {
                    DownloadMap(currentAreaPolygon);
                }
                else
                {
                    if (!xPanderPanelTerminalMap.Expand)
                    {
                        MyMessageBox.ShowTipMessage("请先用画图工具画下载的区域多边形或选择省市区域！");
                    }
                }
            }
        }

        #endregion

        #region Map Operation Event

        private GMapMarker currentMarker;
        private bool isLeftButtonDown = false;
        private PointLatLng lastChangedPostion = PointLatLng.Empty;
        private long lastChangedTime = 0;

        void mapControl_OnPositionChanged(PointLatLng point)
        {
            // 搜索地图中心位置
            long dif_time = CalculateUtils.CurrentTimeMillis() - lastChangedTime;
            if (lastChangedPostion == PointLatLng.Empty || (dif_time > 1000 && CalculateUtils.getDistance(point.Lng, point.Lat, lastChangedPostion.Lng, lastChangedPostion.Lat) > 1000))
            {
                BackgroundWorker centerPositionWorker = new BackgroundWorker();
                centerPositionWorker.DoWork += new DoWorkEventHandler(centerPositionWorker_DoWork);
                centerPositionWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(centerPositionWorker_RunWorkerCompleted);
                centerPositionWorker.RunWorkerAsync(point);
                lastChangedPostion = point;
                lastChangedTime = CalculateUtils.CurrentTimeMillis();
            }
        }
        
        void mapControl_OnMarkerLeave(GMapMarker item)
        {
            currentMarker = null;
            if (!isLeftButtonDown)
            {
                if (item is GMapMarkerEllipse)
                {
                    currentDragableNode = null;
                }
            }
        }

        void mapControl_OnMarkerEnter(GMapMarker item)
        {
            currentMarker = item;
            if (!isLeftButtonDown)
            {
                if (item is GMapMarkerEllipse)
                {
                    currentDragableNode = item as GMapMarkerEllipse;
                }
            }
        }
        
        private void mapControl_OnRouteDoubleClick(GMapRoute item, MouseEventArgs e)
        {
            MyMessageBox.ShowTipMessage(item.Name);
        }

        private void mapControl_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            
        }

        private void mapControl_OnRouteLeave(GMapRoute item)
        {
            
        }

        private void mapControl_OnRouteEnter(GMapRoute item)
        {
            
        }

        void mapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //this.contextMenuStripMarker.Show(Cursor.Position);
                if (item is GMapFlashMarker)
                {
                    currentMarker = item as GMapFlashMarker;
                }
                if (!checkBoxMarker.Checked)
                {
                    sltDelMarker = item;
                    contextMenuStripDelMarker.Show(Cursor.Position);
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                if (item is DrawDeleteMarker)
                {
                    currentMarker = item as DrawDeleteMarker;

                    GMapOverlay overlay = currentMarker.Overlay;
                    if (overlay.Markers.Contains(currentMarker))
                    {
                        overlay.Markers.Remove(currentMarker);
                    }

                    if (this.mapControl.Overlays.Contains(overlay))
                    {
                        this.mapControl.Overlays.Remove(overlay);
                    }
                }
            }
        }

        void panelMap_SizeChanged(object sender, EventArgs e)
        {
            this.buttonMapType.Location = new Point(
                this.panelMenu.Location.X + panelMap.Width - 80,
                this.panelMenu.Location.Y);
        }

        void mapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PointLatLng point = mapControl.FromLocalToLatLng(e.X, e.Y);

        }

        void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                PointLatLng point = mapControl.FromLocalToLatLng(e.X, e.Y);

                int zoom = (int)this.mapControl.Zoom;
                double resolution = this.mapControl.MapProvider.Projection.GetLevelResolution(zoom);
                this.toolStripStatusTip.Text = string.Format("显示级别：{0} 分辨率：{1:F3}米/像素 坐标：{2:F6},{3:F6}", zoom, resolution, point.Lng, point.Lat);

                if (e.Button == System.Windows.Forms.MouseButtons.Left && isLeftButtonDown)
                {
                    if (currentMarker != null && currentMarker is GMapFlashMarker)
                    {
                        currentMarker.Position = point;
                    }
                }

                if (isLeftButtonDown && currentDragableNode != null)
                {
                    int? tag = (int?)this.currentDragableNode.Tag;
                    if (tag.HasValue && this.currentAreaPolygon != null)
                    {
                        int? nullable2 = tag;
                        int count = this.currentAreaPolygon.Points.Count;
                        if (nullable2.GetValueOrDefault() < count)
                        {
                            this.currentAreaPolygon.Points[tag.Value] = point;
                            this.mapControl.UpdatePolygonLocalPosition(this.currentAreaPolygon);
                        }
                    }
                    this.currentDragableNode.Position = point;
                    this.currentDragableNode.ToolTipText = string.Format("X={0} Y={1}", point.Lng.ToString("0.0000"), point.Lat.ToString("0.0000"));
                    this.currentDragableNode.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                    this.mapControl.UpdateMarkerLocalPosition(this.currentDragableNode);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        void mapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftButtonDown = false;
                currentDragableNode = null;
            }
        }

        void mapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftButtonDown = true;
            }
        }
        
        void mapControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                PointLatLng point = mapControl.FromLocalToLatLng(e.X, e.Y);
                Console.WriteLine("当前坐标：" + point.ToString());
                // 地图下载
                leftClickPoint = new GPoint(e.X, e.Y);
                if (this.cb_get_coord_from_map.Checked)
                {
                    RefreshLonLatTextBox(new PointLatLng(point.Lat, point.Lng, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType));
                    return;
                } 
                if (this.checkBoxMarker.Checked)
                {
                    if (this.rbGMarkerGoogle.Checked)
                    {
                        GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green);
                        demoOverlay.Markers.Add(marker);
                    }
                    else if (this.rbGMapFlashMarker.Checked)
                    {
                        Bitmap bitmap = Properties.Resources.point_blue;
                        GMapMarker marker = new GMapFlashMarker(point, bitmap);
                        demoOverlay.Markers.Add(marker);

                    }
                    else if (this.rbGMapGifMarker.Checked)
                    {
                        GifImage gif = new GifImage(Properties.Resources.your_sister);
                        GMapGifMarker ani = new GMapGifMarker(point, gif);
                        demoOverlay.Markers.Add(ani);
                    }
                    else if (this.rbGMapDirectionMarker.Checked)
                    {
                        GMapDirectionMarker marker = new GMapDirectionMarker(point, Properties.Resources.arrow_up, 45);
                        demoOverlay.Markers.Add(marker);
                    }
                    else if (this.rbGMapTipMarker.Checked)
                    {
                        Bitmap bitmap = Properties.Resources.point_blue;
                        GMapTipMarker marker = new GMapTipMarker(point, bitmap, "图标A");
                        demoOverlay.Markers.Add(marker);
                    }
                    else if (this.rbGMapMarkerScopePieAnimate.Checked)
                    {
                        GMapMarkerScopePieAnimate marker = new GMapMarkerScopePieAnimate(this.mapControl, point, 0, 60, 300);
                        demoOverlay.Markers.Add(marker);
                    }
                    else if (this.rbGMapMarkerScopeCircleAnimate.Checked)
                    {
                        GMapMarkerScopeCircleAnimate marker = new GMapMarkerScopeCircleAnimate(this.mapControl, point, 300);
                        demoOverlay.Markers.Add(marker);
                    }
                    return;
                }
                if (allowRouting)
                {
                    this.contextMenuStripLocation.Show(Cursor.Position);
                }
            }
        }

        void mapControl_OnMapZoomChanged()
        {
            if (this.mapControl.Zoom >= 3)
            {
                //Allow routing on map
                allowRouting = true;
            }
            else
            {
                allowRouting = false;
            }
            if (heatMarker != null)
            {
                var tl = mapControl.FromLatLngToLocal(heatRect.LocationTopLeft);
                var br = mapControl.FromLatLngToLocal(heatRect.LocationRightBottom);

                heatMarker.Position = heatRect.LocationTopLeft;
                heatMarker.Size = new System.Drawing.Size((int)(br.X - tl.X), (int)(br.Y - tl.Y));
            }

            // 刷新比例尺
            RefreshScale();
        }

        #endregion

        #region 地图中心

        private string currentCenterCityName = "";

        /// <summary>
        /// 刷新比例尺
        /// </summary>
        private void RefreshScale()
        {
            PointLatLng point = mapControl.FromLocalToLatLng(pb_scale.Bounds.Left, pb_scale.Bounds.Bottom);
            PointLatLng point2 = mapControl.FromLocalToLatLng(pb_scale.Bounds.Right, pb_scale.Bounds.Bottom);
            double dis = GMapHelper.GetDistanceInMeter(point, point2);
            if (dis > 10000)
            {
                lb_scale_max.Text = (int)(dis / 1000) + " km";
            }
            else
            {
                lb_scale_max.Text = (int)dis + " m";
            }
        }

        void centerPositionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Placemark place = (Placemark)e.Result;
                if (!place.Equals(Placemark.Empty))
                {
                    this.toolStripStatusCenter.Text = "地图中心:" + place.ProvinceName + "," + place.CityName + "," + place.DistrictName + "," + place.AdCode;
                    currentCenterCityName = place.CityName;
                    Console.WriteLine("currentCenterCityName: " + currentCenterCityName);
                }
            }
            catch (Exception ex)
            {
                log.Error("Locate the map center error: " + ex);
                Console.WriteLine("Locate the map center error: " + ex);
            }
        }

        void centerPositionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            PointLatLng p = (PointLatLng)e.Argument;
            //Placemark centerPosPlace = SoSoMapProvider.Instance.GetCenterNameByLocation(p);
            //Placemark centerPosPlace = GMapProvidersExt.AMap.AMapProvider.Instance.GetCenterNameByLocation(p);
            Placemark? centerPosPlace;
            PointInDiffCoord coord = new PointInDiffCoord(p);
            if (高德地图ToolStripMenuItem_search.Checked)
            {
                centerPosPlace = AMapProvider.Instance.GetCenterNameByLocation(coord.GCJ02);
            }
            else if (百度地图ToolStripMenuItem_search.Checked)
            {
                centerPosPlace = BaiduMapProvider.Instance.GetCenterNameByLocation(coord.BD09);
            }
            else if (腾讯地图ToolStripMenuItem_search.Checked)
            {
                centerPosPlace = TencentMapProvider.Instance.GetCenterNameByLocation(coord.GCJ02);
            }
            else
            {
                centerPosPlace = AMapProvider.Instance.GetCenterNameByLocation(coord.GCJ02);
            }
            e.Result = centerPosPlace;
        }

        #endregion

        #region 地图选择菜单（地图提供者选择和切换）

        private MapProviderInfo[] curMapProviderInfoArray;
        private int curMapProviderInfoIdx = 0;

        private void RefreshMapLayer()
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null)
            {
                this.buttonMapType.Image = Properties.Resources.other;
                CommonTools.MyMessageBox.ShowWarningMessage("选择的地图错误");
                return;
            }
            else if (curMapProviderInfoArray[curMapProviderInfoIdx].MapLayerType == MapLayerType.Common)
            {
                this.buttonMapType.Image = Properties.Resources.common;
            }
            else if (curMapProviderInfoArray[curMapProviderInfoIdx].MapLayerType == MapLayerType.Satellite)
            {
                this.buttonMapType.Image = Properties.Resources.satellite;
            }
            else if (curMapProviderInfoArray[curMapProviderInfoIdx].MapLayerType == MapLayerType.Hybird)
            {
                this.buttonMapType.Image = Properties.Resources.hybird;
            }
            else if (curMapProviderInfoArray[curMapProviderInfoIdx].MapLayerType == MapLayerType.Other)
            {
                this.buttonMapType.Image = Properties.Resources.other;
            }
            else
            {
                this.buttonMapType.Image = Properties.Resources.other;
            }
            mapControl.MapProvider = curMapProviderInfoArray[curMapProviderInfoIdx].MapProvider;

        }

        private void 高德地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.AMap)
            {
                curMapProviderInfoArray = MapProviderSet.AMapProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void 百度地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.Baidu)
            {
                curMapProviderInfoArray = MapProviderSet.BaiduProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void 腾讯地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.Tencent)
            {
                curMapProviderInfoArray = MapProviderSet.TencentProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void arcGISMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.ArcGIS)
            {
                curMapProviderInfoArray = MapProviderSet.ArcGISProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void bingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.Bing)
            {
                curMapProviderInfoArray = MapProviderSet.BingProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void 天地图福建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.Tianditu_FJ)
            {
                curMapProviderInfoArray = MapProviderSet.Tianditu_FJProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void czechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.Czech)
            {
                curMapProviderInfoArray = MapProviderSet.CzechProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void openCycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.OpenCycle)
            {
                curMapProviderInfoArray = MapProviderSet.OpenCycleProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.Google)
            {
                curMapProviderInfoArray = MapProviderSet.GoogleProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void oSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.OpenStreetMap)
            {
                curMapProviderInfoArray = MapProviderSet.OSMProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        private void otherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx] == null || curMapProviderInfoArray[curMapProviderInfoIdx].MapProviderType != MapProviderType.Other)
            {
                curMapProviderInfoArray = MapProviderSet.OtherProviderArray;
                curMapProviderInfoIdx = 0;
                RefreshMapLayer();
            }
        }

        #endregion

        #region 地图类型切换

        private void buttonMapType_Click(object sender, EventArgs e)
        {
            if (curMapProviderInfoArray != null && curMapProviderInfoIdx + 1 >= curMapProviderInfoArray.Length)
            {
                curMapProviderInfoIdx = 0;
            }
            else
            {
                curMapProviderInfoIdx++;
            }
            RefreshMapLayer();
        }

        #endregion

        #region 帮助菜单

        private void 关于MyMapToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_about about = new Form_about();
            about.ShowDialog();
        }

        #endregion

        #region 地图操作菜单

        private void 保存缓存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mapControl.ShowExportDialog();
        }

        private void 读取缓存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mapControl.ShowImportDialog();
        }

        private void 显示网格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.显示网格ToolStripMenuItem.Checked = !this.显示网格ToolStripMenuItem.Checked;
            if (this.显示网格ToolStripMenuItem.Checked)
            {
                this.mapControl.ShowTileGridLines = true;
            }
            else
            {
                this.mapControl.ShowTileGridLines = false;
            }
        }

        private void 地图截屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Filter = "PNG (*.png)|*.png";
                    dialog.FileName = "GMap.NET image";
                    Image image = this.mapControl.ToImage();
                    if (image != null)
                    {
                        using (image)
                        {
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                string fileName = dialog.FileName;
                                if (!fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                {
                                    fileName += ".png";
                                }
                                image.Save(fileName);
                                MessageBox.Show("图片已保存： " + dialog.FileName, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("图片保存失败： " + exception.Message, "GMap.NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private DrawDistance drawDistance;
        private void 地图测距ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawDistance.IsEnable = true;
        }

        void drawDistance_DrawComplete(object sender, DrawDistanceEventArgs e)
        {
            if (e != null)
            {
                GMapOverlay distanceOverlay = new GMapOverlay();
                this.mapControl.Overlays.Add(distanceOverlay);
                foreach (LineMarker line in e.LineMarkers)
                {
                    distanceOverlay.Markers.Add(line);
                }
                foreach (DrawDistanceMarker marker in e.DistanceMarkers)
                {
                    distanceOverlay.Markers.Add(marker);
                }
                distanceOverlay.Markers.Add(e.DistanceDeleteMarker);
            }
            drawDistance.IsEnable = false;
        }

        #endregion

        #region 坐标拾取

        private GMapOverlay coordinatePickOverlay = new GMapOverlay("CoordinatePick");
        private PointInDiffCoord curCoordinatePickPointInDiffCoord = null;
        private bool isTextChanged = false;

        private void tb_lon_lat_wgs84_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }

        private void tb_lon_lat_wgs84_Validated(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                PointLatLng p = GetCoordFormString(tb_lon_lat_wgs84.Text, CoordType.WGS84);
                RefreshLonLatTextBox(p);
                JumpCoordinatePickMarker(curCoordinatePickPointInDiffCoord);
            }
        }

        private void tb_lon_lat_gcj02_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }

        private void tb_lon_lat_gcj02_Validated(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                PointLatLng p = GetCoordFormString(tb_lon_lat_gcj02.Text, CoordType.GCJ02);
                RefreshLonLatTextBox(p);
                JumpCoordinatePickMarker(curCoordinatePickPointInDiffCoord);
            }
        }

        private void tb_lon_lat_bd09_TextChanged(object sender, EventArgs e)
        {
            isTextChanged = true;
        }

        private void tb_lon_lat_bd09_Validated(object sender, EventArgs e)
        {
            if (isTextChanged)
            {
                PointLatLng p = GetCoordFormString(tb_lon_lat_bd09.Text, CoordType.BD09);
                RefreshLonLatTextBox(p);
                JumpCoordinatePickMarker(curCoordinatePickPointInDiffCoord);
            }
        }

        private void btn_coord_pickup_clean_Click(object sender, EventArgs e)
        {
            tb_lon_lat_wgs84.Text = "";
            tb_lon_lat_gcj02.Text = "";
            tb_lon_lat_bd09.Text = "";
            tb_address.Text = "";
            coordinatePickOverlay.Markers.Clear();
            curCoordinatePickPointInDiffCoord = null;
        }

        private void RefreshLonLatTextBox(PointLatLng p)
        {
            RefreshLonLatTextBox(p, false);
        }
        private void RefreshLonLatTextBox(PointLatLng p, bool isAddressReq)
        {
            coordinatePickOverlay.Markers.Clear();
            if (p != PointLatLng.Empty)
            {
                PointInDiffCoord coord = GetPointInDiffCoord(p);
                tb_lon_lat_wgs84.Text = coord.WGS84.Lng.ToString("f7") + "," + coord.WGS84.Lat.ToString("f7");
                tb_lon_lat_gcj02.Text = coord.GCJ02.Lng.ToString("f7") + "," + coord.GCJ02.Lat.ToString("f7");
                tb_lon_lat_bd09.Text = coord.BD09.Lng.ToString("f7") + "," + coord.BD09.Lat.ToString("f7");
                curCoordinatePickPointInDiffCoord = coord;
                if (!isAddressReq)
                {
                    Placemark? place = getPointAddress(curCoordinatePickPointInDiffCoord);
                    if (place.HasValue)
                    {
                        tb_address.Text = place.Value.Address;
                        ShowCoordinatePickMarker(curCoordinatePickPointInDiffCoord, place.Value.Address);
                    }
                    else
                    {
                        tb_address.Text = "";
                        ShowCoordinatePickMarker(curCoordinatePickPointInDiffCoord, null);
                    }
                }
                else
                {
                    ShowCoordinatePickMarker(curCoordinatePickPointInDiffCoord, null);
                }
            }
            else
            {
                MyMessageBox.ShowWarningMessage("坐标格式错误");
            }
            isTextChanged = false;
        }

        private void ShowCoordinatePickMarker(PointInDiffCoord coord, string tip)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx].CoordType == CoordType.WGS84)
            {
                if (tip == null)
                {
                    coordinatePickOverlay.Markers.Add(new GMapImageMarker(coord.WGS84, Properties.Resources.arrow));
                }
                else
                {
                    coordinatePickOverlay.Markers.Add(new GMapImageMarker(coord.WGS84, Properties.Resources.arrow, tip));
                }
            }
            else if (curMapProviderInfoArray[curMapProviderInfoIdx].CoordType == CoordType.GCJ02)
            {
                if (tip == null)
                {
                    coordinatePickOverlay.Markers.Add(new GMapImageMarker(coord.GCJ02, Properties.Resources.arrow));
                }
                else
                {
                    coordinatePickOverlay.Markers.Add(new GMapImageMarker(coord.GCJ02, Properties.Resources.arrow, tip));
                }
            }
            else
            {
                if (tip == null)
                {
                    coordinatePickOverlay.Markers.Add(new GMapImageMarker(coord.BD09, Properties.Resources.arrow));
                }
                else
                {
                    coordinatePickOverlay.Markers.Add(new GMapImageMarker(coord.BD09, Properties.Resources.arrow, tip));
                }
            }
        }

        private void btn_query_by_coord_Click(object sender, EventArgs e)
        {
            if (curCoordinatePickPointInDiffCoord != null)
            {
                JumpCoordinatePickMarker(curCoordinatePickPointInDiffCoord);
            }
        }

        private Placemark? getPointAddress(PointInDiffCoord coord)
        {
            GeoCoderStatusCode statusCode;
            //Placemark? place = SoSoMapProvider.Instance.GetPlacemark(p, out statusCode);
            Placemark? place;
            if (高德地图ToolStripMenuItem_search.Checked)
            {
                place = AMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            else if (百度地图ToolStripMenuItem_search.Checked)
            {
                place = BaiduMapProvider.Instance.GetPlacemark(coord.BD09, out statusCode);
            }
            else if (腾讯地图ToolStripMenuItem_search.Checked)
            {
                place = TencentMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            else
            {
                place = AMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            return place;
        }

        List<PointLatLng> searchResult = new List<PointLatLng>(); //搜索结果
        private void btn_query_by_addrass_Click(object sender, EventArgs e)
        {
            if (searchResult == null)
            {
                searchResult = new List<PointLatLng>();
            }
            else
            {
                searchResult.Clear();
            }

            string searchStr = this.tb_address.Text;
            if (string.IsNullOrEmpty(searchStr))
            {
                MyMessageBox.ShowConformMessage("请输入关键字");
                return;
            }
            Placemark placemark = new Placemark(searchStr);
            placemark.CityName = currentCenterCityName;
            if (currentAreaPolygon != null)
            {
                placemark.CityName = currentAreaPolygon.Name;
            }
            GeoCoderStatusCode statusCode;
            CoordType coodType = CoordType.UNKNOW;
            if (高德地图ToolStripMenuItem_search.Checked)
            {
                statusCode = AMapProvider.Instance.GetPoints(placemark, out searchResult);
                coodType = CoordType.GCJ02;
            }
            else if (百度地图ToolStripMenuItem_search.Checked)
            {
                statusCode = BaiduMapProvider.Instance.GetPoints(placemark, out searchResult);
                coodType = CoordType.BD09;
            }
            else if (腾讯地图ToolStripMenuItem_search.Checked)
            {
                statusCode = TencentMapProvider.Instance.GetPoints(placemark, out searchResult);
                coodType = CoordType.GCJ02;
            }
            else
            {
                statusCode = AMapProvider.Instance.GetPoints(placemark, out searchResult);
                coodType = CoordType.GCJ02;
            }
            if (statusCode == GeoCoderStatusCode.G_GEO_SUCCESS && searchResult != null && searchResult.Count > 0)
            {
                Console.WriteLine("查询成功");
                foreach (PointLatLng point in searchResult)
                {
                    RefreshLonLatTextBox(new PointLatLng(point.Lat, point.Lng, coodType), true);
                    JumpCoordinatePickMarker(curCoordinatePickPointInDiffCoord);
                    break;
                }
            }
            else
            {
                Console.WriteLine("查询失败");
            }
        }

        #endregion

        #region 公共方法

        private PointInDiffCoord GetPointInDiffCoord(PointLatLng point)
        {
            if (point == PointLatLng.Empty || point.Type == CoordType.UNKNOW)
            {
                return null;
            }
            return new PointInDiffCoord(point);
        }

        private PointLatLng GetCoordFormString(string str, CoordType type)
        {
            if (str == null)
            {
                return PointLatLng.Empty;
            }
            str = str.Trim();
            string[] strs = str.Split(',');
            if (strs != null && strs.Length == 2)
            {
                try
                {
                    double lon = Convert.ToDouble(strs[0].Trim());
                    double lat = Convert.ToDouble(strs[1].Trim());
                    if (Math.Abs(lon) <= 180 && Math.Abs(lat) <= 90)
                    {
                        return new PointLatLng(lat, lon, type);
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            strs = str.Split('，');
            if (strs != null && strs.Length == 2)
            {
                try
                {
                    double lon = Convert.ToDouble(strs[0].Trim());
                    double lat = Convert.ToDouble(strs[1].Trim());
                    if (Math.Abs(lon) <= 180 && Math.Abs(lat) <= 90)
                    {
                        return new PointLatLng(lat, lon, type);
                    }
                }
                catch (Exception)
                {

                }
            }
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }
            strs = str.Split(' ');
            if (strs != null && strs.Length == 2)
            {
                try
                {
                    double lon = Convert.ToDouble(strs[0].Trim());
                    double lat = Convert.ToDouble(strs[1].Trim());
                    if (Math.Abs(lon) <= 180 && Math.Abs(lat) <= 90)
                    {
                        return new PointLatLng(lat, lon, type);
                    }
                }
                catch (Exception)
                {

                }
            }
            return PointLatLng.Empty;
        }

        private void JumpCoordinatePickMarker(PointInDiffCoord coord)
        {
            if (curMapProviderInfoArray[curMapProviderInfoIdx].CoordType == CoordType.WGS84)
            {
                mapControl.Position = coord.WGS84;
            }
            else if (curMapProviderInfoArray[curMapProviderInfoIdx].CoordType == CoordType.GCJ02)
            {
                mapControl.Position = coord.GCJ02;
            }
            else
            {
                mapControl.Position = coord.BD09;
            }
        }

        #endregion

        #region 访问方式切换

        private void ResetToServerAndCacheMode()
        {
            if (this.mapControl.Manager.Mode != AccessMode.ServerAndCache)
            {
                this.mapControl.Manager.Mode = AccessMode.ServerAndCache;
                this.在线和缓存ToolStripMenuItem.Checked = true;
                this.本地缓存ToolStripMenuItem.Checked = false;
                this.在线服务ToolStripMenuItem.Checked = false;
            }
        }

        private void 在线和缓存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mapControl.Manager.Mode = AccessMode.ServerAndCache;
            this.在线和缓存ToolStripMenuItem.Checked = true;
            this.在线服务ToolStripMenuItem.Checked = false;
            this.本地缓存ToolStripMenuItem.Checked = false;
        }

        private void 在线服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mapControl.Manager.Mode = AccessMode.ServerOnly;
            this.在线和缓存ToolStripMenuItem.Checked = false;
            this.在线服务ToolStripMenuItem.Checked = true;
            this.本地缓存ToolStripMenuItem.Checked = false;
        }

        private void 本地缓存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mapControl.Manager.Mode = AccessMode.CacheOnly;
            this.在线和缓存ToolStripMenuItem.Checked = false;
            this.在线服务ToolStripMenuItem.Checked = false;
            this.本地缓存ToolStripMenuItem.Checked = true;
        }

        #endregion

        #region 下载设置

        private void 代理设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProxyForm proxyForm = new ProxyForm();
            DialogResult diaResult = proxyForm.ShowDialog();
            if (diaResult == System.Windows.Forms.DialogResult.OK)
            {
                bool isProxyOn = proxyForm.CheckProxyOn();
                if (isProxyOn)
                {
                    string ip = proxyForm.GetProxyIp();
                    int port = proxyForm.GetProxyPort();
                    // set your proxy here if need
                    GMapProvider.IsSocksProxy = true;
                    GMapProvider.WebProxy = new WebProxy(ip, port);
                }
                else
                {
                    GMapProvider.IsSocksProxy = false;
                }
            }
        }

        private void 口令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyWordForm form = new KeyWordForm();
            form.ShowDialog();
        }

        #endregion

        #region 搜索引擎设置

        private void 高德地图ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.高德地图ToolStripMenuItem_search.Checked = true;
            this.百度地图ToolStripMenuItem_search.Checked = false;
            this.腾讯地图ToolStripMenuItem_search.Checked = false;
            Properties.Settings.Default.Setting_slt_search_engine = 0;
            Properties.Settings.Default.Save();
        }

        private void 百度地图ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.高德地图ToolStripMenuItem_search.Checked = false;
            this.百度地图ToolStripMenuItem_search.Checked = true;
            this.腾讯地图ToolStripMenuItem_search.Checked = false;
            Properties.Settings.Default.Setting_slt_search_engine = 1;
            Properties.Settings.Default.Save();
        }

        private void 腾讯地图ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.高德地图ToolStripMenuItem_search.Checked = false;
            this.百度地图ToolStripMenuItem_search.Checked = false;
            this.腾讯地图ToolStripMenuItem_search.Checked = true;
            Properties.Settings.Default.Setting_slt_search_engine = 2;
            Properties.Settings.Default.Save();
        }


        private void 设置高德地图开发者KeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_set_map_key set_map_key = new Form_set_map_key(SearchEngineType.AMAP);
            set_map_key.ShowDialog();
        }

        private void 设置百度地图开发者KeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_set_map_key set_map_key = new Form_set_map_key(SearchEngineType.BAIDU);
            set_map_key.ShowDialog();
        }

        private void 设置腾讯地图开发者KeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_set_map_key set_map_key = new Form_set_map_key(SearchEngineType.TENCENT);
            set_map_key.ShowDialog();
        }

        #endregion

        #region POI搜索

        private List<PoiData> poiQueryDataList = new List<PoiData>();
        private List<Placemark> poisQueryResult = new List<Placemark>();
        private int poiQueryCount = 0;
        private string searchProvince;
        private string searchCity;
        // POI Query Overlay
        private GMapOverlay poiQueryOverlay = new GMapOverlay("poiQueryOverlay");

        private void queryProgressEvent(long completedCount, long total)
        {
            this.toolStripStatusPOIDownload.Text = string.Format("已找到{0}条POI，还在查询中...", completedCount);
        }

        void poiWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (poisQueryResult != null && poisQueryResult.Count > 0)
            {
                foreach (Placemark place in poisQueryResult)
                {
                    GMarkerGoogle marker = new GMarkerGoogle(PointInDiffCoord.GetPointInCoordType(place.Point, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType), GMarkerGoogleType.blue_dot);
                    marker.ToolTipText = place.Name + "\r\n" + place.Address + "\r\n" + place.Category;
                    this.poiQueryOverlay.Markers.Add(marker);
                    PoiData poiData = new PoiData();
                    poiData.Name = place.Name;
                    poiData.Address = place.Address;
                    poiData.Province = searchProvince;
                    poiData.City = searchCity;
                    poiData.Lat = place.Point.Lat;
                    poiData.Lng = place.Point.Lng;
                    this.poiQueryDataList.Add(poiData);
                }

                //this.dataGridViewPOI.DataSource = poiDataList;=====
                RectLatLng rect = GMapUtil.PolygonUtils.GetRegionMaxRect(poiQueryDataList);
                this.mapControl.SetZoomToFitRect(rect);
            }
            this.toolStripStatusPOIDownload.Text = string.Format("共找到：{0}条POI数据", poisQueryResult.Count);
        }

        void poiWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            POISearchArgument argument = e.Argument as POISearchArgument;
            if (argument != null)
            {
                string regionName = argument.Region;
                string poiQueryRectangleStr = argument.Rectangle;
                string keyWords = argument.KeyWord;
                int mapIndex = argument.MapIndex;
                this.poiQueryDataList.Clear();
                this.poisQueryResult.Clear();
                this.poiQueryCount = 0;
                switch (mapIndex)
                {
                    //高德
                    case 0:
                        AMapProvider.Instance.GetPlacemarksByKeywords(keyWords, regionName, poiQueryRectangleStr, this.queryProgressEvent, out this.poisQueryResult, ref this.poiQueryCount);
                        break;
                    //百度
                    case 1:
                        BaiduMapProvider.Instance.GetPlacemarksByKeywords(keyWords, regionName, poiQueryRectangleStr, this.queryProgressEvent, out this.poisQueryResult, ref this.poiQueryCount);
                        break;
                    //腾讯
                    case 2:
                        TencentMapProvider.Instance.GetPlacemarksByKeywords(keyWords, regionName, poiQueryRectangleStr, "", this.queryProgressEvent, out this.poisQueryResult, ref this.poiQueryCount);
                        break;
                }
            }
        }

        //关键字POI查询
        private void buttonPOISearch_Click(object sender, EventArgs e)
        {
            Province province = this.comboBoxProvince.SelectedItem as Province;
            if (province == null)
            {
                MyMessageBox.ShowTipMessage("请选择POI查询的省份！");
                return;
            }
            searchProvince = province.name;

            City city = this.comboBoxCity.SelectedItem as City;
            if (city == null)
            {
                MyMessageBox.ShowTipMessage("请选择POI查询的城市！");
                return;
            }
            searchCity = city.name;

            string keywords = this.textBoxPOIkeyword.Text.Trim();
            if (string.IsNullOrEmpty(keywords))
            {
                MyMessageBox.ShowTipMessage("请输入POI查询的关键字！");
                return;
            }

            int selectMapIndex = 0;
            if (高德地图ToolStripMenuItem_search.Checked)
            {
                selectMapIndex = 0;
            }
            else if (百度地图ToolStripMenuItem_search.Checked)
            {
                selectMapIndex = 1;
            }
            else if (腾讯地图ToolStripMenuItem_search.Checked)
            {
                selectMapIndex = 2;
            }
            else
            {
                selectMapIndex = 0;
            }
            GetPOIFromMap(searchCity, keywords, selectMapIndex);
        }

        private void GetPOIFromMap(string cityName, string keywords, int mapIndex)
        {
            this.poiQueryOverlay.Markers.Clear();
            this.poiQueryDataList.Clear();
            POISearchArgument argument = new POISearchArgument();
            argument.KeyWord = keywords;
            argument.Region = cityName;
            argument.MapIndex = mapIndex;
            //if (currentAreaPolygon != null)==========
            //{
            //    RectLatLng rect = GMapUtil.PolygonUtils.GetRegionMaxRect(currentAreaPolygon);
            //    argument.Rectangle = string.Format("{0},{1},{2},{3}",
            //        new object[] { rect.LocationRightBottom.Lat, rect.LocationTopLeft.Lng, rect.LocationTopLeft.Lat, rect.LocationRightBottom.Lng });
            //}

            toolStripStatusPOIDownload.Visible = true;
            BackgroundWorker poiWorker = new BackgroundWorker();
            poiWorker.DoWork += new DoWorkEventHandler(poiWorker_DoWork);
            poiWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(poiWorker_RunWorkerCompleted);
            poiWorker.RunWorkerAsync(argument);
        }

        private void InitPOISearch()
        {
            if (!isCountryLoad)
            {
                InitChinaRegion();
                isCountryLoad = true;
            }
        }

        private void InitPOICountrySearchCondition()
        {
            if (china != null)
            {
                foreach (var provice in china.Province)
                {
                    this.comboBoxProvince.Items.Add(provice);
                }
                this.comboBoxProvince.DisplayMember = "name";
                //this.comboBoxProvince.SelectedIndex = 0;
                this.comboBoxProvince.SelectedValueChanged += ComboBoxProvince_SelectedValueChanged;
            }
        }

        private void ComboBoxProvince_SelectedValueChanged(object sender, EventArgs e)
        {
            Province province = this.comboBoxProvince.SelectedItem as Province;
            if (province != null)
            {
                this.comboBoxCity.Items.Clear();
                foreach (var city in province.City)
                {
                    this.comboBoxCity.Items.Add(city);
                }
                this.comboBoxCity.DisplayMember = "name";
                this.comboBoxCity.SelectedIndex = 0;
            }
        }

        private void buttonPoiSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (poiQueryDataList.Count <= 0)
                {
                    MyMessageBox.ShowTipMessage("POI数据为空，无法保存！");
                    return;
                }
                BackgroundWorker poiExportWorker = new BackgroundWorker();
                poiExportWorker.DoWork += new DoWorkEventHandler(poiExportWorker_DoWork);
                poiExportWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(poiExportWorker_RunWorkerCompleted);

                int selectIndex = this.comboBoxPoiSave.SelectedIndex;
                if (selectIndex == 0)
                {
                    SaveFileDialog saveDlg = new SaveFileDialog();
                    saveDlg.Filter = "Excel File (*.xls)|*.xls|(*.xlsx)|*.xlsx";
                    saveDlg.FilterIndex = 1;
                    saveDlg.RestoreDirectory = true;
                    if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string file = saveDlg.FileName;

                        DataTable dt = new DataTable();
                        dt.Columns.Add("名称", typeof(string));
                        dt.Columns.Add("地址", typeof(string));
                        dt.Columns.Add("省份", typeof(string));
                        dt.Columns.Add("城市", typeof(string));
                        dt.Columns.Add("经度", typeof(double));
                        dt.Columns.Add("纬度", typeof(double));

                        foreach (PoiData data in poiQueryDataList)
                        {
                            DataRow dr = dt.NewRow();
                            dr["名称"] = data.Name;
                            dr["地址"] = data.Address;
                            dr["省份"] = data.Province;
                            dr["城市"] = data.City;
                            dr["经度"] = data.Lng;
                            dr["纬度"] = data.Lat;
                            dt.Rows.Add(dr);
                        }
                        PoiExportParameter para = new PoiExportParameter();
                        para.Path = file;
                        para.Data = dt;
                        para.ExportType = selectIndex;
                        poiExportWorker.RunWorkerAsync(para);
                    }
                }
                else if (selectIndex == 1)
                {
                    PoiExportParameter para = new PoiExportParameter();
                    para.ExportType = selectIndex;
                    poiExportWorker.RunWorkerAsync(para);
                }
            }
            catch (Exception ex)
            {
                log.Error("Save POI data error: " + ex);
                MyMessageBox.ShowTipMessage("POI保存失败！");
            }
        }

        void poiExportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MyMessageBox.ShowTipMessage("POI保存完成！");
        }

        void poiExportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e != null)
            {
                PoiExportParameter para = e.Argument as PoiExportParameter;
                if (para.ExportType == 0)
                {
                    DataTable dt = para.Data;
                    string file = para.Path;
                    ExcelHelper.DataTableToExcel(dt, file, null, true);
                }
                else
                {
                    MyMessageBox.ShowTipMessage("请选择正确的保存方式！");
                }
                //else if (para.ExportType == 1)
                //{
                //    MySQLPoiCache mysqlPoiCache = new MySQLPoiCache(this.conString);
                //    bool isInitialized = mysqlPoiCache.Initialize();
                //    if (!isInitialized)
                //    {
                //        MyMessageBox.ShowTipMessage("数据库初始化失败！");
                //        return;
                //    }
                //    //Export data into database
                //    foreach (var data in poiDataList)
                //    {
                //        mysqlPoiCache.PutPoiDataToCache(data);
                //    }
                //}
            }
        }

        private void buttonPoiClean_Click(object sender, EventArgs e)
        {
            this.textBoxPOIkeyword.Text = "";
            this.poiQueryOverlay.Markers.Clear();
            this.poiQueryDataList.Clear();
        }

        #endregion

        #region 加载中国区域

        // China boundry
        private Country china;
        private bool isCountryLoad = false;
        private GMapOverlay regionOverlay = new GMapOverlay("region");

        void xPanderPanelChinaRegion_ExpandClick(object sender, EventArgs e)
        {
            if (!isCountryLoad)
            {
                InitChinaRegion();
                isCountryLoad = true;
            }
        }

        private void InitChinaRegion()
        {
            TreeNode rootNode = new TreeNode("中国（单击清除已绘制边界）");
            this.advTreeChina.Nodes.Add(rootNode);
            rootNode.Expand();

            //异步加载中国省市边界
            BackgroundWorker loadChinaWorker = new BackgroundWorker();
            loadChinaWorker.DoWork += new DoWorkEventHandler(loadChinaWorker_DoWork);
            loadChinaWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadChinaWorker_RunWorkerCompleted);
            loadChinaWorker.RunWorkerAsync();
        }

        private void InitCountryTree()
        {
            try
            {
                if (china.Province != null)
                {
                    foreach (var provice in china.Province)
                    {
                        TreeNode pNode = new TreeNode(provice.name);
                        pNode.Tag = provice;
                        if (provice.City != null)
                        {
                            foreach (var city in provice.City)
                            {
                                TreeNode cNode = new TreeNode(city.name);
                                cNode.Tag = city;
                                if (city.Piecearea != null)
                                {
                                    foreach (var piecearea in city.Piecearea)
                                    {
                                        TreeNode areaNode = new TreeNode(piecearea.name);
                                        areaNode.Tag = piecearea;
                                        cNode.Nodes.Add(areaNode);
                                    }
                                }
                                pNode.Nodes.Add(cNode);
                            }
                        }
                        TreeNode rootNode = this.advTreeChina.Nodes[0];
                        rootNode.Nodes.Add(pNode);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            this.advTreeChina.NodeMouseClick += new TreeNodeMouseClickEventHandler(advTreeChina_NodeMouseClick);
        }

        void advTreeChina_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.advTreeChina.SelectedNode = sender as TreeNode;
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                string name = e.Node.Text;
                string rings = null;
                switch (e.Node.Level)
                {
                    case 0:
                        regionOverlay.Clear();
                        break;
                    case 1:
                        Province province = e.Node.Tag as Province;
                        name = province.name;
                        rings = province.rings;
                        break;
                    case 2:
                        City city = e.Node.Tag as City;
                        name = city.name;
                        rings = city.rings;
                        break;
                    case 3:
                        Piecearea piecearea = e.Node.Tag as Piecearea;
                        name = piecearea.name;
                        rings = piecearea.rings;
                        break;
                }
                if (rings != null && !string.IsNullOrEmpty(rings))
                {
                    GMapPolygon polygon = ChinaMapRegion.GetRegionPolygon(name, rings);
                    if (polygon != null)
                    {
                        GMapAreaPolygon areaPolygon = new GMapAreaPolygon(polygon.Points, name);
                        currentAreaPolygon = areaPolygon;
                        RectLatLng rect = GMapUtil.PolygonUtils.GetRegionMaxRect(polygon);
                        GMapTextMarker textMarker = new GMapTextMarker(rect.LocationMiddle, "双击下载");
                        regionOverlay.Clear();
                        regionOverlay.Polygons.Add(areaPolygon);
                        regionOverlay.Markers.Add(textMarker);
                        this.mapControl.SetZoomToFitRect(rect);
                    }
                }
            }
        }

        void loadChinaWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (china == null)
            {
                log.Error("加载中国省市边界失败！");
                return;
            }

            InitPOICountrySearchCondition();

            InitCountryTree();
        }

        void loadChinaWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //byte[] buffer = Properties.Resources.ChinaBoundary_Province_City;
                byte[] buffer = Properties.Resources.ChinaBoundary;
                china = GMapChinaRegion.ChinaMapRegion.GetChinaRegionFromJsonBinaryBytes(buffer);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        #endregion

        #region 地图下载

        private Draw draw_download;
        private int retryNum = 3;
        // Tile Downloader, init 5 threads
        private TileDownloader tileDownloader = new TileDownloader(5);

        // Current area polygon for downloading
        private GMapAreaPolygon currentAreaPolygon;
        // Current dragable node when editing "current area polygon"
        private GMapMarkerEllipse currentDragableNode = null;
        private List<GMapMarkerEllipse> currentDragableNodes;
        private string tilePath = "D:\\GisMap";

        //画图完成函数
        void draw_download_DrawComplete(object sender, DrawEventArgs e)
        {
            try
            {
                if (e != null && (e.Polygon != null || e.Rectangle != null || e.Circle != null || e.Line != null || e.Route != null))
                {
                    GMapPolygon drawPolygon = null;
                    switch (e.DrawingMode)
                    {
                        case DrawingMode.Polygon:
                            drawPolygon = e.Polygon;
                            break;
                        case DrawingMode.Rectangle:
                            drawPolygon = e.Rectangle;
                            break;
                        default:
                            draw_download.IsEnable = false;
                            break;
                    }

                    if (drawPolygon != null)
                    {
                        GMapAreaPolygon areaPolygon = new GMapAreaPolygon(drawPolygon.Points, "下载区域");
                        currentAreaPolygon = areaPolygon;
                        RectLatLng rect = GMapUtil.PolygonUtils.GetRegionMaxRect(currentAreaPolygon);
                        GMapTextMarker textMarker = new GMapTextMarker(rect.LocationMiddle, "双击下载");
                        regionOverlay.Clear();
                        regionOverlay.Polygons.Add(areaPolygon);
                        regionOverlay.Markers.Add(textMarker);
                        this.mapControl.SetZoomToFitRect(rect);
                    }
                }
            }
            finally
            {
                draw_download.IsEnable = false;
            }
        }
        private void buttonDrawRectangle_Click(object sender, EventArgs e)
        {
            draw_download.DrawingMode = DrawingMode.Rectangle;
            draw_download.IsEnable = true;
        }

        private void buttonDrawPolygon_Click(object sender, EventArgs e)
        {
            draw_download.DrawingMode = DrawingMode.Polygon;
            draw_download.IsEnable = true;
        }

        private void buttonCleanDownloadArea_Click(object sender, EventArgs e)
        {
            currentAreaPolygon = null;
            regionOverlay.Clear();
        }

        private void buttonMapImage_Click(object sender, EventArgs e)
        {
            if (currentAreaPolygon != null)
            {
                RectLatLng area = GMapUtil.PolygonUtils.GetRegionMaxRect(currentAreaPolygon);
                try
                {
                    ResetToServerAndCacheMode();
                    int zoom = int.Parse(this.comboBoxZoom.Text);
                    //int retry = this.mapControl.Manager.Mode == AccessMode.CacheOnly ? 0 : 1; //是否重试
                    TileImageConnector tileImage = new TileImageConnector();
                    tileImage.Retry = retryNum;
                    tileImage.ImageTileComplete += new EventHandler(tileImage_ImageTileComplete);
                    tileImage.Start(this.mapControl.MapProvider, area, zoom);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MyMessageBox.ShowTipMessage("请先用“矩形”画图工具选择区域");
            }
        }

        void tileImage_ImageTileComplete(object sender, EventArgs e)
        {
            MessageBox.Show("拼接图生成完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void DownloadMap(GMapPolygon polygon)
        {
            if (polygon != null)
            {
                if (!tileDownloader.IsComplete)
                {
                    MyMessageBox.ShowWarningMessage("正在下载地图，等待下载完成！");
                }
                else
                {
                    RectLatLng area = GMapUtil.PolygonUtils.GetRegionMaxRect(polygon);
                    try
                    {
                        DownloadCfgForm downloadCfgForm = new DownloadCfgForm(area, this.mapControl.MapProvider);
                        if (downloadCfgForm.ShowDialog() == DialogResult.OK)
                        {
                            TileDownloaderArgs downloaderArgs = downloadCfgForm.GetDownloadTileGPoints();
                            ResetToServerAndCacheMode();

                            if (this.comboBoxStore.SelectedIndex == 1)
                            {
                                tileDownloader.TilePath = this.tilePath;
                            }
                            tileDownloader.Retry = retryNum;
                            tileDownloader.PrefetchTileStart += new EventHandler<TileDownloadEventArgs>(tileDownloader_PrefetchTileStart);
                            tileDownloader.PrefetchTileProgress += new EventHandler<TileDownloadEventArgs>(tileDownloader_PrefetchTileProgress);
                            tileDownloader.PrefetchTileComplete += new EventHandler<TileDownloadEventArgs>(tileDownloader_PrefetchTileComplete);
                            tileDownloader.StartDownload(downloaderArgs);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        log.Error(ex);
                    }
                }
            }
            else
            {
                MyMessageBox.ShowTipMessage("请先用画图工具画下载的区域多边形或选择省市区域！");
            }
        }

        private void ShowDownloadTip(bool isVisible)
        {
            if (this.Created && this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.toolStripProgressBarDownload.Visible = isVisible;
                    this.toolStripStatusDownload.Visible = isVisible;
                }));
            }
            else
            {
                this.toolStripProgressBarDownload.Visible = isVisible;
                this.toolStripStatusDownload.Visible = isVisible;
            }
        }

        void tileDownloader_PrefetchTileComplete(object sender, TileDownloadEventArgs e)
        {
            MessageBox.Show("地图下载完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ShowDownloadTip(false);
        }

        private delegate void UpdateDownloadProress(int completedCount, int totalCount);

        private void UpdateDownloadBar(int completedCount, int totalCount)
        {
            if (this.toolStripProgressBarDownload.Visible)
            {
                int value = completedCount * 100 / totalCount;
                this.toolStripStatusDownload.Text = string.Format("下载进度：{0}/{1}", completedCount, totalCount);
                this.toolStripProgressBarDownload.Value = value;
            }
        }

        void tileDownloader_PrefetchTileProgress(object sender, TileDownloadEventArgs e)
        {
            if (e != null)
            {
                if (this.IsDisposed || !this.IsHandleCreated) return;
                this.Invoke(new UpdateDownloadProress(UpdateDownloadBar), e.TileCompleteNum, e.TileAllNum);
            }
        }

        void tileDownloader_PrefetchTileStart(object sender, TileDownloadEventArgs e)
        {
            ShowDownloadTip(true);
        }

        private void 下载地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadMap(currentAreaPolygon);
        }

        private void buttonMapDownload_Click(object sender, EventArgs e)
        {
            DownloadMap(currentAreaPolygon);
        }

        private void 允许编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.允许编辑ToolStripMenuItem.Enabled = false;
            MapRoute route = currentAreaPolygon;
            this.currentDragableNodes = new List<GMapMarkerEllipse>();
            for (int i = 0; i < route.Points.Count; i++)
            {
                GMapMarkerEllipse item = new GMapMarkerEllipse(route.Points[i])
                {
                    Pen = new Pen(Color.Blue)
                };
                item.Pen.Width = 2f;
                item.Pen.DashStyle = DashStyle.Solid;
                item.Fill = new SolidBrush(Color.FromArgb(0xff, Color.AliceBlue));
                item.Tag = i;
                this.currentDragableNodes.Add(item);
                this.regionOverlay.Markers.Add(item);
            }
        }

        private void 停止编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.允许编辑ToolStripMenuItem.Enabled = true;
            if (currentDragableNodes == null) return;
            for (int i = 0; i < currentDragableNodes.Count; ++i)
            {
                if (this.regionOverlay.Markers.Contains(currentDragableNodes[i]))
                {
                    this.regionOverlay.Markers.Remove(currentDragableNodes[i]);
                }
            }
        }

        private void 清除区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentAreaPolygon = null;
            regionOverlay.Clear();
        }

        private void SaveKmlToFile(MapRoute item, string name, string fileName)
        {
            if (item is GMapRoute)
            {
                GMapRoute route = (GMapRoute)item;
                KmlUtil.SaveLineString(route.Points, name, fileName);
            }
            else if (item is GMapRectangle)
            {
                GMapRectangle rectangle = (GMapRectangle)item;
                KmlUtil.SavePolygon(rectangle.Points, name, fileName);
            }
            else if (item is GMapPolygon)
            {
                GMapPolygon polygon = (GMapPolygon)item;
                KmlUtil.SavePolygon(polygon.Points, name, fileName);
            }
        }

        private void 下载KMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentAreaPolygon != null)
            {
                string name = "KmlFile.kml";
                SaveFileDialog dialog = new SaveFileDialog
                {
                    FileName = name,
                    Title = "选择Kml文件位置",
                    Filter = "Kml文件|*.kml"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SaveKmlToFile(currentAreaPolygon, name, dialog.FileName);
                }
            }
        }

        #endregion

        #region 右键菜单

        private GPoint leftClickPoint = GPoint.Empty;

        private void 拾取该点坐标和地址ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointLatLng p = this.mapControl.FromLocalToLatLng((int)leftClickPoint.X, (int)leftClickPoint.Y);
            p.Type = curMapProviderInfoArray[curMapProviderInfoIdx].CoordType;
            RefreshLonLatTextBox(p, false);
        }

        private void 以此为起点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointLatLng p = this.mapControl.FromLocalToLatLng((int)leftClickPoint.X, (int)leftClickPoint.Y);
            GeoCoderStatusCode statusCode;
            //Placemark? place = AMapProvider.Instance.GetPlacemark(p, out statusCode);
            Placemark? place;
            PointInDiffCoord coord = new PointInDiffCoord(p);
            if (高德地图ToolStripMenuItem_search.Checked)
            {
                place = AMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            else if (百度地图ToolStripMenuItem_search.Checked)
            {
                place = BaiduMapProvider.Instance.GetPlacemark(coord.BD09, out statusCode);
            }
            else if (腾讯地图ToolStripMenuItem_search.Checked)
            {
                place = TencentMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            else
            {
                place = AMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            if (place.HasValue)
            {
                p.Type = curMapProviderInfoArray[curMapProviderInfoIdx].CoordType;
                routeStartPoint = p;
                if (this.routeOverlay.Markers.Contains(routeStartMarker))
                {
                    this.routeOverlay.Markers.Remove(routeStartMarker);
                }
                routeStartMarker = new GMapImageMarker(routeStartPoint, Properties.Resources.MapMarker_Bubble_Chartreuse);
                this.routeOverlay.Markers.Add(routeStartMarker);
                textBoxNaviStartPoint.Text = place.Value.Address;
            }
        }

        private void 添加途径点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointLatLng p = this.mapControl.FromLocalToLatLng((int)leftClickPoint.X, (int)leftClickPoint.Y);
            GeoCoderStatusCode statusCode;
            //Placemark? place = AMapProvider.Instance.GetPlacemark(p, out statusCode);
            Placemark? place;
            PointInDiffCoord coord = new PointInDiffCoord(p);
            if (高德地图ToolStripMenuItem_search.Checked)
            {
                place = AMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            else if (百度地图ToolStripMenuItem_search.Checked)
            {
                place = BaiduMapProvider.Instance.GetPlacemark(coord.BD09, out statusCode);
            }
            else if (腾讯地图ToolStripMenuItem_search.Checked)
            {
                place = TencentMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            else
            {
                place = AMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            if (place.HasValue)
            {
                p.Type = curMapProviderInfoArray[curMapProviderInfoIdx].CoordType;
                if (wayPoint1 == PointLatLng.Empty)
                {
                    wayPoint1 = p;
                    if (this.routeOverlay.Markers.Contains(routeWayMarker1))
                    {
                        this.routeOverlay.Markers.Remove(routeWayMarker1);
                    }
                    routeWayMarker1 = new GMapImageMarker(wayPoint1, Properties.Resources.MapMarker_Bubble_Azure);
                    this.routeOverlay.Markers.Add(routeWayMarker1);
                    textBoxNaviWay1.Text = place.Value.Address;
                }
                else if (wayPoint2 == PointLatLng.Empty)
                {
                    wayPoint2 = p;
                    if (this.routeOverlay.Markers.Contains(routeWayMarker2))
                    {
                        this.routeOverlay.Markers.Remove(routeWayMarker2);
                    }
                    routeWayMarker2 = new GMapImageMarker(wayPoint2, Properties.Resources.MapMarker_Bubble_Azure);
                    this.routeOverlay.Markers.Add(routeWayMarker2);
                    textBoxNaviWay2.Text = place.Value.Address;
                }
                else if (wayPoint3 == PointLatLng.Empty)
                {
                    wayPoint3 = p;
                    if (this.routeOverlay.Markers.Contains(routeWayMarker3))
                    {
                        this.routeOverlay.Markers.Remove(routeWayMarker3);
                    }
                    routeWayMarker3 = new GMapImageMarker(wayPoint3, Properties.Resources.MapMarker_Bubble_Azure);
                    this.routeOverlay.Markers.Add(routeWayMarker3);
                    textBoxNaviWay3.Text = place.Value.Address;
                }
                else
                {
                    MyMessageBox.ShowTipMessage("最多只能添加3个途经点");
                }
            }
        }

        private void 以此为终点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointLatLng p = this.mapControl.FromLocalToLatLng((int)leftClickPoint.X, (int)leftClickPoint.Y);
            GeoCoderStatusCode statusCode;
            //Placemark? place = AMapProvider.Instance.GetPlacemark(p, out statusCode);
            Placemark? place;
            PointInDiffCoord coord = new PointInDiffCoord(p);
            if (高德地图ToolStripMenuItem_search.Checked)
            {
                place = AMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            else if (百度地图ToolStripMenuItem_search.Checked)
            {
                place = BaiduMapProvider.Instance.GetPlacemark(coord.BD09, out statusCode);
            }
            else if (腾讯地图ToolStripMenuItem_search.Checked)
            {
                place = TencentMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            else
            {
                place = AMapProvider.Instance.GetPlacemark(coord.GCJ02, out statusCode);
            }
            if (place.HasValue)
            {
                p.Type = curMapProviderInfoArray[curMapProviderInfoIdx].CoordType;
                routeEndPoint = p;
                if (this.routeOverlay.Markers.Contains(routeEndMarker))
                {
                    this.routeOverlay.Markers.Remove(routeEndMarker);
                }
                routeEndMarker = new GMapImageMarker(routeEndPoint, Properties.Resources.MapMarker_Bubble_Pink);
                this.routeOverlay.Markers.Add(routeEndMarker);
                textBoxNaviEndPoint.Text = place.Value.Address;
            }
        }

        GMapMarker sltDelMarker;
        private void 删除当前MarkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltDelMarker != null)
            {
                demoOverlay.Markers.Remove(sltDelMarker);
            }
        }

        #endregion

        #region 地图覆盖物测试

        private GMapOverlay demoOverlay = new GMapOverlay("demoOverlay"); //放置demoOverlay的图层
        GMapHeatImage heatMarker = null;
        RectLatLng heatRect = RectLatLng.Empty;
        private Draw draw_demo;

        private void buttonBeginBlink_Click(object sender, EventArgs e)
        {
            foreach (GMapMarker m in demoOverlay.Markers)
            {
                if (m is GMapFlashMarker)
                {
                    GMapFlashMarker marker = m as GMapFlashMarker;
                    marker.StartFlash();
                }
            }
        }

        private void buttonStopBlink_Click(object sender, EventArgs e)
        {
            foreach (GMapMarker m in demoOverlay.Markers)
            {
                if (m is GMapFlashMarker)
                {
                    GMapFlashMarker marker = m as GMapFlashMarker;
                    marker.StopFlash();
                }
            }
        }

        void draw_demo_DrawComplete(object sender, DrawEventArgs e)
        {
            if (e != null && (e.Polygon != null || e.Rectangle != null || e.Circle != null || e.Route != null || e.Line != null))
            {
                switch (e.DrawingMode)
                {
                    case DrawingMode.Polygon:
                        demoOverlay.Polygons.Add(e.Polygon);
                        break;
                    case DrawingMode.Rectangle:
                        demoOverlay.Polygons.Add(e.Rectangle);
                        break;
                    case DrawingMode.Circle:
                        demoOverlay.Markers.Add(e.Circle);
                        break;
                    case DrawingMode.Route:
                        demoOverlay.Routes.Add(e.Route);
                        break;
                    case DrawingMode.Line:
                        demoOverlay.Routes.Add(e.Line);
                        break;
                    default:
                        draw_demo.IsEnable = false;
                        break;
                }
            }
            draw_demo.IsEnable = false;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            draw_demo.DrawingMode = DrawingMode.Circle;
            draw_demo.IsEnable = true;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            draw_demo.DrawingMode = DrawingMode.Rectangle;
            draw_demo.IsEnable = true;
        }

        private void buttonPolygon_Click(object sender, EventArgs e)
        {
            draw_demo.DrawingMode = DrawingMode.Polygon;
            draw_demo.IsEnable = true;
        }

        private void buttonPolyline_Click(object sender, EventArgs e)
        {
            draw_demo.DrawingMode = DrawingMode.Route;
            draw_demo.IsEnable = true;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            draw_demo.DrawingMode = DrawingMode.Line;
            draw_demo.IsEnable = true;
        }

        private void buttonHeatMarker_Click(object sender, EventArgs e)
        {
            if (heatMarker != null)
            {
                if (demoOverlay.Markers.Contains(heatMarker))
                {
                    demoOverlay.Markers.Remove(heatMarker);
                    heatMarker.Dispose();
                }
            }
            int zoom = (int)this.mapControl.Zoom;

            List<PointLatLng> ps = GetRandomPoint();
            foreach (var p in ps)
            {
                GMapPointMarker pointmarker = new GMapPointMarker(p);
                //this.poiOverlay.Markers.Add(pointmarker);
            }

            //热力图范围
            heatRect = GMapUtils.GetPointsMaxRect(ps);
            GPoint plt = this.mapControl.MapProvider.Projection.FromLatLngToPixel(heatRect.LocationTopLeft, zoom);
            GPoint prb = this.mapControl.MapProvider.Projection.FromLatLngToPixel(heatRect.LocationRightBottom, zoom);

            List<HeatPoint> hps = new List<HeatPoint>();
            foreach (var p in ps)
            {
                GPoint gp = this.mapControl.MapProvider.Projection.FromLatLngToPixel(p, zoom);
                HeatPoint hp = new HeatPoint();
                hp.X = gp.X - plt.X;
                hp.Y = gp.Y - plt.Y;
                hp.W = 1.0f;
                hps.Add(hp);
            }

            int width = (int)(prb.X - plt.X);
            int height = (int)(prb.Y - plt.Y);

            var hmMaker = new HeatMapMaker
            {
                Width = width,
                Height = height,
                Radius = 10,
                ColorRamp = ColorRamp.RAINBOW,
                HeatPoints = hps,
                Opacity = 111
            };
            Bitmap bitmap = hmMaker.MakeHeatMap();
            heatMarker = new GMapHeatImage(heatRect.LocationTopLeft, bitmap);
            this.demoOverlay.Markers.Add(heatMarker);
            this.mapControl.SetZoomToFitRect(heatRect);
        }

        private List<PointLatLng> GetRandomPoint()
        {
            Random rand = new Random();
            List<PointLatLng> points = new List<PointLatLng>();
            int pointNum = 500;
            for (int i = 0; i < pointNum; ++i)
            {
                double x = 118 + rand.NextDouble() * 0.1 + rand.NextDouble() * 0.1 * 0.1 + rand.NextDouble();
                double y = 24.5 + rand.NextDouble() * 0.1 + rand.NextDouble() * 0.1 * 0.1 + rand.NextDouble();
                points.Add(new PointLatLng(y, x));
            }

            return points;
        }

        private void buttonClearDemoOverlay_Click(object sender, EventArgs e)
        {
            if (demoOverlay != null)
            {
                demoOverlay.Polygons.Clear();
                demoOverlay.Markers.Clear();
                demoOverlay.Routes.Clear();
            }
        }

        #endregion

        #region 导航路线

        private bool allowRouting = true;
        private PointLatLng routeStartPoint = PointLatLng.Empty;
        private PointLatLng wayPoint1 = PointLatLng.Empty;
        private PointLatLng wayPoint2 = PointLatLng.Empty;
        private PointLatLng wayPoint3 = PointLatLng.Empty;
        private PointLatLng routeEndPoint = PointLatLng.Empty;
        private GMapImageMarker routeStartMarker;
        private GMapImageMarker routeWayMarker1;
        private GMapImageMarker routeWayMarker2;
        private GMapImageMarker routeWayMarker3;
        private GMapImageMarker routeEndMarker;
        private GMapOverlay routeOverlay = new GMapOverlay("routeOverlay");
        private List<PointLatLng> mNaviRoutepPointList = null;

        private List<PointLatLng> getWayList(CoordType type) {
            List<PointLatLng> wayList = new List<PointLatLng>();
            if (wayPoint1 != PointLatLng.Empty)
            {
                wayList.Add(PointInDiffCoord.GetPointInCoordType(wayPoint1, type));
            }
            if (wayPoint2 != PointLatLng.Empty)
            {
                wayList.Add(PointInDiffCoord.GetPointInCoordType(wayPoint2, type));
            }
            if (wayPoint3 != PointLatLng.Empty)
            {
                wayList.Add(PointInDiffCoord.GetPointInCoordType(wayPoint3, type));
            }
            return wayList;
        }

        private void buttonNaviGetRoute_Click(object sender, EventArgs e)
        {
            if (routeStartPoint != PointLatLng.Empty && routeEndPoint != PointLatLng.Empty)
            {
                if (高德地图ToolStripMenuItem_search.Checked)
                {
                    PointLatLng startPoint = PointInDiffCoord.GetGCJ02Point(routeStartPoint);
                    PointLatLng endPoint = PointInDiffCoord.GetGCJ02Point(routeEndPoint);
                    List<PointLatLng> wayList = getWayList(CoordType.GCJ02);
                    MapRoute route = AMapProvider.Instance.GetDrivingRoute(startPoint, endPoint, wayList);
                    mNaviRoutepPointList = PointInDiffCoord.GetPointListInCoordType(route.Points, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                    GMapRoute mapRoute = new GMapRoute(mNaviRoutepPointList, "");
                    if (mapRoute != null)
                    {
                        this.routeOverlay.Routes.Clear();
                        this.routeOverlay.Routes.Add(mapRoute);
                        this.mapControl.ZoomAndCenterRoute(mapRoute);
                    }
                    else
                    {
                        MyMessageBox.ShowWarningMessage("获取导航路线失败");
                    }
                }
                else if (百度地图ToolStripMenuItem_search.Checked)
                {
                    PointLatLng startPoint = PointInDiffCoord.GetBD09Point(routeStartPoint);
                    PointLatLng endPoint = PointInDiffCoord.GetBD09Point(routeEndPoint);
                    List<PointLatLng> wayList = getWayList(CoordType.BD09);
                    MapRoute route = BaiduMapProvider.Instance.GetDrivingRoute(startPoint, endPoint, wayList);
                    mNaviRoutepPointList = PointInDiffCoord.GetPointListInCoordType(route.Points, CoordType.BD09, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                    GMapRoute mapRoute = new GMapRoute(mNaviRoutepPointList, "");
                    if (mapRoute != null)
                    {
                        this.routeOverlay.Routes.Clear();
                        this.routeOverlay.Routes.Add(mapRoute);
                        this.mapControl.ZoomAndCenterRoute(mapRoute);
                    }
                    else
                    {
                        MyMessageBox.ShowWarningMessage("获取导航路线失败");
                    }
                }
                else if (腾讯地图ToolStripMenuItem_search.Checked)
                {
                    PointLatLng startPoint = PointInDiffCoord.GetGCJ02Point(routeStartPoint);
                    PointLatLng endPoint = PointInDiffCoord.GetGCJ02Point(routeEndPoint);
                    List<PointLatLng> wayList = getWayList(CoordType.GCJ02);
                    MapRoute route = TencentMapProvider.Instance.GetDrivingRoute(startPoint, endPoint, wayList);
                    mNaviRoutepPointList = PointInDiffCoord.GetPointListInCoordType(route.Points, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                    GMapRoute mapRoute = new GMapRoute(mNaviRoutepPointList, "");
                    if (mapRoute != null)
                    {
                        this.routeOverlay.Routes.Clear();
                        this.routeOverlay.Routes.Add(mapRoute);
                        this.mapControl.ZoomAndCenterRoute(mapRoute);
                    }
                    else
                    {
                        MyMessageBox.ShowWarningMessage("获取导航路线失败");
                    }
                }
                else
                {
                    PointLatLng startPoint = PointInDiffCoord.GetGCJ02Point(routeStartPoint);
                    PointLatLng endPoint = PointInDiffCoord.GetGCJ02Point(routeEndPoint);
                    List<PointLatLng> wayList = getWayList(CoordType.GCJ02);
                    MapRoute route = AMapProvider.Instance.GetDrivingRoute(startPoint, endPoint, wayList);
                    mNaviRoutepPointList = PointInDiffCoord.GetPointListInCoordType(route.Points, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                    GMapRoute mapRoute = new GMapRoute(mNaviRoutepPointList, "");
                    if (mapRoute != null)
                    {
                        this.routeOverlay.Routes.Clear();
                        this.routeOverlay.Routes.Add(mapRoute);
                        this.mapControl.ZoomAndCenterRoute(mapRoute);
                    }
                    else
                    {
                        MyMessageBox.ShowWarningMessage("获取导航路线失败");
                    }
                }
            }
            else
            {
                MyMessageBox.ShowWarningMessage("请先选择起点终点");
            }
        }

        private void buttonCleanRoute_Click(object sender, EventArgs e)
        {
            textBoxNaviStartPoint.Text = "";
            textBoxNaviWay1.Text = "";
            textBoxNaviWay2.Text = "";
            textBoxNaviWay3.Text = "";
            textBoxNaviEndPoint.Text = "";
            routeStartPoint = PointLatLng.Empty;
            wayPoint1 = PointLatLng.Empty;
            wayPoint2 = PointLatLng.Empty;
            wayPoint3 = PointLatLng.Empty;
            routeEndPoint = PointLatLng.Empty;
            routeOverlay.Markers.Clear();
            routeOverlay.Routes.Clear();
        }

        private void buttonNaviExport_Click(object sender, EventArgs e)
        {
            List<PointLatLng> tempNaviList = mNaviRoutepPointList;
            if (routeStartPoint == PointLatLng.Empty || routeEndPoint == PointLatLng.Empty || tempNaviList == null)
            {
                MyMessageBox.ShowTipMessage("请先规划导航路线");
                return;
            }
            GpsRoute gpsRoute = new GpsRoute();
            List<GpsRoutePoint> gpsRoutePointList = new List<GpsRoutePoint>();
            PointLatLng lastPoint = PointLatLng.Empty;
            int idx = 0;
            for (int i = 0; i < tempNaviList.Count; i++)
            {
                if (i == 0)
                {
                    lastPoint = tempNaviList[i];
                }
                else
                {
                    PointLatLng curPoint = tempNaviList[i];
                    List<GpsRoutePoint> tempRoutePointList = getNaviRouteGpsPointList(lastPoint, curPoint);
                    if (tempRoutePointList == null)
                    {
                        continue;
                    }
                    for (int j = 0; j < tempRoutePointList.Count; j++)
                    {
                        if (j == 0 && i != 1)
                        {
                            continue;
                        }
                        tempRoutePointList[j].ID = idx++;
                        gpsRoutePointList.Add(tempRoutePointList[j]);
                    }
                    lastPoint = curPoint;
                }
            }
            if (gpsRoutePointList == null || gpsRoutePointList.Count <= 0)
            {
                MyMessageBox.ShowWarningMessage("获取导航轨迹点为空");
                return;
            }
            gpsRoute.GpsRouteInfoList = gpsRoutePointList;
            gpsRoute.RouteName = textBoxNaviStartPoint.Text + " 》 " + textBoxNaviEndPoint.Text;
            gpsRoute.CoordType = routeStartPoint.Type;
            gpsRoute.Bitmap = gpsRouteBitmapArray[gpsRouteBitmapArrayIdx++ % gpsRouteBitmapArray.Length];
            gpsRoute.Overlay = new GMapOverlay("hro-" + gpsRoute.RouteName);
            DialogResult diaResult = MyMessageBox.ShowConformMessage("获取到" +  + gpsRoutePointList.Count + "个轨迹点，是否显示？");
            if (diaResult == System.Windows.Forms.DialogResult.OK)
            {
                clb_route_list.Items.Add(gpsRoute, true);
                ShowGpsRoute(gpsRoute, true, true);
            }
            else
            {
                clb_route_list.Items.Add(gpsRoute, false);
            }
        }

        private List<GpsRoutePoint> getNaviRouteGpsPointList(PointLatLng lastPoint, PointLatLng curPoint)
        {
            // 先判断两个点是否重合
            if (lastPoint == PointLatLng.Empty || curPoint == PointLatLng.Empty)
            {
                return null;
            }
            if (lastPoint.Lat == curPoint.Lat && lastPoint.Lng == curPoint.Lng)
            {
                return null;
            }
            // 计算方向
            double dir = CalculateUtils.getDirection(lastPoint.Lng, lastPoint.Lat, curPoint.Lng, curPoint.Lat);
            double dist = CalculateUtils.getDistance(lastPoint.Lng, lastPoint.Lat, curPoint.Lng, curPoint.Lat);
            if (dist < 30)
            {
                return null;
            }
            int min_dist = 100;
            List<GpsRoutePoint> gpsRoutePointList = new List<GpsRoutePoint>();
            // 起点
            GpsRoutePoint point = new GpsRoutePoint();
            point.Longitude = lastPoint.Lng;
            point.Latitude = lastPoint.Lat;
            point.Direction = dir;
            gpsRoutePointList.Add(point);
            // 插值点
            int insertNum = (int)dist / min_dist;
            double insertLon = (curPoint.Lng - lastPoint.Lng) / (insertNum + 1);
            double insertLat = (curPoint.Lat - lastPoint.Lat) / (insertNum + 1);
            for (int i = 0; i < insertNum; i++)
            {
                point = new GpsRoutePoint();
                point.Longitude = lastPoint.Lng + (i + 1) * insertLon;
                point.Latitude = lastPoint.Lat + (i + 1) * insertLat;
                point.Direction = dir;
                point.Type = 1;
                gpsRoutePointList.Add(point);
            }
            // 尾点
            point = new GpsRoutePoint();
            point.Longitude = curPoint.Lng;
            point.Latitude = curPoint.Lat;
            point.Direction = dir;
            gpsRoutePointList.Add(point);
            return gpsRoutePointList;
        }

        private void buttonNaviStartDel_Click(object sender, EventArgs e)
        {
            textBoxNaviStartPoint.Text = "";
            routeStartPoint = PointLatLng.Empty;
            if (this.routeOverlay.Markers.Contains(routeStartMarker))
            {
                this.routeOverlay.Markers.Remove(routeStartMarker);
            }
            routeOverlay.Routes.Clear();
        }

        private void buttonNaviWay1Del_Click(object sender, EventArgs e)
        {
            if (wayPoint2 == PointLatLng.Empty)
            {
                textBoxNaviWay1.Text = "";
                wayPoint1 = PointLatLng.Empty;
                if (this.routeOverlay.Markers.Contains(routeWayMarker1))
                {
                    this.routeOverlay.Markers.Remove(routeWayMarker1);
                }
                routeOverlay.Routes.Clear();
            }
            else
            {
                textBoxNaviWay1.Text = textBoxNaviWay2.Text;
                wayPoint1 = wayPoint2;
                if (this.routeOverlay.Markers.Contains(routeWayMarker1))
                {
                    this.routeOverlay.Markers.Remove(routeWayMarker1);
                }
                routeWayMarker1 = new GMapImageMarker(wayPoint1, Properties.Resources.MapMarker_Bubble_Azure);
                this.routeOverlay.Markers.Add(routeWayMarker1);
                routeOverlay.Routes.Clear();
                if (wayPoint3 == PointLatLng.Empty)
                {
                    textBoxNaviWay2.Text = "";
                    wayPoint2 = PointLatLng.Empty;
                    if (this.routeOverlay.Markers.Contains(routeWayMarker2))
                    {
                        this.routeOverlay.Markers.Remove(routeWayMarker2);
                    }
                    routeOverlay.Routes.Clear();
                }
                else
                {
                    textBoxNaviWay2.Text = textBoxNaviWay3.Text;
                    wayPoint2 = wayPoint3;
                    if (this.routeOverlay.Markers.Contains(routeWayMarker2))
                    {
                        this.routeOverlay.Markers.Remove(routeWayMarker2);
                    }
                    routeWayMarker2 = new GMapImageMarker(wayPoint2, Properties.Resources.MapMarker_Bubble_Azure);
                    this.routeOverlay.Markers.Add(routeWayMarker2);
                    routeOverlay.Routes.Clear();
                    textBoxNaviWay3.Text = "";
                    wayPoint3 = PointLatLng.Empty;
                    if (this.routeOverlay.Markers.Contains(routeWayMarker3))
                    {
                        this.routeOverlay.Markers.Remove(routeWayMarker3);
                    }
                    routeOverlay.Routes.Clear();
                }
            }
        }

        private void buttonNaviWay2Del_Click(object sender, EventArgs e)
        {
            if (wayPoint3 == PointLatLng.Empty)
            {
                textBoxNaviWay2.Text = "";
                wayPoint2 = PointLatLng.Empty;
                if (this.routeOverlay.Markers.Contains(routeWayMarker2))
                {
                    this.routeOverlay.Markers.Remove(routeWayMarker2);
                }
                routeOverlay.Routes.Clear();
            }
            else
            {
                textBoxNaviWay2.Text = textBoxNaviWay3.Text;
                wayPoint2 = wayPoint3;
                if (this.routeOverlay.Markers.Contains(routeWayMarker2))
                {
                    this.routeOverlay.Markers.Remove(routeWayMarker2);
                }
                routeWayMarker2 = new GMapImageMarker(wayPoint2, Properties.Resources.MapMarker_Bubble_Azure);
                this.routeOverlay.Markers.Add(routeWayMarker2);
                routeOverlay.Routes.Clear();
                textBoxNaviWay3.Text = "";
                wayPoint3 = PointLatLng.Empty;
                if (this.routeOverlay.Markers.Contains(routeWayMarker3))
                {
                    this.routeOverlay.Markers.Remove(routeWayMarker3);
                }
                routeOverlay.Routes.Clear();
            }
        }

        private void buttonNaviWay3Del_Click(object sender, EventArgs e)
        {
            textBoxNaviWay3.Text = "";
            wayPoint3 = PointLatLng.Empty;
            if (this.routeOverlay.Markers.Contains(routeWayMarker3))
            {
                this.routeOverlay.Markers.Remove(routeWayMarker3);
            }
            routeOverlay.Routes.Clear();
        }

        private void buttonNaviEndDel_Click(object sender, EventArgs e)
        {
            textBoxNaviEndPoint.Text = "";
            routeEndPoint = PointLatLng.Empty;
            if (this.routeOverlay.Markers.Contains(routeEndMarker))
            {
                this.routeOverlay.Markers.Remove(routeEndMarker);
            }
            routeOverlay.Routes.Clear();
        }

        #endregion

        #region 历史轨迹数据加载
        Bitmap[] gpsRouteBitmapArray = new Bitmap[] { Properties.Resources.arrow_up_0, Properties.Resources.arrow_up_1, Properties.Resources.arrow_up_2
        , Properties.Resources.arrow_up_3, Properties.Resources.arrow_up_4, Properties.Resources.arrow_up_5, Properties.Resources.arrow_up_6
        , Properties.Resources.arrow_up_7};
        int gpsRouteBitmapArrayIdx = 0;
        GpsRoute sltGpsRoute;
        GpsRoute simulateGpsRoute;

        private void buttonLoadGpsRouteFile_Click(object sender, EventArgs e)
        {
            Form_load_gps load_gps = new Form_load_gps();
            DialogResult diaResult = load_gps.ShowDialog();
            if (diaResult == System.Windows.Forms.DialogResult.OK)
            {
                GpsRoute gpsRoute = load_gps.gpsRoute;
                gpsRoute.Bitmap = gpsRouteBitmapArray[gpsRouteBitmapArrayIdx++ % gpsRouteBitmapArray.Length];
                gpsRoute.Overlay = new GMapOverlay("hro-" + gpsRoute.RouteName);
                diaResult = MyMessageBox.ShowConformMessage("加载完成，是否显示？");
                if (diaResult == System.Windows.Forms.DialogResult.OK)
                {
                    clb_route_list.Items.Add(gpsRoute, true);
                    ShowGpsRoute(gpsRoute, true, true);
                }
                else
                {
                    clb_route_list.Items.Add(gpsRoute, false);
                }
            }
        }

        private void clb_route_list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Console.WriteLine("clb_route_list_ItemCheck   " + e.Index + " " + e.NewValue + " " + e.CurrentValue);
            GpsRoute gpsRoute = (GpsRoute)clb_route_list.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                ShowGpsRoute(gpsRoute, true, false);
            }
            else
            {
                gpsRoute.Overlay.Clear();
                mapControl.Overlays.Remove(gpsRoute.Overlay);
            }
        }

        private void ShowGpsRoute(GpsRoute gpsRoute, bool display, bool zoom)
        {
            if (display)
            {
                mapControl.Overlays.Add(gpsRoute.Overlay);
                gpsRoute.Overlay.Clear();
            }
            List<PointLatLng> pointList = new List<PointLatLng>();
            foreach (var routePoint in gpsRoute.GpsRouteInfoList)
            {
                PointLatLng point = PointInDiffCoord.GetPointInCoordType(routePoint.Latitude, routePoint.Longitude, gpsRoute.CoordType, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                pointList.Add(point);
                if (display)
                {
                    GMapDirectionMarker marker = new GMapDirectionMarker(point, gpsRoute.Bitmap, (float)routePoint.Direction);
                    marker.ToolTipText = routePoint.AttributeStr;
                    gpsRoute.Overlay.Markers.Add(marker);
                }
            }
            if (zoom)
            {
                RectLatLng rect = GMapUtils.GetPointsMaxRect(pointList);
                mapControl.SetZoomToFitRect(rect);
            }
        }

        private void buttonDelectGpsRouteFile_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clb_route_list.Items.Count; i++)
            {
                if (clb_route_list.GetItemChecked(i))
                {
                    GpsRoute checkedItem = (GpsRoute)clb_route_list.Items[i];
                    checkedItem.Overlay.Clear();
                    mapControl.Overlays.Remove(checkedItem.Overlay);
                    clb_route_list.Items.RemoveAt(i);
                    i--;
                }
            }
        }

        private void clb_route_list_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//判断是否右键点击
            {
                Point p = e.Location;//获取点击的位置
                int index = clb_route_list.IndexFromPoint(p);//根据位置获取右键点击项的索引
                if (index >= 0)
                {
                    //checkedListBox1.SelectedIndex = index;//设置该索引值对应的项为选定状态
                    //checkedListBox1.SetItemChecked(index, true);//如果需要的话这句可以同时设置check状态
                    GpsRoute clickItem = (GpsRoute)clb_route_list.Items[index];
                    //Console.WriteLine("checkedItem = " + clickItem.RouteName);
                    if (clickItem != null)
                    {
                        sltGpsRoute = clickItem;
                        contextMenuStripHistoryRoute.Show(Cursor.Position);
                    }
                }
            }
        }

        private void 缩放至图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltGpsRoute != null)
            {
                ShowGpsRoute(sltGpsRoute, false, true);
            }
        }

        private void 设置为模拟轨迹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltGpsRoute != null)
            {
                simulateGpsRoute = sltGpsRoute;
                cb_simulate_type.SelectedIndex = 0;
                tb_simulate_src.Text = sltGpsRoute.RouteName;
                this.dataGridViewGpsRoute.DataSource = simulateGpsRoute.GpsRouteInfoList;
            }
        }

        private void 导出轨迹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_export_gps export = new Form_export_gps(sltGpsRoute);
            export.ShowDialog();
        }

        private void 删除轨迹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltGpsRoute != null)
            {
                sltGpsRoute.Overlay.Clear();
                mapControl.Overlays.Remove(sltGpsRoute.Overlay);
                clb_route_list.Items.Remove(sltGpsRoute);
                sltGpsRoute = null;
            }
        }

        #endregion

        #region 测试数据加载

        private GMapOverlay gridOverlay = new GMapOverlay("gridOverlay"); //放置网格Overlay的图层
        TerminalMapInfo terminalMapInfo = null;
        TerminalMapInfo sltTerminalMapInfo = null;
        CityDataInfo sltCityDataInfo = null; 
        TerminalMapInfo sltCityTerminalMapInfo = null;
        TreeNode sltRootNode;
        TreeNode sltCityNode;

        private void buttonLoadMapFile_Click(object sender, EventArgs e)
        {
            // 选择文件夹
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择测试数据所在文件夹";
            string setting_path = Properties.Settings.Default.Setting_slt_tmap_path;
            if (setting_path != null && setting_path != string.Empty)
            {
                dialog.SelectedPath = setting_path;
            }
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sltPath = dialog.SelectedPath;
                if (string.IsNullOrEmpty(sltPath))
                {
                    MyMessageBox.ShowTipMessage("文件夹路径不能为空");
                    return;
                }
                BackgroundWorker loadCityIndexWorker = new BackgroundWorker();
                loadCityIndexWorker.DoWork += new DoWorkEventHandler(loadCityIndexWorker_DoWork);
                loadCityIndexWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadCityIndexWorker_RunWorkerCompleted);
                loadCityIndexWorker.RunWorkerAsync(sltPath);
                Properties.Settings.Default.Setting_slt_tmap_path = sltPath;
            }
        }

        void loadCityIndexWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (terminalMapInfo != null)
            {
                mapControl.Overlays.Add(terminalMapInfo.TerminalMapOverlay);
                TreeNode rootNode = new TreeNode(terminalMapInfo.PathName);
                rootNode.Tag = terminalMapInfo;
                this.treeViewTerminalMap.Nodes.Add(rootNode);
                TreeNode idxNode = new TreeNode("000000_索引文件");
                idxNode.Tag = terminalMapInfo;
                TreeNode idxNodeSub = new TreeNode("cityIndex.dat -> " + terminalMapInfo.CityIndexReleaseVersion + " -> " + terminalMapInfo.CityIndexStructVersion);
                idxNodeSub.Tag = terminalMapInfo;
                idxNode.Nodes.Add(idxNodeSub);
                rootNode.Nodes.Add(idxNode);
                foreach (CityDataInfo cityData in terminalMapInfo.CityDataList)
                {
                    mapControl.Overlays.Add(cityData.CityDataOverlay);
                    TreeNode cityNode = new TreeNode(cityData.City_code+"_"+cityData.City_name);
                    cityNode.Tag = cityData;
                    bool hasData = false;
                    if (cityData.RoadFileTag)
                    {
                        TreeNode topoNode = new TreeNode("topomap.dat -> " + cityData.RoadFileInfo.ReleaseVersion + " -> " + cityData.RoadFileInfo.StructVersion);
                        topoNode.Tag = cityData.RoadFileInfo;
                        cityNode.Nodes.Add(topoNode);
                        hasData = true;
                    }
                    if (cityData.AdasFileTag)
                    {
                        TreeNode adasNode = new TreeNode("Adas.dat -> " + cityData.AdasFileInfo.ReleaseVersion + " -> " + cityData.AdasFileInfo.StructVersion);
                        adasNode.Tag = cityData.AdasFileInfo;
                        cityNode.Nodes.Add(adasNode);
                        hasData = true;
                    }
                    if (hasData)
                    {
                        rootNode.Nodes.Add(cityNode);
                    }
                }
                rootNode.Expand();
                sltRootNode = rootNode;
                if (sltMatchTestRootNode == null)
                {
                    sltMatchTestRootNode = rootNode;
                }
                MyMessageBox.ShowTipMessage("加载完成！");
            }
        }

        void treeViewTerminalMap_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.treeViewTerminalMap.SelectedNode = sender as TreeNode;
            if (e.Node.Level == 0)
            {
                sltRootNode = e.Node;
            }
            else
            {
                sltCityNode = e.Node;
            }
            if (e.Button == MouseButtons.Right)
            {
                string name = e.Node.Text;
                switch (e.Node.Level)
                {
                    case 0:
                        sltTerminalMapInfo = e.Node.Tag as TerminalMapInfo;
                        this.contextMenuStripDisplayInfo.Show(Cursor.Position);
                        break;
                    case 1:
                        if (name.Contains("000000"))
                        {
                            //TerminalMapInfo terminalMapInfo = e.Node.Tag as TerminalMapInfo;
                            //// 显示行政区
                            //if (terminalMapInfo.TerminalMapOverlay.Polygons.Count > 0)
                            //{
                            //    terminalMapInfo.TerminalMapOverlay.Polygons.Clear();
                            //}
                            //else
                            //{
                            //    foreach (var item in terminalMapInfo.CityDataList)
                            //    {
                            //        showCityBorder(item, terminalMapInfo.TerminalMapOverlay, terminalMapInfo);
                            //    }
                            //}
                        }
                        else
                        {
                            sltCityDataInfo = e.Node.Tag as CityDataInfo;
                            sltCityTerminalMapInfo = e.Node.Parent.Tag as TerminalMapInfo;
                            this.contextMenuCityDataView.Show(Cursor.Position);
                        }
                        break;
                    case 2:
                        break;
                }
            }
        }

        private void CleanCityDataOverlay(CityDataInfo cityData, bool remove)
        {
            cityData.CityDataOverlay.Markers.Clear();
            cityData.CityDataOverlay.Routes.Clear();
            cityData.CityDataOverlay.Polygons.Clear();
            if (remove)
            {
                mapControl.Overlays.Remove(cityData.CityDataOverlay);
            }
        }

        private void ShowCityDataOverlay(TerminalMapLib.CityDataInfo cityData, TerminalMapLib.TerminalMapInfo terminalMapInfo, RectLatLng rect, bool isMatchGrid)
        {
            if (terminalMapInfo.DisplayInfo.IsShowBoundary)
            {
                showCityBorder(cityData, cityData.CityDataOverlay, terminalMapInfo);
            }
            if (terminalMapInfo.DisplayInfo.IsShowRoad && cityData.RoadFileTag && cityData.RoadFileInfo != null)
            {
                if (cityData.RoadFileInfo.LoadStatus == 0)
                {
                    RoadFileInfo roadFileInfo = TerminalMapTool.GetRoadFileInfo(cityData.RoadFileInfo.PathName, cityData, false);
                    if (roadFileInfo != null)
                    {
                        cityData.RoadFileInfo = roadFileInfo;
                    }
                }
                if (cityData.RoadFileInfo.LoadStatus == 1)
                {
                    showRoadFile(cityData, terminalMapInfo, rect, false, isMatchGrid);
                }
            }
            if (terminalMapInfo.DisplayInfo.IsShowAdas && cityData.AdasFileTag && cityData.AdasFileInfo != null)
            {
                if (cityData.AdasFileInfo.LoadStatus == 0)
                {
                    AdasFileInfo adasFileInfo = TerminalMapTool.GetAdasFileInfo(cityData.AdasFileInfo.PathName, cityData, false);
                    if (adasFileInfo != null)
                    {
                        cityData.AdasFileInfo = adasFileInfo;
                    }
                }
                if (cityData.AdasFileInfo.LoadStatus == 1)
                {
                    showAdasFile(cityData, terminalMapInfo, rect, isMatchGrid);
                }
            }
        }
        private void ShowCityDataOverlay(TerminalMapLib.CityDataInfo cityData, TerminalMapLib.TerminalMapInfo terminalMapInfo)
        {
            ShowCityDataOverlay(cityData, terminalMapInfo, RectLatLng.Empty, false);
        }

        /// <summary>
        /// 判断点是否在多边形内
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool IsPointInRect(RectLatLng rect, PointLatLng p)
        {
            if (rect == RectLatLng.Empty || p == PointLatLng.Empty)
            {
                return false;
            }
            return p.Lat > rect.Bottom && p.Lat < rect.Top && p.Lng > rect.Left && p.Lng < rect.Right;
        }

        private void showAdasFile(CityDataInfo cityDataInfo, TerminalMapInfo terminalMapInfo, RectLatLng rect, bool isMatchGrid)
        {
            AdasFileInfo adasFileInfo = cityDataInfo.AdasFileInfo;
            if (adasFileInfo == null || adasFileInfo.AdasGridInfoList == null || adasFileInfo.AdasGridInfoList.Count == 0 || cityDataInfo.CityDataOverlay == null)
            {
                return;
            }
            List<GMarkerGoogle> GMarkerGoogleList = new List<GMarkerGoogle>();
            List<GMapDirectionMarker> GMapDirectionMarkerList = new List<GMapDirectionMarker>();

            foreach (AdasGridInfo gridInfo in adasFileInfo.AdasGridInfoList)
            {
                // 判断是否与城市边框相交，当rect == null 时表示显示该城市所有数据
                if (rect != RectLatLng.Empty && !IsRectIntersect(rect, cityDataInfo.City_minlon, cityDataInfo.City_maxlon, cityDataInfo.City_minlat, cityDataInfo.City_maxlat))
                {
                    continue;
                }
                // 判断矩形与网格边框是否相交
                if (rect != RectLatLng.Empty && isMatchGrid && !IsRectIntersect(rect, gridInfo.MinLon, gridInfo.MaxLon, gridInfo.MinLat, gridInfo.MaxLat))
                {
                    continue;
                }
                foreach (var item in gridInfo.AdasPointInfoList)
                {
                    if (item.Ptype < terminalMapInfo.DisplayInfo.AdasShowTag.Length && terminalMapInfo.DisplayInfo.AdasShowTag[item.Ptype])
                    {
                        PointLatLng p = PointInDiffCoord.GetPointInCoordType(item.Lat, item.Lon, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);

                        // 判断是否在矩形框外
                        if (rect != RectLatLng.Empty && !isMatchGrid && !IsPointInRect(rect, p))
                        {
                            continue;
                        }
                        if (item.Ptype == 0)
                        {
                            GMapPointMarker marker = new GMapPointMarker(p);
                            double slope = (item.Slope - 511) / 10.0;
                            if (slope < -3)
                            {
                                marker.FillBrush = terminalMapInfo.DisplayInfo.AdasSlopeDefaultBrush_FastDown;
                                marker.DrawPen = terminalMapInfo.DisplayInfo.AdasSlopeDefaultPen_FastDown;
                                marker.R = terminalMapInfo.DisplayInfo.AdasSlopeDefaultR;
                            }
                            else if (slope < -1)
                            {
                                marker.FillBrush = terminalMapInfo.DisplayInfo.AdasSlopeDefaultBrush_SlowDown;
                                marker.DrawPen = terminalMapInfo.DisplayInfo.AdasSlopeDefaultPen_SlowDown;
                                marker.R = terminalMapInfo.DisplayInfo.AdasSlopeDefaultR;
                            }
                            else if (slope < 0)
                            {
                                marker.FillBrush = terminalMapInfo.DisplayInfo.AdasSlopeDefaultBrush_FlatDown;
                                marker.DrawPen = terminalMapInfo.DisplayInfo.AdasSlopeDefaultPen_FlatDown;
                                marker.R = terminalMapInfo.DisplayInfo.AdasSlopeDefaultR;
                            }
                            else if (slope < 1)
                            {
                                marker.FillBrush = terminalMapInfo.DisplayInfo.AdasSlopeDefaultBrush_FlatUp;
                                marker.DrawPen = terminalMapInfo.DisplayInfo.AdasSlopeDefaultPen_FlatUp;
                                marker.R = terminalMapInfo.DisplayInfo.AdasSlopeDefaultR;
                            }
                            else if (slope < 3)
                            {
                                marker.FillBrush = terminalMapInfo.DisplayInfo.AdasSlopeDefaultBrush_SlowUp;
                                marker.DrawPen = terminalMapInfo.DisplayInfo.AdasSlopeDefaultPen_SlowUp;
                                marker.R = terminalMapInfo.DisplayInfo.AdasSlopeDefaultR;
                            }
                            else
                            {
                                marker.FillBrush = terminalMapInfo.DisplayInfo.AdasSlopeDefaultBrush_FastUp;
                                marker.DrawPen = terminalMapInfo.DisplayInfo.AdasSlopeDefaultPen_FastUp;
                                marker.R = terminalMapInfo.DisplayInfo.AdasSlopeDefaultR;
                            }
                            cityDataInfo.CityDataOverlay.Markers.Add(marker);
                        }
                        else
                        {
                            if (terminalMapInfo.DisplayInfo.AdasDisplayType == DisplayType.STANDARD)
                            {
                                GMarkerGoogle marker;
                                if (item.Ptype == 34 || item.Ptype == 35 || item.Ptype == 36 || item.Ptype == 37)
                                {
                                    marker = new GMarkerGoogle(p, GMarkerGoogleType.red);
                                }
                                else if (item.Ptype > 37)
                                {
                                    marker = new GMarkerGoogle(p, GMarkerGoogleType.orange);
                                }
                                else
                                {
                                    marker = new GMarkerGoogle(p, GMarkerGoogleType.blue);
                                }
                                marker.ToolTipText = item.AttributeStr;
                                //cityDataInfo.CityDataOverlay.Markers.Add(marker);
                                GMarkerGoogleList.Add(marker);
                            }
                            else if (terminalMapInfo.DisplayInfo.AdasDisplayType == DisplayType.ARROW)
                            {
                                GMapDirectionMarker marker;
                                if (item.Ptype == 34 || item.Ptype == 35 || item.Ptype == 36 || item.Ptype == 37)
                                {
                                    marker = new GMapDirectionMarker(p, Properties.Resources.camera_up_24_red, (float)item.Speech - 180);
                                }
                                else if (item.Ptype > 37)
                                {
                                    marker = new GMapDirectionMarker(p, Properties.Resources.camera_up_24_orange, (float)item.Speech - 180);
                                }
                                else
                                {
                                    marker = new GMapDirectionMarker(p, Properties.Resources.camera_up_24_blue, (float)item.Speech - 180);
                                }
                                marker.ToolTipText = item.AttributeStr;
                                GMapDirectionMarkerList.Add(marker);
                            }
                            else
                            {
                                GMapPointMarker marker = new GMapPointMarker(p);
                                marker.FillBrush = terminalMapInfo.DisplayInfo.AdasBrush;
                                marker.DrawPen = terminalMapInfo.DisplayInfo.AdasPen;
                                marker.R = terminalMapInfo.DisplayInfo.AdasR;
                                cityDataInfo.CityDataOverlay.Markers.Add(marker);
                            }
                            GMapTextMarker textMarker = new GMapTextMarker(p, "" + item.Ptype, 0.5);
                            cityDataInfo.CityDataOverlay.Markers.Add(textMarker);
                        }

                    }
                }
            }
            
            if (GMarkerGoogleList != null && GMarkerGoogleList.Count > 0)
            {
                foreach (var item in GMarkerGoogleList)
                {
                    cityDataInfo.CityDataOverlay.Markers.Add(item);
                }
            }
            if (GMapDirectionMarkerList != null && GMapDirectionMarkerList.Count > 0)
            {
                foreach (var item in GMapDirectionMarkerList)
                {
                    cityDataInfo.CityDataOverlay.Markers.Add(item);
                }
            }
        }

        /// <summary>
        /// 判断两个矩形是否相交
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="minlon"></param>
        /// <param name="maxlon"></param>
        /// <param name="minlat"></param>
        /// <param name="maxlat"></param>
        /// <returns></returns>
        private bool IsRectIntersect(RectLatLng rect, double minlon, double maxlon, double minlat, double maxlat){
            bool nonIntersect = (rect.Right < minlon) ||
                    (rect.Left > maxlon) ||
                    (rect.Bottom > maxlat) ||
                    (rect.Top < minlat);
            return !nonIntersect;
        }

        private void showRoadFile(CityDataInfo cityDataInfo, TerminalMapInfo terminalMapInfo, RectLatLng rect, bool isMatchLoad, bool isMatchGrid)
        {
            RoadFileInfo roadFileInfo = cityDataInfo.RoadFileInfo;
            if (roadFileInfo == null || roadFileInfo.RoadGridInfoList == null || roadFileInfo.RoadGridInfoList.Count == 0 || cityDataInfo.CityDataOverlay == null)
            {
                return;
            }
            CoordType type = curMapProviderInfoArray[curMapProviderInfoIdx].CoordType;
            foreach (RoadGridInfo gridInfo in roadFileInfo.RoadGridInfoList)
            {
                // 判断是否与城市边框相交，当rect == null 时表示显示该城市所有数据
                if (rect != RectLatLng.Empty && !IsRectIntersect(rect, cityDataInfo.City_minlon, cityDataInfo.City_maxlon, cityDataInfo.City_minlat, cityDataInfo.City_maxlat))
                {
                    continue;
                }
                    // 判断矩形与网格边框是否相交
                if (rect != RectLatLng.Empty && isMatchGrid && !IsRectIntersect(rect, gridInfo.MinLon, gridInfo.MaxLon, gridInfo.MinLat, gridInfo.MaxLat))
                {
                    continue;
                }
                List<RoadSectionInfo> tempSections = new List<RoadSectionInfo>();
                foreach (var item in gridInfo.RoadSectionInfoList)
                {
                    if (item.Point_list == null || item.Point_list.Count < 2)
                    {
                        continue;
                    }

                    // 判断矩形是否相交
                    if (rect != RectLatLng.Empty && !isMatchGrid && !IsRectIntersect(rect, item.Ui8MinLon, item.Ui8MaxLon, item.Ui8MinLat, item.Ui8MaxLat))
                    {
                        continue;
                    }

                    List<PointLatLng> pList = PointInDiffCoord.GetPointListInCoordType(item.Point_list, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                    //GMapRoute mapRoute = new GMapRoute(pList, item.AttributeStr);
                    GMapRouteBezier mapRoute = new GMapRouteBezier(pList, item.AttributeStr);
                    if (item.EmFCLevel - 1 >= terminalMapInfo.DisplayInfo.RoadShowTag.Length || !terminalMapInfo.DisplayInfo.RoadShowTag[item.EmFCLevel - 1])
                    {
                        continue;
                    }
                    if (isMatchLoad)
                    {
                        tempSections.Add(item);
                    }
                    else
                    {
                        if (terminalMapInfo.DisplayInfo.RoadDisplayType == DisplayType.STANDARD)
                        {
                            if (item.Ui8Nr == 1)
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPenDefault1;
                            }
                            else if (item.Ui8Nr == 2)
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPenDefault2;
                            }
                            else if (item.Ui8Nr == 3)
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPenDefault3;
                            }
                            else if (item.Ui8Nr == 4)
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPenDefault4;
                            }
                            else
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPenDefault5;
                            }
                        }
                        else if (terminalMapInfo.DisplayInfo.RoadDisplayType == DisplayType.CUSTOM)
                        {
                            if (item.EmFCLevel == 1)
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPen1;
                            }
                            else if (item.EmFCLevel == 2)
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPen2;
                            }
                            else if (item.EmFCLevel == 3)
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPen3;
                            }
                            else if (item.EmFCLevel == 4)
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPen4;
                            }
                            else
                            {
                                mapRoute.Stroke = terminalMapInfo.DisplayInfo.RoadPen5;
                            }
                        }
                        mapRoute.IsHitTestVisible = true;
                        cityDataInfo.CityDataOverlay.Routes.Add(mapRoute);
                    }
                }
                if (isMatchLoad)
                {
                    sltRoadSectionInfos.AddRange(tempSections);
                }
            }
        }

        private void showCityBorder(CityDataInfo cityDataInfo, GMapOverlay overlay, TerminalMapInfo terminalMapInfo)
        {
            if (cityDataInfo == null || cityDataInfo.Block_list == null || cityDataInfo.Block_list.Count == 0 || overlay == null)
            {
                return;
            }
            foreach (var item in cityDataInfo.Block_list)
            {
                List<PointLatLng> pList = PointInDiffCoord.GetPointListInCoordType(item, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                GMapAreaPolygon areaPolygon = new GMapAreaPolygon(pList, cityDataInfo.City_name);
                overlay.Polygons.Add(areaPolygon);
                RectLatLng rect = GMapUtil.PolygonUtils.GetRegionMaxRect(pList);
                GMapTextMarker textMarker = new GMapTextMarker(rect.LocationMiddle, cityDataInfo.City_name + "\n" + cityDataInfo.City_code);
                overlay.Markers.Add(textMarker);
            }
        }

        void loadCityIndexWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            terminalMapInfo = null;
            string path = (string)e.Argument;
            string pathName = null;
            int releaseVersion = 0;
            int internalVersion = 0;
            int structVersion = 0;
            int number = 0;
            List<CityDataInfo> cityDataInfoList = TerminalMapTool.loadTerminalMap(path, out pathName, out releaseVersion, out internalVersion, out structVersion, out number);
            if (cityDataInfoList != null && cityDataInfoList.Count > 0)
            {
                cityDataInfoList.Sort();
                terminalMapInfo = new TerminalMapInfo();
                terminalMapInfo.PathName = pathName;
                terminalMapInfo.CityIndexReleaseVersion = releaseVersion;
                terminalMapInfo.CityIndexInternalVersion = internalVersion;
                terminalMapInfo.CityIndexStructVersion = structVersion;
                terminalMapInfo.CityCount = number;
                terminalMapInfo.CityDataList = cityDataInfoList;
                terminalMapInfo.TerminalMapOverlay = new GMapOverlay(pathName);
                terminalMapInfo.DisplayInfo = new TerminalMapDisplayInfo();
            }
            else
            {
                MyMessageBox.ShowErrorMessage("加载地图失败");
            }
        }

        private void buttonDelectMapFile_Click(object sender, EventArgs e)
        {
            RemoveRootNode();
        }
        private void 修改显示信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltTerminalMapInfo != null && sltTerminalMapInfo.DisplayInfo != null)
            {
                Form_display_info display_info = new Form_display_info(sltTerminalMapInfo.DisplayInfo);
                DialogResult diaResult = display_info.ShowDialog();
                if (diaResult == System.Windows.Forms.DialogResult.OK)
                {
                    TerminalMapDisplayInfo displayInfo = display_info.displayInfo;
                    if (display_info != null)
                    {
                        sltTerminalMapInfo.DisplayInfo = displayInfo;
                    }
                }
            }
        }

        private void 设置为地图匹配测试底图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltRootNode != null)
            {
                sltMatchTestRootNode = sltRootNode;
            }
        }

        private void 显示当前区域地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltRootNode != null)
            {
                RectLatLng rect = (RectLatLng)mapControl.ViewArea;
                foreach (TreeNode item in sltRootNode.Nodes)
                {
                    if (item.Text.Contains("000000"))
                    {
                        continue;
                    }
                    else
                    {
                        TerminalMapInfo terminalMapInfo = item.Parent.Tag as TerminalMapInfo;
                        CityDataInfo cityData = item.Tag as CityDataInfo;
                        if (IsRectIntersect(rect, cityData.City_minlon, cityData.City_maxlon, cityData.City_minlat, cityData.City_maxlat))
                        {
                            CleanCityDataOverlay(cityData, false);
                            ShowCityDataOverlay(cityData, terminalMapInfo, rect, false);
                        }
                    }
                }
            }
        }

        private void 显示当前区域城市地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltRootNode != null)
            {
                RectLatLng rect = (RectLatLng)mapControl.ViewArea;
                foreach (TreeNode item in sltRootNode.Nodes)
                {
                    if (item.Text.Contains("000000"))
                    {
                        continue;
                    }
                    else
                    {
                        TerminalMapLib.TerminalMapInfo terminalMapInfo = item.Parent.Tag as TerminalMapLib.TerminalMapInfo;
                        TerminalMapLib.CityDataInfo cityData = item.Tag as TerminalMapLib.CityDataInfo;
                        if (IsRectIntersect(rect, cityData.City_minlon, cityData.City_maxlon, cityData.City_minlat, cityData.City_maxlat))
                        {
                            CleanCityDataOverlay(cityData, false);
                            ShowCityDataOverlay(cityData, terminalMapInfo);
                        }
                    }
                }
            }
        }

        private void 清除当前区域城市地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltRootNode != null)
            {
                RectLatLng rect = (RectLatLng)mapControl.ViewArea;
                foreach (TreeNode item in sltRootNode.Nodes)
                {
                    if (item.Text.Contains("000000"))
                    {
                        continue;
                    }
                    else
                    {
                        TerminalMapInfo terminalMapInfo = item.Parent.Tag as TerminalMapInfo;
                        CityDataInfo cityData = item.Tag as CityDataInfo;
                        bool nonIntersect = (rect.Right < cityData.City_minlon) ||
                                         (rect.Left > cityData.City_maxlon) ||
                                         (rect.Bottom > cityData.City_maxlat) ||
                                         (rect.Top < cityData.City_minlat);
                        if (!nonIntersect)
                        {
                            CleanCityDataOverlay(cityData, false);
                        }
                    }
                }
            }
        }

        private void 清除所有显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanAllTMapShow();
        }

        private void cleanAllTMapShow()
        {
            if (sltRootNode != null)
            {
                foreach (TreeNode item in sltRootNode.Nodes)
                {
                    if (item.Text.Contains("000000"))
                    {
                        TerminalMapInfo terminalMapInfo = item.Tag as TerminalMapInfo;
                        terminalMapInfo.TerminalMapOverlay.Polygons.Clear();
                    }
                    else
                    {
                        CityDataInfo cityData = item.Tag as CityDataInfo;
                        CleanCityDataOverlay(cityData, false);
                    }
                }
            }
        }

        private void 删除地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveRootNode();
        }

        private void toolStripMenuItem_缩放至城市_Click(object sender, EventArgs e)
        {
            zoomToCity(sltCityDataInfo);
        }

        private void zoomToCity(CityDataInfo cityDataInfo)
        {
            if (sltCityDataInfo != null)
            {
                List<PointLatLng> pList = new List<PointLatLng>();
                pList.Add(new PointLatLng(cityDataInfo.City_minlat, cityDataInfo.City_minlon));
                pList.Add(new PointLatLng(cityDataInfo.City_minlat, cityDataInfo.City_maxlon));
                pList.Add(new PointLatLng(cityDataInfo.City_maxlat, cityDataInfo.City_maxlon));
                pList.Add(new PointLatLng(cityDataInfo.City_maxlat, cityDataInfo.City_minlon));
                RectLatLng rect = GMapUtils.GetPointsMaxRect(pList);
                mapControl.SetZoomToFitRect(rect);
            }
        }

        private void toolStripMenuItem_显示城市数据_Click(object sender, EventArgs e)
        {
            if (sltCityDataInfo != null && sltCityTerminalMapInfo != null)
            {
                if (sltCityDataInfo.CityDataOverlay.Markers.Count > 0 || sltCityDataInfo.CityDataOverlay.Routes.Count > 0 || sltCityDataInfo.CityDataOverlay.Polygons.Count > 0)
                {
                    CleanCityDataOverlay(sltCityDataInfo, false);
                }
                ShowCityDataOverlay(sltCityDataInfo, sltCityTerminalMapInfo);
                zoomToCity(sltCityDataInfo);
            }
        }

        private void 清除城市显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltCityDataInfo != null)
            {
                if (sltCityDataInfo.CityDataOverlay.Markers.Count > 0 || sltCityDataInfo.CityDataOverlay.Routes.Count > 0 || sltCityDataInfo.CityDataOverlay.Polygons.Count > 0)
                {
                    CleanCityDataOverlay(sltCityDataInfo, false);
                }
            }
        }

        private void toolStripMenuItem_显示城市网格_Click(object sender, EventArgs e)
        {
            showCityGrid(sltCityDataInfo);
        }

        private void 显示当前网格地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sltRootNode != null)
            {
                RectLatLng rect = (RectLatLng)mapControl.ViewArea;
                foreach (TreeNode item in sltRootNode.Nodes)
                {
                    if (item.Text.Contains("000000"))
                    {
                        continue;
                    }
                    else
                    {
                        TerminalMapInfo terminalMapInfo = item.Parent.Tag as TerminalMapInfo;
                        CityDataInfo cityData = item.Tag as CityDataInfo;
                        if (IsRectIntersect(rect, cityData.City_minlon, cityData.City_maxlon, cityData.City_minlat, cityData.City_maxlat))
                        {
                            CleanCityDataOverlay(cityData, false);
                            ShowCityDataOverlay(cityData, terminalMapInfo, rect, true);
                        }
                    }
                }
            }
        }

        private void showCityGrid(CityDataInfo sltCityDataInfo)
        {
            cleanCityGrid();
            if (sltCityDataInfo == null)
            {
                return;
            }
            if (sltCityDataInfo.AdasFileInfo != null && sltCityDataInfo.AdasFileInfo.AdasGridInfoList != null && sltCityDataInfo.AdasFileInfo.AdasGridInfoList.Count > 0)
            {
                foreach (var item in sltCityDataInfo.AdasFileInfo.AdasGridInfoList)
                {
                    List<PointLatLng> pList = new List<PointLatLng>();
                    pList.Add(new PointLatLng(item.MinLat, item.MinLon));
                    pList.Add(new PointLatLng(item.MinLat, item.MaxLon));
                    pList.Add(new PointLatLng(item.MaxLat, item.MaxLon));
                    pList.Add(new PointLatLng(item.MaxLat, item.MinLon));
                    GMapAreaPolygon areaPolygon = new GMapAreaPolygon(pList, "");
                    gridOverlay.Polygons.Add(areaPolygon);
                    RectLatLng rect = GMapUtil.PolygonUtils.GetRegionMaxRect(pList);
                    GMapTextMarker textMarker = new GMapTextMarker(rect.LocationMiddle, "" + item.GridId);
                    gridOverlay.Markers.Add(textMarker);
                }
                return;
            }
            if (sltCityDataInfo.RoadFileInfo != null && sltCityDataInfo.RoadFileInfo.RoadGridInfoList != null && sltCityDataInfo.RoadFileInfo.RoadGridInfoList.Count > 0)
            {
                foreach (var item in sltCityDataInfo.RoadFileInfo.RoadGridInfoList)
                {
                    List<PointLatLng> pList = new List<PointLatLng>();
                    pList.Add(new PointLatLng(item.MinLat, item.MinLon));
                    pList.Add(new PointLatLng(item.MinLat, item.MaxLon));
                    pList.Add(new PointLatLng(item.MaxLat, item.MaxLon));
                    pList.Add(new PointLatLng(item.MaxLat, item.MinLon));
                    GMapAreaPolygon areaPolygon = new GMapAreaPolygon(pList, "");
                    gridOverlay.Polygons.Add(areaPolygon);
                    RectLatLng rect = GMapUtil.PolygonUtils.GetRegionMaxRect(pList);
                    GMapTextMarker textMarker = new GMapTextMarker(rect.LocationMiddle, "" + item.GridId);
                    gridOverlay.Markers.Add(textMarker);
                }
                return;
            }
        }

        private void 清除网格显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cleanCityGrid();
        }

        private void cleanCityGrid()
        {
            if (gridOverlay.Polygons.Count > 0 || gridOverlay.Markers.Count > 0)
            {
                gridOverlay.Polygons.Clear();
                gridOverlay.Markers.Clear();
            }
        }

        private void RemoveRootNode()
        {
            if (sltRootNode != null)
            {
                foreach (TreeNode item in sltRootNode.Nodes)
                {
                    if (item.Text.Contains("000000"))
                    {
                        TerminalMapInfo terminalMapInfo = item.Tag as TerminalMapInfo;
                        terminalMapInfo.TerminalMapOverlay.Polygons.Clear();
                        mapControl.Overlays.Remove(terminalMapInfo.TerminalMapOverlay);
                    }
                    else
                    {
                        CityDataInfo cityData = item.Tag as CityDataInfo;
                        CleanCityDataOverlay(cityData, true);
                    }
                }
                sltRootNode.Remove();
            }
            else
            {
                MyMessageBox.ShowTipMessage("请选择要删除的节点");
            }
        }

        #endregion

        #region 历史轨迹模拟/实时轨迹接收

        private HistoryGeoOverlay historyGeoOverlay = new HistoryGeoOverlay();
        private RealtimeGeoOverlay realtimeGeoOverlay = new RealtimeGeoOverlay();
        private GMapOverlay matchTestOverlay = new GMapOverlay("matchTestOverlay");
        private GMapOverlay sltHistoryPointOverlay = new GMapOverlay("sltHistoryPointOverlay");
        private enum RealtimeType
        {
            串口接收Nmea, 串口接收Text1, 串口接收Match
        }
        private DataTable realtimeTypeDataTable = new DataTable();
        private RealtimeType sltRealtimeType;

        private enum SimulateType
        {
            History, Realtime
        }
        private SimulateType sltSimulateType;

        private void InitHistoryLayerUI()
        {
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = false;
            this.buttonBack.Enabled = false;
            this.buttonForward.Enabled = false;
            this.buttonPause.Enabled = false;
            this.buttonResume.Enabled = false;
            this.buttonSetTimerInterval.Enabled = false;
            this.checkBoxFollow.Enabled = false;
            this.cb_simulate_type.SelectedIndex = 0;
            realtimeTypeDataTable.Columns.Add("Text", typeof(string));
            realtimeTypeDataTable.Columns.Add("Type", typeof(RealtimeType));
            realtimeTypeDataTable.Rows.Add("串口接收:Nmea", RealtimeType.串口接收Nmea);
            realtimeTypeDataTable.Rows.Add("串口接收:lon,lat,dir,speed", RealtimeType.串口接收Text1);
            realtimeTypeDataTable.Rows.Add("串口接收:匹配测试", RealtimeType.串口接收Match);
            this.cb_simulate_src.DataSource = realtimeTypeDataTable;
            this.cb_simulate_src.DisplayMember = "Text";   // Text，即显式的文本
            this.cb_simulate_src.ValueMember = "Type";    // Value，即实际的值
        }

        private List<HistoryGeoData> geoDataList = new List<HistoryGeoData>();

        private List<HistoryGeoData> GetHisTestData()
        {
            List<HistoryGeoData> dataList = new List<HistoryGeoData>();
            if (simulateGpsRoute != null && simulateGpsRoute.GpsRouteInfoList != null)
            {
                GpsRoutePoint[] grps = simulateGpsRoute.GpsRouteInfoList.ToArray();
                for (int i = 0; i < grps.Length; ++i)
                {
                    HistoryGeoData data = new HistoryGeoData();
                    data.ID = i;
                    data.PhoneNumber = "" + i;
                    data.X = grps[i].Longitude;
                    data.Y = grps[i].Latitude;
                    data.Time = DateTime.Now;

                    dataList.Add(data);
                }
            }
            return dataList;
        }

        void checkBoxFollow_CheckedChanged(object sender, EventArgs e)
        {
            if (historyGeoOverlay != null)
            {
                historyGeoOverlay.Follow = this.checkBoxFollow.Checked;
            }
            if (realtimeGeoOverlay != null)
            {
                realtimeGeoOverlay.Follow = this.checkBoxFollow.Checked;
            }
        }

        private void checkBoxRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (historyGeoOverlay != null)
            {
                historyGeoOverlay.Repeat = this.checkBoxRepeat.Checked;
            }
        }

        private void cb_simulate_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_simulate_type.SelectedIndex == 0)
            {
                sltSimulateType = SimulateType.History;
                this.comboBoxTimeSpan.Enabled = true;
                this.lb_simulate_src.Text = "模拟轨迹:";
                this.tb_simulate_src.Visible = true;
                this.cb_simulate_src.Visible = false;
            }
            else if (cb_simulate_type.SelectedIndex == 1)
            {
                sltSimulateType = SimulateType.Realtime;
                this.comboBoxTimeSpan.Enabled = false;
                this.lb_simulate_src.Text = "接收数据:";
                this.tb_simulate_src.Visible = false;
                this.cb_simulate_src.Visible = true;
            }
            else
            {
                MyMessageBox.ShowTipMessage("该功能暂未实现");
                return;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (sltSimulateType == SimulateType.History)
            {
                if (simulateGpsRoute == null || simulateGpsRoute.GpsRouteInfoList == null || simulateGpsRoute.GpsRouteInfoList.Count <= 0)
                {
                    MyMessageBox.ShowTipMessage("历史轨迹为空");
                    return;
                }
                if (historyGeoOverlay != null)
                {
                    int start_idx;
                    int end_idx;
                    try
                    {
                        start_idx = int.Parse(tb_start_idx.Text.ToString().Trim());
                        end_idx = int.Parse(tb_end_idx.Text.ToString().Trim());
                        if (start_idx <= 0)
                        {
                            start_idx = 0;
                        }
                        if (end_idx <= 0)
                        {
                            end_idx = simulateGpsRoute.GpsRouteInfoList.Count - 1;
                        }
                        if (start_idx < 0 || end_idx < 0 || start_idx >= end_idx
                            || start_idx > simulateGpsRoute.GpsRouteInfoList.Count - 1
                            || end_idx > simulateGpsRoute.GpsRouteInfoList.Count - 1)
                        {
                            DialogResult ret =  MessageBox.Show("设置的起点终点下标错误，是否使用完整轨迹？", "提醒", MessageBoxButtons.OKCancel);
                            if (ret == System.Windows.Forms.DialogResult.OK)
                            {
                                start_idx = -1;
                                end_idx = -1;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        DialogResult ret = MessageBox.Show("解析起点终点下标错误，是否使用完整轨迹？", "提醒", MessageBoxButtons.OKCancel);
                        if (ret == System.Windows.Forms.DialogResult.OK)
                        {
                            start_idx = -1;
                            end_idx = -1;
                        }
                        else
                        {
                            return;
                        }
                    }
                    mapControl.Overlays.Add(historyGeoOverlay);
                    historyGeoOverlay.Start(simulateGpsRoute, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType, start_idx, end_idx);
                }
                else
                {
                    MyMessageBox.ShowConformMessage("Overlay不能为空");
                    return;
                }
            }
            else if (sltSimulateType == SimulateType.Realtime)
            {
                if (realtimeGeoOverlay != null)
                {
                    mapControl.Overlays.Add(realtimeGeoOverlay);
                    realtimeGeoOverlay.Start(serialCoordType, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                    if (sltRealtimeType == RealtimeType.串口接收Match)
                    {
                        mapControl.Overlays.Add(matchTestOverlay);
                    }
                }
                else
                {
                    MyMessageBox.ShowConformMessage("Overlay不能为空");
                    return;
                }
            }
            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = true;
            if (sltSimulateType == SimulateType.History)
            {
                this.buttonBack.Enabled = true;
                this.buttonForward.Enabled = true;
            }
            this.buttonPause.Enabled = true;
            this.buttonSetTimerInterval.Enabled = true;
            this.checkBoxFollow.Enabled = true;
            this.cb_simulate_type.Enabled = false;
            this.tb_start_idx.Enabled = false;
            this.tb_end_idx.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = false;
            this.buttonBack.Enabled = false;
            this.buttonForward.Enabled = false;
            this.buttonPause.Enabled = false;
            this.buttonResume.Enabled = false;
            this.buttonSetTimerInterval.Enabled = false;
            this.checkBoxFollow.Enabled = false;
            this.cb_simulate_type.Enabled = true;
            this.tb_start_idx.Enabled = true;
            this.tb_end_idx.Enabled = true;
            if (sltSimulateType == SimulateType.History)
            {
                if (historyGeoOverlay != null)
                {
                    historyGeoOverlay.Stop();
                    mapControl.Overlays.Remove(historyGeoOverlay);
                }
            }
            else if (sltSimulateType == SimulateType.Realtime)
            {
                if (realtimeGeoOverlay != null)
                {
                    realtimeGeoOverlay.Stop();
                    mapControl.Overlays.Remove(realtimeGeoOverlay);
                }
            } 
            if (sltRealtimeType == RealtimeType.串口接收Match)
            {
                mapControl.Overlays.Remove(matchTestOverlay);
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            this.buttonPause.Enabled = false;
            this.buttonSetTimerInterval.Enabled = false;
            this.checkBoxFollow.Enabled = false;
            this.buttonResume.Enabled = true;
            if (sltSimulateType == SimulateType.History)
            {
                if (historyGeoOverlay != null)
                {
                    historyGeoOverlay.Pause();
                }
            }
            else if (sltSimulateType == SimulateType.Realtime)
            {
                if (realtimeGeoOverlay != null)
                {
                    realtimeGeoOverlay.Pause();
                }
            }
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            this.buttonResume.Enabled = false;
            this.buttonPause.Enabled = true;
            this.buttonSetTimerInterval.Enabled = true;
            this.checkBoxFollow.Enabled = true;
            if (sltSimulateType == SimulateType.History)
            {
                if (historyGeoOverlay != null)
                {
                    historyGeoOverlay.Resume();
                }
            }
            else if (sltSimulateType == SimulateType.Realtime)
            {
                if (realtimeGeoOverlay != null)
                {
                    realtimeGeoOverlay.Resume();
                }
            }
        }

        private void buttonSetTimerInterval_Click(object sender, EventArgs e)
        {
            int index = this.comboBoxTimeSpan.SelectedIndex;

            int span = 1000;

            switch (index)
            {
                case 0:
                    span = 100;
                    break;
                case 1:
                    span = 500;
                    break;
                case 2:
                    span = 1000;
                    break;
                case 3:
                    span = 2000;
                    break;
                case 4:
                    span = 3000;
                    break;
                case 5:
                    span = 5000;
                    break;
                case 6:
                    span = 10000;
                    break;
                case 7:
                    span = 20000;
                    break;
                case 8:
                    span = 30000;
                    break;
                case 9:
                    span = 60000;
                    break;
                default:
                    break;
            }

            if (historyGeoOverlay != null)
            {
                historyGeoOverlay.SetTimerInterval(span);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (sltSimulateType == SimulateType.History)
            {
                if (historyGeoOverlay != null)
                {
                    historyGeoOverlay.Back();
                }
            }
            else if (sltSimulateType == SimulateType.Realtime)
            {
                MyMessageBox.ShowTipMessage("实时模式不支持快进/快退");
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (sltSimulateType == SimulateType.History)
            {
                if (historyGeoOverlay != null)
                {
                    historyGeoOverlay.Forward();
                }
            }
            else if (sltSimulateType == SimulateType.Realtime)
            {
                MyMessageBox.ShowTipMessage("实时模式不支持快进/快退");
            }
        }

        private void dataGridViewGpsRoute_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (simulateGpsRoute == null)
            {
                return;
            }
            try
            {
                mapControl.Overlays.Remove(sltHistoryPointOverlay);
                mapControl.Overlays.Add(sltHistoryPointOverlay);
                double lon = Double.Parse(dataGridViewGpsRoute.Rows[e.RowIndex].Cells[1].Value.ToString());
                double lat = Double.Parse(dataGridViewGpsRoute.Rows[e.RowIndex].Cells[2].Value.ToString());
                double dir = Double.Parse(dataGridViewGpsRoute.Rows[e.RowIndex].Cells[3].Value.ToString());
                PointLatLng p = PointInDiffCoord.GetPointInCoordType(lat, lon, simulateGpsRoute.CoordType, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                sltHistoryPointOverlay.Markers.Clear();
                GMapDirectionMarker dm = new GMapDirectionMarker(p, Properties.Resources.arrow_up_32_purple, (float)dir);
                sltHistoryPointOverlay.Markers.Add(dm);
                mapControl.Position = p;
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 串口接收设置

        SerialPort sp = null;   //声明串口类
        bool isOpen = false;    //打开串口标志
        bool isSetProperty = false; //属性设置标志
        CoordType serialCoordType;

        private void InitSerialUI(){
            cbxBaudRate.SelectedIndex = 9;
            cbxStopBits.SelectedIndex = 1;
            cbxParitv.SelectedIndex = 0;
            cbxDataBits.SelectedIndex = 0;
            cb_serial_CoordType.SelectedIndex = 0;
        }

        private void cb_simulate_src_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sltRealtimeType = (RealtimeType)cb_simulate_src.SelectedValue.GetType();
            //e.GetType();
            sltRealtimeType = (RealtimeType) realtimeTypeDataTable.Rows[cb_simulate_src.SelectedIndex][1];
        }

        private void cb_serial_CoordType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_serial_CoordType.Text.Equals("WGS84"))
            {
                serialCoordType = CoordType.WGS84;
            }
            else if (cb_serial_CoordType.Text.Equals("GCJ02"))
            {
                serialCoordType = CoordType.GCJ02;
            }
            else if (cb_serial_CoordType.Text.Equals("BD09"))
            {
                serialCoordType = CoordType.BD09;
            }
            else
            {
                serialCoordType = CoordType.WGS84;
            }
            if (realtimeGeoOverlay != null)
            {
                realtimeGeoOverlay.SrcCoordType = serialCoordType;
            }
        }

        private void CloseSerial()
        {
            if (isOpen)
            {
                sp.Close();
            }
        }

        private void btnCheckCOM_Click(object sender, EventArgs e)
        {
            if (checkComNum())
            {
                cbxCOMPort.SelectedIndex = 0;//使ListBox显示第一个添加的索引
            }
            else
            {
                MessageBox.Show("没有找到可用串口！", "错误提示");
            }
        }

        private bool checkComNum()
        {
            bool comExistence = false;  //是否有可用的串口
            cbxCOMPort.Items.Clear();   //清除当前串口号中的所有串口名称
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    SerialPort sp = new SerialPort("COM" + (i + 1).ToString());
                    sp.Open();
                    cbxCOMPort.Items.Add("COM" + (i + 1).ToString());
                    comExistence = true;
                    sp.Close();
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return comExistence;
        }

        private bool CheckPortSetting()     //串口是否设置
        {
            if (cbxCOMPort.Text.Trim() == "") return false;
            if (cbxBaudRate.Text.Trim() == "") return false;
            if (cbxDataBits.Text.Trim() == "") return false;
            if (cbxParitv.Text.Trim() == "") return false;
            if (cbxStopBits.Text.Trim() == "") return false;
            return true;
        }

        private void SetPortProPerty()      //设置串口属性
        {
            sp = new SerialPort();

            sp.PortName = cbxCOMPort.Text.Trim();       //串口名

            sp.BaudRate = Convert.ToInt32(cbxBaudRate.Text.Trim());//波特率

            float f = Convert.ToSingle(cbxStopBits.Text.Trim());//停止位
            if (f == 0)
            {
                sp.StopBits = StopBits.None;
            }
            else if (f == 1.5)
            {
                sp.StopBits = StopBits.OnePointFive;
            }
            else if (f == 1)
            {
                sp.StopBits = StopBits.One;
            }
            else if (f == 2)
            {
                sp.StopBits = StopBits.Two;
            }
            else
            {
                sp.StopBits = StopBits.One;
            }

            sp.DataBits = Convert.ToInt16(cbxDataBits.Text.Trim());//数据位

            string s = cbxParitv.Text.Trim();       //校验位
            if (s.CompareTo("无") == 0)
            {
                sp.Parity = Parity.None;
            }
            else if (s.CompareTo("奇校验") == 0)
            {
                sp.Parity = Parity.Odd;
            }
            else if (s.CompareTo("偶校验") == 0)
            {
                sp.Parity = Parity.Even;
            }
            else
            {
                sp.Parity = Parity.None;
            }

            sp.ReadTimeout = -1;         //设置超时读取时间
            sp.RtsEnable = true;

            //定义DataReceived事件，当串口收到数据后触发事件
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);

        }

        int count_recv = 0;
        int count_parse = 0;
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(10);     //延时10ms等待接收数据
            string line = sp.ReadLine();
            Console.WriteLine(line);
            count_recv++;
            if (lb_recv_count.InvokeRequired)
            {
                lb_recv_count.Invoke(new Action<int>(n => { this.lb_recv_count.Text = n.ToString(); }), count_recv);
            }

            GpsRoutePoint point = ParseGpsRoutePoint(line);
            if (point != null && realtimeGeoOverlay != null)
            {
                count_parse++;
                if (lb_parse_count.InvokeRequired)
                {
                    lb_parse_count.Invoke(new Action<int>(n => { this.lb_parse_count.Text = n.ToString(); }), count_parse);
                }
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<GpsRoutePoint>(p => { realtimeGeoOverlay.Update(p); }), point);
                }
            }
        }

        private String time;
        private double lat;
        private double lon;
        private double speed;
        private double dir;
        private double alt;
        private GpsRoutePoint ParseGpsRoutePoint(string line)
        {
            string[] arrs;
            try
            {
                if (sltRealtimeType == RealtimeType.串口接收Text1)
                {
                    arrs = line.Split(',');
                    if (arrs != null && arrs.Length >= 4)
                    {
                        double lon = Double.Parse(arrs[0].Trim());
                        double lat = Double.Parse(arrs[1].Trim());
                        double dir = Double.Parse(arrs[2].Trim());
                        double speed = Double.Parse(arrs[3].Trim());
                        GpsRoutePoint point = new GpsRoutePoint();
                        point.Longitude = lon;
                        point.Latitude = lat;
                        point.Direction = dir;
                        point.Speed = speed;
                        return point;
                    }
                }
                else if (sltRealtimeType == RealtimeType.串口接收Nmea)
                {
                    if (line.StartsWith("$GPRMC")) 
                    {
						arrs = line.Split(',');

						if ("".Equals(arrs[1]) || "".Equals(arrs[3]) || "".Equals(arrs[5]) || "".Equals(arrs[7]) || "".Equals(arrs[8])) {
							return null;
						}
						
						time = arrs[1];
						lat = getLat(arrs[3]);
						lon = getLon(arrs[5]);
						speed = Double.Parse(arrs[7]);
						dir = Double.Parse(arrs[8]);
                        GpsRoutePoint point = new GpsRoutePoint();
                        point.Longitude = lon;
                        point.Latitude = lat;
                        point.Direction = dir;
                        point.Speed = speed;
                        return point;
						
					}
					else if (line.StartsWith("$GNRMC")) 
                    {
						arrs = line.Split(',');

						if (arrs == null || arrs.Length < 9 || "".Equals(arrs[1]) || "".Equals(arrs[3]) || "".Equals(arrs[5]) || "".Equals(arrs[7])) {
							return null;
						}

						time = arrs[1];
						lat = getLat(arrs[3]);
						lon = getLon(arrs[5]);
						speed = Double.Parse(arrs[7]);
						if (!"".Equals(arrs[8])) {
							dir = Double.Parse(arrs[8]);
                        }
                        else
                        {
                            dir = 0;
                        }
                        GpsRoutePoint point = new GpsRoutePoint();
                        point.Longitude = lon;
                        point.Latitude = lat;
                        point.Direction = dir;
                        point.Speed = speed;
                        return point;

					}
					else if (line.StartsWith("$GNGGA")) 
                    {
						arrs = line.Split(',');

						if (arrs[9] != null && !arrs[9].Trim().Equals("")) {
							alt = Double.Parse(arrs[9]);
						}

					}
                }
                else if (sltRealtimeType == RealtimeType.串口接收Match)
                {
                    arrs = line.Split(',');
                    if (line.StartsWith("&Pos"))
                    {
                        this.BeginInvoke(new UpdateMatchRecv(HandleMatchRecvMsg), new object[] { line });
                        // &Pos,id,经度,纬度,方向,速度,匹配结果（-4:未知错误；-3:没道路；-2:匹配概率低； -1:参数异常，不进行匹配 0:未定位； 1:匹配成功）,搜索距离
                        if (arrs != null && arrs.Length >= 4)
                        {
                            int id = Int32.Parse(arrs[1].Trim());
                            double lon = Double.Parse(arrs[2].Trim());
                            double lat = Double.Parse(arrs[3].Trim());
                            double dir = Double.Parse(arrs[4].Trim());
                            double speed = Double.Parse(arrs[5].Trim());
                            int matchRet = Int32.Parse(arrs[6].Trim());
                            if (matchRet != 0)
                            {
                                GpsRoutePoint point = new GpsRoutePoint();
                                point.Longitude = lon;
                                point.Latitude = lat;
                                point.Direction = dir;
                                point.Speed = speed;
                                return point;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        private String getTimeStr(String timeStr)
        {

            int h = Int32.Parse(timeStr.Substring(0, 2));
            int m = Int32.Parse(timeStr.Substring(2, 4));
            int s = Int32.Parse(timeStr.Substring(4, 6));
            int S = Int32.Parse(timeStr.Substring(7, 9));
            return (h) + ":" + m + ":" + s + "." + S;
        }

        private double getLat(String latStr)
        {
            int d = Int32.Parse(latStr.Substring(0, 2));
            double m = Double.Parse(latStr.Substring(2, latStr.Length - 2));
            return d + (m / 60);
        }

        private double getLon(String lonStr)
        {
            int d = Int32.Parse(lonStr.Substring(0, 3));
            double m = Double.Parse(lonStr.Substring(3, lonStr.Length - 3));
            return d + (m / 60);
        }

        private void sendCom(String sd)      //发送数据
        {
            if (isOpen)
            {
                if (sd == null || sd == string.Empty)
                {
                    MessageBox.Show("要发送的数据错误!", "错误提示");
                    return;
                }
                try
                {
                    byte[] byteArray = System.Text.Encoding.Default.GetBytes(sd);
                    sp.Write(byteArray, 0, byteArray.Length);
                }
                catch (Exception)
                {
                    MessageBox.Show("发送数据时发生错误！", "错误提示");
                    return;
                }
            }
            else
            {
                MessageBox.Show("串口未打开", "错误提示");
                return;
            }
        }

        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            if (isOpen == false)
            {
                if (!CheckPortSetting())        //检测串口设置
                {
                    MessageBox.Show("串口未设置！", "错误提示");
                    return;
                }
                if (!isSetProperty)             //串口未设置则设置串口
                {
                    SetPortProPerty();
                    isSetProperty = true;
                }
                try
                {
                    sp.Open();
                    isOpen = true;
                    btnOpenCom.Text = "关闭串口";
                    //串口打开后则相关串口设置按钮便不可再用
                    cbxCOMPort.Enabled = false;
                    cbxBaudRate.Enabled = false;
                    cbxDataBits.Enabled = false;
                    cbxParitv.Enabled = false;
                    cbxStopBits.Enabled = false;
                }
                catch (Exception)
                {
                    //打开串口失败后，相应标志位取消
                    isSetProperty = false;
                    isOpen = false;
                    MessageBox.Show("串口无效或已被占用！", "错误提示");
                }
            }
            else
            {
                try       //关闭串口       
                {
                    sp.Close();
                    isOpen = false;
                    btnOpenCom.Text = "打开串口";
                    //关闭串口后，串口设置选项可以继续使用
                    cbxCOMPort.Enabled = true;
                    cbxBaudRate.Enabled = true;
                    cbxDataBits.Enabled = true;
                    cbxParitv.Enabled = true;
                    cbxStopBits.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("关闭串口时发生错误！", "错误提示");
                }
            }
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            lb_recv_count.Text = "0";
            count_recv = 0;
            lb_parse_count.Text = "0";
            count_parse = 0;
        }

        #endregion

        #region 匹配测试

        public delegate void UpdateMatchRecv(string str1);
        private List<RoadSectionInfo> sltRoadSectionInfos = new List<RoadSectionInfo>();
        TreeNode sltMatchTestRootNode;
        PointLatLng lastCenterPoint = PointLatLng.Empty;
        GpsRoutePoint lastMatchPoint = null;
        int matchRet = 0;

        private void LoadMtachTestMap(PointLatLng p)
        {
            if (p == PointLatLng.Empty || sltMatchTestRootNode == null)
            {
                return;
            }

            if (lastCenterPoint != PointLatLng.Empty)
            {
                double diff_dist = GMapHelper.GetDistanceInMeter(p, lastCenterPoint);
                Console.WriteLine("diff_dist = " + diff_dist);
                if (diff_dist < 1000)
                {
                    return;
                }
            }
            if (sltRootNode == null)
            {
                return;
            }
            // 加载地图
            sltRoadSectionInfos.Clear();
            RectLatLng rect = new RectLatLng(p.Lat + 0.1, p.Lng - 0.1, 0.2, 0.2);
            RectLatLng rect2 = new RectLatLng(p.Lat + 0.02, p.Lng - 0.02, 0.04, 0.04);
            foreach (TreeNode item in sltRootNode.Nodes)
            {
                if (item.Text.Contains("000000"))
                {
                    continue;
                }
                else
                {
                    TerminalMapInfo terminalMapInfo = item.Parent.Tag as TerminalMapInfo;
                    CityDataInfo cityData = item.Tag as CityDataInfo;
                    if (IsRectIntersect(rect, cityData.City_minlon, cityData.City_maxlon, cityData.City_minlat, cityData.City_maxlat))
                    {
                        LoadMatchTestMap(cityData, terminalMapInfo, rect);
                        if (cb_mt_is_show_tmap.Checked)
                        {
                            CleanCityDataOverlay(cityData, false);
                            ShowCityDataOverlay(cityData, terminalMapInfo, rect2, false);
                        }
                    }
                }
            }
            lastCenterPoint = p;
        }
        private void LoadMatchTestMap(CityDataInfo cityData, TerminalMapInfo terminalMapInfo, RectLatLng rect)
        {
            if (terminalMapInfo.DisplayInfo.IsShowRoad && cityData.RoadFileTag && cityData.RoadFileInfo != null)
            {
                if (cityData.RoadFileInfo.LoadStatus == 0)
                {
                    RoadFileInfo roadFileInfo = TerminalMapTool.GetRoadFileInfo(cityData.RoadFileInfo.PathName, cityData, false);
                    if (roadFileInfo != null)
                    {
                        cityData.RoadFileInfo = roadFileInfo;
                    }
                }
                if (cityData.RoadFileInfo.LoadStatus == 1)
                {
                    showRoadFile(cityData, terminalMapInfo, rect, true, false);
                }
            }
        }

        private int recv_num = 0;
        private void ShowMatchRecvMsg(string msg)
        {
            if (cb_mt_is_dispaly.Checked)
            {
                tb_mt_recv_msg.Text += DateTime.Now.ToString() + " " + msg + "\r\n";
                tb_mt_recv_msg.Select(tb_mt_recv_msg.Text.Length, 0);
                tb_mt_recv_msg.ScrollToCaret();
            }
            lb_mt_recv_num.Text = ++recv_num + "";
        }
        private void HandleMatchRecvMsg(string line)
        {
            if (realtimeGeoOverlay == null || !realtimeGeoOverlay.IsStarted || realtimeGeoOverlay.IsPaused)
            {
                return;
            }
            matchTestOverlay.Markers.Clear();
            matchTestOverlay.Routes.Clear();
            string[] arrs_line = line.Split('&');
            foreach (var item in arrs_line)
            {
                string[] arrs = item.Split(',');
                try
                {
                    if (item.StartsWith("Pos"))
                    {
                        ShowMatchRecvMsg(item);
                        // &Pos,id,经度,纬度,方向,速度,匹配结果（-4:未知错误；-3:没道路；-2:匹配概率低； -1:参数异常，不进行匹配 0:未定位； 1:匹配成功）,搜索距离
                        if (arrs != null && arrs.Length >= 9)
                        {
                            int id = Int32.Parse(arrs[1].Trim());
                            double lon = Double.Parse(arrs[2].Trim());
                            double lat = Double.Parse(arrs[3].Trim());
                            double dir = Double.Parse(arrs[4].Trim());
                            double speed = Double.Parse(arrs[5].Trim());
                            matchRet = Int32.Parse(arrs[6].Trim());
                            int search_dist = Int32.Parse(arrs[7].Trim());
                            double probability = Double.Parse(arrs[8].Trim());
                            GpsRoutePoint point;
                            if (matchRet == 0)
                            {
                                if (lastMatchPoint == null)
                                {
                                    point = new GpsRoutePoint();
                                }
                                else
                                {
                                    point = lastMatchPoint;
                                }
                            }
                            else
                            {
                                point = new GpsRoutePoint();
                                point.Longitude = lon;
                                point.Latitude = lat;
                                point.Direction = dir;
                                point.Speed = speed;
                                lastMatchPoint = point;
                            }
                            lb_mt_ret.Text = GetMatchRetStr(matchRet);
                            lb_mt_search_dist.Text = search_dist.ToString();
                            lb_mt_probability.Text = probability.ToString();
                            lb_mt_road_num.Text = "0";
                            lb_mt_sign_num.Text = "0";
                            PointLatLng p = PointInDiffCoord.GetPointInCoordType(point.Latitude, point.Longitude, serialCoordType, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                            Bitmap bm;
                            if (matchRet == 1)
                            {
                                bm = Properties.Resources.arrow_up_32_green;
                            }
                            else if (matchRet == 0)
                            {
                                bm = Properties.Resources.arrow_up_32_gray;
                            }
                            else if (matchRet == -1)
                            {
                                bm = Properties.Resources.arrow_up_32_blue;
                            }
                            else if (matchRet == -2)
                            {
                                bm = Properties.Resources.arrow_up_32_yellow;
                            }
                            else if (matchRet == -3)
                            {
                                bm = Properties.Resources.arrow_up_32_red;
                            }
                            else
                            {
                                bm = Properties.Resources.arrow_up_32_red;
                            }
                            GMapDirectionMarker dm = new GMapDirectionMarker(p, bm, (float)dir);
                            matchTestOverlay.Markers.Add(dm);
                            if (cb_mt_is_show_road.Checked || cb_mt_is_show_tmap.Checked)
                            {
                                LoadMtachTestMap(p);
                            }
                        }
                    }
                    else if (item.StartsWith("Section"))
                    {
                        ShowMatchRecvMsg(item);
                        // &Section,id,size,道理ID|道路长度,道理ID|道路长度,道理ID|道路长度
                        int id = Int32.Parse(arrs[1].Trim());
                        int size = Int32.Parse(arrs[2].Trim());
                        lb_mt_road_num.Text = size.ToString();
                        if (cb_mt_is_show_road.Checked)
                        {
                            for (int i = 0; i < size && i < arrs.Length - 3; i++)
                            {
                                string[] sections = arrs[i + 3].Split('|');
                                if (sections == null || sections.Length < 2)
                                {
                                    continue;
                                }
                                int road_id = Int32.Parse(sections[0].Trim());
                                int road_len = Int32.Parse(sections[1].Trim());
                                foreach (RoadSectionInfo roadSection in sltRoadSectionInfos)
                                {
                                    int dif_len = Math.Abs(road_len - roadSection.UiLnkLen);
                                    if (road_id == roadSection.Ui32EdgeId && (dif_len < 20 || dif_len < road_len / 50))
                                    {
                                        // 找到相同道路，显示路网
                                        List<PointLatLng> pList = PointInDiffCoord.GetPointListInCoordType(roadSection.Point_list, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                                        GMapRoute mapRoute = new GMapRoute(pList, roadSection.AttributeStr);
                                        if (matchRet != -2)
                                        {
                                            mapRoute.Stroke = new Pen(Color.FromArgb(255, Color.Lime), 5);
                                        }
                                        else
                                        {
                                            mapRoute.Stroke = new Pen(Color.FromArgb(255, Color.Yellow), 5);
                                        }
                                        matchTestOverlay.Routes.Add(mapRoute);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (item.StartsWith("Traffsign"))
                    {
                        ShowMatchRecvMsg(item);
                        // &Traffsign,id,size,类型|限速|经度|纬度,类型|限速|经度|纬度,类型|限速|经度|纬度
                        int id = Int32.Parse(arrs[1].Trim());
                        int size = Int32.Parse(arrs[2].Trim());
                        lb_mt_sign_num.Text = size.ToString();
                        if (cb_mt_is_show_sign.Checked)
                        {
                            for (int i = 0; i < size && i < arrs.Length - 3; i++)
                            {
                                string[] signs = arrs[i + 3].Split('|');
                                if (signs == null || signs.Length < 4)
                                {
                                    continue;
                                }
                                int signs_type = Int32.Parse(signs[0].Trim());
                                int signs_limit = Int32.Parse(signs[1].Trim());
                                double signs_lon = Double.Parse(signs[2].Trim());
                                double signs_lat = Double.Parse(signs[3].Trim());
                                PointLatLng p = PointInDiffCoord.GetPointInCoordType(signs_lat, signs_lon, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                                GMarkerGoogle marker = new GMarkerGoogle(p, GMarkerGoogleType.green);
                                matchTestOverlay.Markers.Add(marker);
                                GMapTextMarker textMarker = new GMapTextMarker(p, "" + signs_type);
                                matchTestOverlay.Markers.Add(textMarker);
                            }
                        }
                    }
                    else if (item.StartsWith("MatchEdge"))
                    {
                        ShowMatchRecvMsg(item);
                        // &MatchEdge,id,size,道理ID|道路长度|匹配概率,道理ID|道路长度|匹配概率,道理ID|道路长度|匹配概率
                        int id = Int32.Parse(arrs[1].Trim());
                        int size = Int32.Parse(arrs[2].Trim());
                        lb_mt_match_road_num.Text = size.ToString();
                        if (cb_mt_is_show_match_road.Checked)
                        {
                            for (int i = 0; i < size && i < arrs.Length - 3; i++)
                            {
                                string[] matchEdges = arrs[i + 3].Split('|');
                                if (matchEdges == null || matchEdges.Length < 3)
                                {
                                    continue;
                                }
                                int road_id = Int32.Parse(matchEdges[0].Trim());
                                int road_len = Int32.Parse(matchEdges[1].Trim());
                                double road_matchProbability = Double.Parse(matchEdges[2].Trim());
                                foreach (RoadSectionInfo roadSection in sltRoadSectionInfos)
                                {
                                    int dif_len = Math.Abs(road_len - roadSection.UiLnkLen);
                                    if (road_id == roadSection.Ui32EdgeId && (dif_len < 20 || dif_len < road_len / 50))
                                    {
                                        // 找到相同道路，显示路网
                                        List<PointLatLng> pList = PointInDiffCoord.GetPointListInCoordType(roadSection.Point_list, CoordType.GCJ02, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
                                        GMapRoute mapRoute = new GMapRoute(pList, roadSection.AttributeStr);
                                        if (road_matchProbability < 0)
                                        {
                                            mapRoute.Stroke = new Pen(Color.FromArgb(255, Color.Red), 5);
                                        }
                                        else if (road_matchProbability < 0.5)
                                        {
                                            mapRoute.Stroke = new Pen(Color.FromArgb(255, Color.Yellow), 5);
                                        }
                                        else
                                        {
                                            mapRoute.Stroke = new Pen(Color.FromArgb(255, Color.Lime), 5);
                                        }
                                        matchTestOverlay.Routes.Add(mapRoute);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private string GetMatchRetStr(int ret)
        {
            if (ret == 1)
            {
                return "匹配成功";
            }
            else if (ret == 0)
            {
                return "未定位";
            }
            else if (ret == -1)
            {
                return "不进行匹配";
            }
            else if (ret == -2)
            {
                return "匹配概率低";
            }
            else if (ret == -3)
            {
                return "没道路";
            }
            else
            {
                return "未知错误";
            }
        }
        private void btn_mt_clean_Click(object sender, EventArgs e)
        {
            recv_num = 0;
            tb_mt_recv_msg.Text = "";
        }

        private void cb_mt_is_show_tmap_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_mt_is_show_tmap.Checked)
            {
                if (lastCenterPoint != PointLatLng.Empty)
                {
                    RectLatLng rect2 = new RectLatLng(lastCenterPoint.Lat + 0.02, lastCenterPoint.Lng - 0.02, 0.04, 0.04);
                    foreach (TreeNode item in sltRootNode.Nodes)
                    {
                        if (item.Text.Contains("000000"))
                        {
                            continue;
                        }
                        else
                        {
                            TerminalMapInfo terminalMapInfo = item.Parent.Tag as TerminalMapInfo;
                            CityDataInfo cityData = item.Tag as CityDataInfo;
                            if (IsRectIntersect(rect2, cityData.City_minlon, cityData.City_maxlon, cityData.City_minlat, cityData.City_maxlat))
                            {
                                CleanCityDataOverlay(cityData, false);
                                ShowCityDataOverlay(cityData, terminalMapInfo, rect2, false);
                            }
                        }
                    }
                }
            }
            else
            {
                cleanAllTMapShow();
            }
        }

        #endregion

        #region 临时坐标显示

        private GMapOverlay tempCoordOverlay = new GMapOverlay("tempCoordOverlay");
        private GMarkerGoogleType[] gMarkerGoogleTypeArray = new GMarkerGoogleType[] { 
                                                                    GMarkerGoogleType.red_pushpin,
                                                                    GMarkerGoogleType.pink_pushpin,
                                                                    GMarkerGoogleType.yellow_pushpin,
                                                                    GMarkerGoogleType.green_pushpin,
                                                                    GMarkerGoogleType.lightblue_pushpin,
                                                                    GMarkerGoogleType.blue_pushpin,
                                                                    GMarkerGoogleType.purple_pushpin };
        private int gMarkerGoogleTypeIndex = 0;
        private void btn_coord_view_add_Click(object sender, EventArgs e)
        {
            CoordType coordType = CoordType.WGS84;
            if (cb_coord_view_type.SelectedIndex == 0)
            {
                coordType = CoordType.WGS84;
            }
            else if (cb_coord_view_type.SelectedIndex == 1)
            {
                coordType = CoordType.GCJ02;
            }
            else if (cb_coord_view_type.SelectedIndex == 2)
            {
                coordType = CoordType.BD09;
            }
            PointLatLng p = GetCoordFormString(tb_coord_view_text.Text, coordType);
            if (p == PointLatLng.Empty)
            {
                MyMessageBox.ShowTipMessage("请输入经度在前，纬度在后，中间用逗号或空格隔开的格式坐标。");
                return;
            }
            mapControl.Overlays.Remove(tempCoordOverlay);
            mapControl.Overlays.Add(tempCoordOverlay);
            p = PointInDiffCoord.GetPointInCoordType(p, curMapProviderInfoArray[curMapProviderInfoIdx].CoordType);
            GMarkerGoogle marker = new GMarkerGoogle(p, gMarkerGoogleTypeArray[gMarkerGoogleTypeIndex++]);
            tempCoordOverlay.Markers.Add(marker);
            GMapTextMarker textMarker = new GMapTextMarker(p, tb_coord_view_text.Text);
            tempCoordOverlay.Markers.Add(textMarker);
            if (gMarkerGoogleTypeIndex >= gMarkerGoogleTypeArray.Length)
            {
                gMarkerGoogleTypeIndex = 0;
            }
            JumpCoordinatePickMarker(new PointInDiffCoord(p));
        }

        private void btn_coord_view_clean_Click(object sender, EventArgs e)
        {
            tempCoordOverlay.Markers.Clear();
            mapControl.Overlays.Remove(tempCoordOverlay);
        }

        #endregion

    }
}