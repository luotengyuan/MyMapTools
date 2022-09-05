using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.MapProviders;
using GMap.NET;

namespace GMapCommonType
{
    public class MapProviderSet
    {
        public static MapProviderInfo[] AMapProviderArray;
        public static MapProviderInfo[] BaiduProviderArray;
        public static MapProviderInfo[] TencentProviderArray;
        public static MapProviderInfo[] ArcGISProviderArray;
        public static MapProviderInfo[] BingProviderArray;
        public static MapProviderInfo[] Tianditu_FJProviderArray;
        public static MapProviderInfo[] CzechProviderArray;
        public static MapProviderInfo[] OpenCycleProviderArray;
        public static MapProviderInfo[] GoogleProviderArray;
        public static MapProviderInfo[] OSMProviderArray;
        public static MapProviderInfo[] OtherProviderArray;
        public static void InitMapProviderSet()
        {
            // AMap	GCJ02			
            //mapControl.MapProvider = GMapProvidersExt.AMap.AMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.AMap.AMapSateliteProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.AMap.AMapHybirdProvider.Instance;//OK 卫星+路网
            AMapProviderArray = new MapProviderInfo[3];
            AMapProviderArray[0] = new MapProviderInfo(MapProviderType.AMap, GMapProvidersExt.AMap.AMapProvider.Instance, MapLayerType.Common, CoordType.GCJ02);
            AMapProviderArray[1] = new MapProviderInfo(MapProviderType.AMap, GMapProvidersExt.AMap.AMapSateliteProvider.Instance, MapLayerType.Satellite, CoordType.GCJ02);
            AMapProviderArray[2] = new MapProviderInfo(MapProviderType.AMap, GMapProvidersExt.AMap.AMapHybirdProvider.Instance, MapLayerType.Hybird, CoordType.GCJ02);
            // Baidu	BD09
            //mapControl.MapProvider = GMapProvidersExt.Baidu.BaiduMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.Baidu.BaiduSatelliteMapProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.Baidu.BaiduHybridMapProvider.Instance;//OK 路网+卫星
            BaiduProviderArray = new MapProviderInfo[3];
            BaiduProviderArray[0] = new MapProviderInfo(MapProviderType.Baidu, GMapProvidersExt.Baidu.BaiduMapProvider.Instance, MapLayerType.Common, CoordType.BD09);
            BaiduProviderArray[1] = new MapProviderInfo(MapProviderType.Baidu, GMapProvidersExt.Baidu.BaiduSatelliteMapProvider.Instance, MapLayerType.Satellite, CoordType.BD09);
            BaiduProviderArray[2] = new MapProviderInfo(MapProviderType.Baidu, GMapProvidersExt.Baidu.BaiduHybridMapProvider.Instance, MapLayerType.Hybird, CoordType.BD09);
            // Tencent	GCJ02	
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentMapProvider.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentMapSateliteProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentMapHybridProvider.Instance;//OK 路网+卫星
            TencentProviderArray = new MapProviderInfo[3];
            TencentProviderArray[0] = new MapProviderInfo(MapProviderType.Tencent, GMapProvidersExt.Tencent.TencentMapProvider.Instance, MapLayerType.Common, CoordType.GCJ02);
            TencentProviderArray[1] = new MapProviderInfo(MapProviderType.Tencent, GMapProvidersExt.Tencent.TencentMapSateliteProvider.Instance, MapLayerType.Satellite, CoordType.GCJ02);
            TencentProviderArray[2] = new MapProviderInfo(MapProviderType.Tencent, GMapProvidersExt.Tencent.TencentMapHybridProvider.Instance, MapLayerType.Hybird, CoordType.GCJ02);
            // ArcGIS	WGS84
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISMapProvider.Instance;//OK 路网（GCJ02）
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISSatelliteMapProvider.Instance;//OK 卫星（WGS84）
            //mapControl.MapProvider = GMapProvidersExt.ArcGIS.ArcGISGrayMapProvider.Instance;//OK （路网+卫星）（GCJ02）
            ArcGISProviderArray = new MapProviderInfo[3];
            ArcGISProviderArray[0] = new MapProviderInfo(MapProviderType.ArcGIS, GMapProvidersExt.ArcGIS.ArcGISMapProvider.Instance, MapLayerType.Common, CoordType.GCJ02);
            ArcGISProviderArray[1] = new MapProviderInfo(MapProviderType.ArcGIS, GMapProvidersExt.ArcGIS.ArcGISSatelliteMapProvider.Instance, MapLayerType.Satellite, CoordType.WGS84);
            ArcGISProviderArray[2] = new MapProviderInfo(MapProviderType.ArcGIS, GMapProvidersExt.ArcGIS.ArcGISGrayMapProvider.Instance, MapLayerType.Hybird, CoordType.GCJ02);
            // Bing	WGS84		
            //mapControl.MapProvider = GMapProvidersExt.Bing.BingChinaMapProvider.Instance;//OK 路网（GCJ02）
            //mapControl.MapProvider = GMapProviders.BingSatelliteMap;//OK 卫星（WGS84）
            //mapControl.MapProvider = GMapProviders.BingHybridMap;//OK 卫星+路网 英文（WGS84）
            BingProviderArray = new MapProviderInfo[3];
            BingProviderArray[0] = new MapProviderInfo(MapProviderType.Bing, GMapProvidersExt.Bing.BingChinaMapProvider.Instance, MapLayerType.Common, CoordType.GCJ02);
            BingProviderArray[1] = new MapProviderInfo(MapProviderType.Bing, GMapProviders.BingSatelliteMap, MapLayerType.Satellite, CoordType.WGS84);
            BingProviderArray[2] = new MapProviderInfo(MapProviderType.Bing, GMapProviders.BingHybridMap, MapLayerType.Hybird, CoordType.WGS84);
            // Tianditu_FJ	WGS84
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.Fujian.TiandituFujianMapProviderWithAnno.Instance;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.Fujian.TiandituFujianSatelliteMapProvider.Instance;//OK 卫星
            //mapControl.MapProvider = GMapProvidersExt.TianDitu.Fujian.TiandituFujianSatelliteMapProviderWithAnno.Instance;//OK 路网+卫星
            Tianditu_FJProviderArray = new MapProviderInfo[3];
            Tianditu_FJProviderArray[0] = new MapProviderInfo(MapProviderType.Tianditu_FJ, GMapProvidersExt.TianDitu.Fujian.TiandituFujianMapProviderWithAnno.Instance, MapLayerType.Common, CoordType.WGS84);
            Tianditu_FJProviderArray[1] = new MapProviderInfo(MapProviderType.Tianditu_FJ, GMapProvidersExt.TianDitu.Fujian.TiandituFujianSatelliteMapProvider.Instance, MapLayerType.Satellite, CoordType.WGS84);
            Tianditu_FJProviderArray[2] = new MapProviderInfo(MapProviderType.Tianditu_FJ, GMapProvidersExt.TianDitu.Fujian.TiandituFujianSatelliteMapProviderWithAnno.Instance, MapLayerType.Hybird, CoordType.WGS84);
            // Czech	WGS84
            //mapControl.MapProvider = GMapProviders.CzechMap;//OK 路网
            //mapControl.MapProvider = GMapProviders.CzechSatelliteMap;//OK 卫星
            //mapControl.MapProvider = GMapProviders.CzechGeographicMap;//OK 渲染+路网
            CzechProviderArray = new MapProviderInfo[3];
            CzechProviderArray[0] = new MapProviderInfo(MapProviderType.Czech, GMapProviders.CzechMap, MapLayerType.Common, CoordType.WGS84);
            CzechProviderArray[1] = new MapProviderInfo(MapProviderType.Czech, GMapProviders.CzechSatelliteMap, MapLayerType.Satellite, CoordType.WGS84);
            CzechProviderArray[2] = new MapProviderInfo(MapProviderType.Czech, GMapProviders.CzechGeographicMap, MapLayerType.Hybird, CoordType.WGS84);
            // OpenCycle	WGS84
            //mapControl.MapProvider = GMapProviders.OpenCycleTransportMap;//OK 路网（路网）
            //mapControl.MapProvider = GMapProviders.OpenCycleMap;//OK 路网（卫星）
            //mapControl.MapProvider = GMapProviders.OpenCycleLandscapeMap;//OK 路网（卫星+路网）
            OpenCycleProviderArray = new MapProviderInfo[3];
            OpenCycleProviderArray[0] = new MapProviderInfo(MapProviderType.OpenCycle, GMapProviders.OpenCycleTransportMap, MapLayerType.Common, CoordType.WGS84);
            OpenCycleProviderArray[1] = new MapProviderInfo(MapProviderType.OpenCycle, GMapProviders.OpenCycleMap, MapLayerType.Satellite, CoordType.WGS84);
            OpenCycleProviderArray[2] = new MapProviderInfo(MapProviderType.OpenCycle, GMapProviders.OpenCycleLandscapeMap, MapLayerType.Hybird, CoordType.WGS84);
            // Google	WGS84
            //mapControl.MapProvider = GMapProviders.GoogleChinaMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleChinaSatelliteMap;//NO
            //mapControl.MapProvider = GMapProviders.GoogleChinaHybridMap;//NO
            GoogleProviderArray = new MapProviderInfo[3];
            GoogleProviderArray[0] = new MapProviderInfo(MapProviderType.Google, GMapProviders.GoogleChinaMap, MapLayerType.Common, CoordType.WGS84);
            GoogleProviderArray[1] = new MapProviderInfo(MapProviderType.Google, GMapProviders.GoogleChinaSatelliteMap, MapLayerType.Satellite, CoordType.WGS84);
            GoogleProviderArray[2] = new MapProviderInfo(MapProviderType.Google, GMapProviders.GoogleChinaHybridMap, MapLayerType.Hybird, CoordType.WGS84);
            // OSM	WGS84
            //mapControl.MapProvider = GMapProviders.OpenStreetMap;//NO
            //mapControl.MapProvider = GMapProviders.OpenStreetMapQuestSatelite;//NO
            //mapControl.MapProvider = GMapProviders.OpenStreetMapQuestHybrid;//NO
            OSMProviderArray = new MapProviderInfo[3];
            OSMProviderArray[0] = new MapProviderInfo(MapProviderType.OpenStreetMap, GMapProviders.OpenStreetMap, MapLayerType.Common, CoordType.WGS84);
            OSMProviderArray[1] = new MapProviderInfo(MapProviderType.OpenStreetMap, GMapProviders.OpenStreetMapQuestSatelite, MapLayerType.Satellite, CoordType.WGS84);
            OSMProviderArray[2] = new MapProviderInfo(MapProviderType.OpenStreetMap, GMapProviders.OpenStreetMapQuestHybrid, MapLayerType.Hybird, CoordType.WGS84);
            // Other
            //mapControl.MapProvider = GMapProviders.ArcGIS_Imagery_World_2D_Map;//OK 卫星
            //mapControl.MapProvider = GMapProviders.ArcGIS_StreetMap_World_2D_Map;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.ArcGIS_World_Shaded_Relief_Map;//OK 地貌渲染
            //mapControl.MapProvider = GMapProviders.ArcGIS_World_Street_Map;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.ArcGIS_World_Topo_Map;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.BingMap;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.BingOSMap;//OK 路网 英文
            //mapControl.MapProvider = GMapProviders.CzechHybridMap;//OK 卫星
            //mapControl.MapProvider = GMapProviders.CzechTuristWinterMap;//OK 路网
            //mapControl.MapProvider = GMapProvidersExt.Ship.ShipMapProvider.Instance;//OK 渲染
            //mapControl.MapProvider = GMapProvidersExt.Ship.ShipMapTileProvider.Instance;//OK 渲染
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentTerrainMapAnnoProvider.Instance;//OK 路网+渲染
            //mapControl.MapProvider = GMapProvidersExt.Tencent.TencentTerrainMapProvider.Instance;//OK 渲染
            OtherProviderArray = new MapProviderInfo[13];
            OtherProviderArray[0] = new MapProviderInfo(MapProviderType.Other, GMapProviders.ArcGIS_Imagery_World_2D_Map, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[1] = new MapProviderInfo(MapProviderType.Other, GMapProviders.ArcGIS_StreetMap_World_2D_Map, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[2] = new MapProviderInfo(MapProviderType.Other, GMapProviders.ArcGIS_World_Shaded_Relief_Map, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[3] = new MapProviderInfo(MapProviderType.Other, GMapProviders.ArcGIS_World_Street_Map, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[4] = new MapProviderInfo(MapProviderType.Other, GMapProviders.ArcGIS_World_Topo_Map, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[5] = new MapProviderInfo(MapProviderType.Other, GMapProviders.BingMap, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[6] = new MapProviderInfo(MapProviderType.Other, GMapProviders.BingOSMap, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[7] = new MapProviderInfo(MapProviderType.Other, GMapProviders.CzechHybridMap, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[8] = new MapProviderInfo(MapProviderType.Other, GMapProviders.CzechTuristWinterMap, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[9] = new MapProviderInfo(MapProviderType.Other, GMapProvidersExt.Ship.ShipMapProvider.Instance, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[10] = new MapProviderInfo(MapProviderType.Other, GMapProvidersExt.Ship.ShipMapTileProvider.Instance, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[11] = new MapProviderInfo(MapProviderType.Other, GMapProvidersExt.Tencent.TencentTerrainMapAnnoProvider.Instance, MapLayerType.Other, CoordType.WGS84);
            OtherProviderArray[12] = new MapProviderInfo(MapProviderType.Other, GMapProvidersExt.Tencent.TencentTerrainMapProvider.Instance, MapLayerType.Other, CoordType.WGS84);
        }
    }
}
