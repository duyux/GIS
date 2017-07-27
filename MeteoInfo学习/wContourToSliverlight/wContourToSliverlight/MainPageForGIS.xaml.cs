using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Browser;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using wContour;


namespace wContourToSliverlight
{
    public partial class MainPageForGIS : UserControl
    {
        
       
        public MainPageForGIS()
        {
            bool registerResult = WebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp);
            bool httpsResult = WebRequest.RegisterPrefix("https://", WebRequestCreator.ClientHttp); 

            InitializeComponent();

            HtmlPage.RegisterScriptableObject("WebSL", this);

            pGCommon.setMapInitExtent(MyMap, 27, 118,31, 123, 9);//浙江范围
           // pGCommon.setMapInitExtent(MyMap, 40.199855, 120.942993 , 37.252194,124.134521, 9);//大连范围

            gcontourGraphicsLayer = MyMap.Layers["ContourGraphicsLayer"] as GraphicsLayer;//等值线
            gstationGraphicsLayer = MyMap.Layers["StationGraphicsLayer"] as GraphicsLayer;//站位
            gWaterLineGraphicsLayer = MyMap.Layers["WaterLineGraphicsLayer"] as GraphicsLayer; //河流渲染图

            //_paramerDic["GetPointInfoUrl"] = "http://www.epbpm25.dl.gov.cn/services/PUBServicForGisLiving.asmx";
           _paramerDic["GetPointInfoUrl"] = "http://yzserver02:9777/services/PUBServicForGisLiving.asmx";

            AddMarkerGraphics();
           
        }
        void AddMarkerGraphics()
        {
            LoadStations("大气");
        }

        #region 切换地图
        private void RoadBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {


            if (pGCommon.HaveSameLayer(MyMap, gRoadLyrID) == true)
            {
                MyMap.Layers[gRoadLyrID].Visible = true;
                MyMap.Layers[gAerialLyrID].Visible = false;
                MyMap.Layers[gTerrainLyrID].Visible = false;
            }
            else
            {
                Lijoy.AppFx.GIS.Layers.GMapLayer pRoadLyr = new Lijoy.AppFx.GIS.Layers.GMapLayer();
                pRoadLyr.ID = gRoadLyrID;
                // pRoadLyr.HighlighMapNo = SLGISCommon.getHighlightMapNo(_paramerDic["CityCode"].ToString());
                pRoadLyr.LayerType = Lijoy.AppFx.GIS.Layers.GMapLayerType.Road;
                MyMap.Layers.Add(pRoadLyr);
            }


        }

        private void AerialBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (pGCommon.HaveSameLayer(MyMap, gAerialLyrID) == true)
            {
                MyMap.Layers[gAerialLyrID].Visible = true;
                MyMap.Layers[gRoadLyrID].Visible = false;
                MyMap.Layers[gTerrainLyrID].Visible = false;
            }
            else
            {
                Lijoy.AppFx.GIS.Layers.GMapLayer pAerialLyr = new Lijoy.AppFx.GIS.Layers.GMapLayer();
                pAerialLyr.ID = gAerialLyrID;
                pAerialLyr.LayerType = Lijoy.AppFx.GIS.Layers.GMapLayerType.Aerial;

                MyMap.Layers.Add(pAerialLyr);
            }
        }

        private void TerrainBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (pGCommon.HaveSameLayer(MyMap, gTerrainLyrID) == true)
            {
                MyMap.Layers[gTerrainLyrID].Visible = true;
                MyMap.Layers[gRoadLyrID].Visible = false;
                MyMap.Layers[gAerialLyrID].Visible = false;
            }
            else
            {
                Lijoy.AppFx.GIS.Layers.GMapLayer pTerrainLyr = new Lijoy.AppFx.GIS.Layers.GMapLayer();
                pTerrainLyr.ID = gTerrainLyrID;
                //pTerrainLyr.HighlighMapNo = pGCommon.getHighlightMapNo(gCurrSeleCityName);
                pTerrainLyr.LayerType = Lijoy.AppFx.GIS.Layers.GMapLayerType.Terrain;

                MyMap.Layers.Add(pTerrainLyr);
            }


        }
        #endregion

        
        private void btnDoContoure_Click(object sender, RoutedEventArgs e)
        {
            DoContour();//等值线
           
        }

        //河流渲染图
        private void btnDoWater_Click(object sender, RoutedEventArgs e)
        {
            DoWaterGraphics();

        }
    }

  
}
