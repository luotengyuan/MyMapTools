
namespace GMapProvidersExt.OSM
{
   using System;
   using System.Collections.Generic;
   using System.Diagnostics;
   using System.Globalization;
   using System.Xml;
   using GMap.NET.Internals;
   using GMap.NET.Projections;
   using NetUtil;
   using Newtonsoft.Json.Linq;
   using GMap.NET.MapProviders;
   using GMap.NET;

   public abstract class OsmMapProviderBase : GMapProvider, RoutingProvider, GeocodingProvider
   {
       public OsmMapProviderBase()
      {
         MaxZoom = null;
         //Tile usage policy of openstreetmap (https://operations.osmfoundation.org/policies/tiles/) define as optional and providing referer 
         //only if one valid available. by providing http://www.openstreetmap.org/ a 418 error is given by the server.
         //RefererUrl = "http://www.openstreetmap.org/";
         Copyright = string.Format("© OpenStreetMap - Map data ©{0} OpenStreetMap", DateTime.Today.Year);
      }

      public readonly string ServerLetters = "abc";
      public int MinExpectedRank = 0;

      #region GMapProvider Members

      public override Guid Id
      {
         get
         {
            throw new NotImplementedException();
         }
      }

      public override string Name
      {
         get
         {
            throw new NotImplementedException();
         }
      }

      public override PureProjection Projection
      {
         get
         {
            return MercatorProjection.Instance;
         }
      }

      public override GMapProvider[] Overlays
      {
         get
         {
            throw new NotImplementedException();
         }
      }

      public override PureImage GetTileImage(GPoint pos, int zoom)
      {
         throw new NotImplementedException();
      }

      #endregion

      #region GMapRoutingProvider Members

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

      public MapRoute GetDrivingRoute(PointLatLng start, PointLatLng end, List<PointLatLng> wayList)
      {
          List<PointLatLng> points = new List<PointLatLng>();
          string origin = string.Format("{0},{1}", start.Lng, start.Lat);
          string destination = string.Format("{0},{1}", end.Lng, end.Lat);
          string url = "";
          if (wayList == null || wayList.Count <= 0)
          {
              //url = string.Format("https://restapi.amap.com/v3/direction/driving?origin={0}&destination={1}&output=json", origin, destination);
              url = string.Format("http://routing.openstreetmap.de/routed-car/route/v1/driving/{0};{1}?overview=false&geometries=geojson&steps=true", origin, destination);
          }
          else
          {
              string wayStr = "";
              foreach (var item in wayList)
              {
                  if (item != PointLatLng.Empty)
                  {
                      wayStr += string.Format("{0},{1};", item.Lng, item.Lat);
                  }
              }
              wayStr = wayStr.TrimEnd(';');
              //url = string.Format("https://restapi.amap.com/v3/direction/driving?origin={0}&destination={1}&output=json&waypoints={2}", origin, destination, wayStr);
              url = string.Format("http://routing.openstreetmap.de/routed-car/route/v1/driving/{0};{2}{1}?overview=false&geometries=geojson&steps=true", origin, destination, wayStr);
          }

          string result = HttpUtil.GetData(url);

          if (!string.IsNullOrEmpty(result))
          {
              JObject resJosn = JObject.Parse(result);
              string isOk = resJosn["code"].ToString();
              if (isOk == "Ok")
              {
                  JArray routes = (JArray)resJosn["routes"];
                  if (routes != null && routes.Count > 0)
                  {
                      JObject route = (JObject)routes[0];
                      JArray legs = (JArray)route["legs"];
                      if (legs != null && legs.Count > 0)
                      {
                          JObject leg = (JObject)legs[0];
                          JArray steps = (JArray)leg["steps"];
                          if (steps != null && steps.Count > 0)
                          {
                              foreach (JObject step in steps)
                              {
                                  JArray coordinates = (JArray)step["geometry"]["coordinates"];
                                  if (coordinates != null && coordinates.Count > 0)
                                  {
                                      foreach (JArray item in coordinates)
                                      {
                                          double lon = double.Parse(item[0].ToString());
                                          double lat = double.Parse(item[1].ToString());
                                          PointLatLng p = new PointLatLng(lat, lon, CoordType.WGS84);
                                          points.Add(p);
                                      }
                                  }  
                              }
                          }
                      }
                  }

              }
          }

          MapRoute mapRoute = points != null ? new MapRoute(points, "") : null;
          return mapRoute;
      }

