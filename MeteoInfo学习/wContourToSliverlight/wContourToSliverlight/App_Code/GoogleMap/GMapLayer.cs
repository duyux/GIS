using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;

namespace Lijoy.AppFx.GIS.Layers
{
    public class GMapLayer : TiledMapServiceLayer
    {
        // Fields
       
        private string x94a6c1c57fea6649;
      
        private GMapLayerType xca4ffbc3f158aceb;
        private string _HighlighMapNo = "0x342eaef8dd85f26f:0xe579493796aa923e";//高亮地图编号，默认湖北省

        public string HighlighMapNo
        {
            get { return _HighlighMapNo; }
            set { _HighlighMapNo = value; }
        }

        // Methods
       
        public override string GetTileUrl(int level, int row, int col)
        {
            int num = (col + (2 * row)) % 4;
            int length = ((col * 3) + row) % 8;
            string str = "Galileo".Substring(0, length);
            return string.Format(this.x7eac8ca199c20ab4(this.LayerType), new object[] { num, col, row, level, str });
        }



        public override void Initialize()
        {
            int num2=0;
            Envelope envelope = new Envelope(-20037508.342787, -20037508.342787, 20037508.342787, 20037508.342787)
            {
                SpatialReference = new SpatialReference(102113)
            };
            this.FullExtent = envelope;
        Label_009B:
            base.SpatialReference = new SpatialReference(102113);
            TileInfo info = new TileInfo
            {
                Height = 0x100,
                Width = 0x100
            };
            MapPoint point = new MapPoint(-20037508.342787, 20037508.342787)
            {
                SpatialReference = new SpatialReference(0x18ee1)
            };
            info.Origin = point;
            info.Lods = new Lod[20];
            base.TileInfo = info;
            double num = 156543.033928; //分辨率
            if ((((uint)num2) + ((uint)num2)) <= uint.MaxValue)
            {
                num2 = 0;
                while (num2 < base.TileInfo.Lods.Length)
                {
                    Lod lod = new Lod
                    {
                        Resolution = num
                    };
                    base.TileInfo.Lods[num2] = lod;
                    num /= 2.0;
                    num2++;
                }
                base.Initialize();
                if (((uint)num2) < 0)
                {
                    goto Label_009B;
                }
            }
        }


        private string x7eac8ca199c20ab4(GMapLayerType xa28bbc85eb805e63)
        {
            switch (xa28bbc85eb805e63)
            {
                case GMapLayerType.Aerial:
                    //return "http://khm{0}.google.com/kh/v=102&x={1}&y={2}&z={3}&s={4}";
                    return "http://khm{0}.google.com/kh/v=102&x={1}&y={2}&z={3}&s={4}";

                case GMapLayerType.Label:
                    return "http://mt{0}.google.cn/vt/lyrs=h@169000000&hl=zh-CN&x={1}&y={2}&z={3}&s={4}";

                case GMapLayerType.Road:
                    //return "http://mt{0}.google.cn/vt/lyrs=m@169000000&hl=zh-CN&x={1}&y={2}&z={3}&s={4}";
                    return "http://mt{0}.google.cn/vt/lyrs=m@169000000,highlight:" + HighlighMapNo + "@1%7Cstyle:maps&hl=zh-CN&x={1}&y={2}&z={3}&s={4}";

                case GMapLayerType.Terrain:
                    //return "http://mt{0}.google.cn/vt/lyrs=t@128,r@169000000&hl=zh-CN&x={1}&y={2}&z={3}&s={4}";
                    //return "http://mt{0}.google.cn/vt/lyrs=t@130,r@205000000&hl=zh-CN&x={1}&y={2}&z={3}&s={4}";
                    return "http://mt{0}.google.cn/vt/lyrs=t@130,r@205000000,highlight:" + HighlighMapNo + "@1%7Cstyle:maps&hl=zh-CN&x={1}&y={2}&z={3}&s={4}";
                case GMapLayerType.Custom:
                    return this.CustomLayerUrlFormat;
            }
            return "http://khm{0}.google.com/kh/v=102&x={1}&y={2}&z={3}&s={4}";
        }

 

 


        // Properties
        public string CustomLayerUrlFormat
        {
           
            get
            {
                return this.x94a6c1c57fea6649;
            }
          
            set
            {
                this.x94a6c1c57fea6649 = value;
            }
        }


        public GMapLayerType LayerType
        {
          
            get
            {
                return this.xca4ffbc3f158aceb;
            }
          
            set
            {
                this.xca4ffbc3f158aceb = value;
            }
        }
 

    }

    public enum GMapLayerType
    {
        Aerial,
        Label,
        Road,
        Terrain,
        Custom
    }
 

}
