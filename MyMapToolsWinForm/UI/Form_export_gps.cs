﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GMapCommonType;
using GMap.NET;
using GMapUtil;

namespace MapToolsWinForm
{
    public partial class Form_export_gps : Form
    {
        GpsRoute sltGpsRoute;
        public Form_export_gps(GpsRoute sltGpsRoute)
        {
            InitializeComponent();
            this.sltGpsRoute = sltGpsRoute;
            textBox_name.Text = sltGpsRoute.RouteName;
            if (sltGpsRoute.CoordType == GMap.NET.CoordType.WGS84)
            {
                comboBox_coord_type.SelectedIndex = 0;
            }
            else if (sltGpsRoute.CoordType == GMap.NET.CoordType.GCJ02)
            {
                comboBox_coord_type.SelectedIndex = 1;
            }
            else if (sltGpsRoute.CoordType == GMap.NET.CoordType.BD09)
            {
                comboBox_coord_type.SelectedIndex = 2;
            }
            else
            {
                comboBox_coord_type.SelectedIndex = 0;
            }
            comboBox_file_type.SelectedIndex = 0;
        }

        private void button_sel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择文件保存文件夹";  //提示的文字
            if (folder.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = folder.SelectedPath;
            }
        }

        private void button_cencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("请先选择输出路径");
                return;
            }
            string file_name = textBox_name.Text.ToString().Trim();
            if (file_name.Equals(""))
            {
                MessageBox.Show("请先输入文件名称");
                return;
            }
            if (comboBox_file_type.SelectedIndex == 0)
            {
                if (!file_name.EndsWith(".csv"))
                {
                    file_name += ".csv";
                }
            }
            else
            {
                if (!file_name.EndsWith(".kml"))
                {
                    file_name += ".kml";
                }
            }
            CoordType type;
            if (comboBox_coord_type.SelectedIndex == 0)
            {
                type = CoordType.WGS84;
            }
            else if (comboBox_coord_type.SelectedIndex == 1)
            {
                type = CoordType.GCJ02;
            }
            else
            {
                type = CoordType.BD09;
            }
            string full_path_name = textBox_path.Text.ToString().Trim().TrimEnd('\\') + "\\" + type.ToString() + "_" + file_name;
            if (File.Exists(full_path_name))
            {
                DialogResult result = MessageBox.Show("导出文件已存在，是否覆盖保存？");
                if (result == DialogResult.OK)
                {
                    File.Delete(full_path_name);
                }
                else
                {
                    return;
                }
            }

            if (sltGpsRoute == null || sltGpsRoute.GpsRouteInfoList == null || sltGpsRoute.GpsRouteInfoList.Count <= 0)
            {
                MessageBox.Show("轨迹为空");
                return;
            }
            bool ret = true;
            if (comboBox_file_type.SelectedIndex == 0)
            {
                ret = saveGpsRouteToCsvFile(full_path_name, sltGpsRoute, type);
            }
            else
            {
                List<PointLatLng> points = new List<PointLatLng>();
                foreach (var item in sltGpsRoute.GpsRouteInfoList)
                {
                    points.Add(PointInDiffCoord.GetPointInCoordType(new PointLatLng(item.Latitude, item.Longitude, sltGpsRoute.CoordType), type));
                }
                KmlUtil.SavePointsIcon(points, sltGpsRoute.RouteName, full_path_name);
            }
            if (ret)
            {
                MessageBox.Show("轨迹导出成功");
            }
            else
            {
                MessageBox.Show("轨迹导出失败");
            }
            this.Close();
        }

        public static bool saveGpsRouteToCsvFile(string full_path_name, GpsRoute sltGpsRoute, CoordType type)
        {
            try
            {
                using (FileStream fs = new FileStream(full_path_name, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                    {
                        string headStr = "lon,lat,direction,speed,altitude,accuracy,datetime";
                        if (sltGpsRoute.GpsRouteInfoList[0].HeadAttributes != null)
                        {
                            for (int i = 0; i < sltGpsRoute.GpsRouteInfoList[0].HeadAttributes.Length; i++)
                            {
                                headStr += "," + sltGpsRoute.GpsRouteInfoList[0].HeadAttributes[i];
                            }
                        }
                        sw.WriteLine(headStr);
                        foreach (var item in sltGpsRoute.GpsRouteInfoList)
                        {
                            StringBuilder sb = new StringBuilder();
                            PointLatLng lonLat = new PointLatLng(item.Latitude, item.Longitude, sltGpsRoute.CoordType);
                            lonLat = PointInDiffCoord.GetPointInCoordType(lonLat, type);
                            sb.Append(lonLat.Lng + ",");
                            sb.Append(lonLat.Lat + ",");
                            sb.Append(item.Direction + ",");
                            sb.Append(item.Speed + ",");
                            sb.Append(item.Altitude + ",");
                            sb.Append(item.Accuracy + ",");
                            sb.Append(item.Datetime.ToString("yyyy-MM-dd HH:mm:ss"));
                            if (item.Attributes != null)
                            {
                                for (int i = 0; i < item.Attributes.Length; i++)
                                {
                                    sb.Append(item.Attributes[i] + ",");
                                }
                            }
                            sw.WriteLine(sb.ToString());
                        }
                    }
                }

                Console.WriteLine("CSV文件已生成！");
                return true;
            }
            catch (System.Exception)
            {
            }
            Console.WriteLine("CSV文件生成失败！");
            return false;

        }
    }
}
