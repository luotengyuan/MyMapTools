using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using GMap.NET;
using GMap.NET.MapProviders;
using NetUtil;
using Newtonsoft.Json.Linq;
using log4net;
using GMap.NET.WindowsForms;
using MyDefaultLib;

namespace GMapProvidersExt.Baidu
{
    public class BaiduMapProvider : BaiduMapProviderBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BaiduMapProvider));
        private static string KEY = "";

        private int succeedCount;
        public delegate void QueryProgressDelegate(long completedCount, long total);

        // Fields
        private readonly string cnName;
        public string fm;
        private readonly Guid id = new Guid("5532ECC6-6561-4451-BF2D-22E86D0DC9F8");
        public static readonly BaiduMapProvider Instance;
        private readonly string name;
        public string type;
        public string Version;

        public void SetKey(string key)
        {
            KEY = key;
        }

        public string GetKey()
        {
            return KEY;
        }

        // Methods
        static BaiduMapProvider()
        {
            Instance = new BaiduMapProvider();
            GMapProviders.AddMapProvider(Instance);
        }

        private BaiduMapProvider()
        {
            this.Version = "039";
            this.type = "web";
            this.fm = "44";
            this.name = "BaiduMap";
            this.cnName = "百度普通地图";
        }

        public Placemark GetCenterNameByLocation(PointLatLng location)
        {
            GeoCoderStatusCode statusCode = new GeoCoderStatusCode();
            Placemark? place = this.GetPlacemark(location, out statusCode);
            if (place.HasValue)
            {
                return place.Value;
            }

            return Placemark.Empty;
        }

        public GeoCoderStatusCode GetPlacemarksByKeywords(string keywords, string region, string rectangle,
            QueryProgressDelegate queryProgressEvent, out List<Placemark> placemarkList, ref int count)
        {
            this.succeedCount = 0;
            //this.totalCount = 0;
            placemarkList = this.GetPlacemarksByKeywords(keywords, region, rectangle, 0, queryProgressEvent, ref count);
            return GeoCoderStatusCode.G_GEO_SUCCESS;
        }

        private List<Placemark> GetPlacemarksByKeywords(string keywords, string region, string rectangle,
            int pageIndex, QueryProgressDelegate queryProgressEvent, ref int totalCount)
        {
            List<Placemark> list = new List<Placemark>();
            int pageSize = 20;
            string keyWordUrlEncode = HttpUtility.UrlEncode(keywords);
            string format = string.Format("http://api.map.baidu.com/place/v2/search?q={0}&output=json&page_size={1}&page_num={2}&scope=1&city_limit=true&extensions_adcode=true&scope=2", keyWordUrlEncode, pageSize, pageIndex);
            //"http://api.map.baidu.com/place/v2/search?ak=您的密钥&output=json&query=%E9%93%B6%E8%A1%8C&page_size=10&page_num=0&scope=1&region=%E5%8C%97%E4%BA%AC"
            if (!string.IsNullOrEmpty(region))
            {
                format += string.Format("&region={0}", HttpUtility.UrlEncode(region));
            }
            if (!string.IsNullOrWhiteSpace(KEY))
            {
                format += string.Format("&ak={0}", KEY);
            }
            //Get Cache Json Result if exist
            //string cacheUrl = string.Format("http://api.map.baidu.com/place/v2/search/{0}/{1}/{2}/{3}", new object[] { keyWordUrlEncode, HttpUtility.UrlEncode(region), pageIndex, pageSize });
            //string cacheResult = Singleton<Cache>.Instance.GetContent(cacheUrl, CacheType.UrlCache, TimeSpan.FromHours(360.0));
            //if (string.IsNullOrEmpty(cacheResult))
            //{
            //    cacheResult = HttpUtil.GetData(format);
            //    if (!string.IsNullOrEmpty(cacheResult))
            //    {
            //        Singleton<Cache>.Instance.SaveContent(cacheUrl, CacheType.UrlCache, cacheResult);
            //    }
            //}
            //if (string.IsNullOrEmpty(cacheResult))
            //{
            //    return list;
            //}
            try
            {
                string cacheResult = MapRequestTools.GetData(format);
                JObject jsonResult = JObject.Parse(cacheResult);
                string message = (string)jsonResult["message"];
                if (message == "ok")
                {
                    if (pageIndex == 0)
                    {
                        totalCount = int.Parse((string)jsonResult["total"]);
                    }
                    if (totalCount <= 0) return list;

                    JArray results = (JArray)jsonResult["results"];
                    if (results != null && results.Count > 0)
                    {
                        for (int i = 0; i < results.Count; ++i)
                        {
                            JObject obj = results[i] as JObject;
                            string name = obj["name"].ToString();
                            string address = obj["address"].ToString();
                            double lat = double.Parse(obj["location"]["lat"].ToString());
                            double lng = double.Parse(obj["location"]["lng"].ToString());
                            string provinceName = obj["province"].ToString();
                            string cityName = obj["city"].ToString();
                            //string cityCode = obj["ad_info"]["province"].ToString();
                            string adCode = obj["adcode"].ToString();
                            string adName = obj["area"].ToString();
                            string tel = obj["telephone"].ToString();
                            string category = "";
                            if ("1".Equals(obj["detail"].ToString()))
                            {
                                category = obj["detail_info"]["type"].ToString();
                            }
                            Placemark item = new Placemark(address);
                            item.Point = new PointLatLng(lat, lng, CoordType.BD09);
                            item.Name = name;
                            item.ProvinceName = provinceName;
                            item.CityName = cityName;
                            //item.CityCode = cityCode;
                            item.AdCode = adCode;
                            item.AdName = adName;
                            item.Tel = tel;
                            item.Category = category;
                            list.Add(item);
                            ++this.succeedCount;
                            if (queryProgressEvent != null)
                            {
                                queryProgressEvent((long)this.succeedCount, (long)totalCount);
                            }
                        }
                    }
                    int allPageNum = (int)Math.Ceiling((double)(((double)totalCount) / ((double)pageSize)));
                    if (pageIndex < allPageNum)
                    {
                        list.AddRange(this.GetPlacemarksByKeywords(keywords, region, rectangle, pageIndex + 1, queryProgressEvent, ref totalCount));
                    }
                }
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message);
            }
            return list;
        }

        public GeoCoderStatusCode GetPlacemarks(PointLatLng location, out List<Placemark> placemarkList)
        {
            placemarkList = this.GetPlacemarksByLocation(location);
            return GeoCoderStatusCode.G_GEO_SUCCESS;
        }

        public Placemark? GetPlacemark(PointLatLng location, out GeoCoderStatusCode status)
        {
            List<Placemark> placemarksByLocation = this.GetPlacemarksByLocation(location);
            if (placemarksByLocation != null && placemarksByLocation.Count > 0)
            {
                status = GeoCoderStatusCode.G_GEO_SUCCESS;
                return new Placemark(placemarksByLocation[0]);
            }
            status = GeoCoderStatusCode.Unknow;
            return null;
        }

        public List<Placemark> GetPlacemarksByLocation(PointLatLng location)
        {
            List<Placemark> list = new List<Placemark>();
            try
            {
                string reqUrl = string.Format("https://api.map.baidu.com/place/v2/search?query=门址$银行$酒店$美食$山$村$号&location={0}&radius=10000&output=json&page_size=5", location.Lat + "," + location.Lng);
                if (!string.IsNullOrWhiteSpace(KEY))
                {
                    reqUrl += string.Format("&ak={0}", KEY);
                }
                //https://api.map.baidu.com/place/v2/search?query=门址&location=39.915,116.404&radius=1000&output=json&page_size=5&ak=CQnucm2q5gflDUai9Q9nVWtIhVaZXRIB
                string content = MapRequestTools.GetData(reqUrl);
                JObject jsonObj = JObject.Parse(content);
                if (jsonObj != null && jsonObj["message"].ToString() == "ok")
                {
                    JArray results = jsonObj["results"] as JArray;
                    if (results != null)
                    {
                        foreach (var item in results)
                        {
                            Placemark place = new Placemark();
                            place.Address = item["address"].ToString();
                            place.ProvinceName = item["province"].ToString();
                            place.CityName = item["city"].ToString();
                            place.DistrictName = item["area"].ToString();
                            JObject locationObj = item["location"] as JObject;
                            if (locationObj != null)
                            {
                                double lng = double.Parse(locationObj["lng"].ToString());
                                double lat = double.Parse(locationObj["lat"].ToString());
                                PointLatLng p = new PointLatLng(lat, lng, CoordType.BD09);
                                place.Point = p;
                            }
                            list.Add(place);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message);
            }

            return list;
        }

        private List<PointLatLng> GetPointsByPlacemark(Placemark placemark)
        {
            List<PointLatLng> list = new List<PointLatLng>();
            try
            {
                string url = string.Format("https://api.map.baidu.com/geocoding/v3/?address={0}&output=json", placemark.Address);
                if (placemark.CityName != null)
                {
                    url += string.Format("&city={0}", placemark.CityName);
                }
                if (!string.IsNullOrWhiteSpace(KEY))
                {
                    url += string.Format("&ak={0}", KEY);
                }
                string content = MapRequestTools.GetData(url);
                JObject jsonObj = JObject.Parse(content);
                if (jsonObj != null && Int32.Parse(jsonObj["status"].ToString()) == 0)
                {
                    JObject result = jsonObj["result"] as JObject;
                    if (result != null)
                    {
                        JObject location = result["location"] as JObject;
                        if (location != null)
                        {
                            double lon = double.Parse(location["lng"].ToString());
                            double lat = double.Parse(location["lat"].ToString());
                            PointLatLng point = new PointLatLng(lat, lon, CoordType.BD09);
                            list.Add(point);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message);
            }
            return list;
        }

        public GeoCoderStatusCode GetPoints(string keywords, out List<PointLatLng> pointList)
        {
            throw new Exception("未实现");
        }

        public PointLatLng? GetPoint(string keywords, out GeoCoderStatusCode status)
        {
            throw new Exception("未实现");
        }

        public GeoCoderStatusCode GetPoints(Placemark placemark, out List<PointLatLng> pointList)
        {
            pointList = this.GetPointsByPlacemark(placemark);
            return GeoCoderStatusCode.G_GEO_SUCCESS;
        }

        public PointLatLng? GetPoint(Placemark placemark, out GeoCoderStatusCode status)
        {
            List<PointLatLng> points = this.GetPointsByPlacemark(placemark);
            if (points != null && points.Count > 0)
            {
                status = GeoCoderStatusCode.G_GEO_SUCCESS;
                return points[0];
            }

            status = GeoCoderStatusCode.Unknow;
            return null;
        }

        #region GetRoute

        public GMapRoute GetDrivingRoute(PointLatLng start, PointLatLng end, List<PointLatLng> wayList)
        {
            List<PointLatLng> points = new List<PointLatLng>();
            string origin = string.Format("{0},{1}", start.Lat, start.Lng);
            string destination = string.Format("{0},{1}", end.Lat, end.Lng);
            string url = "";
            if (wayList == null || wayList.Count <= 0)
            {
                url = string.Format("https://api.map.baidu.com/direction/v2/driving?origin={0}&destination={1}", origin, destination);
            }
            else
            {
                string waysStr = "";
                foreach (var item in wayList)
                {
                    waysStr += string.Format("{0},{1}|", item.Lat, item.Lng);
                }
                waysStr = waysStr.TrimEnd('|');
                url = string.Format("https://api.map.baidu.com/direction/v2/driving?origin={0}&destination={1}&waypoints={2}", origin, destination, waysStr);
            }
            if (!string.IsNullOrWhiteSpace(KEY))
            {
                url += string.Format("&ak={0}", KEY);
            }
            string result = MapRequestTools.GetData(url);
            if (!string.IsNullOrEmpty(result))
            {
                JObject resJosn = JObject.Parse(result);
                string isOk = resJosn["status"].ToString();
                if (isOk == "0")
                {
                    JObject result_json = (JObject)resJosn["result"];
                    if (result_json != null)
                    {
                        JArray routes = (JArray)result_json["routes"];
                        if (routes != null && routes.Count > 0)
                        {
                            JObject route = (JObject)routes[0];
                            JArray steps = (JArray)route["steps"];
                            if (steps != null && steps.Count > 0)
                            {
                                foreach (JObject step in steps)
                                {
                                    string path = step["path"].ToString();
                                    string[] pointsString = path.Split(';');
                                    foreach (string pStr in pointsString)
                                    {
                                        string[] pointStr = pStr.Split(',');
                                        PointLatLng p = new PointLatLng(double.Parse(pointStr[1]), double.Parse(pointStr[0]), CoordType.BD09);
                                        points.Add(p);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            GMapRoute mapRoute = points != null ? new GMapRoute(points, "") : null;
            return mapRoute;
        }

        #endregion

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            string url = this.MakeTileImageUrl(pos, zoom, GMapProvider.LanguageStr);
            try
            {
                return base.GetTileImageUsingHttp(url);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string MakeTileImageUrl(GPoint pos, int zoom, string language)
        {
            long num = pos.X - ((long)Math.Pow(2.0, (double)(zoom - 1)));
            long num2 = (((long)Math.Pow(2.0, (double)(zoom - 1))) - pos.Y) - 1;
            string str = num.ToString();
            string str2 = num2.ToString();
            if (str.StartsWith("-"))
            {
                str = "M" + str.Substring(1);
            }
            if (str2.StartsWith("-"))
            {
                str2 = "M" + str2.Substring(1);
            }
            int serverNum = GMapProvider.GetServerNum(pos, BaiduMapProviderBase.maxServer) + 1;
            return string.Format(BaiduMapProviderBase.UrlFormat, new object[] { serverNum, str, str2, zoom });
        }

        // Properties
        public string CnName
        {
            get
            {
                return this.cnName;
            }
        }

        public override Guid Id
        {
            get
            {
                return this.id;
            }
        }

        public override string Name
        {
            get
            {
                return this.name;
            }
        }
    }


}
