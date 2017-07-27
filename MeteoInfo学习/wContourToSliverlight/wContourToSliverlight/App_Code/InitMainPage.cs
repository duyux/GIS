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

using System.Windows.Threading;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using ESRI.ArcGIS.Client.Toolkit;
using ESRI.ArcGIS.Client.Geometry;
using wContourToSliverlight.GetPointInfo;
using ESRI.ArcGIS.Client;

namespace wContourToSliverlight
{
    public partial class MainPageForGIS : UserControl
    {
        string _LayerIndex = "0";//默认为0 图层,LAP业务切换时改变
        string _PointGrade = string.Empty;
        string _ModType = string.Empty;
        string _OperType = string.Empty;
        string _PointName = string.Empty;// 下拉框选中的测点名称
     
        private string _objectId = string.Empty;
        private string _pcode = string.Empty;
        private string _pname = string.Empty;
      
        //定义一个字典集合存储参数
        public Dictionary<string, string> _paramerDic = new Dictionary<string, string>();
        string _index = string.Empty;

        string strAllPcode = string.Empty;
        public static int i;

        string[] strArray = new string[2];
      
        private wContourToSliverlight.GetPointInfo.PointItemInfo[] AirPointItemReport;
        private wContourToSliverlight.GetPointInfo.PointItemInfo[] WPointItemReport;
       
        //private List<PointItemInfoEx> pPointItemInfoEx = new List<PointItemInfoEx> { };
        private List<PointItemInfoEx> pPointItemInfoEx = new List<PointItemInfoEx> { };

        GisCommon pGCommon = new GisCommon();//自定义全局类20110324dyx
        GraphicsLayer gcontourGraphicsLayer = null;//等值线GraphicsLayer
        GraphicsLayer gstationGraphicsLayer = null;//站位GraphicsLayer
        GraphicsLayer gWaterLineGraphicsLayer = null;//河流渲染线GraphicsLayer

        public PointInfo gCurrPointInfo;//存放当前点位信息
        private PointInfo[] gPointInfo = new PointInfo[1200];//存放点位信息
        public string gstrLayerType = "大气";//dyx20120403图层类型，默认是空气自动

        public PointItemInfo[] gAirPointItemInfoChart;//存放当前空气点位实时数据信息用做Chart
        private Storyboard sb;
        private bool l=true;
        private bool j=true;

        public int  gintDataDayInterval=2;//取数据的时间间隔
        public string  gstrInitSystem = "";//默认初始化系统
      
        public string gCurrSeleCityCode = "330000";//当前选择城市代码
        public string gCurrSeleCityName = "浙江省";//当前选择城市名称
       


        /////////////////////////////////////////////////////////
        public double gZoomLevel = 9;//缩放级别
        //ESRI.ArcGIS.Client.GraphicsLayer stationLayer=new ESRI.ArcGIS.Client.GraphicsLayer();//存放站位信息

        public string gRoadLyrID = "RoadLyrID";//政区图ID
        public string gAerialLyrID = "AerialLyrID";//卫星图ID
        public string gTerrainLyrID = "TerrainLyrID";//地形图ID

        public static ESRI.ArcGIS.Client.Projection.WebMercator mercator =new ESRI.ArcGIS.Client.Projection.WebMercator();

        public MapPoint gMapPositinPoint = new MapPoint();
     
        public bool gblnAllowDrop=true;
        public string gstrStationControlType = "AQI";//AQI：表示显示AQI时弹出的信息框  SO2：表示选择SO2监测因子时 NO2:表示选择NO2监测因子时 ，以此类推
        public string gstrStationItemCode = "AQI";//AQI：表示显示AQI时弹出的信息框  101：表示选择SO2监测因子时 141:表示选择NO2监测因子时 ，以此类推
        public string gstrStationItemName = "AQI";//AQI：表示显示AQI时弹出的信息框  二氧化硫：表示选择SO2监测因子时 二氧化氮:表示选择NO2监测因子时 ，以此类推
        public string gstrStationItemCharCode = "AQI";//AQI：表示显示AQI时弹出的信息框  SO2：表示选择SO2监测因子时 NO2:表示选择NO2监测因子时 ，以此类推


        
      
    }
    /// <summary>
    /// 静态类：存储业务功能类型
    /// 
    /// </summary>
    public static class FunType
    {
        public const string _Air = "大气";
        public const string _Water = "河流";
        public const string _Noise = "噪声";
        public const string _Wry = "污染源";

        public const string _Hssz = "海水水质";
        public const string _Dcfs = "电磁辐射";

        public const string _CSKQZLRB = "城市空气质量日报";
        public const string _HLSZZB = "河流水质周报";
        public const string _HLSZYB = "河流水质月报";
        public const string _HLSZNB = "河流水质年报";
        public const string _YYSYDYB= "饮用水源地月报";
      
    }
}
