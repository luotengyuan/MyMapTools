using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonTools;
using System.IO;
using GMap.NET;
using System.Data.OleDb;

namespace MapToolsWinForm
{
    public partial class Form_load_gps : Form
    {
        public Form_load_gps()
        {
            InitializeComponent();
        }

        private void Form_load_gps_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            cb_file_format.SelectedIndex = Properties.Settings.Default.Setting_file_format_idx;
            cb_separator.SelectedIndex = Properties.Settings.Default.Setting_separator_idx;
            cb_coord_type.SelectedIndex = Properties.Settings.Default.Setting_coord_type_idx;
            cb_filter_0_point.Checked = Properties.Settings.Default.Setting_is_filter_0_point;
            cb_filter_repeat_point.Checked = Properties.Settings.Default.Setting_is_filter_repeat_point;
            tb_lon_scale.Text = Properties.Settings.Default.Setting_lon_scale;
            tb_lat_scale.Text = Properties.Settings.Default.Setting_lat_scale;
            tb_dir_scale.Text = Properties.Settings.Default.Setting_dir_scale;
            tb_speed_scale.Text = Properties.Settings.Default.Setting_speed_scale;
            tb_alt_scale.Text = Properties.Settings.Default.Setting_alt_scale;
            tb_acc_scale.Text = Properties.Settings.Default.Setting_acc_scale;
            tb_time_scale.Text = Properties.Settings.Default.Setting_time_scale;
            tb_type_scale.Text = Properties.Settings.Default.Setting_type_scale;
            tb_jump_num.Text = Properties.Settings.Default.Setting_jump_num;
            tb_min_speed.Text = Properties.Settings.Default.Setting_min_speed;
        }

        /// <summary>
        /// 加载文件内容
        /// </summary>
        private List<string[]> routeInfoList = null;
        private string[] headLine = null;
        private string routeName = null;
        private void btn_load_file_Click(object sender, EventArgs e)
        {
            int file_format = cb_file_format.SelectedIndex;
            if (file_format < 0 || file_format > 2)
            {
                MyMessageBox.ShowTipMessage("暂不支持该文件类型");
                return;
            }
            int separator_type = cb_separator.SelectedIndex;
            if (file_format == 0)
            {
                if (separator_type < 0 || separator_type > 4)
                {
                    MyMessageBox.ShowTipMessage("暂不支持分隔符类型");
                    return;
                }
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Title = "请选择轨迹文件";
            if (cb_file_format.SelectedIndex == 0)
            {
                ofd.Filter = "文本文档|*.csv;*.txt|所有文件(*.*)|*.*";
            }
            else if (cb_file_format.SelectedIndex == 1)
            {
                ofd.Filter = "表格文件|*.xls;*.xlsx|所有文件(*.*)|*.*";
            }
            else if (cb_file_format.SelectedIndex == 2)
            {
                ofd.Filter = "文本文档|*.nmea;*.log;*.txt|所有文件(*.*)|*.*";
            }
            else
            {
                ofd.Filter = "所有文件(*.*)|*.*";
            }
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tb_file_path.Text = ofd.FileName; string sltpath = ofd.FileName;
                if (sltpath == null || sltpath.Trim().Equals(""))
                {
                    MyMessageBox.ShowTipMessage("选择的文件路径有问题");
                    return;
                }
                if (!File.Exists(sltpath))
                {
                    MyMessageBox.ShowTipMessage("选择的文件不存在");
                    return;
                }

                routeName = Path.GetFileName(sltpath);

                routeInfoList = getRouteInfoList(sltpath, file_format, separator_type);

                if (routeInfoList == null || routeInfoList.Count <= 0)
                {
                    MyMessageBox.ShowTipMessage("未识别到数据，请检查文件内容格式是否正确或者文件是否被加密！");
                }
                else
                {
                    int lineNum = 0;
                    foreach (var item in routeInfoList)
                    {
                        if (lineNum == 0)
                        {
                            headLine = item;
                            InitListView(this.lv_route_info, headLine);
                        }
                        if (lineNum > 500)
                        {
                            break;
                        }
                        InsertListView(this.lv_route_info, item);
                        lineNum++;
                    }
                    MyMessageBox.ShowTipMessage("加载数据成功" + routeInfoList.Count() + "条待发送数据！");
                }
            }
        }

