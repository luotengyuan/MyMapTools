using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using GMap.NET;
using GMapCommonType;
using System.IO;

namespace GMapUtil
{
    public class KmlFileUtils_bak
    {
        public static bool saveGpsRouteToKmlFile(string filePath, CoordType type)
        {
            try
            {
                //// 创建XML文档对象
                //XmlDocument doc = new XmlDocument();

                //// 创建KML根元素
                //XmlElement kmlElement = doc.CreateElement("kml");
                //kmlElement.SetAttribute("xmlns", "http://www.opengis.net/kml/2.2");
                //doc.AppendChild(kmlElement);

                //// 创建Document元素
                //XmlElement documentElement = doc.CreateElement("Document");
                //kmlElement.AppendChild(documentElement);

                //// 创建名称元素
                //XmlElement nameElement = doc.CreateElement("name");
                //nameElement.InnerText = gpsRoute.RouteName;
                //documentElement.AppendChild(nameElement);

                //// 添加GPS点坐标
                //List<GpsRoutePoint> gpsPoints = gpsRoute.GpsRouteInfoList;
                //foreach (GpsRoutePoint point in gpsPoints)
                //{
                //    // 创建Placemark元素
                //    XmlElement placemarkElement = doc.CreateElement("Placemark");
                //    documentElement.AppendChild(placemarkElement);

                //    // 创建visibility元素
                //    XmlElement visibilityElement = doc.CreateElement("visibility");
                //    placemarkElement.AppendChild(visibilityElement);
                //    visibilityElement.InnerText = "1";

                //    // 创建线段元素
                //    XmlElement pointElement = doc.CreateElement("Point");
                //    placemarkElement.AppendChild(pointElement);

                //    // 创建坐标元素
                //    XmlElement coordinatesElement = doc.CreateElement("coordinates");
                //    pointElement.AppendChild(coordinatesElement);
                //    PointLatLng lonLat = new PointLatLng(point.Latitude, point.Longitude, gpsRoute.CoordType);
                //    lonLat = PointInDiffCoord.GetPointInCoordType(lonLat, type);
                //    coordinatesElement.InnerText = lonLat.Lng + "," + lonLat.Lat + "," + point.Altitude;

                //    // 创建Style元素
                //    XmlElement styleElement = doc.CreateElement("Style");
                //    placemarkElement.AppendChild(styleElement);
                //    // 创建IconStyle元素
                //    XmlElement iconStyleElement = doc.CreateElement("IconStyle");
                //    styleElement.AppendChild(iconStyleElement);

                //    // 创建scale元素
                //    XmlElement scaleElement = doc.CreateElement("scale");
                //    iconStyleElement.AppendChild(scaleElement);
                //    scaleElement.InnerText = "1";

                //    //// 创建heading元素
                //    //XmlElement headingElement = doc.CreateElement("heading");
                //    //iconStyleElement.AppendChild(headingElement);
                //    //headingElement.InnerText = ((int)point.Direction).ToString();

                //    // 创建Icon元素
                //    XmlElement iconElement = doc.CreateElement("Icon");
                //    iconStyleElement.AppendChild(iconElement);

                //    // 创建href元素
                //    XmlElement hrefElement = doc.CreateElement("href");
                //    iconElement.AppendChild(hrefElement);
                //    hrefElement.InnerText = "https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/ylw-stars.png";

                //}

                //// 保存KML文件
                //doc.Save(filePath);

                Console.WriteLine("KML文件已生成！");
                return true;
            }
            catch (System.Exception)
            {
            }
            Console.WriteLine("KML文件生成失败！");
            return false;
            
        }

        public static int loadKmlFile(string filePath, List<string[]> pointsStrList)
        {
            if (!File.Exists(filePath))
            {
                return -1;
            }
            if (pointsStrList == null)
            {
                return -1;
            }
            // 加载KML文件
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            // 查找所有的Point节点
            List<XmlNode> pointNodes = new List<XmlNode>();
            FindPointNodes(xmlDoc.DocumentElement, pointNodes, "Point");

            if (pointNodes != null)
            {
                pointsStrList.Add(new string[] { "lon", "lat" });
                foreach (XmlNode pointNode in pointNodes)
                {
                    // 解析经度和纬度
                    List<XmlNode> coordinatesNodes = new List<XmlNode>();
                    FindPointNodes(pointNode, coordinatesNodes, "coordinates");
                    if (coordinatesNodes != null)
                    {
                        foreach (XmlNode coordinatesNode in coordinatesNodes)
                        {
                            string[] coordinates = coordinatesNode.InnerText.Trim().Split(',');
                            if (coordinates.Length >= 2)
                            {
                                double longitude = double.Parse(coordinates[0]);
                                double latitude = double.Parse(coordinates[1]);

                                // 处理经度和纬度数据
                                pointsStrList.Add(new string[] { longitude + "", latitude + "" });
                            }
                        }
                    }
                }
            }

            return pointsStrList.Count;
        }

        static void FindPointNodes(XmlNode node, List<XmlNode> pointNodes, string noteName)
        {
            if (node.Name == noteName)
            {
                pointNodes.Add(node);
            }

            foreach (XmlNode childNode in node.ChildNodes)
            {
                FindPointNodes(childNode, pointNodes, noteName);
            }
        }
    }
}
