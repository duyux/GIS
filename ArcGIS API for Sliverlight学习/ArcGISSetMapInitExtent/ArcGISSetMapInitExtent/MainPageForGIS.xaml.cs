using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;


namespace ArcGISSetMapInitExtent
{
    public partial class MainPageForGIS : UserControl
    {
        
        public MainPageForGIS()
        {
            InitializeComponent();
            //pGCommon.setMapInitExtent(MyMap, 27, 118,31, 123, 9);//浙江范围
            //pGCommon.setMapInitExtent(MyMap, 40.199855, 120.942993 , 37.252194,124.134521, 9);//大连范围
            pGCommon.setMapInitExtent(MyMap, 28.360216, 112.014551, 31.512036, 117.014551, 9);//湖北省范围
        }
     

        private void MyMap_ExtentChanged(object sender, ExtentEventArgs e)
        {
            DispTempExtent(e);//临时用，发布时要注释掉
        }
        /// <summary>
        /// 临时用，发布时要注释掉
        /// </summary>
        /// <param name="e"></param>
        private void DispTempExtent(ExtentEventArgs e)
        {
            double xmin, xmax, ymin, ymax;
            xmin = e.NewExtent.XMin;
            ymin = e.NewExtent.YMin;
            xmax = e.NewExtent.XMax;
            ymax = e.NewExtent.YMax;


            ESRI.ArcGIS.Client.Geometry.MapPoint mpmin = new ESRI.ArcGIS.Client.Geometry.MapPoint(xmin, ymin);
            ESRI.ArcGIS.Client.Geometry.MapPoint mpmax = new ESRI.ArcGIS.Client.Geometry.MapPoint(xmax, ymax);

            ESRI.ArcGIS.Client.Geometry.MapPoint mpmin2 = ESRI.ArcGIS.Client.Bing.Transform.WebMercatorToGeographic(mpmin);
            ESRI.ArcGIS.Client.Geometry.MapPoint mpmax2 = ESRI.ArcGIS.Client.Bing.Transform.WebMercatorToGeographic(mpmax);


            LongLat1.Text = "xmin:" + mpmin2.X + ",ymin:" + mpmin2.Y;
            LongLat2.Text = "xmax:" + mpmax2.X + ",ymax:" + mpmax2.Y;

            //MessageBox.Show("xmin:" + mpmin2.X + ",ymin:" + mpmin2.Y + ",xmax:" + mpmax2.X + ",ymax:" + mpmax2.Y);
        }


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
      
    }

  
}
