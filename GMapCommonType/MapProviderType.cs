using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMapCommonType
{
    /// <summary>
    /// 地图数据源类型
    /// </summary>
    public enum MapProviderType
    {
        Google,
        AMap,
        Tencent,
        Bing,
        Baidu,
        ArcGIS,
        Here,
        Ship,
        Sogou,
        Soso,
        Tianditu_FJ,
        Czech,
        OpenCycle,
        OpenStreetMap,
        Other
    }
    /// <summary>
    /// 图层类型
    /// </summary>
    public enum MapLayerType
    {
        Common,
        Satellite,
        Hybird,
        Other
    }
}
