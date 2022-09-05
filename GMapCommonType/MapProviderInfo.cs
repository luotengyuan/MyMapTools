using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GMap.NET.MapProviders;
using GMap.NET;

namespace GMapCommonType
{
    public class MapProviderInfo
    {
        public MapProviderType MapProviderType { set; get; }

        public GMapProvider MapProvider { set; get; }

        public MapLayerType MapLayerType { set; get; }

        public CoordType CoordType { set; get; }

        public MapProviderInfo()
        {

        }

        public MapProviderInfo(MapProviderType MapProviderType, GMapProvider MapProvider, MapLayerType MapLayerType, CoordType CoordType)
        {
            this.MapProviderType = MapProviderType;
            this.MapProvider = MapProvider;
            this.MapLayerType = MapLayerType;
            this.CoordType = CoordType;
        }
    }
}