      public virtual MapRoute GetRoute(PointLatLng start, PointLatLng end, bool avoidHighways, bool walkingMode, int Zoom, bool getInstructions = false)
      {
         var url = MakeRoutingUrl(start, end, walkingMode ? TravelTypeFoot : TravelTypeMotorCar, getInstructions);

         string routeXml = GMaps.Instance.UseRouteCache ? Cache.Instance.GetContent(url, CacheType.RouteCache) : string.Empty;
         if (string.IsNullOrEmpty(routeXml))
         {
            routeXml = GetContentUsingHttp(url);
            if (!string.IsNullOrEmpty(routeXml))
            {
               if (GMaps.Instance.UseRouteCache)
               {
                  Cache.Instance.SaveContent(url, CacheType.RouteCache, routeXml);
               }
            }
         }

         MapRoute route = null;
         try
         {
            if (!string.IsNullOrEmpty(routeXml))
            {
               XmlDocument xmldoc = new XmlDocument();
               xmldoc.LoadXml(routeXml);
               XmlNamespaceManager xmlnsManager = new XmlNamespaceManager(xmldoc.NameTable);
               xmlnsManager.AddNamespace("sm", "http://earth.google.com/kml/2.0");

               if (!string.IsNullOrEmpty(routeXml))
               {
                  var points = GetRoutePoints(xmldoc, xmlnsManager);

                  if (points != null)
                  {
                     route = new MapRoute(points, walkingMode ? WalkingStr : DrivingStr)
                     {
                        TravelTime = GetTravelTime(xmldoc, xmlnsManager)
                     };

                     if (getInstructions)
                        route.Instructions.AddRange(GetInstructions(xmldoc, xmlnsManager));
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Debug.WriteLine("GetRoute: " + ex);
         }

         return route;
      }

      /// <summary>
      /// NotImplemented
      /// </summary>
      /// <param name="start"></param>
      /// <param name="end"></param>
      /// <param name="avoidHighways"></param>
      /// <param name="walkingMode"></param>
      /// <param name="zoom"></param>
      /// <returns></returns>
      public virtual MapRoute GetRoute(string start, string end, bool avoidHighways, bool walkingMode, int zoom)
      {
         throw new NotImplementedException("use GetRoute(PointLatLng start, PointLatLng end...");
      }

      #region -- internals --
      string MakeRoutingUrl(PointLatLng start, PointLatLng end, string travelType, bool withInstructions = false)
      {
         return string.Format(CultureInfo.InvariantCulture, RoutingUrlFormat, start.Lat, start.Lng, end.Lat, end.Lng, travelType, withInstructions ? "1" : "0", LanguageStr);
      }

      int GetTravelTime(XmlDocument xmldoc, XmlNamespaceManager xmlnsManager)
      {
         ///traveltime
         var travelTimeNode = xmldoc.SelectSingleNode("/sm:kml/sm:Document/sm:traveltime", xmlnsManager);

         if (travelTimeNode.InnerText.Length > 0)
         {
            return Convert.ToInt32(travelTimeNode.InnerText);
         }
         return 0;
      }

      IEnumerable<string> GetInstructions(XmlDocument xmldoc, XmlNamespaceManager xmlnsManager)
      {
         ///description
         var instructionsNode = xmldoc.SelectSingleNode("/sm:kml/sm:Document/sm:description", xmlnsManager);

         if (instructionsNode.InnerText.Length > 0)
         {
            var instructions = instructionsNode.InnerText.Split(new string[1] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < instructions.Length; i++)
            {
               instructions[i] = instructions[i].Trim();
            }

            return instructions;
         }

         return null;
      }

      List<PointLatLng> GetRoutePoints(XmlDocument xmldoc, XmlNamespaceManager xmlnsManager)
      {
         List<PointLatLng> points = null;
         ///Folder/Placemark/LineString/coordinates
         var coordNode = xmldoc.SelectSingleNode("/sm:kml/sm:Document/sm:Folder/sm:Placemark/sm:LineString/sm:coordinates", xmlnsManager);

         string[] coordinates = coordNode.InnerText.Split('\n');

         if (coordinates.Length > 0)
         {
            points = new List<PointLatLng>();

            foreach (string coordinate in coordinates)
            {
               if (coordinate != string.Empty)
               {
                  string[] XY = coordinate.Split(',');
                  if (XY.Length == 2)
                  {
                     double lat = double.Parse(XY[1], CultureInfo.InvariantCulture);
                     double lng = double.Parse(XY[0], CultureInfo.InvariantCulture);
                     points.Add(new PointLatLng(lat, lng));
                  }
               }
            }
         }
         return points;
      }

      static readonly string RoutingUrlFormat = "http://www.yournavigation.org/api/1.0/gosmore.php?format=kml&flat={0}&flon={1}&tlat={2}&tlon={3}&v={4}&fast=1&layer=mapnik&instructions={5}&lang={6}";
      static readonly string TravelTypeFoot = "foot";
      static readonly string TravelTypeMotorCar = "motorcar";

      static readonly string WalkingStr = "Walking";
      static readonly string DrivingStr = "Driving";
      #endregion

      #endregion

      #region GeocodingProvider Members

      public GeoCoderStatusCode GetPoints(string keywords, out List<PointLatLng> pointList)
      {
          // http://nominatim.openstreetmap.org/search?q=lithuania,vilnius&format=xml
          // https://nominatim.openstreetmap.org/search?q=福建省厦门市&format=json&addressdetails=1&limit=1&polygon_svg=0

         #region -- response --
         //<searchresults timestamp="Wed, 01 Feb 12 09:46:00 -0500" attribution="Data Copyright OpenStreetMap Contributors, Some Rights Reserved. CC-BY-SA 2.0." querystring="lithuania,vilnius" polygon="false" exclude_place_ids="29446018,53849547,8831058,29614806" more_url="http://open.mapquestapi.com/nominatim/v1/search?format=xml&exclude_place_ids=29446018,53849547,8831058,29614806&accept-language=en&q=lithuania%2Cvilnius">
         //<place place_id="29446018" osm_type="way" osm_id="24598347" place_rank="30" boundingbox="54.6868133544922,54.6879043579102,25.2885360717773,25.2898139953613" lat="54.6873633486028" lon="25.289199818878" display_name="National Museum of Lithuania, 1, Arsenalo g., Senamiesčio seniūnija, YAHOO-HIRES-20080313, Vilnius County, Šalčininkų rajonas, Vilniaus apskritis, 01513, Lithuania" class="tourism" type="museum" icon="http://open.mapquestapi.com/nominatim/v1/images/mapicons/tourist_museum.p.20.png"/>
         //<place place_id="53849547" osm_type="way" osm_id="55469274" place_rank="30" boundingbox="54.6896553039551,54.690486907959,25.2675743103027,25.2692089080811" lat="54.6900227236882" lon="25.2683589759401" display_name="Ministry of Foreign Affairs of the Republic of Lithuania, 2, J. Tumo Vaižganto g., Naujamiesčio seniūnija, Vilnius, Vilnius County, Vilniaus m. savivaldybė, Vilniaus apskritis, LT-01104, Lithuania" class="amenity" type="public_building"/>
         //<place place_id="8831058" osm_type="node" osm_id="836234960" place_rank="30" boundingbox="54.6670935059,54.6870973206,25.2638857269,25.2838876343" lat="54.677095" lon="25.2738876" display_name="Railway Museum of Lithuania, 15, Mindaugo g., Senamiesčio seniūnija, Vilnius, Vilnius County, Vilniaus m. savivaldybė, Vilniaus apskritis, 03215, Lithuania" class="tourism" type="museum" icon="http://open.mapquestapi.com/nominatim/v1/images/mapicons/tourist_museum.p.20.png"/>
         //<place place_id="29614806" osm_type="way" osm_id="24845629" place_rank="30" boundingbox="54.6904983520508,54.6920852661133,25.2606296539307,25.2628803253174" lat="54.6913385159005" lon="25.2617684209873" display_name="Seimas (Parliament) of the Republic of Lithuania, 53, Gedimino pr., Naujamiesčio seniūnija, Vilnius, Vilnius County, Vilniaus m. savivaldybė, Vilniaus apskritis, LT-01111, Lithuania" class="amenity" type="public_building"/>
         //</searchresults> 
         #endregion

         return GetLatLngFromGeocoderUrl(MakeGeocoderUrl(keywords), out pointList);
      }

      public PointLatLng? GetPoint(string keywords, out GeoCoderStatusCode status)
      {
         List<PointLatLng> pointList;
         status = GetPoints(keywords, out pointList);
         return pointList != null && pointList.Count > 0 ? pointList[0] : (PointLatLng?) null;
      }

      public GeoCoderStatusCode GetPoints(Placemark placemark, out List<PointLatLng> pointList)
      {
         // http://nominatim.openstreetmap.org/search?street=&city=vilnius&county=&state=&country=lithuania&postalcode=&format=xml
          // https://nominatim.openstreetmap.org/search?q=福建省厦门市&format=json&addressdetails=1&limit=1&polygon_svg=0

         #region -- response --
         //<searchresults timestamp="Thu, 29 Nov 12 08:38:23 +0000" attribution="Data © OpenStreetMap contributors, ODbL 1.0. http://www.openstreetmap.org/copyright" querystring="vilnius, lithuania" polygon="false" exclude_place_ids="98093941" more_url="http://nominatim.openstreetmap.org/search?format=xml&exclude_place_ids=98093941&accept-language=de-de,de;q=0.8,en-us;q=0.5,en;q=0.3&q=vilnius%2C+lithuania">
         //<place place_id="98093941" osm_type="relation" osm_id="1529146" place_rank="16" boundingbox="54.5693359375,54.8323097229004,25.0250644683838,25.4815216064453" lat="54.6843135" lon="25.2853984" display_name="Vilnius, Vilniaus m. savivaldybė, Distrikt Vilnius, Litauen" class="boundary" type="administrative" icon="http://nominatim.openstreetmap.org/images/mapicons/poi_boundary_administrative.p.20.png"/>
         //</searchresults> 
         #endregion

         return GetLatLngFromGeocoderUrl(MakeDetailedGeocoderUrl(placemark), out pointList);
      }

      public PointLatLng? GetPoint(Placemark placemark, out GeoCoderStatusCode status)
      {
         List<PointLatLng> pointList;
         status = GetPoints(placemark, out pointList);
         return pointList != null && pointList.Count > 0 ? pointList[0] : (PointLatLng?) null;
      }

      public GeoCoderStatusCode GetPlacemarks(PointLatLng location, out List<Placemark> placemarkList)
      {
         throw new NotImplementedException("use GetPlacemark");
      }

      public Placemark? GetPlacemark(PointLatLng location, out GeoCoderStatusCode status)
      {
          //https://nominatim.openstreetmap.org/reverse?format=geojson&lat=24.4882&lon=118.0973&zoom=21&addressdetails=1

         #region -- response --
          /*
         {
            "type": "FeatureCollection",
            "licence": "Data © OpenStreetMap contributors, ODbL 1.0. http://osm.org/copyright",
            "features": [
                {
                    "type": "Feature",
                    "properties": {
                        "place_id": 229982981,
                        "osm_type": "way",
                        "osm_id": 502367181,
                        "place_rank": 26,
                        "category": "highway",
                        "type": "residential",
                        "importance": 0.10000999999999993,
                        "addresstype": "road",
                        "name": "金桥路",
                        "display_name": "金桥路, 筼筜街道, 厦门市, 思明区, 厦门市, 福建省, 361012, 中国",
                        "address": {
                            "road": "金桥路",
                            "suburb": "筼筜街道",
                            "city": "厦门市",
                            "district": "思明区",
                            "county": "厦门市",
                            "state": "福建省",
                            "ISO3166-2-lvl4": "CN-FJ",
                            "postcode": "361012",
                            "country": "中国",
                            "country_code": "cn"
                        }
                    },
                    "bbox": [
                        118.0968581,
                        24.4855204,
                        118.0978985,
                        24.4887452
                    ],
                    "geometry": {
                        "type": "Point",
                        "coordinates": [
                            118.0970637905345,
                            24.48812203358516
                        ]
                    }
                }
            ]
        }
         */

         #endregion

          return GetPlacemarkFromReverseGeocoderUrl(MakeReverseGeocoderUrl(location), out status);
      }

      #region -- internals --

      string MakeGeocoderUrl(string keywords)
      {
         return string.Format(GeocoderUrlFormat, keywords.Replace(' ', '+'));
      }

      string MakeDetailedGeocoderUrl(Placemark placemark)
      {
         var street = String.Join(" ", new[] { placemark.HouseNo, placemark.ThoroughfareName }).Trim();
         return string.Format(GeocoderDetailedUrlFormat,
                              street.Replace(' ', '+'),
                              placemark.LocalityName.Replace(' ', '+'),
                              placemark.SubAdministrativeAreaName.Replace(' ', '+'),
                              placemark.AdministrativeAreaName.Replace(' ', '+'),
                              placemark.CountryName.Replace(' ', '+'),
                              placemark.PostalCodeNumber.Replace(' ', '+'));
      }

      string MakeReverseGeocoderUrl(PointLatLng pt)
      {
         return string.Format(CultureInfo.InvariantCulture, ReverseGeocoderUrlFormat, pt.Lat, pt.Lng);
      }

      GeoCoderStatusCode GetLatLngFromGeocoderUrl(string url, out List<PointLatLng> pointList)
      {
         var status = GeoCoderStatusCode.Unknow;
         pointList = null;

         try
         {
             string content = HttpUtil.GetData(url);
             JArray jsonarr = JArray.Parse(content);
             if (jsonarr != null)
             {
                 foreach (JObject jsonObj in jsonarr)
                 {
                     if (jsonObj["lat"] != null && jsonObj["lon"] != null)
                     {
                         double lat = double.Parse(jsonObj["lat"].ToString());
                         double lng = double.Parse(jsonObj["lon"].ToString());
                         PointLatLng p = new PointLatLng(lat, lng, CoordType.WGS84);
                         if (pointList == null)
                         {
                            pointList = new List<PointLatLng>();
                         }
                         pointList.Add(p);
                         status = GeoCoderStatusCode.G_GEO_SUCCESS;
                     }
                 }
                 
             }
         }
         catch(Exception ex)
         {
            status = GeoCoderStatusCode.ExceptionInCode;
            Debug.WriteLine("GetLatLngFromGeocoderUrl: " + ex);
         }

         return status;
      }

      Placemark? GetPlacemarkFromReverseGeocoderUrl(string url, out GeoCoderStatusCode status)
      {
         status = GeoCoderStatusCode.Unknow;
         Placemark? ret = null;

         try
         {
             string content = HttpUtil.GetData(url);
             JObject jsonObj = JObject.Parse(content);
             if (jsonObj != null)
             {
                 JArray features = jsonObj["features"] as JArray;
                 if (features != null && features.Count > 0)
                 {
                     JObject feature = features[0] as JObject;
                     JObject properties = feature["properties"] as JObject;
                     if (properties != null)
                     {
                         JObject address = properties["address"] as JObject;
                         if (address != null)
                         {
                             Placemark place = new Placemark();
                             if (properties["display_name"] != null)
                             {
                                place.Address = properties["display_name"].ToString();
                             }
                             if (address["state"] != null)
                             {
                                 place.ProvinceName = address["state"].ToString();
                             }
                             if (address["city"] != null)
                             {
                                 place.CityName = address["city"].ToString();
                             }
                             if (address["postcode"] != null)
                             {
                                 place.CityCode = address["postcode"].ToString();
                                 place.AdCode = address["postcode"].ToString();
                             }
                             if (address["district"] != null)
                             {
                                 place.DistrictName = address["district"].ToString();
                             }
                             if (address["suburb"] != null)
                             {
                                 place.StreetNumber = address["suburb"].ToString();
                             }

                             double lat = double.Parse(feature["geometry"]["coordinates"][1].ToString());
                             double lng = double.Parse(feature["geometry"]["coordinates"][0].ToString());
                             PointLatLng p = new PointLatLng(lat, lng, CoordType.WGS84);
                             place.Point = p;

                             ret = place;
                             status = GeoCoderStatusCode.G_GEO_SUCCESS;

                         }
                     }
                 }
             }
         }
         catch(Exception ex)
         {
            ret = null;
            status = GeoCoderStatusCode.ExceptionInCode;
            Debug.WriteLine("GetPlacemarkFromReverseGeocoderUrl: " + ex);
         }

         return ret;
      }

      static readonly string ReverseGeocoderUrlFormat = "http://nominatim.openstreetmap.org/reverse?format=geojson&lat={0}&lon={1}&zoom=21&addressdetails=1";
      static readonly string GeocoderUrlFormat = "https://nominatim.openstreetmap.org/search?q={0}&format=json";
      static readonly string GeocoderDetailedUrlFormat = "https://nominatim.openstreetmap.org/search?street={0}&city={1}&county={2}&state={3}&country={4}&postalcode={5}&format=json";

      #endregion

      #endregion
   }
   /// <summary>
   /// OpenStreetMap provider - http://www.openstreetmap.org/
   /// </summary>
   public class OsmMapProvider : OsmMapProviderBase
   {
       public static readonly OsmMapProvider Instance;

       OsmMapProvider()
       {
       }

       static OsmMapProvider()
       {
           Instance = new OsmMapProvider();
       }

       #region GMapProvider Members

       readonly Guid id = new Guid("57CFD87E-5869-5E4A-86DC-4A547F54C6EE");
       public override Guid Id
       {
           get
           {
               return id;
           }
       }

       readonly string name = "OSM";
       public override string Name
       {
           get
           {
               return name;
           }
       }

       GMapProvider[] overlays;
       public override GMapProvider[] Overlays
       {
           get
           {
               if (overlays == null)
               {
                   overlays = new GMapProvider[] { this };
               }
               return overlays;
           }
       }

       public override PureImage GetTileImage(GPoint pos, int zoom)
       {
           string url = MakeTileImageUrl(pos, zoom, string.Empty);

           return GetTileImageUsingHttp(url);
       }

       #endregion

       string MakeTileImageUrl(GPoint pos, int zoom, string language)
       {
           char letter = ServerLetters[GetServerNum(pos, 3)];
           return string.Format(UrlFormat, letter, zoom, pos.X, pos.Y);
       }

       //static readonly string UrlFormat = "https://{0}.tile.openstreetmap.org/{1}/{2}/{3}.png";
       // https://a.tile.geofabrik.de
       static readonly string UrlFormat = "https://{0}.tile.geofabrik.de/549e80f319af070f8ea8d0f149a149c2/{1}/{2}/{3}.png";
   }

}
