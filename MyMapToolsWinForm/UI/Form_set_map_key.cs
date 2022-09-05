using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMapProvidersExt.Tencent;
using GMapProvidersExt.AMap;
using GMapProvidersExt.Baidu;
using GMap.NET;

namespace MapToolsWinForm
{
    public partial class Form_set_map_key : Form
    {
        SearchEngineType mType;
        public Form_set_map_key(SearchEngineType type)
        {
            InitializeComponent();
            this.mType = type;
        }

        private void Form_set_map_key_Load(object sender, EventArgs e)
        {
            switch (mType)
            {
                case SearchEngineType.AMAP:
                    textBoxKey.Text = Properties.Settings.Default.Setting_amap_key;
                    this.Text = "设置高德地图Key";
                    break;
                case SearchEngineType.BAIDU:
                    textBoxKey.Text = Properties.Settings.Default.Setting_baidu_map_key;
                    this.Text = "设置百度地图Key";
                    break;
                case SearchEngineType.TENCENT:
                    textBoxKey.Text = Properties.Settings.Default.Setting_tencent_map_key;
                    this.Text = "设置腾讯地图Key";
                    break;
                default:
                    break;
            }
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            switch (mType)
            {
                case SearchEngineType.AMAP:
                    Process.Start("https://lbs.amap.com/");
                    break;
                case SearchEngineType.BAIDU:
                    Process.Start("https://lbsyun.baidu.com/");
                    break;
                case SearchEngineType.TENCENT:
                    Process.Start("https://lbs.qq.com/");
                    break;
                default:
                    break;
            }
        }

        private void button_verify_Click(object sender, EventArgs e)
        {
            PointLatLng point = new PointLatLng(24.4987084, 118.1377029);
            List<Placemark> placeList = null;
            string tempKey = null;
            switch (mType)
            {
                case SearchEngineType.AMAP:
                    tempKey = AMapProvider.Instance.GetKey();
                    AMapProvider.Instance.SetKey(textBoxKey.Text);
                    placeList = AMapProvider.Instance.GetPlacemarksByLocation(point);
                    AMapProvider.Instance.SetKey(tempKey);
                    break;
                case SearchEngineType.BAIDU:
                    tempKey = BaiduMapProvider.Instance.GetKey();
                    BaiduMapProvider.Instance.SetKey(textBoxKey.Text);
                    placeList = BaiduMapProvider.Instance.GetPlacemarksByLocation(point);
                    BaiduMapProvider.Instance.SetKey(tempKey);
                    break;
                case SearchEngineType.TENCENT:
                    tempKey = TencentMapProvider.Instance.GetKey();
                    TencentMapProvider.Instance.SetKey(textBoxKey.Text);
                    placeList = TencentMapProvider.Instance.GetPlacemarksByLocation(point);
                    TencentMapProvider.Instance.SetKey(tempKey);
                    break;
                default:
                    break;
            }
            if (placeList == null || placeList.Count <= 0) 
            {
                MessageBox.Show("校验失败");
            }
            else
            {
                MessageBox.Show("校验成功");
            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            string key = textBoxKey.Text.ToString().Trim();
            switch (mType)
            {
                case SearchEngineType.AMAP:
                    if (key == null || "".Equals(key.Trim()))
                    {
                        AMapProvider.Instance.SetKey(Properties.Settings.Default.Defult_amap_key);
                    }
                    else
                    {
                        AMapProvider.Instance.SetKey(key);
                    }
                    Properties.Settings.Default.Setting_amap_key = key;
                    Properties.Settings.Default.Save();
                    break;
                case SearchEngineType.BAIDU:
                    if (key == null || "".Equals(key.Trim()))
                    {
                        BaiduMapProvider.Instance.SetKey(Properties.Settings.Default.Defult_baidu_map_key);
                    }
                    else
                    {
                        BaiduMapProvider.Instance.SetKey(key);
                    }
                    Properties.Settings.Default.Setting_baidu_map_key = key;
                    Properties.Settings.Default.Save();
                    break;
                case SearchEngineType.TENCENT:
                    if (key == null || "".Equals(key.Trim()))
                    {
                        TencentMapProvider.Instance.SetKey(Properties.Settings.Default.Defult_tencent_map_key);
                    }
                    else
                    {
                        TencentMapProvider.Instance.SetKey(key);
                    }
                    Properties.Settings.Default.Setting_tencent_map_key = key;
                    Properties.Settings.Default.Save();
                    break;
                default:
                    break;
            }
            MessageBox.Show("设置成功");
            this.Close();
        }
    }
}
