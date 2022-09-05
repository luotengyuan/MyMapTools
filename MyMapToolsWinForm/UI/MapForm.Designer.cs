namespace MapToolsWinForm
{
    partial class MapForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.地图操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高德地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.百度地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.腾讯地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.天地图福建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arcGISMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czechToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图操作ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.保存缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示网格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图截屏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图测距ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.搜索引擎ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高德地图ToolStripMenuItem_search = new System.Windows.Forms.ToolStripMenuItem();
            this.设置高德地图开发者KeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.百度地图ToolStripMenuItem_search = new System.Windows.Forms.ToolStripMenuItem();
            this.设置百度地图开发者KeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.腾讯地图ToolStripMenuItem_search = new System.Windows.Forms.ToolStripMenuItem();
            this.设置腾讯地图开发者KeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地图访问ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在线和缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在线服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本地缓存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.代理设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.口令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于MyMapToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMap = new System.Windows.Forms.Panel();
            this.pb_compass = new System.Windows.Forms.PictureBox();
            this.lb_scale_max = new System.Windows.Forms.Label();
            this.lb_scale_min = new System.Windows.Forms.Label();
            this.pb_scale = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusTip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCenter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusDownload = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarDownload = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusPOIDownload = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusExport = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter_button = new System.Windows.Forms.Splitter();
            this.buttonMapType = new System.Windows.Forms.Button();
            this.mapControl = new MapToolsWinForm.MapControl();
            this.panelDock = new System.Windows.Forms.Panel();
            this.dataGridViewGpsRoute = new System.Windows.Forms.DataGridView();
            this.dataGridViewID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewAltitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewAccuracy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewAttributes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyGeoDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelButtonTools = new System.Windows.Forms.Panel();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.checkBoxRepeat = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tb_end_idx = new System.Windows.Forms.TextBox();
            this.tb_start_idx = new System.Windows.Forms.TextBox();
            this.tb_simulate_src = new System.Windows.Forms.TextBox();
            this.lb_simulate_src = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_simulate_src = new System.Windows.Forms.ComboBox();
            this.cb_simulate_type = new System.Windows.Forms.ComboBox();
            this.checkBoxFollow = new System.Windows.Forms.CheckBox();
            this.comboBoxTimeSpan = new System.Windows.Forms.ComboBox();
            this.buttonSetTimerInterval = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.contextMenuStripSelectedArea = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下载地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载KMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.允许编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripLocation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.搜索该点的地址ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.以此为起点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加途径点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.以此为终点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.显示当前网格地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDisplayInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改显示信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置为地图匹配测试底图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示当前区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示当前网格地图ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.显示当前区域城市地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除当前区域地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除所有显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripHistoryRoute = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.导出轨迹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除轨迹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new BSE.Windows.Forms.Splitter();
            this.panelMenu = new BSE.Windows.Forms.Panel();
            this.xPanderPanelList1 = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanderPanel_coord_pickup = new BSE.Windows.Forms.XPanderPanel();
            this.btn_coord_pickup_clean = new System.Windows.Forms.Button();
            this.cb_get_coord_from_map = new System.Windows.Forms.CheckBox();
            this.btn_query_by_addrass = new System.Windows.Forms.Button();
            this.tb_address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_query_by_coord = new System.Windows.Forms.Button();
            this.tb_lon_lat_bd09 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_lon_lat_gcj02 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_lon_lat_wgs84 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xPanderPanel2 = new BSE.Windows.Forms.XPanderPanel();
            this.buttonPoiClean = new System.Windows.Forms.Button();
            this.buttonPoiSave = new System.Windows.Forms.Button();
            this.buttonPOISearch = new System.Windows.Forms.Button();
            this.comboBoxPoiSave = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxProvince = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPOIkeyword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.xPanderPanel3 = new BSE.Windows.Forms.XPanderPanel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.comboBoxStore = new System.Windows.Forms.ComboBox();
            this.buttonMapDownload = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.buttonCleanDownloadArea = new System.Windows.Forms.Button();
            this.buttonDrawPolygon = new System.Windows.Forms.Button();
            this.buttonDrawRectangle = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.gbMapImage = new System.Windows.Forms.GroupBox();
            this.comboBoxZoom = new System.Windows.Forms.ComboBox();
            this.buttonMapImage = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.xPanderPanelChinaRegion = new BSE.Windows.Forms.XPanderPanel();
            this.advTreeChina = new System.Windows.Forms.TreeView();
            this.xPanderPanel4 = new BSE.Windows.Forms.XPanderPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonClearDemoOverlay = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbGMapMarkerScopeCircleAnimate = new System.Windows.Forms.RadioButton();
            this.rbGMapMarkerScopePieAnimate = new System.Windows.Forms.RadioButton();
            this.rbGMapTipMarker = new System.Windows.Forms.RadioButton();
            this.rbGMapDirectionMarker = new System.Windows.Forms.RadioButton();
            this.rbGMapGifMarker = new System.Windows.Forms.RadioButton();
            this.rbGMapFlashMarker = new System.Windows.Forms.RadioButton();
            this.rbGMarkerGoogle = new System.Windows.Forms.RadioButton();
            this.checkBoxMarker = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStopBlink = new System.Windows.Forms.Button();
            this.buttonBeginBlink = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonHeatMarker = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonPolyline = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonPolygon = new System.Windows.Forms.Button();
            this.xPanderPanel5 = new BSE.Windows.Forms.XPanderPanel();
            this.buttonNaviEndDel = new System.Windows.Forms.Button();
            this.buttonNaviWay3Del = new System.Windows.Forms.Button();
            this.textBoxNaviWay3 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.buttonNaviWay2Del = new System.Windows.Forms.Button();
            this.textBoxNaviWay2 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.buttonNaviWay1Del = new System.Windows.Forms.Button();
            this.buttonNaviStartDel = new System.Windows.Forms.Button();
            this.textBoxNaviWay1 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.buttonNaviExport = new System.Windows.Forms.Button();
            this.buttonCleanRoute = new System.Windows.Forms.Button();
            this.buttonNaviGetRoute = new System.Windows.Forms.Button();
            this.textBoxNaviEndPoint = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxNaviStartPoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanderPanel6 = new BSE.Windows.Forms.XPanderPanel();
            this.clb_route_list = new System.Windows.Forms.CheckedListBox();
            this.buttonDelectGpsRouteFile = new System.Windows.Forms.Button();
            this.buttonLoadGpsRouteFile = new System.Windows.Forms.Button();
            this.xPanderPanelTerminalMap = new BSE.Windows.Forms.XPanderPanel();
            this.treeViewTerminalMap = new System.Windows.Forms.TreeView();
            this.buttonDelectMapFile = new System.Windows.Forms.Button();
            this.buttonLoadMapFile = new System.Windows.Forms.Button();
            this.xPanderPanel1 = new BSE.Windows.Forms.XPanderPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.lb_parse_count = new System.Windows.Forms.Label();
            this.cb_serial_CoordType = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btn_clean = new System.Windows.Forms.Button();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.btnCheckCOM = new System.Windows.Forms.Button();
            this.lb_recv_count = new System.Windows.Forms.Label();
            this.cbxDataBits = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxStopBits = new System.Windows.Forms.ComboBox();
            this.cbxParitv = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.cbxCOMPort = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.xPanderPanel7 = new BSE.Windows.Forms.XPanderPanel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lb_mt_recv_num = new System.Windows.Forms.Label();
            this.btn_mt_clean = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.cb_mt_is_dispaly = new System.Windows.Forms.CheckBox();
            this.tb_mt_recv_msg = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lb_mt_match_road_num = new System.Windows.Forms.Label();
            this.cb_mt_is_show_match_road = new System.Windows.Forms.CheckBox();
            this.cb_mt_is_show_tmap = new System.Windows.Forms.CheckBox();
            this.lb_mt_probability = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cb_mt_is_show_sign = new System.Windows.Forms.CheckBox();
            this.cb_mt_is_show_road = new System.Windows.Forms.CheckBox();
            this.lb_mt_sign_num = new System.Windows.Forms.Label();
            this.lb_mt_road_num = new System.Windows.Forms.Label();
            this.lb_mt_search_dist = new System.Windows.Forms.Label();
            this.lb_mt_ret = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.contextMenuCityDataView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_缩放至城市 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_显示城市数据 = new System.Windows.Forms.ToolStripMenuItem();
            this.清除城市显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_显示城市网格 = new System.Windows.Forms.ToolStripMenuItem();
            this.清除网格显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cb_coord_view_type = new System.Windows.Forms.ComboBox();
            this.tb_coord_view_text = new System.Windows.Forms.TextBox();
            this.btn_coord_view_add = new System.Windows.Forms.Button();
            this.btn_coord_view_clean = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_compass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_scale)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panelDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGpsRoute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyGeoDataBindingSource)).BeginInit();
            this.panelButtonTools.SuspendLayout();
            this.contextMenuStripSelectedArea.SuspendLayout();
            this.contextMenuStripLocation.SuspendLayout();
            this.contextMenuStripDisplayInfo.SuspendLayout();
            this.contextMenuStripHistoryRoute.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.xPanderPanelList1.SuspendLayout();
            this.xPanderPanel_coord_pickup.SuspendLayout();
            this.xPanderPanel2.SuspendLayout();
            this.xPanderPanel3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gbMapImage.SuspendLayout();
            this.xPanderPanelChinaRegion.SuspendLayout();
            this.xPanderPanel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.xPanderPanel5.SuspendLayout();
            this.xPanderPanel6.SuspendLayout();
            this.xPanderPanelTerminalMap.SuspendLayout();
            this.xPanderPanel1.SuspendLayout();
            this.xPanderPanel7.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.contextMenuCityDataView.SuspendLayout();
            this.SuspendLayout();
            // 
            // 地图操作ToolStripMenuItem
            // 
            this.地图操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.高德地图ToolStripMenuItem,
            this.百度地图ToolStripMenuItem,
            this.腾讯地图ToolStripMenuItem,
            this.天地图福建ToolStripMenuItem,
            this.arcGISMapToolStripMenuItem,
            this.bingToolStripMenuItem,
            this.czechToolStripMenuItem,
            this.openCycleToolStripMenuItem,
            this.googleToolStripMenuItem,
            this.oSMToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.地图操作ToolStripMenuItem.Name = "地图操作ToolStripMenuItem";
            this.地图操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.地图操作ToolStripMenuItem.Text = "地图选择";
            // 
            // 高德地图ToolStripMenuItem
            // 
            this.高德地图ToolStripMenuItem.Name = "高德地图ToolStripMenuItem";
            this.高德地图ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.高德地图ToolStripMenuItem.Text = "高德地图";
            this.高德地图ToolStripMenuItem.Click += new System.EventHandler(this.高德地图ToolStripMenuItem_Click);
            // 
            // 百度地图ToolStripMenuItem
            // 
            this.百度地图ToolStripMenuItem.Name = "百度地图ToolStripMenuItem";
            this.百度地图ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.百度地图ToolStripMenuItem.Text = "百度地图";
            this.百度地图ToolStripMenuItem.Click += new System.EventHandler(this.百度地图ToolStripMenuItem_Click);
            // 
            // 腾讯地图ToolStripMenuItem
            // 
            this.腾讯地图ToolStripMenuItem.Name = "腾讯地图ToolStripMenuItem";
            this.腾讯地图ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.腾讯地图ToolStripMenuItem.Text = "腾讯地图";
            this.腾讯地图ToolStripMenuItem.Click += new System.EventHandler(this.腾讯地图ToolStripMenuItem_Click);
            // 
            // 天地图福建ToolStripMenuItem
            // 
            this.天地图福建ToolStripMenuItem.Name = "天地图福建ToolStripMenuItem";
            this.天地图福建ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.天地图福建ToolStripMenuItem.Text = "天地图(福建)";
            this.天地图福建ToolStripMenuItem.Click += new System.EventHandler(this.天地图福建ToolStripMenuItem_Click);
            // 
            // arcGISMapToolStripMenuItem
            // 
            this.arcGISMapToolStripMenuItem.Name = "arcGISMapToolStripMenuItem";
            this.arcGISMapToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.arcGISMapToolStripMenuItem.Text = "ArcGIS";
            this.arcGISMapToolStripMenuItem.Click += new System.EventHandler(this.arcGISMapToolStripMenuItem_Click);
            // 
            // bingToolStripMenuItem
            // 
            this.bingToolStripMenuItem.Name = "bingToolStripMenuItem";
            this.bingToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.bingToolStripMenuItem.Text = "Bing";
            this.bingToolStripMenuItem.Click += new System.EventHandler(this.bingToolStripMenuItem_Click);
            // 
            // czechToolStripMenuItem
            // 
            this.czechToolStripMenuItem.Name = "czechToolStripMenuItem";
            this.czechToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.czechToolStripMenuItem.Text = "Czech";
            this.czechToolStripMenuItem.Click += new System.EventHandler(this.czechToolStripMenuItem_Click);
            // 
            // openCycleToolStripMenuItem
            // 
            this.openCycleToolStripMenuItem.Name = "openCycleToolStripMenuItem";
            this.openCycleToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.openCycleToolStripMenuItem.Text = "OpenCycle";
            this.openCycleToolStripMenuItem.Click += new System.EventHandler(this.openCycleToolStripMenuItem_Click);
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.googleToolStripMenuItem.Text = "Google";
            this.googleToolStripMenuItem.Click += new System.EventHandler(this.googleToolStripMenuItem_Click);
            // 
            // oSMToolStripMenuItem
            // 
            this.oSMToolStripMenuItem.Name = "oSMToolStripMenuItem";
            this.oSMToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.oSMToolStripMenuItem.Text = "OSM";
            this.oSMToolStripMenuItem.Click += new System.EventHandler(this.oSMToolStripMenuItem_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.otherToolStripMenuItem.Text = "Other";
            this.otherToolStripMenuItem.Click += new System.EventHandler(this.otherToolStripMenuItem_Click);
            // 
            // 地图操作ToolStripMenuItem1
            // 
            this.地图操作ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存缓存ToolStripMenuItem,
            this.读取缓存ToolStripMenuItem,
            this.显示网格ToolStripMenuItem,
            this.地图截屏ToolStripMenuItem,
            this.地图测距ToolStripMenuItem});
            this.地图操作ToolStripMenuItem1.Name = "地图操作ToolStripMenuItem1";
            this.地图操作ToolStripMenuItem1.Size = new System.Drawing.Size(68, 21);
            this.地图操作ToolStripMenuItem1.Text = "地图操作";
            // 
            // 保存缓存ToolStripMenuItem
            // 
            this.保存缓存ToolStripMenuItem.Name = "保存缓存ToolStripMenuItem";
            this.保存缓存ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存缓存ToolStripMenuItem.Text = "保存缓存";
            this.保存缓存ToolStripMenuItem.Click += new System.EventHandler(this.保存缓存ToolStripMenuItem_Click);
            // 
            // 读取缓存ToolStripMenuItem
            // 
            this.读取缓存ToolStripMenuItem.Name = "读取缓存ToolStripMenuItem";
            this.读取缓存ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.读取缓存ToolStripMenuItem.Text = "读取缓存";
            this.读取缓存ToolStripMenuItem.Click += new System.EventHandler(this.读取缓存ToolStripMenuItem_Click);
            // 
            // 显示网格ToolStripMenuItem
            // 
            this.显示网格ToolStripMenuItem.Name = "显示网格ToolStripMenuItem";
            this.显示网格ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示网格ToolStripMenuItem.Text = "显示网格";
            this.显示网格ToolStripMenuItem.Click += new System.EventHandler(this.显示网格ToolStripMenuItem_Click);
            // 
            // 地图截屏ToolStripMenuItem
            // 
            this.地图截屏ToolStripMenuItem.Name = "地图截屏ToolStripMenuItem";
            this.地图截屏ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.地图截屏ToolStripMenuItem.Text = "地图截屏";
            this.地图截屏ToolStripMenuItem.Click += new System.EventHandler(this.地图截屏ToolStripMenuItem_Click);
            // 
            // 地图测距ToolStripMenuItem
            // 
            this.地图测距ToolStripMenuItem.Name = "地图测距ToolStripMenuItem";
            this.地图测距ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.地图测距ToolStripMenuItem.Text = "地图测距";
            this.地图测距ToolStripMenuItem.Click += new System.EventHandler(this.地图测距ToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.地图操作ToolStripMenuItem,
            this.搜索引擎ToolStripMenuItem,
            this.地图操作ToolStripMenuItem1,
            this.地图访问ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1130, 25);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 搜索引擎ToolStripMenuItem
            // 
            this.搜索引擎ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.高德地图ToolStripMenuItem_search,
            this.百度地图ToolStripMenuItem_search,
            this.腾讯地图ToolStripMenuItem_search});
            this.搜索引擎ToolStripMenuItem.Name = "搜索引擎ToolStripMenuItem";
            this.搜索引擎ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.搜索引擎ToolStripMenuItem.Text = "搜索引擎";
            // 
            // 高德地图ToolStripMenuItem_search
            // 
            this.高德地图ToolStripMenuItem_search.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置高德地图开发者KeyToolStripMenuItem});
            this.高德地图ToolStripMenuItem_search.Name = "高德地图ToolStripMenuItem_search";
            this.高德地图ToolStripMenuItem_search.Size = new System.Drawing.Size(124, 22);
            this.高德地图ToolStripMenuItem_search.Text = "高德地图";
            this.高德地图ToolStripMenuItem_search.Click += new System.EventHandler(this.高德地图ToolStripMenuItem1_Click);
            // 
            // 设置高德地图开发者KeyToolStripMenuItem
            // 
            this.设置高德地图开发者KeyToolStripMenuItem.Name = "设置高德地图开发者KeyToolStripMenuItem";
            this.设置高德地图开发者KeyToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.设置高德地图开发者KeyToolStripMenuItem.Text = "设置高德地图开发者Key";
            this.设置高德地图开发者KeyToolStripMenuItem.Click += new System.EventHandler(this.设置高德地图开发者KeyToolStripMenuItem_Click);
            // 
            // 百度地图ToolStripMenuItem_search
            // 
            this.百度地图ToolStripMenuItem_search.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置百度地图开发者KeyToolStripMenuItem});
            this.百度地图ToolStripMenuItem_search.Name = "百度地图ToolStripMenuItem_search";
            this.百度地图ToolStripMenuItem_search.Size = new System.Drawing.Size(124, 22);
            this.百度地图ToolStripMenuItem_search.Text = "百度地图";
            this.百度地图ToolStripMenuItem_search.Click += new System.EventHandler(this.百度地图ToolStripMenuItem1_Click);
            // 
            // 设置百度地图开发者KeyToolStripMenuItem
            // 
            this.设置百度地图开发者KeyToolStripMenuItem.Name = "设置百度地图开发者KeyToolStripMenuItem";
            this.设置百度地图开发者KeyToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.设置百度地图开发者KeyToolStripMenuItem.Text = "设置百度地图开发者Key";
            this.设置百度地图开发者KeyToolStripMenuItem.Click += new System.EventHandler(this.设置百度地图开发者KeyToolStripMenuItem_Click);
            // 
            // 腾讯地图ToolStripMenuItem_search
            // 
            this.腾讯地图ToolStripMenuItem_search.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置腾讯地图开发者KeyToolStripMenuItem});
            this.腾讯地图ToolStripMenuItem_search.Name = "腾讯地图ToolStripMenuItem_search";
            this.腾讯地图ToolStripMenuItem_search.Size = new System.Drawing.Size(124, 22);
            this.腾讯地图ToolStripMenuItem_search.Text = "腾讯地图";
            this.腾讯地图ToolStripMenuItem_search.Click += new System.EventHandler(this.腾讯地图ToolStripMenuItem1_Click);
            // 
            // 设置腾讯地图开发者KeyToolStripMenuItem
            // 
            this.设置腾讯地图开发者KeyToolStripMenuItem.Name = "设置腾讯地图开发者KeyToolStripMenuItem";
            this.设置腾讯地图开发者KeyToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.设置腾讯地图开发者KeyToolStripMenuItem.Text = "设置腾讯地图开发者Key";
            this.设置腾讯地图开发者KeyToolStripMenuItem.Click += new System.EventHandler(this.设置腾讯地图开发者KeyToolStripMenuItem_Click);
            // 
            // 地图访问ToolStripMenuItem
            // 
            this.地图访问ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在线和缓存ToolStripMenuItem,
            this.在线服务ToolStripMenuItem,
            this.本地缓存ToolStripMenuItem});
            this.地图访问ToolStripMenuItem.Name = "地图访问ToolStripMenuItem";
            this.地图访问ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.地图访问ToolStripMenuItem.Text = "访问模式";
            // 
            // 在线和缓存ToolStripMenuItem
            // 
            this.在线和缓存ToolStripMenuItem.Name = "在线和缓存ToolStripMenuItem";
            this.在线和缓存ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.在线和缓存ToolStripMenuItem.Text = "在线和缓存";
            this.在线和缓存ToolStripMenuItem.Click += new System.EventHandler(this.在线和缓存ToolStripMenuItem_Click);
            // 
            // 在线服务ToolStripMenuItem
            // 
            this.在线服务ToolStripMenuItem.Name = "在线服务ToolStripMenuItem";
            this.在线服务ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.在线服务ToolStripMenuItem.Text = "在线服务";
            this.在线服务ToolStripMenuItem.Click += new System.EventHandler(this.在线服务ToolStripMenuItem_Click);
            // 
            // 本地缓存ToolStripMenuItem
            // 
            this.本地缓存ToolStripMenuItem.Name = "本地缓存ToolStripMenuItem";
            this.本地缓存ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.本地缓存ToolStripMenuItem.Text = "本地缓存";
            this.本地缓存ToolStripMenuItem.Click += new System.EventHandler(this.本地缓存ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.代理设置ToolStripMenuItem,
            this.口令ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 代理设置ToolStripMenuItem
            // 
            this.代理设置ToolStripMenuItem.Name = "代理设置ToolStripMenuItem";
            this.代理设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.代理设置ToolStripMenuItem.Text = "代理设置";
            this.代理设置ToolStripMenuItem.Click += new System.EventHandler(this.代理设置ToolStripMenuItem_Click);
            // 
            // 口令ToolStripMenuItem
            // 
            this.口令ToolStripMenuItem.Name = "口令ToolStripMenuItem";
            this.口令ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.口令ToolStripMenuItem.Text = "口令设置";
            this.口令ToolStripMenuItem.Click += new System.EventHandler(this.口令ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于MyMapToolsToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于MyMapToolsToolStripMenuItem
            // 
            this.关于MyMapToolsToolStripMenuItem.Name = "关于MyMapToolsToolStripMenuItem";
            this.关于MyMapToolsToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于MyMapToolsToolStripMenuItem.Text = "关于";
            this.关于MyMapToolsToolStripMenuItem.Click += new System.EventHandler(this.关于MyMapToolsToolStripMenuItem_Click);
            // 
            // panelMap
            // 
            this.panelMap.Controls.Add(this.pb_compass);
            this.panelMap.Controls.Add(this.lb_scale_max);
            this.panelMap.Controls.Add(this.lb_scale_min);
            this.panelMap.Controls.Add(this.pb_scale);
            this.panelMap.Controls.Add(this.statusStrip1);
            this.panelMap.Controls.Add(this.splitter_button);
            this.panelMap.Controls.Add(this.buttonMapType);
            this.panelMap.Controls.Add(this.mapControl);
            this.panelMap.Controls.Add(this.panelDock);
            this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(302, 25);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(828, 687);
            this.panelMap.TabIndex = 18;
            // 
            // pb_compass
            // 
            this.pb_compass.BackColor = System.Drawing.Color.Transparent;
            this.pb_compass.Image = global::MapToolsWinForm.Properties.Resources.compass;
            this.pb_compass.Location = new System.Drawing.Point(10, 17);
            this.pb_compass.Name = "pb_compass";
            this.pb_compass.Size = new System.Drawing.Size(64, 64);
            this.pb_compass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_compass.TabIndex = 12;
            this.pb_compass.TabStop = false;
            // 
            // lb_scale_max
            // 
            this.lb_scale_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_scale_max.AutoSize = true;
            this.lb_scale_max.Location = new System.Drawing.Point(64, 506);
            this.lb_scale_max.Name = "lb_scale_max";
            this.lb_scale_max.Size = new System.Drawing.Size(23, 12);
            this.lb_scale_max.TabIndex = 11;
            this.lb_scale_max.Text = "1km";
            // 
            // lb_scale_min
            // 
            this.lb_scale_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_scale_min.AutoSize = true;
            this.lb_scale_min.Location = new System.Drawing.Point(6, 506);
            this.lb_scale_min.Name = "lb_scale_min";
            this.lb_scale_min.Size = new System.Drawing.Size(11, 12);
            this.lb_scale_min.TabIndex = 10;
            this.lb_scale_min.Text = "0";
            // 
            // pb_scale
            // 
            this.pb_scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_scale.BackColor = System.Drawing.Color.Transparent;
            this.pb_scale.Image = global::MapToolsWinForm.Properties.Resources.scale;
            this.pb_scale.Location = new System.Drawing.Point(8, 521);
            this.pb_scale.Name = "pb_scale";
            this.pb_scale.Size = new System.Drawing.Size(72, 15);
            this.pb_scale.TabIndex = 9;
            this.pb_scale.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusTip,
            this.toolStripStatusCenter,
            this.toolStripStatusDownload,
            this.toolStripProgressBarDownload,
            this.toolStripStatusPOIDownload,
            this.toolStripStatusExport});
            this.statusStrip1.Location = new System.Drawing.Point(0, 546);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(828, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusTip
            // 
            this.toolStripStatusTip.Name = "toolStripStatusTip";
            this.toolStripStatusTip.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusTip.Text = "显示";
            // 
            // toolStripStatusCenter
            // 
            this.toolStripStatusCenter.Name = "toolStripStatusCenter";
            this.toolStripStatusCenter.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusCenter.Text = "地图中心：";
            // 
            // toolStripStatusDownload
            // 
            this.toolStripStatusDownload.Name = "toolStripStatusDownload";
            this.toolStripStatusDownload.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusDownload.Text = "下载进度：";
            // 
            // toolStripProgressBarDownload
            // 
            this.toolStripProgressBarDownload.Name = "toolStripProgressBarDownload";
            this.toolStripProgressBarDownload.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusPOIDownload
            // 
            this.toolStripStatusPOIDownload.Name = "toolStripStatusPOIDownload";
            this.toolStripStatusPOIDownload.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusPOIDownload.Text = "POI下载进度：";
            // 
            // toolStripStatusExport
            // 
            this.toolStripStatusExport.Name = "toolStripStatusExport";
            this.toolStripStatusExport.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusExport.Text = "正在导出切片...";
            // 
            // splitter_button
            // 
            this.splitter_button.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter_button.Location = new System.Drawing.Point(0, 568);
            this.splitter_button.Name = "splitter_button";
            this.splitter_button.Size = new System.Drawing.Size(828, 3);
            this.splitter_button.TabIndex = 7;
            this.splitter_button.TabStop = false;
            // 
            // buttonMapType
            // 
            this.buttonMapType.Location = new System.Drawing.Point(766, 17);
            this.buttonMapType.Name = "buttonMapType";
            this.buttonMapType.Size = new System.Drawing.Size(50, 49);
            this.buttonMapType.TabIndex = 0;
            // 
            // mapControl
            // 
            this.mapControl.Bearing = 0F;
            this.mapControl.CanDragMap = true;
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapControl.GrayScaleMode = false;
            this.mapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapControl.LevelsKeepInMemmory = 5;
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.MarkersEnabled = true;
            this.mapControl.MaxZoom = 2;
            this.mapControl.MinZoom = 2;
            this.mapControl.MouseWheelZoomEnabled = true;
            this.mapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapControl.Name = "mapControl";
            this.mapControl.NegativeMode = false;
            this.mapControl.PolygonsEnabled = true;
            this.mapControl.RetryLoadTile = 0;
            this.mapControl.RoutesEnabled = true;
            this.mapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapControl.ShowTileGridLines = false;
            this.mapControl.Size = new System.Drawing.Size(828, 571);
            this.mapControl.TabIndex = 6;
            this.mapControl.Zoom = 0D;
            // 
            // panelDock
            // 
            this.panelDock.Controls.Add(this.dataGridViewGpsRoute);
            this.panelDock.Controls.Add(this.panelButtonTools);
            this.panelDock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDock.Location = new System.Drawing.Point(0, 571);
            this.panelDock.Name = "panelDock";
            this.panelDock.Size = new System.Drawing.Size(828, 116);
            this.panelDock.TabIndex = 5;
            // 
            // dataGridViewGpsRoute
            // 
            this.dataGridViewGpsRoute.AllowUserToOrderColumns = true;
            this.dataGridViewGpsRoute.AutoGenerateColumns = false;
            this.dataGridViewGpsRoute.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGpsRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGpsRoute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewID,
            this.dataGridViewLongitude,
            this.dataGridViewLatitude,
            this.dataGridViewDirection,
            this.dataGridViewSpeed,
            this.dataGridViewAltitude,
            this.dataGridViewAccuracy,
            this.dataGridViewDateTime,
            this.dataGridViewType,
            this.dataGridViewAttributes});
            this.dataGridViewGpsRoute.DataSource = this.historyGeoDataBindingSource;
            this.dataGridViewGpsRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGpsRoute.Location = new System.Drawing.Point(0, 54);
            this.dataGridViewGpsRoute.Name = "dataGridViewGpsRoute";
            this.dataGridViewGpsRoute.RowTemplate.Height = 23;
            this.dataGridViewGpsRoute.Size = new System.Drawing.Size(828, 62);
            this.dataGridViewGpsRoute.TabIndex = 1;
            this.dataGridViewGpsRoute.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGpsRoute_CellDoubleClick);
            // 
            // dataGridViewID
            // 
            this.dataGridViewID.DataPropertyName = "ID";
            this.dataGridViewID.FillWeight = 39.73235F;
            this.dataGridViewID.HeaderText = "ID";
            this.dataGridViewID.Name = "dataGridViewID";
            // 
            // dataGridViewLongitude
            // 
            this.dataGridViewLongitude.DataPropertyName = "Longitude";
            this.dataGridViewLongitude.FillWeight = 63.57176F;
            this.dataGridViewLongitude.HeaderText = "Longitude";
            this.dataGridViewLongitude.Name = "dataGridViewLongitude";
            // 
            // dataGridViewLatitude
            // 
            this.dataGridViewLatitude.DataPropertyName = "Latitude";
            this.dataGridViewLatitude.FillWeight = 63.57176F;
            this.dataGridViewLatitude.HeaderText = "Latitude";
            this.dataGridViewLatitude.Name = "dataGridViewLatitude";
            // 
            // dataGridViewDirection
            // 
            this.dataGridViewDirection.DataPropertyName = "Direction";
            this.dataGridViewDirection.FillWeight = 55.62529F;
            this.dataGridViewDirection.HeaderText = "Direction";
            this.dataGridViewDirection.Name = "dataGridViewDirection";
            // 
            // dataGridViewSpeed
            // 
            this.dataGridViewSpeed.DataPropertyName = "Speed";
            this.dataGridViewSpeed.FillWeight = 55.62529F;
            this.dataGridViewSpeed.HeaderText = "Speed";
            this.dataGridViewSpeed.Name = "dataGridViewSpeed";
            // 
            // dataGridViewAltitude
            // 
            this.dataGridViewAltitude.DataPropertyName = "Altitude";
            this.dataGridViewAltitude.FillWeight = 55.62529F;
            this.dataGridViewAltitude.HeaderText = "Altitude";
            this.dataGridViewAltitude.Name = "dataGridViewAltitude";
            // 
            // dataGridViewAccuracy
            // 
            this.dataGridViewAccuracy.DataPropertyName = "Accuracy";
            this.dataGridViewAccuracy.FillWeight = 55.62529F;
            this.dataGridViewAccuracy.HeaderText = "Accuracy";
            this.dataGridViewAccuracy.Name = "dataGridViewAccuracy";
            // 
            // dataGridViewDateTime
            // 
            this.dataGridViewDateTime.DataPropertyName = "DateTime";
            this.dataGridViewDateTime.FillWeight = 63.57176F;
            this.dataGridViewDateTime.HeaderText = "DateTime";
            this.dataGridViewDateTime.Name = "dataGridViewDateTime";
            // 
            // dataGridViewType
            // 
            this.dataGridViewType.DataPropertyName = "Type";
            this.dataGridViewType.FillWeight = 50F;
            this.dataGridViewType.HeaderText = "Type";
            this.dataGridViewType.Name = "dataGridViewType";
            // 
            // dataGridViewAttributes
            // 
            this.dataGridViewAttributes.DataPropertyName = "OtherAttributeStr";
            this.dataGridViewAttributes.FillWeight = 158.9294F;
            this.dataGridViewAttributes.HeaderText = "Attributes";
            this.dataGridViewAttributes.Name = "dataGridViewAttributes";
            // 
            // historyGeoDataBindingSource
            // 
            this.historyGeoDataBindingSource.DataSource = typeof(MapToolsWinForm.HistoryGeoData);
            // 
            // panelButtonTools
            // 
            this.panelButtonTools.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelButtonTools.Controls.Add(this.buttonForward);
            this.panelButtonTools.Controls.Add(this.buttonBack);
            this.panelButtonTools.Controls.Add(this.checkBoxRepeat);
            this.panelButtonTools.Controls.Add(this.label25);
            this.panelButtonTools.Controls.Add(this.label24);
            this.panelButtonTools.Controls.Add(this.tb_end_idx);
            this.panelButtonTools.Controls.Add(this.tb_start_idx);
            this.panelButtonTools.Controls.Add(this.tb_simulate_src);
            this.panelButtonTools.Controls.Add(this.lb_simulate_src);
            this.panelButtonTools.Controls.Add(this.label14);
            this.panelButtonTools.Controls.Add(this.cb_simulate_src);
            this.panelButtonTools.Controls.Add(this.cb_simulate_type);
            this.panelButtonTools.Controls.Add(this.checkBoxFollow);
            this.panelButtonTools.Controls.Add(this.comboBoxTimeSpan);
            this.panelButtonTools.Controls.Add(this.buttonSetTimerInterval);
            this.panelButtonTools.Controls.Add(this.buttonResume);
            this.panelButtonTools.Controls.Add(this.buttonPause);
            this.panelButtonTools.Controls.Add(this.buttonStop);
            this.panelButtonTools.Controls.Add(this.buttonStart);
            this.panelButtonTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtonTools.Location = new System.Drawing.Point(0, 0);
            this.panelButtonTools.Name = "panelButtonTools";
            this.panelButtonTools.Size = new System.Drawing.Size(828, 54);
            this.panelButtonTools.TabIndex = 0;
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(256, 28);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(44, 23);
            this.buttonForward.TabIndex = 18;
            this.buttonForward.Text = "》";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(206, 28);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(44, 23);
            this.buttonBack.TabIndex = 17;
            this.buttonBack.Text = "《";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // checkBoxRepeat
            // 
            this.checkBoxRepeat.AutoSize = true;
            this.checkBoxRepeat.Location = new System.Drawing.Point(529, 32);
            this.checkBoxRepeat.Name = "checkBoxRepeat";
            this.checkBoxRepeat.Size = new System.Drawing.Size(60, 16);
            this.checkBoxRepeat.TabIndex = 16;
            this.checkBoxRepeat.Text = "Repeat";
            this.checkBoxRepeat.UseVisualStyleBackColor = true;
            this.checkBoxRepeat.CheckedChanged += new System.EventHandler(this.checkBoxRepeat_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(715, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 15;
            this.label25.Text = "end:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(599, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 14;
            this.label24.Text = "start:";
            // 
            // tb_end_idx
            // 
            this.tb_end_idx.Location = new System.Drawing.Point(750, 29);
            this.tb_end_idx.Name = "tb_end_idx";
            this.tb_end_idx.Size = new System.Drawing.Size(63, 21);
            this.tb_end_idx.TabIndex = 13;
            this.tb_end_idx.Text = "0";
            // 
            // tb_start_idx
            // 
            this.tb_start_idx.Location = new System.Drawing.Point(646, 29);
            this.tb_start_idx.Name = "tb_start_idx";
            this.tb_start_idx.Size = new System.Drawing.Size(63, 21);
            this.tb_start_idx.TabIndex = 12;
            this.tb_start_idx.Text = "0";
            // 
            // tb_simulate_src
            // 
            this.tb_simulate_src.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_simulate_src.Enabled = false;
            this.tb_simulate_src.Location = new System.Drawing.Point(248, 5);
            this.tb_simulate_src.Name = "tb_simulate_src";
            this.tb_simulate_src.Size = new System.Drawing.Size(565, 21);
            this.tb_simulate_src.TabIndex = 11;
            // 
            // lb_simulate_src
            // 
            this.lb_simulate_src.AutoSize = true;
            this.lb_simulate_src.Location = new System.Drawing.Point(187, 8);
            this.lb_simulate_src.Name = "lb_simulate_src";
            this.lb_simulate_src.Size = new System.Drawing.Size(59, 12);
            this.lb_simulate_src.TabIndex = 10;
            this.lb_simulate_src.Text = "模拟轨迹:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 9;
            this.label14.Text = "模拟方式:";
            // 
            // cb_simulate_src
            // 
            this.cb_simulate_src.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_simulate_src.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_simulate_src.FormattingEnabled = true;
            this.cb_simulate_src.Location = new System.Drawing.Point(248, 5);
            this.cb_simulate_src.Name = "cb_simulate_src";
            this.cb_simulate_src.Size = new System.Drawing.Size(565, 20);
            this.cb_simulate_src.TabIndex = 8;
            this.cb_simulate_src.SelectedIndexChanged += new System.EventHandler(this.cb_simulate_src_SelectedIndexChanged);
            // 
            // cb_simulate_type
            // 
            this.cb_simulate_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_simulate_type.FormattingEnabled = true;
            this.cb_simulate_type.Items.AddRange(new object[] {
            "历史轨迹回放",
            "实时轨迹接收"});
            this.cb_simulate_type.Location = new System.Drawing.Point(66, 5);
            this.cb_simulate_type.Name = "cb_simulate_type";
            this.cb_simulate_type.Size = new System.Drawing.Size(115, 20);
            this.cb_simulate_type.TabIndex = 7;
            this.cb_simulate_type.SelectedIndexChanged += new System.EventHandler(this.cb_simulate_type_SelectedIndexChanged);
            // 
            // checkBoxFollow
            // 
            this.checkBoxFollow.AutoSize = true;
            this.checkBoxFollow.Checked = true;
            this.checkBoxFollow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFollow.Location = new System.Drawing.Point(463, 32);
            this.checkBoxFollow.Name = "checkBoxFollow";
            this.checkBoxFollow.Size = new System.Drawing.Size(60, 16);
            this.checkBoxFollow.TabIndex = 6;
            this.checkBoxFollow.Text = "Follow";
            this.checkBoxFollow.UseVisualStyleBackColor = true;
            // 
            // comboBoxTimeSpan
            // 
            this.comboBoxTimeSpan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimeSpan.FormattingEnabled = true;
            this.comboBoxTimeSpan.Items.AddRange(new object[] {
            "0.1秒",
            "0.5秒",
            "1秒",
            "2秒",
            "3秒",
            "5秒",
            "10秒",
            "20秒",
            "30秒",
            "60秒"});
            this.comboBoxTimeSpan.Location = new System.Drawing.Point(306, 30);
            this.comboBoxTimeSpan.Name = "comboBoxTimeSpan";
            this.comboBoxTimeSpan.Size = new System.Drawing.Size(81, 20);
            this.comboBoxTimeSpan.TabIndex = 5;
            // 
            // buttonSetTimerInterval
            // 
            this.buttonSetTimerInterval.Location = new System.Drawing.Point(393, 28);
            this.buttonSetTimerInterval.Name = "buttonSetTimerInterval";
            this.buttonSetTimerInterval.Size = new System.Drawing.Size(64, 23);
            this.buttonSetTimerInterval.TabIndex = 4;
            this.buttonSetTimerInterval.Text = "Set Time";
            this.buttonSetTimerInterval.UseVisualStyleBackColor = true;
            this.buttonSetTimerInterval.Click += new System.EventHandler(this.buttonSetTimerInterval_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(156, 28);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(44, 23);
            this.buttonResume.TabIndex = 3;
            this.buttonResume.Text = "Resume";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(106, 28);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(44, 23);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(56, 28);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(44, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 28);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(44, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // contextMenuStripSelectedArea
            // 
            this.contextMenuStripSelectedArea.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripSelectedArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载地图ToolStripMenuItem,
            this.下载KMLToolStripMenuItem,
            this.允许编辑ToolStripMenuItem,
            this.停止编辑ToolStripMenuItem,
            this.清除区域ToolStripMenuItem});
            this.contextMenuStripSelectedArea.Name = "contextMenuStripSelectedArea";
            this.contextMenuStripSelectedArea.Size = new System.Drawing.Size(127, 114);
            // 
            // 下载地图ToolStripMenuItem
            // 
            this.下载地图ToolStripMenuItem.Name = "下载地图ToolStripMenuItem";
            this.下载地图ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.下载地图ToolStripMenuItem.Text = "下载地图";
            this.下载地图ToolStripMenuItem.Click += new System.EventHandler(this.下载地图ToolStripMenuItem_Click);
            // 
            // 下载KMLToolStripMenuItem
            // 
            this.下载KMLToolStripMenuItem.Name = "下载KMLToolStripMenuItem";
            this.下载KMLToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.下载KMLToolStripMenuItem.Text = "下载KML";
            this.下载KMLToolStripMenuItem.Click += new System.EventHandler(this.下载KMLToolStripMenuItem_Click);
            // 
            // 允许编辑ToolStripMenuItem
            // 
            this.允许编辑ToolStripMenuItem.Name = "允许编辑ToolStripMenuItem";
            this.允许编辑ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.允许编辑ToolStripMenuItem.Text = "允许编辑";
            this.允许编辑ToolStripMenuItem.Click += new System.EventHandler(this.允许编辑ToolStripMenuItem_Click);
            // 
            // 停止编辑ToolStripMenuItem
            // 
            this.停止编辑ToolStripMenuItem.Name = "停止编辑ToolStripMenuItem";
            this.停止编辑ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.停止编辑ToolStripMenuItem.Text = "停止编辑";
            this.停止编辑ToolStripMenuItem.Click += new System.EventHandler(this.停止编辑ToolStripMenuItem_Click);
            // 
            // 清除区域ToolStripMenuItem
            // 
            this.清除区域ToolStripMenuItem.Name = "清除区域ToolStripMenuItem";
            this.清除区域ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.清除区域ToolStripMenuItem.Text = "清除区域";
            this.清除区域ToolStripMenuItem.Click += new System.EventHandler(this.清除区域ToolStripMenuItem_Click);
            // 
            // contextMenuStripLocation
            // 
            this.contextMenuStripLocation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripLocation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.搜索该点的地址ToolStripMenuItem,
            this.以此为起点ToolStripMenuItem,
            this.添加途径点ToolStripMenuItem,
            this.以此为终点ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.显示当前网格地图ToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.contextMenuStripLocation.Name = "contextMenuStripLocation";
            this.contextMenuStripLocation.Size = new System.Drawing.Size(197, 202);
            // 
            // 搜索该点的地址ToolStripMenuItem
            // 
            this.搜索该点的地址ToolStripMenuItem.Name = "搜索该点的地址ToolStripMenuItem";
            this.搜索该点的地址ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.搜索该点的地址ToolStripMenuItem.Text = "拾取该点坐标和地址";
            this.搜索该点的地址ToolStripMenuItem.Click += new System.EventHandler(this.拾取该点坐标和地址ToolStripMenuItem_Click);
            // 
            // 以此为起点ToolStripMenuItem
            // 
            this.以此为起点ToolStripMenuItem.Name = "以此为起点ToolStripMenuItem";
            this.以此为起点ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.以此为起点ToolStripMenuItem.Text = "以此为起点";
            this.以此为起点ToolStripMenuItem.Click += new System.EventHandler(this.以此为起点ToolStripMenuItem_Click);
            // 
            // 添加途径点ToolStripMenuItem
            // 
            this.添加途径点ToolStripMenuItem.Name = "添加途径点ToolStripMenuItem";
            this.添加途径点ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.添加途径点ToolStripMenuItem.Text = "添加途径点";
            this.添加途径点ToolStripMenuItem.Click += new System.EventHandler(this.添加途径点ToolStripMenuItem_Click);
            // 
            // 以此为终点ToolStripMenuItem
            // 
            this.以此为终点ToolStripMenuItem.Name = "以此为终点ToolStripMenuItem";
            this.以此为终点ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.以此为终点ToolStripMenuItem.Text = "以此为终点";
            this.以此为终点ToolStripMenuItem.Click += new System.EventHandler(this.以此为终点ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem3.Text = "显示当前区域地图";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.显示当前区域地图ToolStripMenuItem_Click);
            // 
            // 显示当前网格地图ToolStripMenuItem
            // 
            this.显示当前网格地图ToolStripMenuItem.Name = "显示当前网格地图ToolStripMenuItem";
            this.显示当前网格地图ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.显示当前网格地图ToolStripMenuItem.Text = "显示当前网格地图";
            this.显示当前网格地图ToolStripMenuItem.Click += new System.EventHandler(this.显示当前网格地图ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem4.Text = "显示当前区域城市地图";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.显示当前区域城市地图ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem5.Text = "清除当前区域城市地图";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.清除当前区域城市地图ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem6.Text = "清除所有显示";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.清除所有显示ToolStripMenuItem_Click);
            // 
            // contextMenuStripDisplayInfo
            // 
            this.contextMenuStripDisplayInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改显示信息ToolStripMenuItem,
            this.设置为地图匹配测试底图ToolStripMenuItem,
            this.显示当前区域ToolStripMenuItem,
            this.显示当前网格地图ToolStripMenuItem1,
            this.显示当前区域城市地图ToolStripMenuItem,
            this.清除当前区域地图ToolStripMenuItem,
            this.清除所有显示ToolStripMenuItem,
            this.删除地图ToolStripMenuItem});
            this.contextMenuStripDisplayInfo.Name = "contextMenuStripDisplayInfo";
            this.contextMenuStripDisplayInfo.Size = new System.Drawing.Size(209, 180);
            // 
            // 修改显示信息ToolStripMenuItem
            // 
            this.修改显示信息ToolStripMenuItem.Name = "修改显示信息ToolStripMenuItem";
            this.修改显示信息ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.修改显示信息ToolStripMenuItem.Text = "修改显示信息";
            this.修改显示信息ToolStripMenuItem.Click += new System.EventHandler(this.修改显示信息ToolStripMenuItem_Click);
            // 
            // 设置为地图匹配测试底图ToolStripMenuItem
            // 
            this.设置为地图匹配测试底图ToolStripMenuItem.Name = "设置为地图匹配测试底图ToolStripMenuItem";
            this.设置为地图匹配测试底图ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.设置为地图匹配测试底图ToolStripMenuItem.Text = "设置为地图匹配测试底图";
            this.设置为地图匹配测试底图ToolStripMenuItem.Click += new System.EventHandler(this.设置为地图匹配测试底图ToolStripMenuItem_Click);
            // 
            // 显示当前区域ToolStripMenuItem
            // 
            this.显示当前区域ToolStripMenuItem.Name = "显示当前区域ToolStripMenuItem";
            this.显示当前区域ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.显示当前区域ToolStripMenuItem.Text = "显示当前区域地图";
            this.显示当前区域ToolStripMenuItem.Click += new System.EventHandler(this.显示当前区域地图ToolStripMenuItem_Click);
            // 
            // 显示当前网格地图ToolStripMenuItem1
            // 
            this.显示当前网格地图ToolStripMenuItem1.Name = "显示当前网格地图ToolStripMenuItem1";
            this.显示当前网格地图ToolStripMenuItem1.Size = new System.Drawing.Size(208, 22);
            this.显示当前网格地图ToolStripMenuItem1.Text = "显示当前网格地图";
            this.显示当前网格地图ToolStripMenuItem1.Click += new System.EventHandler(this.显示当前网格地图ToolStripMenuItem_Click);
            // 
            // 显示当前区域城市地图ToolStripMenuItem
            // 
            this.显示当前区域城市地图ToolStripMenuItem.Name = "显示当前区域城市地图ToolStripMenuItem";
            this.显示当前区域城市地图ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.显示当前区域城市地图ToolStripMenuItem.Text = "显示当前区域城市地图";
            this.显示当前区域城市地图ToolStripMenuItem.Click += new System.EventHandler(this.显示当前区域城市地图ToolStripMenuItem_Click);
            // 
            // 清除当前区域地图ToolStripMenuItem
            // 
            this.清除当前区域地图ToolStripMenuItem.Name = "清除当前区域地图ToolStripMenuItem";
            this.清除当前区域地图ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.清除当前区域地图ToolStripMenuItem.Text = "清除当前区域城市地图";
            this.清除当前区域地图ToolStripMenuItem.Click += new System.EventHandler(this.清除当前区域城市地图ToolStripMenuItem_Click);
            // 
            // 清除所有显示ToolStripMenuItem
            // 
            this.清除所有显示ToolStripMenuItem.Name = "清除所有显示ToolStripMenuItem";
            this.清除所有显示ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.清除所有显示ToolStripMenuItem.Text = "清除所有显示";
            this.清除所有显示ToolStripMenuItem.Click += new System.EventHandler(this.清除所有显示ToolStripMenuItem_Click);
            // 
            // 删除地图ToolStripMenuItem
            // 
            this.删除地图ToolStripMenuItem.Name = "删除地图ToolStripMenuItem";
            this.删除地图ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.删除地图ToolStripMenuItem.Text = "删除地图";
            this.删除地图ToolStripMenuItem.Click += new System.EventHandler(this.删除地图ToolStripMenuItem_Click);
            // 
            // contextMenuStripHistoryRoute
            // 
            this.contextMenuStripHistoryRoute.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.导出轨迹ToolStripMenuItem,
            this.删除轨迹ToolStripMenuItem});
            this.contextMenuStripHistoryRoute.Name = "contextMenuStripDisplayInfo";
            this.contextMenuStripHistoryRoute.Size = new System.Drawing.Size(161, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "缩放至图层";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.缩放至图层ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem2.Text = "设置为模拟轨迹";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.设置为模拟轨迹ToolStripMenuItem_Click);
            // 
            // 导出轨迹ToolStripMenuItem
            // 
            this.导出轨迹ToolStripMenuItem.Name = "导出轨迹ToolStripMenuItem";
            this.导出轨迹ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.导出轨迹ToolStripMenuItem.Text = "导出轨迹";
            this.导出轨迹ToolStripMenuItem.Click += new System.EventHandler(this.导出轨迹ToolStripMenuItem_Click);
            // 
            // 删除轨迹ToolStripMenuItem
            // 
            this.删除轨迹ToolStripMenuItem.Name = "删除轨迹ToolStripMenuItem";
            this.删除轨迹ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.删除轨迹ToolStripMenuItem.Text = "删除轨迹";
            this.删除轨迹ToolStripMenuItem.Click += new System.EventHandler(this.删除轨迹ToolStripMenuItem_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Transparent;
            this.splitter1.Location = new System.Drawing.Point(297, 25);
            this.splitter1.MinSize = 5;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 687);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.AssociatedSplitter = this.splitter1;
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.CaptionFont = new System.Drawing.Font("Segoe UI", 11.75F, System.Drawing.FontStyle.Bold);
            this.panelMenu.CaptionHeight = 27;
            this.panelMenu.Controls.Add(this.xPanderPanelList1);
            this.panelMenu.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panelMenu.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelMenu.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.panelMenu.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelMenu.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panelMenu.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panelMenu.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.panelMenu.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.panelMenu.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.panelMenu.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMenu.Image = null;
            this.panelMenu.Location = new System.Drawing.Point(0, 25);
            this.panelMenu.MinimumSize = new System.Drawing.Size(27, 27);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.panelMenu.ShowExpandIcon = true;
            this.panelMenu.Size = new System.Drawing.Size(297, 687);
            this.panelMenu.TabIndex = 16;
            this.panelMenu.Text = "地图工具";
            this.panelMenu.ToolTipTextCloseIcon = null;
            this.panelMenu.ToolTipTextExpandIconPanelCollapsed = null;
            this.panelMenu.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // xPanderPanelList1
            // 
            this.xPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal;
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel_coord_pickup);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel2);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel3);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanelChinaRegion);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel4);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel5);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel6);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanelTerminalMap);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel1);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel7);
            this.xPanderPanelList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanderPanelList1.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderPanelList1.Location = new System.Drawing.Point(0, 28);
            this.xPanderPanelList1.Name = "xPanderPanelList1";
            this.xPanderPanelList1.PanelColors = null;
            this.xPanderPanelList1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelList1.Size = new System.Drawing.Size(297, 658);
            this.xPanderPanelList1.TabIndex = 0;
            this.xPanderPanelList1.Text = "xPanderPanelList1";
            // 
            // xPanderPanel_coord_pickup
            // 
            this.xPanderPanel_coord_pickup.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel_coord_pickup.Controls.Add(this.btn_coord_pickup_clean);
            this.xPanderPanel_coord_pickup.Controls.Add(this.cb_get_coord_from_map);
            this.xPanderPanel_coord_pickup.Controls.Add(this.btn_query_by_addrass);
            this.xPanderPanel_coord_pickup.Controls.Add(this.tb_address);
            this.xPanderPanel_coord_pickup.Controls.Add(this.label5);
            this.xPanderPanel_coord_pickup.Controls.Add(this.btn_query_by_coord);
            this.xPanderPanel_coord_pickup.Controls.Add(this.tb_lon_lat_bd09);
            this.xPanderPanel_coord_pickup.Controls.Add(this.label4);
            this.xPanderPanel_coord_pickup.Controls.Add(this.tb_lon_lat_gcj02);
            this.xPanderPanel_coord_pickup.Controls.Add(this.label3);
            this.xPanderPanel_coord_pickup.Controls.Add(this.tb_lon_lat_wgs84);
            this.xPanderPanel_coord_pickup.Controls.Add(this.label2);
            this.xPanderPanel_coord_pickup.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel_coord_pickup.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel_coord_pickup.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel_coord_pickup.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel_coord_pickup.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_coord_pickup.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_coord_pickup.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel_coord_pickup.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel_coord_pickup.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_coord_pickup.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_coord_pickup.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel_coord_pickup.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel_coord_pickup.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel_coord_pickup.Expand = true;
            this.xPanderPanel_coord_pickup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_coord_pickup.Image = null;
            this.xPanderPanel_coord_pickup.Name = "xPanderPanel_coord_pickup";
            this.xPanderPanel_coord_pickup.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel_coord_pickup.Size = new System.Drawing.Size(297, 433);
            this.xPanderPanel_coord_pickup.TabIndex = 5;
            this.xPanderPanel_coord_pickup.Text = "坐标拾取";
            this.xPanderPanel_coord_pickup.ToolTipTextCloseIcon = null;
            this.xPanderPanel_coord_pickup.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel_coord_pickup.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btn_coord_pickup_clean
            // 
            this.btn_coord_pickup_clean.Location = new System.Drawing.Point(96, 211);
            this.btn_coord_pickup_clean.Name = "btn_coord_pickup_clean";
            this.btn_coord_pickup_clean.Size = new System.Drawing.Size(75, 23);
            this.btn_coord_pickup_clean.TabIndex = 12;
            this.btn_coord_pickup_clean.Text = "清除";
            this.btn_coord_pickup_clean.UseVisualStyleBackColor = true;
            this.btn_coord_pickup_clean.Click += new System.EventHandler(this.btn_coord_pickup_clean_Click);
            // 
            // cb_get_coord_from_map
            // 
            this.cb_get_coord_from_map.AutoSize = true;
            this.cb_get_coord_from_map.Location = new System.Drawing.Point(10, 37);
            this.cb_get_coord_from_map.Name = "cb_get_coord_from_map";
            this.cb_get_coord_from_map.Size = new System.Drawing.Size(132, 16);
            this.cb_get_coord_from_map.TabIndex = 11;
            this.cb_get_coord_from_map.Text = "地图选点(鼠标右键)";
            this.cb_get_coord_from_map.UseVisualStyleBackColor = true;
            // 
            // btn_query_by_addrass
            // 
            this.btn_query_by_addrass.Location = new System.Drawing.Point(10, 319);
            this.btn_query_by_addrass.Name = "btn_query_by_addrass";
            this.btn_query_by_addrass.Size = new System.Drawing.Size(75, 23);
            this.btn_query_by_addrass.TabIndex = 9;
            this.btn_query_by_addrass.Text = "按地址查询";
            this.btn_query_by_addrass.UseVisualStyleBackColor = true;
            this.btn_query_by_addrass.Click += new System.EventHandler(this.btn_query_by_addrass_Click);
            // 
            // tb_address
            // 
            this.tb_address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_address.Location = new System.Drawing.Point(12, 267);
            this.tb_address.Multiline = true;
            this.tb_address.Name = "tb_address";
            this.tb_address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_address.Size = new System.Drawing.Size(279, 44);
            this.tb_address.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "地址：\t";
            // 
            // btn_query_by_coord
            // 
            this.btn_query_by_coord.Location = new System.Drawing.Point(10, 211);
            this.btn_query_by_coord.Name = "btn_query_by_coord";
            this.btn_query_by_coord.Size = new System.Drawing.Size(75, 23);
            this.btn_query_by_coord.TabIndex = 6;
            this.btn_query_by_coord.Text = "跳转";
            this.btn_query_by_coord.UseVisualStyleBackColor = true;
            this.btn_query_by_coord.Click += new System.EventHandler(this.btn_query_by_coord_Click);
            // 
            // tb_lon_lat_bd09
            // 
            this.tb_lon_lat_bd09.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_lon_lat_bd09.Location = new System.Drawing.Point(12, 177);
            this.tb_lon_lat_bd09.Name = "tb_lon_lat_bd09";
            this.tb_lon_lat_bd09.Size = new System.Drawing.Size(279, 21);
            this.tb_lon_lat_bd09.TabIndex = 5;
            this.tb_lon_lat_bd09.TextChanged += new System.EventHandler(this.tb_lon_lat_bd09_TextChanged);
            this.tb_lon_lat_bd09.Validated += new System.EventHandler(this.tb_lon_lat_bd09_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "BD09坐标系(经度,纬度)：\t";
            // 
            // tb_lon_lat_gcj02
            // 
            this.tb_lon_lat_gcj02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_lon_lat_gcj02.Location = new System.Drawing.Point(12, 127);
            this.tb_lon_lat_gcj02.Name = "tb_lon_lat_gcj02";
            this.tb_lon_lat_gcj02.Size = new System.Drawing.Size(279, 21);
            this.tb_lon_lat_gcj02.TabIndex = 3;
            this.tb_lon_lat_gcj02.TextChanged += new System.EventHandler(this.tb_lon_lat_gcj02_TextChanged);
            this.tb_lon_lat_gcj02.Validated += new System.EventHandler(this.tb_lon_lat_gcj02_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "GCJ02坐标系(经度,纬度)：\t";
            // 
            // tb_lon_lat_wgs84
            // 
            this.tb_lon_lat_wgs84.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_lon_lat_wgs84.Location = new System.Drawing.Point(12, 80);
            this.tb_lon_lat_wgs84.Name = "tb_lon_lat_wgs84";
            this.tb_lon_lat_wgs84.Size = new System.Drawing.Size(279, 21);
            this.tb_lon_lat_wgs84.TabIndex = 1;
            this.tb_lon_lat_wgs84.TextChanged += new System.EventHandler(this.tb_lon_lat_wgs84_TextChanged);
            this.tb_lon_lat_wgs84.Validated += new System.EventHandler(this.tb_lon_lat_wgs84_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "WGS84坐标系(经度,纬度)：\t";
            // 
            // xPanderPanel2
            // 
            this.xPanderPanel2.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel2.Controls.Add(this.buttonPoiClean);
            this.xPanderPanel2.Controls.Add(this.buttonPoiSave);
            this.xPanderPanel2.Controls.Add(this.buttonPOISearch);
            this.xPanderPanel2.Controls.Add(this.comboBoxPoiSave);
            this.xPanderPanel2.Controls.Add(this.label8);
            this.xPanderPanel2.Controls.Add(this.comboBoxCity);
            this.xPanderPanel2.Controls.Add(this.label6);
            this.xPanderPanel2.Controls.Add(this.comboBoxProvince);
            this.xPanderPanel2.Controls.Add(this.label7);
            this.xPanderPanel2.Controls.Add(this.textBoxPOIkeyword);
            this.xPanderPanel2.Controls.Add(this.label9);
            this.xPanderPanel2.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel2.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel2.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel2.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel2.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel2.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel2.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel2.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel2.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel2.Image = null;
            this.xPanderPanel2.Name = "xPanderPanel2";
            this.xPanderPanel2.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel2.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanel2.TabIndex = 6;
            this.xPanderPanel2.Text = "POI查询";
            this.xPanderPanel2.ToolTipTextCloseIcon = null;
            this.xPanderPanel2.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel2.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // buttonPoiClean
            // 
            this.buttonPoiClean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPoiClean.Location = new System.Drawing.Point(170, 110);
            this.buttonPoiClean.Name = "buttonPoiClean";
            this.buttonPoiClean.Size = new System.Drawing.Size(56, 23);
            this.buttonPoiClean.TabIndex = 33;
            this.buttonPoiClean.Text = "清除";
            this.buttonPoiClean.UseVisualStyleBackColor = true;
            this.buttonPoiClean.Click += new System.EventHandler(this.buttonPoiClean_Click);
            // 
            // buttonPoiSave
            // 
            this.buttonPoiSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPoiSave.Location = new System.Drawing.Point(234, 110);
            this.buttonPoiSave.Name = "buttonPoiSave";
            this.buttonPoiSave.Size = new System.Drawing.Size(56, 23);
            this.buttonPoiSave.TabIndex = 32;
            this.buttonPoiSave.Text = "保存";
            this.buttonPoiSave.UseVisualStyleBackColor = true;
            this.buttonPoiSave.Click += new System.EventHandler(this.buttonPoiSave_Click);
            // 
            // buttonPOISearch
            // 
            this.buttonPOISearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPOISearch.Location = new System.Drawing.Point(233, 83);
            this.buttonPOISearch.Name = "buttonPOISearch";
            this.buttonPOISearch.Size = new System.Drawing.Size(57, 23);
            this.buttonPOISearch.TabIndex = 31;
            this.buttonPOISearch.Text = "查询";
            this.buttonPOISearch.UseVisualStyleBackColor = true;
            this.buttonPOISearch.Click += new System.EventHandler(this.buttonPOISearch_Click);
            // 
            // comboBoxPoiSave
            // 
            this.comboBoxPoiSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPoiSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPoiSave.FormattingEnabled = true;
            this.comboBoxPoiSave.Items.AddRange(new object[] {
            "Excel存储"});
            this.comboBoxPoiSave.Location = new System.Drawing.Point(58, 112);
            this.comboBoxPoiSave.Name = "comboBoxPoiSave";
            this.comboBoxPoiSave.Size = new System.Drawing.Size(103, 20);
            this.comboBoxPoiSave.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "POI保存：";
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(58, 59);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(232, 20);
            this.comboBoxCity.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "市：";
            // 
            // comboBoxProvince
            // 
            this.comboBoxProvince.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProvince.FormattingEnabled = true;
            this.comboBoxProvince.Location = new System.Drawing.Point(58, 33);
            this.comboBoxProvince.Name = "comboBoxProvince";
            this.comboBoxProvince.Size = new System.Drawing.Size(232, 20);
            this.comboBoxProvince.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "省：";
            // 
            // textBoxPOIkeyword
            // 
            this.textBoxPOIkeyword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPOIkeyword.Location = new System.Drawing.Point(58, 85);
            this.textBoxPOIkeyword.Name = "textBoxPOIkeyword";
            this.textBoxPOIkeyword.Size = new System.Drawing.Size(169, 21);
            this.textBoxPOIkeyword.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "关键字：";
            // 
            // xPanderPanel3
            // 
            this.xPanderPanel3.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel3.Controls.Add(this.groupBox9);
            this.xPanderPanel3.Controls.Add(this.groupBox8);
            this.xPanderPanel3.Controls.Add(this.gbMapImage);
            this.xPanderPanel3.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel3.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel3.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel3.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel3.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel3.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel3.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel3.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel3.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel3.Image = null;
            this.xPanderPanel3.Name = "xPanderPanel3";
            this.xPanderPanel3.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel3.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanel3.TabIndex = 7;
            this.xPanderPanel3.Text = "地图下载";
            this.xPanderPanel3.ToolTipTextCloseIcon = null;
            this.xPanderPanel3.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel3.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.comboBoxStore);
            this.groupBox9.Controls.Add(this.buttonMapDownload);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Location = new System.Drawing.Point(9, 184);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(281, 61);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "下载地图";
            // 
            // comboBoxStore
            // 
            this.comboBoxStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStore.FormattingEnabled = true;
            this.comboBoxStore.Items.AddRange(new object[] {
            "SQLite数据库",
            "本地磁盘（切片）"});
            this.comboBoxStore.Location = new System.Drawing.Point(63, 22);
            this.comboBoxStore.Name = "comboBoxStore";
            this.comboBoxStore.Size = new System.Drawing.Size(131, 20);
            this.comboBoxStore.TabIndex = 5;
            // 
            // buttonMapDownload
            // 
            this.buttonMapDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMapDownload.Location = new System.Drawing.Point(200, 20);
            this.buttonMapDownload.Name = "buttonMapDownload";
            this.buttonMapDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonMapDownload.TabIndex = 4;
            this.buttonMapDownload.Text = "下载切片";
            this.buttonMapDownload.UseVisualStyleBackColor = true;
            this.buttonMapDownload.Click += new System.EventHandler(this.buttonMapDownload_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "存储方式：";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.buttonCleanDownloadArea);
            this.groupBox8.Controls.Add(this.buttonDrawPolygon);
            this.groupBox8.Controls.Add(this.buttonDrawRectangle);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Location = new System.Drawing.Point(9, 37);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(281, 74);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "设定下载区域";
            // 
            // buttonCleanDownloadArea
            // 
            this.buttonCleanDownloadArea.Location = new System.Drawing.Point(183, 20);
            this.buttonCleanDownloadArea.Name = "buttonCleanDownloadArea";
            this.buttonCleanDownloadArea.Size = new System.Drawing.Size(75, 23);
            this.buttonCleanDownloadArea.TabIndex = 6;
            this.buttonCleanDownloadArea.Text = "清除区域";
            this.buttonCleanDownloadArea.UseVisualStyleBackColor = true;
            this.buttonCleanDownloadArea.Click += new System.EventHandler(this.buttonCleanDownloadArea_Click);
            // 
            // buttonDrawPolygon
            // 
            this.buttonDrawPolygon.Location = new System.Drawing.Point(102, 20);
            this.buttonDrawPolygon.Name = "buttonDrawPolygon";
            this.buttonDrawPolygon.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawPolygon.TabIndex = 5;
            this.buttonDrawPolygon.Text = "多边形";
            this.buttonDrawPolygon.UseVisualStyleBackColor = true;
            this.buttonDrawPolygon.Click += new System.EventHandler(this.buttonDrawPolygon_Click);
            // 
            // buttonDrawRectangle
            // 
            this.buttonDrawRectangle.Location = new System.Drawing.Point(21, 20);
            this.buttonDrawRectangle.Name = "buttonDrawRectangle";
            this.buttonDrawRectangle.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawRectangle.TabIndex = 5;
            this.buttonDrawRectangle.Text = "矩形";
            this.buttonDrawRectangle.UseVisualStyleBackColor = true;
            this.buttonDrawRectangle.Click += new System.EventHandler(this.buttonDrawRectangle_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(233, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "注：按行政区下载请到行政边界列表中选择";
            // 
            // gbMapImage
            // 
            this.gbMapImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMapImage.Controls.Add(this.comboBoxZoom);
            this.gbMapImage.Controls.Add(this.buttonMapImage);
            this.gbMapImage.Controls.Add(this.label10);
            this.gbMapImage.Location = new System.Drawing.Point(9, 117);
            this.gbMapImage.Name = "gbMapImage";
            this.gbMapImage.Size = new System.Drawing.Size(281, 61);
            this.gbMapImage.TabIndex = 6;
            this.gbMapImage.TabStop = false;
            this.gbMapImage.Text = "拼接大图";
            // 
            // comboBoxZoom
            // 
            this.comboBoxZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZoom.FormattingEnabled = true;
            this.comboBoxZoom.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.comboBoxZoom.Location = new System.Drawing.Point(63, 22);
            this.comboBoxZoom.Name = "comboBoxZoom";
            this.comboBoxZoom.Size = new System.Drawing.Size(131, 20);
            this.comboBoxZoom.TabIndex = 5;
            // 
            // buttonMapImage
            // 
            this.buttonMapImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMapImage.Location = new System.Drawing.Point(200, 20);
            this.buttonMapImage.Name = "buttonMapImage";
            this.buttonMapImage.Size = new System.Drawing.Size(75, 23);
            this.buttonMapImage.TabIndex = 4;
            this.buttonMapImage.Text = "拼接大图";
            this.buttonMapImage.UseVisualStyleBackColor = true;
            this.buttonMapImage.Click += new System.EventHandler(this.buttonMapImage_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "显示等级：";
            // 
            // xPanderPanelChinaRegion
            // 
            this.xPanderPanelChinaRegion.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanelChinaRegion.Controls.Add(this.advTreeChina);
            this.xPanderPanelChinaRegion.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanelChinaRegion.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanelChinaRegion.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanelChinaRegion.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanelChinaRegion.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelChinaRegion.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelChinaRegion.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanelChinaRegion.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelChinaRegion.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelChinaRegion.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelChinaRegion.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelChinaRegion.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelChinaRegion.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanelChinaRegion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelChinaRegion.Image = null;
            this.xPanderPanelChinaRegion.Name = "xPanderPanelChinaRegion";
            this.xPanderPanelChinaRegion.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelChinaRegion.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanelChinaRegion.TabIndex = 8;
            this.xPanderPanelChinaRegion.Text = "中国行政边界";
            this.xPanderPanelChinaRegion.ToolTipTextCloseIcon = null;
            this.xPanderPanelChinaRegion.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanelChinaRegion.ToolTipTextExpandIconPanelExpanded = null;
            this.xPanderPanelChinaRegion.ExpandClick += new System.EventHandler<System.EventArgs>(this.xPanderPanelChinaRegion_ExpandClick);
            // 
            // advTreeChina
            // 
            this.advTreeChina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeChina.Location = new System.Drawing.Point(1, 25);
            this.advTreeChina.Name = "advTreeChina";
            this.advTreeChina.Size = new System.Drawing.Size(295, 0);
            this.advTreeChina.TabIndex = 0;
            // 
            // xPanderPanel4
            // 
            this.xPanderPanel4.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel4.Controls.Add(this.groupBox5);
            this.xPanderPanel4.Controls.Add(this.groupBox4);
            this.xPanderPanel4.Controls.Add(this.groupBox3);
            this.xPanderPanel4.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel4.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel4.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel4.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel4.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel4.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel4.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel4.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel4.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel4.Image = null;
            this.xPanderPanel4.Name = "xPanderPanel4";
            this.xPanderPanel4.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel4.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanel4.TabIndex = 9;
            this.xPanderPanel4.Text = "地图覆盖物";
            this.xPanderPanel4.ToolTipTextCloseIcon = null;
            this.xPanderPanel4.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel4.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.buttonClearDemoOverlay);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.checkBoxMarker);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Location = new System.Drawing.Point(5, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(285, 306);
            this.groupBox5.TabIndex = 30;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Marker";
            // 
            // buttonClearDemoOverlay
            // 
            this.buttonClearDemoOverlay.Location = new System.Drawing.Point(211, 18);
            this.buttonClearDemoOverlay.Name = "buttonClearDemoOverlay";
            this.buttonClearDemoOverlay.Size = new System.Drawing.Size(67, 23);
            this.buttonClearDemoOverlay.TabIndex = 8;
            this.buttonClearDemoOverlay.Text = "清除所有";
            this.buttonClearDemoOverlay.UseVisualStyleBackColor = true;
            this.buttonClearDemoOverlay.Click += new System.EventHandler(this.buttonClearDemoOverlay_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rbGMapMarkerScopeCircleAnimate);
            this.groupBox2.Controls.Add(this.rbGMapMarkerScopePieAnimate);
            this.groupBox2.Controls.Add(this.rbGMapTipMarker);
            this.groupBox2.Controls.Add(this.rbGMapDirectionMarker);
            this.groupBox2.Controls.Add(this.rbGMapGifMarker);
            this.groupBox2.Controls.Add(this.rbGMapFlashMarker);
            this.groupBox2.Controls.Add(this.rbGMarkerGoogle);
            this.groupBox2.Location = new System.Drawing.Point(10, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 200);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Marker Type";
            // 
            // rbGMapMarkerScopeCircleAnimate
            // 
            this.rbGMapMarkerScopeCircleAnimate.AutoSize = true;
            this.rbGMapMarkerScopeCircleAnimate.Location = new System.Drawing.Point(5, 177);
            this.rbGMapMarkerScopeCircleAnimate.Name = "rbGMapMarkerScopeCircleAnimate";
            this.rbGMapMarkerScopeCircleAnimate.Size = new System.Drawing.Size(191, 16);
            this.rbGMapMarkerScopeCircleAnimate.TabIndex = 6;
            this.rbGMapMarkerScopeCircleAnimate.Text = "GMapMarkerScopeCircleAnimate";
            this.rbGMapMarkerScopeCircleAnimate.UseVisualStyleBackColor = true;
            // 
            // rbGMapMarkerScopePieAnimate
            // 
            this.rbGMapMarkerScopePieAnimate.AutoSize = true;
            this.rbGMapMarkerScopePieAnimate.Location = new System.Drawing.Point(5, 151);
            this.rbGMapMarkerScopePieAnimate.Name = "rbGMapMarkerScopePieAnimate";
            this.rbGMapMarkerScopePieAnimate.Size = new System.Drawing.Size(173, 16);
            this.rbGMapMarkerScopePieAnimate.TabIndex = 5;
            this.rbGMapMarkerScopePieAnimate.Text = "GMapMarkerScopePieAnimate";
            this.rbGMapMarkerScopePieAnimate.UseVisualStyleBackColor = true;
            // 
            // rbGMapTipMarker
            // 
            this.rbGMapTipMarker.AutoSize = true;
            this.rbGMapTipMarker.Location = new System.Drawing.Point(5, 125);
            this.rbGMapTipMarker.Name = "rbGMapTipMarker";
            this.rbGMapTipMarker.Size = new System.Drawing.Size(101, 16);
            this.rbGMapTipMarker.TabIndex = 4;
            this.rbGMapTipMarker.Text = "GMapTipMarker";
            this.rbGMapTipMarker.UseVisualStyleBackColor = true;
            // 
            // rbGMapDirectionMarker
            // 
            this.rbGMapDirectionMarker.AutoSize = true;
            this.rbGMapDirectionMarker.Location = new System.Drawing.Point(5, 99);
            this.rbGMapDirectionMarker.Name = "rbGMapDirectionMarker";
            this.rbGMapDirectionMarker.Size = new System.Drawing.Size(137, 16);
            this.rbGMapDirectionMarker.TabIndex = 3;
            this.rbGMapDirectionMarker.Text = "GMapDirectionMarker";
            this.rbGMapDirectionMarker.UseVisualStyleBackColor = true;
            // 
            // rbGMapGifMarker
            // 
            this.rbGMapGifMarker.AutoSize = true;
            this.rbGMapGifMarker.Location = new System.Drawing.Point(5, 73);
            this.rbGMapGifMarker.Name = "rbGMapGifMarker";
            this.rbGMapGifMarker.Size = new System.Drawing.Size(101, 16);
            this.rbGMapGifMarker.TabIndex = 2;
            this.rbGMapGifMarker.Text = "GMapGifMarker";
            this.rbGMapGifMarker.UseVisualStyleBackColor = true;
            // 
            // rbGMapFlashMarker
            // 
            this.rbGMapFlashMarker.AutoSize = true;
            this.rbGMapFlashMarker.Location = new System.Drawing.Point(5, 47);
            this.rbGMapFlashMarker.Name = "rbGMapFlashMarker";
            this.rbGMapFlashMarker.Size = new System.Drawing.Size(113, 16);
            this.rbGMapFlashMarker.TabIndex = 1;
            this.rbGMapFlashMarker.Text = "GMapFlashMarker";
            this.rbGMapFlashMarker.UseVisualStyleBackColor = true;
            // 
            // rbGMarkerGoogle
            // 
            this.rbGMarkerGoogle.AutoSize = true;
            this.rbGMarkerGoogle.Checked = true;
            this.rbGMarkerGoogle.Location = new System.Drawing.Point(5, 21);
            this.rbGMarkerGoogle.Name = "rbGMarkerGoogle";
            this.rbGMarkerGoogle.Size = new System.Drawing.Size(101, 16);
            this.rbGMarkerGoogle.TabIndex = 0;
            this.rbGMarkerGoogle.TabStop = true;
            this.rbGMarkerGoogle.Text = "GMarkerGoogle";
            this.rbGMarkerGoogle.UseVisualStyleBackColor = true;
            // 
            // checkBoxMarker
            // 
            this.checkBoxMarker.AutoSize = true;
            this.checkBoxMarker.Location = new System.Drawing.Point(10, 20);
            this.checkBoxMarker.Name = "checkBoxMarker";
            this.checkBoxMarker.Size = new System.Drawing.Size(108, 16);
            this.checkBoxMarker.TabIndex = 25;
            this.checkBoxMarker.Text = "右键添加Marker";
            this.checkBoxMarker.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonStopBlink);
            this.groupBox1.Controls.Add(this.buttonBeginBlink);
            this.groupBox1.Location = new System.Drawing.Point(10, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 50);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Flash Marker";
            // 
            // buttonStopBlink
            // 
            this.buttonStopBlink.Location = new System.Drawing.Point(151, 20);
            this.buttonStopBlink.Name = "buttonStopBlink";
            this.buttonStopBlink.Size = new System.Drawing.Size(87, 23);
            this.buttonStopBlink.TabIndex = 23;
            this.buttonStopBlink.Text = "Stop Blink";
            this.buttonStopBlink.UseVisualStyleBackColor = true;
            this.buttonStopBlink.Click += new System.EventHandler(this.buttonStopBlink_Click);
            // 
            // buttonBeginBlink
            // 
            this.buttonBeginBlink.Location = new System.Drawing.Point(31, 20);
            this.buttonBeginBlink.Name = "buttonBeginBlink";
            this.buttonBeginBlink.Size = new System.Drawing.Size(87, 23);
            this.buttonBeginBlink.TabIndex = 22;
            this.buttonBeginBlink.Text = "Marker Blink";
            this.buttonBeginBlink.UseVisualStyleBackColor = true;
            this.buttonBeginBlink.Click += new System.EventHandler(this.buttonBeginBlink_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.buttonHeatMarker);
            this.groupBox4.Location = new System.Drawing.Point(5, 430);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(286, 45);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Heat Marker";
            // 
            // buttonHeatMarker
            // 
            this.buttonHeatMarker.Location = new System.Drawing.Point(10, 17);
            this.buttonHeatMarker.Name = "buttonHeatMarker";
            this.buttonHeatMarker.Size = new System.Drawing.Size(106, 23);
            this.buttonHeatMarker.TabIndex = 22;
            this.buttonHeatMarker.Text = "Heat Marker";
            this.buttonHeatMarker.UseVisualStyleBackColor = true;
            this.buttonHeatMarker.Click += new System.EventHandler(this.buttonHeatMarker_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonLine);
            this.groupBox3.Controls.Add(this.buttonPolyline);
            this.groupBox3.Controls.Add(this.buttonCircle);
            this.groupBox3.Controls.Add(this.buttonRectangle);
            this.groupBox3.Controls.Add(this.buttonPolygon);
            this.groupBox3.Location = new System.Drawing.Point(5, 340);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 84);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Draw Polygon";
            // 
            // buttonLine
            // 
            this.buttonLine.Location = new System.Drawing.Point(10, 20);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(67, 23);
            this.buttonLine.TabIndex = 10;
            this.buttonLine.Text = "Line";
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonPolyline
            // 
            this.buttonPolyline.Location = new System.Drawing.Point(89, 20);
            this.buttonPolyline.Name = "buttonPolyline";
            this.buttonPolyline.Size = new System.Drawing.Size(67, 23);
            this.buttonPolyline.TabIndex = 9;
            this.buttonPolyline.Text = "Polyline";
            this.buttonPolyline.UseVisualStyleBackColor = true;
            this.buttonPolyline.Click += new System.EventHandler(this.buttonPolyline_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(166, 20);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(67, 23);
            this.buttonCircle.TabIndex = 5;
            this.buttonCircle.Text = "Circle";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Location = new System.Drawing.Point(10, 49);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(67, 23);
            this.buttonRectangle.TabIndex = 6;
            this.buttonRectangle.Text = "Rectangle";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonPolygon
            // 
            this.buttonPolygon.Location = new System.Drawing.Point(89, 49);
            this.buttonPolygon.Name = "buttonPolygon";
            this.buttonPolygon.Size = new System.Drawing.Size(67, 23);
            this.buttonPolygon.TabIndex = 7;
            this.buttonPolygon.Text = "Polygon";
            this.buttonPolygon.UseVisualStyleBackColor = true;
            this.buttonPolygon.Click += new System.EventHandler(this.buttonPolygon_Click);
            // 
            // xPanderPanel5
            // 
            this.xPanderPanel5.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel5.Controls.Add(this.buttonNaviEndDel);
            this.xPanderPanel5.Controls.Add(this.buttonNaviWay3Del);
            this.xPanderPanel5.Controls.Add(this.textBoxNaviWay3);
            this.xPanderPanel5.Controls.Add(this.label31);
            this.xPanderPanel5.Controls.Add(this.buttonNaviWay2Del);
            this.xPanderPanel5.Controls.Add(this.textBoxNaviWay2);
            this.xPanderPanel5.Controls.Add(this.label30);
            this.xPanderPanel5.Controls.Add(this.buttonNaviWay1Del);
            this.xPanderPanel5.Controls.Add(this.buttonNaviStartDel);
            this.xPanderPanel5.Controls.Add(this.textBoxNaviWay1);
            this.xPanderPanel5.Controls.Add(this.label28);
            this.xPanderPanel5.Controls.Add(this.buttonNaviExport);
            this.xPanderPanel5.Controls.Add(this.buttonCleanRoute);
            this.xPanderPanel5.Controls.Add(this.buttonNaviGetRoute);
            this.xPanderPanel5.Controls.Add(this.textBoxNaviEndPoint);
            this.xPanderPanel5.Controls.Add(this.label13);
            this.xPanderPanel5.Controls.Add(this.textBoxNaviStartPoint);
            this.xPanderPanel5.Controls.Add(this.label1);
            this.xPanderPanel5.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel5.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel5.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel5.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel5.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel5.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel5.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel5.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel5.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel5.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel5.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel5.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel5.Image = null;
            this.xPanderPanel5.Name = "xPanderPanel5";
            this.xPanderPanel5.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel5.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanel5.TabIndex = 10;
            this.xPanderPanel5.Text = "导航路线";
            this.xPanderPanel5.ToolTipTextCloseIcon = null;
            this.xPanderPanel5.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel5.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // buttonNaviEndDel
            // 
            this.buttonNaviEndDel.Location = new System.Drawing.Point(260, 160);
            this.buttonNaviEndDel.Name = "buttonNaviEndDel";
            this.buttonNaviEndDel.Size = new System.Drawing.Size(27, 23);
            this.buttonNaviEndDel.TabIndex = 17;
            this.buttonNaviEndDel.Text = "x";
            this.buttonNaviEndDel.UseVisualStyleBackColor = true;
            this.buttonNaviEndDel.Click += new System.EventHandler(this.buttonNaviEndDel_Click);
            // 
            // buttonNaviWay3Del
            // 
            this.buttonNaviWay3Del.Location = new System.Drawing.Point(260, 128);
            this.buttonNaviWay3Del.Name = "buttonNaviWay3Del";
            this.buttonNaviWay3Del.Size = new System.Drawing.Size(27, 23);
            this.buttonNaviWay3Del.TabIndex = 16;
            this.buttonNaviWay3Del.Text = "x";
            this.buttonNaviWay3Del.UseVisualStyleBackColor = true;
            this.buttonNaviWay3Del.Click += new System.EventHandler(this.buttonNaviWay3Del_Click);
            // 
            // textBoxNaviWay3
            // 
            this.textBoxNaviWay3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNaviWay3.Location = new System.Drawing.Point(46, 129);
            this.textBoxNaviWay3.Name = "textBoxNaviWay3";
            this.textBoxNaviWay3.Size = new System.Drawing.Size(208, 21);
            this.textBoxNaviWay3.TabIndex = 15;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(2, 132);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(47, 12);
            this.label31.TabIndex = 14;
            this.label31.Text = "途径3：";
            // 
            // buttonNaviWay2Del
            // 
            this.buttonNaviWay2Del.Location = new System.Drawing.Point(260, 96);
            this.buttonNaviWay2Del.Name = "buttonNaviWay2Del";
            this.buttonNaviWay2Del.Size = new System.Drawing.Size(27, 23);
            this.buttonNaviWay2Del.TabIndex = 13;
            this.buttonNaviWay2Del.Text = "x";
            this.buttonNaviWay2Del.UseVisualStyleBackColor = true;
            this.buttonNaviWay2Del.Click += new System.EventHandler(this.buttonNaviWay2Del_Click);
            // 
            // textBoxNaviWay2
            // 
            this.textBoxNaviWay2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNaviWay2.Location = new System.Drawing.Point(46, 97);
            this.textBoxNaviWay2.Name = "textBoxNaviWay2";
            this.textBoxNaviWay2.Size = new System.Drawing.Size(208, 21);
            this.textBoxNaviWay2.TabIndex = 12;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(2, 100);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(47, 12);
            this.label30.TabIndex = 11;
            this.label30.Text = "途径2：";
            // 
            // buttonNaviWay1Del
            // 
            this.buttonNaviWay1Del.Location = new System.Drawing.Point(260, 66);
            this.buttonNaviWay1Del.Name = "buttonNaviWay1Del";
            this.buttonNaviWay1Del.Size = new System.Drawing.Size(27, 23);
            this.buttonNaviWay1Del.TabIndex = 10;
            this.buttonNaviWay1Del.Text = "x";
            this.buttonNaviWay1Del.UseVisualStyleBackColor = true;
            this.buttonNaviWay1Del.Click += new System.EventHandler(this.buttonNaviWay1Del_Click);
            // 
            // buttonNaviStartDel
            // 
            this.buttonNaviStartDel.Location = new System.Drawing.Point(260, 35);
            this.buttonNaviStartDel.Name = "buttonNaviStartDel";
            this.buttonNaviStartDel.Size = new System.Drawing.Size(27, 23);
            this.buttonNaviStartDel.TabIndex = 9;
            this.buttonNaviStartDel.Text = "x";
            this.buttonNaviStartDel.UseVisualStyleBackColor = true;
            this.buttonNaviStartDel.Click += new System.EventHandler(this.buttonNaviStartDel_Click);
            // 
            // textBoxNaviWay1
            // 
            this.textBoxNaviWay1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNaviWay1.Location = new System.Drawing.Point(45, 66);
            this.textBoxNaviWay1.Name = "textBoxNaviWay1";
            this.textBoxNaviWay1.Size = new System.Drawing.Size(208, 21);
            this.textBoxNaviWay1.TabIndex = 8;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(2, 69);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(47, 12);
            this.label28.TabIndex = 7;
            this.label28.Text = "途径1：";
            // 
            // buttonNaviExport
            // 
            this.buttonNaviExport.Location = new System.Drawing.Point(198, 192);
            this.buttonNaviExport.Name = "buttonNaviExport";
            this.buttonNaviExport.Size = new System.Drawing.Size(91, 23);
            this.buttonNaviExport.TabIndex = 6;
            this.buttonNaviExport.Text = "导出轨迹";
            this.buttonNaviExport.UseVisualStyleBackColor = true;
            this.buttonNaviExport.Click += new System.EventHandler(this.buttonNaviExport_Click);
            // 
            // buttonCleanRoute
            // 
            this.buttonCleanRoute.Location = new System.Drawing.Point(106, 192);
            this.buttonCleanRoute.Name = "buttonCleanRoute";
            this.buttonCleanRoute.Size = new System.Drawing.Size(86, 23);
            this.buttonCleanRoute.TabIndex = 5;
            this.buttonCleanRoute.Text = "清除路线";
            this.buttonCleanRoute.UseVisualStyleBackColor = true;
            this.buttonCleanRoute.Click += new System.EventHandler(this.buttonCleanRoute_Click);
            // 
            // buttonNaviGetRoute
            // 
            this.buttonNaviGetRoute.Location = new System.Drawing.Point(8, 192);
            this.buttonNaviGetRoute.Name = "buttonNaviGetRoute";
            this.buttonNaviGetRoute.Size = new System.Drawing.Size(91, 23);
            this.buttonNaviGetRoute.TabIndex = 4;
            this.buttonNaviGetRoute.Text = "规划路线";
            this.buttonNaviGetRoute.UseVisualStyleBackColor = true;
            this.buttonNaviGetRoute.Click += new System.EventHandler(this.buttonNaviGetRoute_Click);
            // 
            // textBoxNaviEndPoint
            // 
            this.textBoxNaviEndPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNaviEndPoint.Location = new System.Drawing.Point(46, 160);
            this.textBoxNaviEndPoint.Name = "textBoxNaviEndPoint";
            this.textBoxNaviEndPoint.Size = new System.Drawing.Size(208, 21);
            this.textBoxNaviEndPoint.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 163);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "终点：";
            // 
            // textBoxNaviStartPoint
            // 
            this.textBoxNaviStartPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNaviStartPoint.Location = new System.Drawing.Point(46, 36);
            this.textBoxNaviStartPoint.Name = "textBoxNaviStartPoint";
            this.textBoxNaviStartPoint.Size = new System.Drawing.Size(207, 21);
            this.textBoxNaviStartPoint.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起点：";
            // 
            // xPanderPanel6
            // 
            this.xPanderPanel6.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel6.Controls.Add(this.clb_route_list);
            this.xPanderPanel6.Controls.Add(this.buttonDelectGpsRouteFile);
            this.xPanderPanel6.Controls.Add(this.buttonLoadGpsRouteFile);
            this.xPanderPanel6.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel6.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel6.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel6.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel6.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel6.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel6.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel6.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel6.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel6.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel6.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel6.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel6.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel6.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel6.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel6.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel6.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel6.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel6.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel6.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel6.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel6.Image = null;
            this.xPanderPanel6.Name = "xPanderPanel6";
            this.xPanderPanel6.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel6.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanel6.TabIndex = 11;
            this.xPanderPanel6.Text = "轨迹加载";
            this.xPanderPanel6.ToolTipTextCloseIcon = null;
            this.xPanderPanel6.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel6.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // clb_route_list
            // 
            this.clb_route_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_route_list.FormattingEnabled = true;
            this.clb_route_list.Location = new System.Drawing.Point(5, 72);
            this.clb_route_list.Name = "clb_route_list";
            this.clb_route_list.Size = new System.Drawing.Size(285, 4);
            this.clb_route_list.TabIndex = 7;
            this.clb_route_list.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clb_route_list_ItemCheck);
            this.clb_route_list.MouseDown += new System.Windows.Forms.MouseEventHandler(this.clb_route_list_MouseDown);
            // 
            // buttonDelectGpsRouteFile
            // 
            this.buttonDelectGpsRouteFile.Location = new System.Drawing.Point(161, 39);
            this.buttonDelectGpsRouteFile.Name = "buttonDelectGpsRouteFile";
            this.buttonDelectGpsRouteFile.Size = new System.Drawing.Size(116, 23);
            this.buttonDelectGpsRouteFile.TabIndex = 6;
            this.buttonDelectGpsRouteFile.Text = "删除轨迹文件";
            this.buttonDelectGpsRouteFile.UseVisualStyleBackColor = true;
            this.buttonDelectGpsRouteFile.Click += new System.EventHandler(this.buttonDelectGpsRouteFile_Click);
            // 
            // buttonLoadGpsRouteFile
            // 
            this.buttonLoadGpsRouteFile.Location = new System.Drawing.Point(20, 38);
            this.buttonLoadGpsRouteFile.Name = "buttonLoadGpsRouteFile";
            this.buttonLoadGpsRouteFile.Size = new System.Drawing.Size(116, 23);
            this.buttonLoadGpsRouteFile.TabIndex = 5;
            this.buttonLoadGpsRouteFile.Text = "加载轨迹文件";
            this.buttonLoadGpsRouteFile.UseVisualStyleBackColor = true;
            this.buttonLoadGpsRouteFile.Click += new System.EventHandler(this.buttonLoadGpsRouteFile_Click);
            // 
            // xPanderPanelTerminalMap
            // 
            this.xPanderPanelTerminalMap.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanelTerminalMap.Controls.Add(this.treeViewTerminalMap);
            this.xPanderPanelTerminalMap.Controls.Add(this.buttonDelectMapFile);
            this.xPanderPanelTerminalMap.Controls.Add(this.buttonLoadMapFile);
            this.xPanderPanelTerminalMap.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanelTerminalMap.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanelTerminalMap.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanelTerminalMap.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanelTerminalMap.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelTerminalMap.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelTerminalMap.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanelTerminalMap.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanelTerminalMap.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelTerminalMap.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelTerminalMap.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanelTerminalMap.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanelTerminalMap.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanelTerminalMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanelTerminalMap.Image = null;
            this.xPanderPanelTerminalMap.Name = "xPanderPanelTerminalMap";
            this.xPanderPanelTerminalMap.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelTerminalMap.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanelTerminalMap.TabIndex = 12;
            this.xPanderPanelTerminalMap.Text = "测试数据加载";
            this.xPanderPanelTerminalMap.ToolTipTextCloseIcon = null;
            this.xPanderPanelTerminalMap.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanelTerminalMap.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // treeViewTerminalMap
            // 
            this.treeViewTerminalMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewTerminalMap.Location = new System.Drawing.Point(5, 75);
            this.treeViewTerminalMap.Name = "treeViewTerminalMap";
            this.treeViewTerminalMap.Size = new System.Drawing.Size(286, 25);
            this.treeViewTerminalMap.TabIndex = 7;
            // 
            // buttonDelectMapFile
            // 
            this.buttonDelectMapFile.Location = new System.Drawing.Point(154, 42);
            this.buttonDelectMapFile.Name = "buttonDelectMapFile";
            this.buttonDelectMapFile.Size = new System.Drawing.Size(116, 23);
            this.buttonDelectMapFile.TabIndex = 4;
            this.buttonDelectMapFile.Text = "删除数据";
            this.buttonDelectMapFile.UseVisualStyleBackColor = true;
            this.buttonDelectMapFile.Click += new System.EventHandler(this.buttonDelectMapFile_Click);
            // 
            // buttonLoadMapFile
            // 
            this.buttonLoadMapFile.Location = new System.Drawing.Point(13, 41);
            this.buttonLoadMapFile.Name = "buttonLoadMapFile";
            this.buttonLoadMapFile.Size = new System.Drawing.Size(116, 23);
            this.buttonLoadMapFile.TabIndex = 1;
            this.buttonLoadMapFile.Text = "加载数据";
            this.buttonLoadMapFile.UseVisualStyleBackColor = true;
            this.buttonLoadMapFile.Click += new System.EventHandler(this.buttonLoadMapFile_Click);
            // 
            // xPanderPanel1
            // 
            this.xPanderPanel1.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel1.Controls.Add(this.label22);
            this.xPanderPanel1.Controls.Add(this.lb_parse_count);
            this.xPanderPanel1.Controls.Add(this.cb_serial_CoordType);
            this.xPanderPanel1.Controls.Add(this.label21);
            this.xPanderPanel1.Controls.Add(this.label20);
            this.xPanderPanel1.Controls.Add(this.btn_clean);
            this.xPanderPanel1.Controls.Add(this.btnOpenCom);
            this.xPanderPanel1.Controls.Add(this.btnCheckCOM);
            this.xPanderPanel1.Controls.Add(this.lb_recv_count);
            this.xPanderPanel1.Controls.Add(this.cbxDataBits);
            this.xPanderPanel1.Controls.Add(this.label19);
            this.xPanderPanel1.Controls.Add(this.cbxStopBits);
            this.xPanderPanel1.Controls.Add(this.cbxParitv);
            this.xPanderPanel1.Controls.Add(this.label17);
            this.xPanderPanel1.Controls.Add(this.label18);
            this.xPanderPanel1.Controls.Add(this.cbxBaudRate);
            this.xPanderPanel1.Controls.Add(this.cbxCOMPort);
            this.xPanderPanel1.Controls.Add(this.label15);
            this.xPanderPanel1.Controls.Add(this.label16);
            this.xPanderPanel1.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel1.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel1.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel1.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel1.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel1.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel1.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel1.Image = null;
            this.xPanderPanel1.Name = "xPanderPanel1";
            this.xPanderPanel1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel1.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanel1.TabIndex = 13;
            this.xPanderPanel1.Text = "串口设置";
            this.xPanderPanel1.ToolTipTextCloseIcon = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel1.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(145, 127);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 33;
            this.label22.Text = "解析数";
            // 
            // lb_parse_count
            // 
            this.lb_parse_count.Location = new System.Drawing.Point(189, 125);
            this.lb_parse_count.Name = "lb_parse_count";
            this.lb_parse_count.Size = new System.Drawing.Size(75, 17);
            this.lb_parse_count.TabIndex = 32;
            this.lb_parse_count.Text = "0";
            this.lb_parse_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cb_serial_CoordType
            // 
            this.cb_serial_CoordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_serial_CoordType.FormattingEnabled = true;
            this.cb_serial_CoordType.Items.AddRange(new object[] {
            "WGS84",
            "GCJ02",
            "BD09"});
            this.cb_serial_CoordType.Location = new System.Drawing.Point(192, 96);
            this.cb_serial_CoordType.Margin = new System.Windows.Forms.Padding(2);
            this.cb_serial_CoordType.Name = "cb_serial_CoordType";
            this.cb_serial_CoordType.Size = new System.Drawing.Size(75, 20);
            this.cb_serial_CoordType.TabIndex = 31;
            this.cb_serial_CoordType.SelectedIndexChanged += new System.EventHandler(this.cb_serial_CoordType_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(146, 99);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 30;
            this.label21.Text = "坐标系";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 126);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 29;
            this.label20.Text = "接收数";
            // 
            // btn_clean
            // 
            this.btn_clean.Location = new System.Drawing.Point(199, 152);
            this.btn_clean.Margin = new System.Windows.Forms.Padding(2);
            this.btn_clean.Name = "btn_clean";
            this.btn_clean.Size = new System.Drawing.Size(64, 22);
            this.btn_clean.TabIndex = 28;
            this.btn_clean.Text = "清空计数";
            this.btn_clean.UseVisualStyleBackColor = true;
            this.btn_clean.Click += new System.EventHandler(this.btn_clean_Click);
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(107, 152);
            this.btnOpenCom.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(64, 22);
            this.btnOpenCom.TabIndex = 27;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // btnCheckCOM
            // 
            this.btnCheckCOM.Location = new System.Drawing.Point(17, 152);
            this.btnCheckCOM.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckCOM.Name = "btnCheckCOM";
            this.btnCheckCOM.Size = new System.Drawing.Size(61, 23);
            this.btnCheckCOM.TabIndex = 26;
            this.btnCheckCOM.Text = "串口检测";
            this.btnCheckCOM.UseVisualStyleBackColor = true;
            this.btnCheckCOM.Click += new System.EventHandler(this.btnCheckCOM_Click);
            // 
            // lb_recv_count
            // 
            this.lb_recv_count.Location = new System.Drawing.Point(57, 124);
            this.lb_recv_count.Name = "lb_recv_count";
            this.lb_recv_count.Size = new System.Drawing.Size(75, 17);
            this.lb_recv_count.TabIndex = 25;
            this.lb_recv_count.Text = "0";
            this.lb_recv_count.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxDataBits
            // 
            this.cbxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDataBits.FormattingEnabled = true;
            this.cbxDataBits.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5"});
            this.cbxDataBits.Location = new System.Drawing.Point(58, 96);
            this.cbxDataBits.Margin = new System.Windows.Forms.Padding(2);
            this.cbxDataBits.Name = "cbxDataBits";
            this.cbxDataBits.Size = new System.Drawing.Size(75, 20);
            this.cbxDataBits.TabIndex = 24;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 99);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 12);
            this.label19.TabIndex = 23;
            this.label19.Text = "数据位";
            // 
            // cbxStopBits
            // 
            this.cbxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStopBits.FormattingEnabled = true;
            this.cbxStopBits.Items.AddRange(new object[] {
            "0",
            "1",
            "1.5",
            "2"});
            this.cbxStopBits.Location = new System.Drawing.Point(57, 67);
            this.cbxStopBits.Margin = new System.Windows.Forms.Padding(2);
            this.cbxStopBits.Name = "cbxStopBits";
            this.cbxStopBits.Size = new System.Drawing.Size(75, 20);
            this.cbxStopBits.TabIndex = 22;
            // 
            // cbxParitv
            // 
            this.cbxParitv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxParitv.FormattingEnabled = true;
            this.cbxParitv.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.cbxParitv.Location = new System.Drawing.Point(192, 67);
            this.cbxParitv.Margin = new System.Windows.Forms.Padding(2);
            this.cbxParitv.Name = "cbxParitv";
            this.cbxParitv.Size = new System.Drawing.Size(75, 20);
            this.cbxParitv.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 70);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 19;
            this.label17.Text = "停止位";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(157, 70);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 20;
            this.label18.Text = "校验";
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200"});
            this.cbxBaudRate.Location = new System.Drawing.Point(192, 38);
            this.cbxBaudRate.Margin = new System.Windows.Forms.Padding(2);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(75, 20);
            this.cbxBaudRate.TabIndex = 18;
            // 
            // cbxCOMPort
            // 
            this.cbxCOMPort.FormattingEnabled = true;
            this.cbxCOMPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30",
            "COM31",
            "COM32",
            "COM33",
            "COM34",
            "COM35",
            "COM36",
            "COM37",
            "COM38",
            "COM39",
            "COM40",
            "COM41",
            "COM42",
            "COM43",
            "COM44",
            "COM45",
            "COM46",
            "COM47",
            "COM48",
            "COM49",
            "COM50",
            "COM51",
            "COM52",
            "COM53",
            "COM54"});
            this.cbxCOMPort.Location = new System.Drawing.Point(57, 38);
            this.cbxCOMPort.Margin = new System.Windows.Forms.Padding(2);
            this.cbxCOMPort.Name = "cbxCOMPort";
            this.cbxCOMPort.Size = new System.Drawing.Size(75, 20);
            this.cbxCOMPort.TabIndex = 17;
            this.cbxCOMPort.Text = "COM3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 41);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 16;
            this.label15.Text = "通讯口";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(148, 41);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 15;
            this.label16.Text = "波特率";
            // 
            // xPanderPanel7
            // 
            this.xPanderPanel7.CaptionFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel7.Controls.Add(this.groupBox10);
            this.xPanderPanel7.Controls.Add(this.groupBox7);
            this.xPanderPanel7.CustomColors.BackColor = System.Drawing.SystemColors.Control;
            this.xPanderPanel7.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.xPanderPanel7.CustomColors.CaptionCheckedGradientBegin = System.Drawing.Color.Empty;
            this.xPanderPanel7.CustomColors.CaptionCheckedGradientEnd = System.Drawing.Color.Empty;
            this.xPanderPanel7.CustomColors.CaptionCheckedGradientMiddle = System.Drawing.Color.Empty;
            this.xPanderPanel7.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel7.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel7.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel7.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.xPanderPanel7.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel7.CustomColors.CaptionPressedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel7.CustomColors.CaptionPressedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel7.CustomColors.CaptionPressedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.xPanderPanel7.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel7.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel7.CustomColors.CaptionSelectedGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.xPanderPanel7.CustomColors.CaptionSelectedText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel7.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel7.CustomColors.FlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel7.CustomColors.FlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel7.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.xPanderPanel7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel7.Image = null;
            this.xPanderPanel7.Name = "xPanderPanel7";
            this.xPanderPanel7.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel7.Size = new System.Drawing.Size(297, 25);
            this.xPanderPanel7.TabIndex = 14;
            this.xPanderPanel7.Text = "匹配测试";
            this.xPanderPanel7.ToolTipTextCloseIcon = null;
            this.xPanderPanel7.ToolTipTextExpandIconPanelCollapsed = null;
            this.xPanderPanel7.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.lb_mt_recv_num);
            this.groupBox10.Controls.Add(this.btn_mt_clean);
            this.groupBox10.Controls.Add(this.label29);
            this.groupBox10.Controls.Add(this.cb_mt_is_dispaly);
            this.groupBox10.Controls.Add(this.tb_mt_recv_msg);
            this.groupBox10.Location = new System.Drawing.Point(10, 228);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(274, 198);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "接收信息";
            // 
            // lb_mt_recv_num
            // 
            this.lb_mt_recv_num.AutoSize = true;
            this.lb_mt_recv_num.Location = new System.Drawing.Point(125, 28);
            this.lb_mt_recv_num.Name = "lb_mt_recv_num";
            this.lb_mt_recv_num.Size = new System.Drawing.Size(11, 12);
            this.lb_mt_recv_num.TabIndex = 4;
            this.lb_mt_recv_num.Text = "0";
            // 
            // btn_mt_clean
            // 
            this.btn_mt_clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_mt_clean.Location = new System.Drawing.Point(193, 20);
            this.btn_mt_clean.Name = "btn_mt_clean";
            this.btn_mt_clean.Size = new System.Drawing.Size(75, 23);
            this.btn_mt_clean.TabIndex = 3;
            this.btn_mt_clean.Text = "清空";
            this.btn_mt_clean.UseVisualStyleBackColor = true;
            this.btn_mt_clean.Click += new System.EventHandler(this.btn_mt_clean_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(90, 28);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 12);
            this.label29.TabIndex = 2;
            this.label29.Text = "数量：";
            // 
            // cb_mt_is_dispaly
            // 
            this.cb_mt_is_dispaly.AutoSize = true;
            this.cb_mt_is_dispaly.Location = new System.Drawing.Point(7, 28);
            this.cb_mt_is_dispaly.Name = "cb_mt_is_dispaly";
            this.cb_mt_is_dispaly.Size = new System.Drawing.Size(72, 16);
            this.cb_mt_is_dispaly.TabIndex = 1;
            this.cb_mt_is_dispaly.Text = "是否显示";
            this.cb_mt_is_dispaly.UseVisualStyleBackColor = true;
            // 
            // tb_mt_recv_msg
            // 
            this.tb_mt_recv_msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_mt_recv_msg.Location = new System.Drawing.Point(7, 50);
            this.tb_mt_recv_msg.Multiline = true;
            this.tb_mt_recv_msg.Name = "tb_mt_recv_msg";
            this.tb_mt_recv_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_mt_recv_msg.Size = new System.Drawing.Size(260, 142);
            this.tb_mt_recv_msg.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.lb_mt_match_road_num);
            this.groupBox7.Controls.Add(this.cb_mt_is_show_match_road);
            this.groupBox7.Controls.Add(this.cb_mt_is_show_tmap);
            this.groupBox7.Controls.Add(this.lb_mt_probability);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.cb_mt_is_show_sign);
            this.groupBox7.Controls.Add(this.cb_mt_is_show_road);
            this.groupBox7.Controls.Add(this.lb_mt_sign_num);
            this.groupBox7.Controls.Add(this.lb_mt_road_num);
            this.groupBox7.Controls.Add(this.lb_mt_search_dist);
            this.groupBox7.Controls.Add(this.lb_mt_ret);
            this.groupBox7.Controls.Add(this.label27);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Location = new System.Drawing.Point(10, 40);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(274, 182);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "当前信息";
            // 
            // lb_mt_match_road_num
            // 
            this.lb_mt_match_road_num.AutoSize = true;
            this.lb_mt_match_road_num.Location = new System.Drawing.Point(100, 124);
            this.lb_mt_match_road_num.Name = "lb_mt_match_road_num";
            this.lb_mt_match_road_num.Size = new System.Drawing.Size(11, 12);
            this.lb_mt_match_road_num.TabIndex = 14;
            this.lb_mt_match_road_num.Text = "0";
            // 
            // cb_mt_is_show_match_road
            // 
            this.cb_mt_is_show_match_road.AutoSize = true;
            this.cb_mt_is_show_match_road.Checked = true;
            this.cb_mt_is_show_match_road.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mt_is_show_match_road.Location = new System.Drawing.Point(2, 122);
            this.cb_mt_is_show_match_road.Name = "cb_mt_is_show_match_road";
            this.cb_mt_is_show_match_road.Size = new System.Drawing.Size(96, 16);
            this.cb_mt_is_show_match_road.TabIndex = 13;
            this.cb_mt_is_show_match_road.Text = "显示匹配路段";
            this.cb_mt_is_show_match_road.UseVisualStyleBackColor = true;
            // 
            // cb_mt_is_show_tmap
            // 
            this.cb_mt_is_show_tmap.AutoSize = true;
            this.cb_mt_is_show_tmap.Checked = true;
            this.cb_mt_is_show_tmap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mt_is_show_tmap.Location = new System.Drawing.Point(2, 142);
            this.cb_mt_is_show_tmap.Name = "cb_mt_is_show_tmap";
            this.cb_mt_is_show_tmap.Size = new System.Drawing.Size(96, 16);
            this.cb_mt_is_show_tmap.TabIndex = 12;
            this.cb_mt_is_show_tmap.Text = "显示测试数据";
            this.cb_mt_is_show_tmap.UseVisualStyleBackColor = true;
            this.cb_mt_is_show_tmap.CheckedChanged += new System.EventHandler(this.cb_mt_is_show_tmap_CheckedChanged);
            // 
            // lb_mt_probability
            // 
            this.lb_mt_probability.AutoSize = true;
            this.lb_mt_probability.Location = new System.Drawing.Point(100, 102);
            this.lb_mt_probability.Name = "lb_mt_probability";
            this.lb_mt_probability.Size = new System.Drawing.Size(11, 12);
            this.lb_mt_probability.TabIndex = 11;
            this.lb_mt_probability.Text = "0";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(18, 102);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 10;
            this.label26.Text = "匹配概率：";
            // 
            // cb_mt_is_show_sign
            // 
            this.cb_mt_is_show_sign.AutoSize = true;
            this.cb_mt_is_show_sign.Checked = true;
            this.cb_mt_is_show_sign.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mt_is_show_sign.Location = new System.Drawing.Point(2, 82);
            this.cb_mt_is_show_sign.Name = "cb_mt_is_show_sign";
            this.cb_mt_is_show_sign.Size = new System.Drawing.Size(96, 16);
            this.cb_mt_is_show_sign.TabIndex = 9;
            this.cb_mt_is_show_sign.Text = "交通牌显示：";
            this.cb_mt_is_show_sign.UseVisualStyleBackColor = true;
            // 
            // cb_mt_is_show_road
            // 
            this.cb_mt_is_show_road.AutoSize = true;
            this.cb_mt_is_show_road.Checked = true;
            this.cb_mt_is_show_road.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mt_is_show_road.Location = new System.Drawing.Point(2, 62);
            this.cb_mt_is_show_road.Name = "cb_mt_is_show_road";
            this.cb_mt_is_show_road.Size = new System.Drawing.Size(84, 16);
            this.cb_mt_is_show_road.TabIndex = 8;
            this.cb_mt_is_show_road.Text = "道路显示：";
            this.cb_mt_is_show_road.UseVisualStyleBackColor = true;
            // 
            // lb_mt_sign_num
            // 
            this.lb_mt_sign_num.AutoSize = true;
            this.lb_mt_sign_num.Location = new System.Drawing.Point(100, 82);
            this.lb_mt_sign_num.Name = "lb_mt_sign_num";
            this.lb_mt_sign_num.Size = new System.Drawing.Size(11, 12);
            this.lb_mt_sign_num.TabIndex = 7;
            this.lb_mt_sign_num.Text = "0";
            // 
            // lb_mt_road_num
            // 
            this.lb_mt_road_num.AutoSize = true;
            this.lb_mt_road_num.Location = new System.Drawing.Point(100, 62);
            this.lb_mt_road_num.Name = "lb_mt_road_num";
            this.lb_mt_road_num.Size = new System.Drawing.Size(11, 12);
            this.lb_mt_road_num.TabIndex = 6;
            this.lb_mt_road_num.Text = "0";
            // 
            // lb_mt_search_dist
            // 
            this.lb_mt_search_dist.AutoSize = true;
            this.lb_mt_search_dist.Location = new System.Drawing.Point(100, 42);
            this.lb_mt_search_dist.Name = "lb_mt_search_dist";
            this.lb_mt_search_dist.Size = new System.Drawing.Size(11, 12);
            this.lb_mt_search_dist.TabIndex = 5;
            this.lb_mt_search_dist.Text = "0";
            // 
            // lb_mt_ret
            // 
            this.lb_mt_ret.AutoSize = true;
            this.lb_mt_ret.Location = new System.Drawing.Point(100, 22);
            this.lb_mt_ret.Name = "lb_mt_ret";
            this.lb_mt_ret.Size = new System.Drawing.Size(11, 12);
            this.lb_mt_ret.TabIndex = 4;
            this.lb_mt_ret.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(18, 42);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 2;
            this.label27.Text = "搜索距离：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(19, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "匹配结果：";
            // 
            // contextMenuCityDataView
            // 
            this.contextMenuCityDataView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_缩放至城市,
            this.toolStripMenuItem_显示城市数据,
            this.清除城市显示ToolStripMenuItem,
            this.toolStripMenuItem_显示城市网格,
            this.清除网格显示ToolStripMenuItem});
            this.contextMenuCityDataView.Name = "contextMenuStripDisplayInfo";
            this.contextMenuCityDataView.Size = new System.Drawing.Size(149, 114);
            // 
            // toolStripMenuItem_缩放至城市
            // 
            this.toolStripMenuItem_缩放至城市.Name = "toolStripMenuItem_缩放至城市";
            this.toolStripMenuItem_缩放至城市.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_缩放至城市.Text = "缩放至城市";
            this.toolStripMenuItem_缩放至城市.Click += new System.EventHandler(this.toolStripMenuItem_缩放至城市_Click);
            // 
            // toolStripMenuItem_显示城市数据
            // 
            this.toolStripMenuItem_显示城市数据.Name = "toolStripMenuItem_显示城市数据";
            this.toolStripMenuItem_显示城市数据.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_显示城市数据.Text = "显示城市数据";
            this.toolStripMenuItem_显示城市数据.Click += new System.EventHandler(this.toolStripMenuItem_显示城市数据_Click);
            // 
            // 清除城市显示ToolStripMenuItem
            // 
            this.清除城市显示ToolStripMenuItem.Name = "清除城市显示ToolStripMenuItem";
            this.清除城市显示ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清除城市显示ToolStripMenuItem.Text = "清除城市显示";
            this.清除城市显示ToolStripMenuItem.Click += new System.EventHandler(this.清除城市显示ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_显示城市网格
            // 
            this.toolStripMenuItem_显示城市网格.Name = "toolStripMenuItem_显示城市网格";
            this.toolStripMenuItem_显示城市网格.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem_显示城市网格.Text = "显示城市网格";
            this.toolStripMenuItem_显示城市网格.Click += new System.EventHandler(this.toolStripMenuItem_显示城市网格_Click);
            // 
            // 清除网格显示ToolStripMenuItem
            // 
            this.清除网格显示ToolStripMenuItem.Name = "清除网格显示ToolStripMenuItem";
            this.清除网格显示ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.清除网格显示ToolStripMenuItem.Text = "清除网格显示";
            this.清除网格显示ToolStripMenuItem.Click += new System.EventHandler(this.清除网格显示ToolStripMenuItem_Click);
            // 
            // cb_coord_view_type
            // 
            this.cb_coord_view_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_coord_view_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_coord_view_type.FormattingEnabled = true;
            this.cb_coord_view_type.Items.AddRange(new object[] {
            "WGS84",
            "GCJ02",
            "BD09"});
            this.cb_coord_view_type.Location = new System.Drawing.Point(972, 3);
            this.cb_coord_view_type.Name = "cb_coord_view_type";
            this.cb_coord_view_type.Size = new System.Drawing.Size(60, 20);
            this.cb_coord_view_type.TabIndex = 19;
            // 
            // tb_coord_view_text
            // 
            this.tb_coord_view_text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_coord_view_text.Location = new System.Drawing.Point(792, 3);
            this.tb_coord_view_text.Name = "tb_coord_view_text";
            this.tb_coord_view_text.Size = new System.Drawing.Size(179, 21);
            this.tb_coord_view_text.TabIndex = 20;
            // 
            // btn_coord_view_add
            // 
            this.btn_coord_view_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_coord_view_add.Location = new System.Drawing.Point(1034, 1);
            this.btn_coord_view_add.Name = "btn_coord_view_add";
            this.btn_coord_view_add.Size = new System.Drawing.Size(45, 23);
            this.btn_coord_view_add.TabIndex = 21;
            this.btn_coord_view_add.Text = "Add";
            this.btn_coord_view_add.UseVisualStyleBackColor = true;
            this.btn_coord_view_add.Click += new System.EventHandler(this.btn_coord_view_add_Click);
            // 
            // btn_coord_view_clean
            // 
            this.btn_coord_view_clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_coord_view_clean.Location = new System.Drawing.Point(1081, 1);
            this.btn_coord_view_clean.Name = "btn_coord_view_clean";
            this.btn_coord_view_clean.Size = new System.Drawing.Size(45, 23);
            this.btn_coord_view_clean.TabIndex = 22;
            this.btn_coord_view_clean.Text = "Clean";
            this.btn_coord_view_clean.UseVisualStyleBackColor = true;
            this.btn_coord_view_clean.Click += new System.EventHandler(this.btn_coord_view_clean_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 712);
            this.Controls.Add(this.btn_coord_view_clean);
            this.Controls.Add(this.btn_coord_view_add);
            this.Controls.Add(this.tb_coord_view_text);
            this.Controls.Add(this.cb_coord_view_type);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyMapTools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapForm_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelMap.ResumeLayout(false);
            this.panelMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_compass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_scale)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGpsRoute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyGeoDataBindingSource)).EndInit();
            this.panelButtonTools.ResumeLayout(false);
            this.panelButtonTools.PerformLayout();
            this.contextMenuStripSelectedArea.ResumeLayout(false);
            this.contextMenuStripLocation.ResumeLayout(false);
            this.contextMenuStripDisplayInfo.ResumeLayout(false);
            this.contextMenuStripHistoryRoute.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.xPanderPanelList1.ResumeLayout(false);
            this.xPanderPanel_coord_pickup.ResumeLayout(false);
            this.xPanderPanel_coord_pickup.PerformLayout();
            this.xPanderPanel2.ResumeLayout(false);
            this.xPanderPanel2.PerformLayout();
            this.xPanderPanel3.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.gbMapImage.ResumeLayout(false);
            this.gbMapImage.PerformLayout();
            this.xPanderPanelChinaRegion.ResumeLayout(false);
            this.xPanderPanel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.xPanderPanel5.ResumeLayout(false);
            this.xPanderPanel5.PerformLayout();
            this.xPanderPanel6.ResumeLayout(false);
            this.xPanderPanelTerminalMap.ResumeLayout(false);
            this.xPanderPanel1.ResumeLayout(false);
            this.xPanderPanel1.PerformLayout();
            this.xPanderPanel7.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.contextMenuCityDataView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BSE.Windows.Forms.Panel panelMenu;
        private BSE.Windows.Forms.XPanderPanelList xPanderPanelList1;
        private System.Windows.Forms.ToolStripMenuItem 地图操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高德地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 腾讯地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 百度地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图操作ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 地图截屏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存缓存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取缓存ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private BSE.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.Panel panelDock;
        private System.Windows.Forms.Button buttonMapType;
        private MapControl mapControl;
        private System.Windows.Forms.Panel panelButtonTools;
        private System.Windows.Forms.DataGridView dataGridViewGpsRoute;
        private System.Windows.Forms.BindingSource historyGeoDataBindingSource;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonSetTimerInterval;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.ComboBox comboBoxTimeSpan;
        private System.Windows.Forms.CheckBox checkBoxFollow;
        private System.Windows.Forms.ToolStripMenuItem 天地图福建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arcGISMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czechToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oSMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter_button;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel_coord_pickup;
        private System.Windows.Forms.Button btn_query_by_addrass;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_query_by_coord;
        private System.Windows.Forms.TextBox tb_lon_lat_bd09;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_lon_lat_gcj02;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_lon_lat_wgs84;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_get_coord_from_map;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于MyMapToolsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusCenter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDownload;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarDownload;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPOIDownload;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusExport;
        private System.Windows.Forms.ToolStripMenuItem 地图访问ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在线和缓存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在线服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 本地缓存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示网格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地图测距ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 代理设置ToolStripMenuItem;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel2;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel3;
        private System.Windows.Forms.Button buttonPoiSave;
        private System.Windows.Forms.Button buttonPOISearch;
        private System.Windows.Forms.ComboBox comboBoxPoiSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxProvince;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPOIkeyword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem 搜索引擎ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高德地图ToolStripMenuItem_search;
        private System.Windows.Forms.ToolStripMenuItem 百度地图ToolStripMenuItem_search;
        private System.Windows.Forms.ToolStripMenuItem 腾讯地图ToolStripMenuItem_search;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox comboBoxStore;
        private System.Windows.Forms.Button buttonMapDownload;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttonDrawPolygon;
        private System.Windows.Forms.Button buttonDrawRectangle;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbMapImage;
        private System.Windows.Forms.ComboBox comboBoxZoom;
        private System.Windows.Forms.Button buttonMapImage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSelectedArea;
        private System.Windows.Forms.ToolStripMenuItem 下载地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载KMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 允许编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止编辑ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLocation;
        private System.Windows.Forms.ToolStripMenuItem 搜索该点的地址ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 以此为起点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 以此为终点ToolStripMenuItem;
        private System.Windows.Forms.Button buttonCleanDownloadArea;
        private System.Windows.Forms.ToolStripMenuItem 清除区域ToolStripMenuItem;
        private BSE.Windows.Forms.XPanderPanel xPanderPanelChinaRegion;
        private System.Windows.Forms.TreeView advTreeChina;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonStopBlink;
        private System.Windows.Forms.Button buttonBeginBlink;
        private System.Windows.Forms.CheckBox checkBoxMarker;
        private System.Windows.Forms.Button buttonClearDemoOverlay;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonHeatMarker;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Button buttonPolyline;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonPolygon;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel5;
        private System.Windows.Forms.Button buttonCleanRoute;
        private System.Windows.Forms.Button buttonNaviGetRoute;
        private System.Windows.Forms.TextBox textBoxNaviEndPoint;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxNaviStartPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbGMapMarkerScopeCircleAnimate;
        private System.Windows.Forms.RadioButton rbGMapMarkerScopePieAnimate;
        private System.Windows.Forms.RadioButton rbGMapTipMarker;
        private System.Windows.Forms.RadioButton rbGMapDirectionMarker;
        private System.Windows.Forms.RadioButton rbGMapGifMarker;
        private System.Windows.Forms.RadioButton rbGMapFlashMarker;
        private System.Windows.Forms.RadioButton rbGMarkerGoogle;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel6;
        private BSE.Windows.Forms.XPanderPanel xPanderPanelTerminalMap;
        private System.Windows.Forms.Button buttonLoadMapFile;
        private System.Windows.Forms.Button buttonDelectMapFile;
        private System.Windows.Forms.Button buttonDelectGpsRouteFile;
        private System.Windows.Forms.Button buttonLoadGpsRouteFile;
        private System.Windows.Forms.CheckedListBox clb_route_list;
        private System.Windows.Forms.TreeView treeViewTerminalMap;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDisplayInfo;
        private System.Windows.Forms.ToolStripMenuItem 修改显示信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除地图ToolStripMenuItem;
        private System.Windows.Forms.ComboBox cb_simulate_src;
        private System.Windows.Forms.ComboBox cb_simulate_type;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lb_simulate_src;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripHistoryRoute;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 删除轨迹ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_Direction;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_clean;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.Button btnCheckCOM;
        private System.Windows.Forms.Label lb_recv_count;
        private System.Windows.Forms.ComboBox cbxDataBits;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbxStopBits;
        private System.Windows.Forms.ComboBox cbxParitv;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.ComboBox cbxCOMPort;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cb_serial_CoordType;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tb_simulate_src;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lb_parse_count;
        private System.Windows.Forms.ToolStripMenuItem 显示当前区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除所有显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除当前区域地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示当前区域城市地图ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_scale;
        private System.Windows.Forms.Label lb_scale_max;
        private System.Windows.Forms.Label lb_scale_min;
        private System.Windows.Forms.PictureBox pb_compass;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewAltitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewAccuracy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewAttributes;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tb_end_idx;
        private System.Windows.Forms.TextBox tb_start_idx;
        private System.Windows.Forms.CheckBox checkBoxRepeat;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel7;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label lb_mt_recv_num;
        private System.Windows.Forms.Button btn_mt_clean;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox cb_mt_is_dispaly;
        private System.Windows.Forms.TextBox tb_mt_recv_msg;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lb_mt_sign_num;
        private System.Windows.Forms.Label lb_mt_road_num;
        private System.Windows.Forms.Label lb_mt_search_dist;
        private System.Windows.Forms.Label lb_mt_ret;
        private System.Windows.Forms.ToolStripMenuItem 设置为地图匹配测试底图ToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_mt_is_show_sign;
        private System.Windows.Forms.CheckBox cb_mt_is_show_road;
        private System.Windows.Forms.Label lb_mt_probability;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ContextMenuStrip contextMenuCityDataView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_缩放至城市;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_显示城市网格;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_显示城市数据;
        private System.Windows.Forms.ToolStripMenuItem 清除城市显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除网格显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示当前网格地图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示当前网格地图ToolStripMenuItem1;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.CheckBox cb_mt_is_show_match_road;
        private System.Windows.Forms.CheckBox cb_mt_is_show_tmap;
        private System.Windows.Forms.ComboBox cb_coord_view_type;
        private System.Windows.Forms.TextBox tb_coord_view_text;
        private System.Windows.Forms.Button btn_coord_view_add;
        private System.Windows.Forms.Button btn_coord_view_clean;
        private System.Windows.Forms.Label lb_mt_match_road_num;
        private System.Windows.Forms.Button buttonNaviExport;
        private System.Windows.Forms.ToolStripMenuItem 添加途径点ToolStripMenuItem;
        private System.Windows.Forms.Button buttonNaviEndDel;
        private System.Windows.Forms.Button buttonNaviWay3Del;
        private System.Windows.Forms.TextBox textBoxNaviWay3;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Button buttonNaviWay2Del;
        private System.Windows.Forms.TextBox textBoxNaviWay2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button buttonNaviWay1Del;
        private System.Windows.Forms.Button buttonNaviStartDel;
        private System.Windows.Forms.TextBox textBoxNaviWay1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ToolStripMenuItem 导出轨迹ToolStripMenuItem;
        private System.Windows.Forms.Button btn_coord_pickup_clean;
        private System.Windows.Forms.ToolStripMenuItem 设置高德地图开发者KeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置百度地图开发者KeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置腾讯地图开发者KeyToolStripMenuItem;
        private System.Windows.Forms.Button buttonPoiClean;
        private System.Windows.Forms.ToolStripMenuItem 口令ToolStripMenuItem;
    }
}