        private List<string[]> getRouteInfoList(string sltpath, int file_format, int separator_type)
        {
            List<string[]> ret = new List<string[]>();
            int rowNum = 0;
            switch (file_format)
            {
                case 0:
                    try
                    {
                        StreamReader sr = new StreamReader(sltpath);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (line == null)
                            {
                                continue;
                            }
                            string[] arrs = line.Split(getSeparatorChar(separator_type));
                            if (arrs == null || arrs.Length < 2)
                            {
                                continue;
                            }
                            if (rowNum == 0)
                            {
                                rowNum = arrs.Length;
                            }
                            string[] retArray = new string[rowNum];
                            for (int i = 0; i < rowNum; i++)
                            {
                                if (i < arrs.Length)
                                {
                                    retArray[i] = arrs[i];
                                }
                                else
                                {
                                    retArray[i] = "";
                                }
                            }
                            ret.Add(retArray);
                            //Console.WriteLine(line);
                        }
                    }
                    catch (Exception exception)
                    {
                        MyMessageBox.ShowTipMessage("读取文件出错！请检查文件内容格式是否正确或者文件是否被加密！\n" + exception.ToString());
                    }
                    break;
                case 1:
                    try
                    {
                        DataTable excelData = null;
                        if (Path.GetExtension(sltpath).ToLower().Contains("xlsx"))
                        {
                            excelData = ImportExcelXlsx(sltpath);
                        }
                        else
                        {
                            excelData = ImportExcelXls(sltpath);
                        }
                        if (excelData == null || excelData.Columns == null || excelData.Columns.Count <= 0 || excelData.Rows == null || excelData.Rows.Count <= 0)
                        {
                            break;
                        }
                        int col = excelData.Columns.Count;
                        string[] line = new string[col];
                        for (int i = 0; i < col; i++)   　　　　　　　　　　　　　　　　　　　//遍历所有的列
                        {
                            line[i] = excelData.Columns[i].ColumnName;
                        }
                        ret.Add(line);
                        foreach (DataRow dr in excelData.Rows)   　　　　　　　　　　　　　　　　　　　　　　　　　　//遍历所有的行
                        {
                            line = new string[col];
                            for (int i = 0; i < col; i++)
                            {
                                line[i] = dr[excelData.Columns[i]].ToString();
                            }
                            ret.Add(line);
                        }
                    }
                    catch (Exception exception)
                    {
                        if (exception.ToString().Contains("未在本地计算机上注册“Microsoft.Ace.OleDb.12.0”提供程序"))
                        {
                            MyMessageBox.ShowTipMessage("读取xlsx文件请安装Microsoft Access Database Engine 2007 Office system驱动：https://download.csdn.net/download/loutengyuan/86501034");
                        }
                        else
                        {
                            MyMessageBox.ShowTipMessage("读取文件出错！请检查文件内容格式是否正确或者文件是否被加密！\n" + exception.ToString());
                        }
                    }
                    break;
                case 2:
                    try
                    {
                        ret.Add(new string[] { "lon", "lat", "dir", "speed", "alt", "time" });
                        string time = "";
                        double lat = 0;
                        double lon = 0;
                        double speed = 0;
                        double dir = 0;
                        double alt = 0;
                        string[] arrs;
                        StreamReader sr = new StreamReader(sltpath);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (line == null)
                            {
                                continue;
                            }
                            if (line.StartsWith("$GPRMC"))
                            {
                                arrs = line.Split(',');

                                if ("".Equals(arrs[1]) || "".Equals(arrs[3]) || "".Equals(arrs[5]) || "".Equals(arrs[7]) || "".Equals(arrs[8]))
                                {
                                    continue;
                                }

                                time = getTimeStr(arrs[1]);
                                lat = getLat(arrs[3]);
                                lon = getLon(arrs[5]);
                                speed = Double.Parse(arrs[7]);
                                dir = Double.Parse(arrs[8]);

                                ret.Add(new string[] { lon.ToString(), lat.ToString(), dir.ToString(), speed.ToString(), alt.ToString(), time });

                                //Console.WriteLine(lat + "," + lon);

                            }
                            if (line.StartsWith("$GNRMC"))
                            {
                                arrs = line.Split(',');

                                if (arrs == null || arrs.Length < 9 || "".Equals(arrs[1]) || "".Equals(arrs[3]) || "".Equals(arrs[5]) || "".Equals(arrs[7]))
                                {
                                    continue;
                                }

                                time = getTimeStr(arrs[1]);
                                lat = getLat(arrs[3]);
                                lon = getLon(arrs[5]);
                                speed = Double.Parse(arrs[7]);
                                if (!"".Equals(arrs[8]))
                                {
                                    dir = Double.Parse(arrs[8]);
                                }

                                ret.Add(new string[] { lon.ToString(), lat.ToString(), dir.ToString(), speed.ToString(), alt.ToString(), time });

                                //Console.WriteLine(lat + "," + lon);

                            }
                            if (line.StartsWith("$GNGGA"))
                            {
                                arrs = line.Split(',');

                                if (arrs[9] != null && !arrs[9].Trim().Equals(""))
                                {
                                    alt = Double.Parse(arrs[9]);
                                }

                            }
                            //Console.WriteLine(line);
                        }
                    }
                    catch (Exception exception)
                    {
                        MyMessageBox.ShowTipMessage("读取文件出错！请检查文件内容格式是否正确或者文件是否被加密！\n" + exception.ToString());
                    }
                    break;
                default:
                    break;
            }
            return ret;
        }

        private static String getTimeStr(String timeStr)
        {
            int h = Int32.Parse(timeStr.Substring(0, 2));
            int m = Int32.Parse(timeStr.Substring(2, 2));
            int s = Int32.Parse(timeStr.Substring(4, 2));
            //int S = Int32.Parse(timeStr.Substring(7, 2));
            return "2000-01-01 " + h + ":" + m + ":" + s;
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

        private char[] getSeparatorChar(int type)
        {
            switch (type)
            {
                case 0:
                    return new char[] { ',' };
                case 1:
                    return new char[] { '，' };
                case 2:
                    return new char[] { ';' };
                case 3:
                    return new char[] { '；' };
                case 4:
                    return new char[] { ' ' };
                default:
                    return new char[] { ',' };
            }
        }

        private int serial = 0;
        /// <summary>
        /// 初始化ListView的方法
        /// </summary>
        /// <param name="lv"></param>
        public void InitListView(ListView lv, string[] head)
        {
            serial = 0;
            //设置属性
            lv.GridLines = true;  //显示网格线
            lv.FullRowSelect = true;  //显示全行
            lv.MultiSelect = false;  //设置只能单选
            lv.View = View.Details;  //设置显示模式为详细
            lv.HoverSelection = true;  //当鼠标停留数秒后自动选择
            //把列名添加到listview中
            lv.Columns.Add("序号", 50);
            cb_lon_slt_row.Items.Clear();
            cb_lat_slt_row.Items.Clear();
            cb_dir_slt_row.Items.Clear();
            cb_speed_slt_row.Items.Clear();
            cb_alt_slt_row.Items.Clear();
            cb_acc_slt_row.Items.Clear();
            cb_time_slt_row.Items.Clear();
            for (int i = 0; i < head.Length; i++)
            {
                lv.Columns.Add("列" + i, 150);
                cb_lon_slt_row.Items.Add("列" + i + ":" + head[i]);
                cb_lat_slt_row.Items.Add("列" + i + ":" + head[i]);
                cb_dir_slt_row.Items.Add("列" + i + ":" + head[i]);
                cb_speed_slt_row.Items.Add("列" + i + ":" + head[i]);
                cb_alt_slt_row.Items.Add("列" + i + ":" + head[i]);
                cb_acc_slt_row.Items.Add("列" + i + ":" + head[i]);
                cb_time_slt_row.Items.Add("列" + i + ":" + head[i]);
                cb_type_slt_row.Items.Add("列" + i + ":" + head[i]);
                if (i == 0)
                {
                    cb_lon_slt_row.SelectedIndex = 0;
                    cb_lat_slt_row.SelectedIndex = 0;
                    cb_dir_slt_row.SelectedIndex = 0;
                    cb_speed_slt_row.SelectedIndex = 0;
                    cb_alt_slt_row.SelectedIndex = 0;
                    cb_acc_slt_row.SelectedIndex = 0;
                    cb_time_slt_row.SelectedIndex = 0;
                    cb_type_slt_row.SelectedIndex = 0;
                    cb_dir_enable.Checked = false;
                    cb_speed_enable.Checked = false;
                    cb_alt_enable.Checked = false;
                    cb_acc_enable.Checked = false;
                    cb_time_enable.Checked = false;
                    cb_type_enable.Checked = false;
                }
                if (cb_lon_slt_row.SelectedIndex == 0 && (head[i].ToLower().Contains("lon") || head[i].ToLower().Trim().Equals("x")))
                {
                    cb_lon_slt_row.SelectedIndex = i;
                }
                else if (cb_lat_slt_row.SelectedIndex == 0 && (head[i].ToLower().Contains("lat") || head[i].ToLower().Trim().Equals("y")))
                {
                    cb_lat_slt_row.SelectedIndex = i;
                }
                else if (cb_dir_slt_row.SelectedIndex == 0 && head[i].ToLower().Contains("dir"))
                {
                    cb_dir_slt_row.SelectedIndex = i;
                    cb_dir_enable.Checked = true;
                }
                else if (cb_speed_slt_row.SelectedIndex == 0 && (head[i].ToLower().Contains("speed") || head[i].ToLower().Trim().Equals("v")))
                {
                    cb_speed_slt_row.SelectedIndex = i;
                    cb_speed_enable.Checked = true;
                }
                else if (cb_alt_slt_row.SelectedIndex == 0 && head[i].ToLower().Contains("alt"))
                {
                    cb_alt_slt_row.SelectedIndex = i;
                    cb_alt_enable.Checked = true;
                }
                else if (cb_acc_slt_row.SelectedIndex == 0 && head[i].ToLower().Contains("acc"))
                {
                    cb_acc_slt_row.SelectedIndex = i;
                    cb_acc_enable.Checked = true;
                }
                else if (cb_time_slt_row.SelectedIndex == 0 && head[i].ToLower().Contains("time"))
                {
                    cb_time_slt_row.SelectedIndex = i;
                    if (Properties.Settings.Default.Setting_time_check)
                    {
                        cb_time_enable.Checked = true; 
                    }
                }
                else if (cb_type_slt_row.SelectedIndex == 0 && head[i].ToLower().Contains("type"))
                {
                    cb_type_slt_row.SelectedIndex = i;
                    cb_type_enable.Checked = true;
                }
            }
        }

        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="lv"></param>
        /// <returns></returns>
        public ListView InsertListView(ListView lv, string[] rowData)
        {
            serial++;
            //创建行对象
            ListViewItem li = new ListViewItem(serial + "");
            for (int i = 0; i < rowData.Length; i++)
            {
                //添加同一行的数据
                li.SubItems.Add(rowData[i]);
            }

            //将行对象绑定在listview对象中
            lv.Items.Add(li);
            //lv.EnsureVisible(lv.Items.Count - 1);
            //lv.Items[lv.Items.Count - 1].Checked = true;

            //MessageBox.Show("新增数据成功！");
            return lv;
        }
        List<GpsRoutePoint> gpsRoutePointList = null;
        string[] headAttributes = null;
        public GpsRoute gpsRoute = null;
        private double lastLon = 0;
        private double lastLat = 0;
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (routeInfoList == null || routeInfoList.Count <= 0 || headLine == null || headLine.Length < 2 || routeName == null)
            {
                MyMessageBox.ShowTipMessage("未加载数据");
                return;
            }
            CoordType coordType;
            if (cb_coord_type.Text.Equals("WGS84"))
            {
                coordType = CoordType.WGS84;
            }
            else if (cb_coord_type.Text.Equals("GCJ02"))
            {
                coordType = CoordType.GCJ02;
            }
            else if (cb_coord_type.Text.Equals("BD09"))
            {
                coordType = CoordType.BD09;
            }
            else
            {
                MyMessageBox.ShowTipMessage("请选择坐标系");
                return;
            }
            bool is_filter_0 = cb_filter_0_point.Checked;
            bool is_filter_repeat = cb_filter_repeat_point.Checked;
            // 分析解析参数
            int exCount = 0;
            int jumpCount = 0;
            int jump_num;
            double min_speed;
            try
            {
                List<int> sltRowList = new List<int>();
                // 经度下标
                int lon_idx = cb_lon_slt_row.SelectedIndex;
                sltRowList.Add(cb_lon_slt_row.SelectedIndex);
                double lon_scale = Double.Parse(tb_lon_scale.Text);
                // 纬度下标
                int lat_idx = cb_lat_slt_row.SelectedIndex;
                sltRowList.Add(cb_lat_slt_row.SelectedIndex);
                double lat_scale = Double.Parse(tb_lat_scale.Text);
                // 方向下标
                int dir_idx = -1;
                double dir_scale = 0;
                if (cb_dir_enable.Checked)
                {
                    dir_idx = cb_dir_slt_row.SelectedIndex;
                    sltRowList.Add(cb_dir_slt_row.SelectedIndex);
                    dir_scale = Double.Parse(tb_dir_scale.Text);
                }
                // 速度下标
                int speed_idx = -1;
                double speed_scale = 0;
                if (cb_speed_enable.Checked)
                {
                    speed_idx = cb_speed_slt_row.SelectedIndex;
                    sltRowList.Add(cb_speed_slt_row.SelectedIndex);
                    speed_scale = Double.Parse(tb_speed_scale.Text);
                }
                // 高度下标
                int alt_idx = -1;
                double alt_scale = 0;
                if (cb_alt_enable.Checked)
                {
                    alt_idx = cb_alt_slt_row.SelectedIndex;
                    sltRowList.Add(cb_alt_slt_row.SelectedIndex);
                    alt_scale = Double.Parse(tb_alt_scale.Text);
                }
                // 精度下标
                int acc_idx = -1;
                double acc_scale = 0;
                if (cb_acc_enable.Checked)
                {
                    acc_idx = cb_acc_slt_row.SelectedIndex;
                    sltRowList.Add(cb_acc_slt_row.SelectedIndex);
                    acc_scale = Double.Parse(tb_acc_scale.Text);
                }
                // 时间下标
                int time_idx = -1;
                string time_scale = "yyyy-MM-dd HH:mm:ss";
                if (cb_time_enable.Checked)
                {
                    time_idx = cb_time_slt_row.SelectedIndex;
                    sltRowList.Add(cb_time_slt_row.SelectedIndex);
                    time_scale = tb_time_scale.Text;
                }
                // 类型下标
                int type_idx = -1;
                double type_scale = 0;
                if (cb_type_enable.Checked)
                {
                    type_idx = cb_type_slt_row.SelectedIndex;
                    sltRowList.Add(cb_type_slt_row.SelectedIndex);
                    type_scale = Double.Parse(tb_type_scale.Text);
                }
                List<int> otherRowIdxList = new List<int>();
                if (headLine.Length - sltRowList.Count > 0)
                {
                    headAttributes = new string[headLine.Length - sltRowList.Count];
                    int j = 0;
                    for (int i = 0; i < headLine.Length; i++)
                    {
                        if (sltRowList.Contains(i))
                        {
                            continue;
                        }
                        otherRowIdxList.Add(i);
                        headAttributes[j] = headLine[i];
                        j++;
                    }
                }

                jump_num = Int32.Parse(tb_jump_num.Text.ToString().Trim());
                if (jump_num < 0)
                {
                    jump_num = 0;
                }
                min_speed = double.Parse(tb_min_speed.Text.ToString().Trim());
                int parse_line = 0;
                gpsRoutePointList = new List<GpsRoutePoint>();
                int id = 0;
                foreach (var item in routeInfoList)
                {
                    try
                    {
                        GpsRoutePoint info = new GpsRoutePoint();
                        // ID
                        info.ID = id;
                        // 经度
                        double lon = Double.Parse(item[lon_idx]) * lon_scale;
                        info.Longitude = lon;
                        // 纬度
                        double lat = Double.Parse(item[lat_idx]) * lat_scale;
                        info.Latitude = lat;
                        if (lon == 0 && lat == 0 && is_filter_0)
                        {
                            jumpCount++;
                            continue;
                        }
                        if (is_filter_repeat)
                        {
                            if (lon == lastLon && lat == lastLat)
                            {
                                jumpCount++;
                                continue;
                            }
                            lastLon = lon;
                            lastLat = lat;
                        }
                        // 方向
                        if (dir_idx >= 0)
                        {
                            double dir = Double.Parse(item[dir_idx]) * dir_scale;
                            info.Direction = dir;
                        }
                        // 速度
                        if (speed_idx >= 0)
                        {
                            double speed = Double.Parse(item[speed_idx]) * speed_scale;
                            if (speed < min_speed)
                            {
                                jumpCount++;
                                continue;
                            }
                            info.Speed = speed;
                        }
                        // 高度
                        if (alt_idx >= 0)
                        {
                            double alt = Double.Parse(item[alt_idx]) * alt_scale;
                            info.Altitude = alt;
                        }
                        // 精度
                        if (acc_idx >= 0)
                        {
                            double acc = Double.Parse(item[acc_idx]) * acc_scale;
                            info.Accuracy = acc;
                        }
                        // 时间
                        if (time_idx >= 0)
                        {
                            DateTime time = DateTime.ParseExact(item[time_idx], time_scale, null);
                            info.Datetime = time;
                        }
                        // 类型
                        if (type_idx >= 0)
                        {
                            double type = Double.Parse(item[type_idx]) * type_scale;
                            info.Type = type;
                        }
                        // 其他属性
                        if (otherRowIdxList.Count > 0)
                        {
                            string[] otherAttributes = new string[otherRowIdxList.Count];
                            int k = 0;
                            foreach (var otherRowIdx in otherRowIdxList)
                            {
                                otherAttributes[k] = item[otherRowIdx];
                                k++;
                            }
                            info.Attributes = otherAttributes;
                            info.HeadAttributes = headAttributes;
                        }
                        if (parse_line % (jump_num + 1) == 0)
                        {
                            gpsRoutePointList.Add(info);
                            id++;
                        }
                        else
                        {
                            jumpCount++;
                        }
                        parse_line++;
                    }
                    catch (Exception)
                    {
                        exCount++;
                        if (exCount > 100)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MyMessageBox.ShowTipMessage("解析参数错误\n" + ex.ToString());
                return;
            }
            if (exCount > 100)
            {
                MyMessageBox.ShowTipMessage("解析错误，请检查解析参数是否正确。");
                return;
            }
            if (gpsRoutePointList == null || gpsRoutePointList.Count <= 0)
            {
                MyMessageBox.ShowTipMessage("未解析到轨迹数据");
                return;
            }
            if (routeInfoList.Count > gpsRoutePointList.Count + 1 + jumpCount)
            {
                MyMessageBox.ShowTipMessage("存在" + (routeInfoList.Count - gpsRoutePointList.Count - 1 - jumpCount) + "行数据解析错误");
            }
            gpsRoute = new GpsRoute();
            gpsRoute.GpsRouteInfoList = gpsRoutePointList;
            gpsRoute.RouteName = routeName;
            gpsRoute.CoordType = coordType;
            // 保存配置
            Properties.Settings.Default.Setting_lon_scale = tb_lon_scale.Text;
            Properties.Settings.Default.Setting_lat_scale = tb_lat_scale.Text;
            Properties.Settings.Default.Setting_dir_scale = tb_dir_scale.Text;
            Properties.Settings.Default.Setting_speed_scale = tb_speed_scale.Text;
            Properties.Settings.Default.Setting_alt_scale = tb_alt_scale.Text;
            Properties.Settings.Default.Setting_acc_scale = tb_acc_scale.Text;
            Properties.Settings.Default.Setting_time_scale = tb_time_scale.Text;
            Properties.Settings.Default.Setting_type_scale = tb_type_scale.Text;
            Properties.Settings.Default.Setting_file_format_idx = cb_file_format.SelectedIndex;
            Properties.Settings.Default.Setting_separator_idx = cb_separator.SelectedIndex;
            Properties.Settings.Default.Setting_coord_type_idx = cb_coord_type.SelectedIndex;
            Properties.Settings.Default.Setting_is_filter_0_point = cb_filter_0_point.Checked;
            Properties.Settings.Default.Setting_is_filter_repeat_point = cb_filter_repeat_point.Checked;
            if (Properties.Settings.Default.Setting_time_check != cb_time_enable.Checked)
            {
                Properties.Settings.Default.Setting_time_check = cb_time_enable.Checked;
            }
            Properties.Settings.Default.Setting_jump_num = tb_jump_num.Text;
            Properties.Settings.Default.Setting_min_speed = tb_min_speed.Text;
            Properties.Settings.Default.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }


        /// <summary>
        /// 根据excle的路径把第一个sheel中的内容放入datatable
        /// </summary>
        /// <param name="execlFile"></param>
        /// <returns></returns>
        public DataTable ImportExcelXlsx(string execlFile)
        {
            //
            //连接字符串
            //
            //Office 07及以上版本,读取XLSX文件
            string connstring = "Provider=Microsoft.Ace.OleDb.12.0;" + "Data Source=" + execlFile + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=1'";

            //Office 07以下版本,读取xls文件
            //string connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + execlFile + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";

            using (OleDbConnection conn = new OleDbConnection(connstring))
            {
                conn.Open();
                DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
                string firstSheetName = sheetsName.Rows[0][2].ToString(); //得到第一个sheet的名字
                string sql = string.Format("SELECT * FROM [{0}]", firstSheetName); //查询字符串
                //string sql = string.Format("SELECT * FROM [{0}] WHERE [日期] is not null", firstSheetName); //查询字符串
                OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
                DataSet set = new DataSet();
                ada.Fill(set);
                return set.Tables[0];
            }
        }

        /// <summary>
        /// 根据excle的路径把第一个sheel中的内容放入datatable
        /// </summary>
        /// <param name="execlFile"></param>
        /// <returns></returns>
        public DataTable ImportExcelXls(string execlFile)
        {
            //
            //连接字符串
            //
            //Office 07及以上版本,读取XLSX文件
            //string connstring = "Provider=Microsoft.Ace.OleDb.12.0;" + "Data Source=" + execlFile + ";Extended Properties='Excel 12.0; HDR=YES; IMEX=1'";

            //Office 07以下版本,读取xls文件
            string connstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + execlFile + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";

            using (OleDbConnection conn = new OleDbConnection(connstring))
            {
                conn.Open();
                DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
                string firstSheetName = sheetsName.Rows[0][2].ToString(); //得到第一个sheet的名字
                string sql = string.Format("SELECT * FROM [{0}]", firstSheetName); //查询字符串
                //string sql = string.Format("SELECT * FROM [{0}] WHERE [日期] is not null", firstSheetName); //查询字符串
                OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
                DataSet set = new DataSet();
                ada.Fill(set);
                return set.Tables[0];
            }
        }
    }
}
