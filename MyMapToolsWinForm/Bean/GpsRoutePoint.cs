using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MapToolsWinForm
{
    /// <summary>
    /// 单个轨迹点信息
    /// </summary>
    class GpsRoutePoint
    {
        /// <summary>
        /// ID
        /// </summary>
        private int id;

        [DisplayName("ID")]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 经度：度
        /// </summary>
        private double longitude;

        [DisplayName("Longitude")]
        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        /// <summary>
        /// 纬度：度
        /// </summary>
        private double latitude;

        [DisplayName("Latitude")]
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        /// <summary>
        /// 方向：度
        /// </summary>
        private double direction;

        [DisplayName("Direction")]
        public double Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        /// <summary>
        /// 速度：公里/小时
        /// </summary>
        private double speed;

        [DisplayName("Speed")]
        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        /// <summary>
        /// 海拔高度：米
        /// </summary>
        private double altitude;

        [DisplayName("Altitude")]
        public double Altitude
        {
            get { return altitude; }
            set { altitude = value; }
        }
        /// <summary>
        /// 定位精度：米
        /// </summary>
        private double accuracy;

        [DisplayName("Accuracy")]
        public double Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        private double type;

        [DisplayName("Type")]
        public double Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        private DateTime datetime;

        [DisplayName("Datetime")]
        public DateTime Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }

        private string[] attributes;

        public string[] Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        private string[] headAttributes;

        public string[] HeadAttributes
        {
            get { return headAttributes; }
            set { headAttributes = value; }
        }

        /// <summary>
        /// 默认属性
        /// </summary>
        [DisplayName("AttributeStr")]
        public string AttributeStr
        {
            get
            {
                string ret = "ID:" + id;
                ret += "\nLongitude:" + longitude;
                ret += "\nLatitude:" + latitude;
                ret += "\nDirection:" + direction;
                ret += "\nSpeed:" + speed;
                ret += "\nAltitude:" + altitude;
                ret += "\nAccuracy:" + accuracy;
                ret += "\nDatetime:" + datetime;
                ret += "\nType:" + type;
                return ret;
            }
        }

        /// <summary>
        /// 其他属性：每个属性使用“|~|”隔开
        /// </summary>
        [DisplayName("OtherAttributeStr")]
        public string OtherAttributeStr
        {
            get 
            {
                string ret = "";
                for (int i = 0; attributes != null && i < attributes.Length && headAttributes != null && i < headAttributes.Length; i++)
                {
                    if (i == 0)
                    {
                        ret += headAttributes[i] + ":" + attributes[i];
                    }
                    else
                    {
                        ret += "\n" + headAttributes[i] + ":" + attributes[i];
                    }
                }
                return ret;
            }
        }

        public GpsRoutePoint()
        {

        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4}", longitude, latitude, direction, speed, altitude);
        }
    }
}
