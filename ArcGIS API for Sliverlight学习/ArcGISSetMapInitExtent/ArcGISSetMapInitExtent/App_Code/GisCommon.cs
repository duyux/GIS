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
using System.IO;
using System.Windows.Media.Imaging;

using System.Collections.Generic;

using System.Linq;


using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Bing;
using ESRI.ArcGIS.Client.Symbols;

namespace ArcGISSetMapInitExtent
{
    /// <summary>
    /// 存放GIS相对通用的一些功能
    /// author:du
    /// date:20120117
    /// </summary>
    public class GisCommon
    {
        public GisCommon()
        { 
        }
        
       

      
        /// <summary>
        /// 根据控制级别获取级别数字，如1,2,3
        /// </summary>
        /// <param name="strGradeName"></param>
        /// <returns></returns>
        public  string getGradeNumValue(string strGradeName)
        {
            string strTemp = "1";
            switch (strGradeName)
            {
                case "国控":
                    strTemp = "1";
                    break;
                case "省控":
                    strTemp = "2";
                    break;
                case "市控":
                    strTemp = "3";
                    break;
                case "县控":
                    strTemp = "4";
                    break;
                case "其它":
                    strTemp = "5";
                    break;
            }

            return strTemp;
        }

        /// <summary>
        /// 根据级别数字获取级别名称
        /// </summary>
        /// <param name="strGradeName"></param>
        /// <returns></returns>
        public string getGradeByNum(string strGrade)
        {
            string strTemp = "国控";
            switch (strGrade)
            {
                case "1":
                    strTemp = "国控";
                    break;
                case "2":
                    strTemp = "省控";
                    break;
                case "3":
                    strTemp = "市控";
                    break;
                case "4":
                    strTemp = "县控";
                    break;
                case "5":
                    strTemp = "其它";
                    break;
            }

            return strTemp;
        }

        /// <summary>
        /// 根据水质类别数字获取水质类别名称
        /// </summary>
        /// <param name="strLevelNum"></param>
        /// <returns></returns>
        public string getWaterStageByNum(string strLevelNum)
        {
            string strTemp = "I";
            switch (strLevelNum)
            {
                case "1":
                    strTemp = "I";
                    break;
                case "2":
                    strTemp = "II";
                    break;
                case "3":
                    strTemp = "III";
                    break;
                case "4":
                    strTemp = "IV";
                    break;
                case "5":
                    strTemp = "V";
                    break;
                case "6":
                    strTemp = "劣V";
                    break;
            }

            return strTemp;
        }

        /// <summary>
        /// 根据经纬度进行定位
        /// </summary>
        /// <param name="MyMap"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="zoomLevel"></param>
        public void SetPosition(ESRI.ArcGIS.Client.Map MyMap, double latitude, double longitude, double zoomLevel, out MapPoint gmp)
        {
            MapPoint mp = new MapPoint();

            mp.X = longitude;
            mp.Y = latitude;

            mp = ESRI.ArcGIS.Client.Bing.Transform.GeographicToWebMercator(mp);

            gmp = mp;//后面用
            // Calculate the bounding extents of the zoom centered on the users point click on the Map.

            double currentResolution = MyMap.Resolution;

            // Get the ZoomFactor of the Map. The default is 2.
            double myZoomFactor = MyMap.ZoomFactor;

            // Calculate the ZoomIn Ratio. It is the inverse of the ZoomFactor (ex: 1 / 2 = 0.5).
            double myZoomInRatio = 1 / myZoomFactor;

            // Calculate the ZoomIn Resolution. The current Map.Resolution * ZoomIn Ratio.
            double myZoomInResolution = currentResolution * myZoomInRatio;

            //double xMin = mp.X - (MyMap.ActualWidth * myZoomInResolution * 0.5);
            //double yMin = mp.Y - (MyMap.ActualHeight * myZoomInResolution * 0.5);
            //double xMax = mp.X + (MyMap.ActualWidth * myZoomInResolution * 0.5);
            //double yMax = mp.Y + (MyMap.ActualHeight * myZoomInResolution * 0.5);

            double xMin = mp.X - (MyMap.ActualWidth * myZoomInResolution * 0.5);
            double yMin = mp.Y - (MyMap.ActualHeight * myZoomInResolution );
            double xMax = mp.X + (MyMap.ActualWidth * myZoomInResolution * 0.5);
            double yMax = mp.Y + (MyMap.ActualHeight * myZoomInResolution * 0.5);
  
              // Construct an Envelope from the bounding extents.
              ESRI.ArcGIS.Client.Geometry.Envelope myEnvelope = new ESRI.ArcGIS.Client.Geometry.Envelope(xMin, yMin, xMax, yMax);
  
              // Adjust the Map.Extent using the ZoomTo Method. It will be centered where the user clicked.
              MyMap.ZoomTo(myEnvelope);
        }



        /// <summary>
        /// 高亮符号
        /// </summary>
        /// <param name="MyMap"></param>
        /// <param name="strGraphicsLyrName"></param>
        /// <param name="pGraphic"></param>
        /// <param name="objHighSymbol"></param>
        public void HighGraphic(ESRI.ArcGIS.Client.Map MyMap, string strGraphicsLyrName, double dLatitude, double dLongitude, Symbol objHighSymbol)
        {
            ESRI.ArcGIS.Client.GraphicsLayer graphicsLayer = MyMap.Layers[strGraphicsLyrName] as GraphicsLayer;
            graphicsLayer.ClearGraphics();
          
           ESRI.ArcGIS.Client.Projection.WebMercator mercator =new ESRI.ArcGIS.Client.Projection.WebMercator();
           ESRI.ArcGIS.Client.Geometry.Geometry pPoint = mercator.FromGeographic(new MapPoint(dLongitude, dLatitude));
           Graphic graphic = new Graphic();


           //MarkerSymbol pSymbol = new MarkerSymbol();
            graphic.Geometry = pPoint;
            graphic.Symbol = objHighSymbol;

            graphicsLayer.Graphics.Add(graphic);
            
        }
        

         //经纬度转墨卡托
         public MapPoint lonLat2Mercator(MapPoint lonLat)
         {
                 MapPoint mercator = new MapPoint();
                 double x = lonLat.X * 20037508.34 / 180;
                 double y = Math.Log(Math.Tan((90 + lonLat.Y) * Math.PI / 360)) / (Math.PI / 180);
                 y = y * 20037508.34 / 180;
                 mercator.X = x;
                 mercator.Y = y;
                 return mercator;
         }
         //墨卡托转经纬度
         public MapPoint Mercator2lonLat(MapPoint mercator)
         {
                 MapPoint lonLat = new MapPoint();
                 double x = mercator.X / 20037508.34 * 180;
                 double y = mercator.Y / 20037508.34 * 180;
                 y = 180 / Math.PI * (2 * Math.Atan(Math.Exp(y * Math.PI / 180)) - Math.PI / 2);
                 lonLat.X = x;
                 lonLat.Y = y;
                 return lonLat;
         }

        /// <summary>
        /// 
        /// </summary>
         public void setMapInitExtent(ESRI.ArcGIS.Client.Map MyMap, double latitude, double longitude, double latitude2, double longitude2, double zoomLevel)
         {
             //Envelope initialExtent = new Envelope(ESRI.ArcGIS.Client.Bing.Transform.GeographicToWebMercator(new MapPoint(-130, 20)),
             //    ESRI.ArcGIS.Client.Bing.Transform.GeographicToWebMercator(new MapPoint(-65, 55)));

             MapPoint mp=ESRI.ArcGIS.Client.Bing.Transform.GeographicToWebMercator(new MapPoint(longitude, latitude));
             Envelope initialExtent = new Envelope(ESRI.ArcGIS.Client.Bing.Transform.GeographicToWebMercator(new MapPoint(longitude, latitude)),
               ESRI.ArcGIS.Client.Bing.Transform.GeographicToWebMercator(new MapPoint(longitude2, latitude2)));

             initialExtent.SpatialReference = new ESRI.ArcGIS.Client.Geometry.SpatialReference(102113);

            // MyMap.ZoomTo(initialExtent);
             MyMap.Extent = initialExtent;

 
         }
        /// <summary>
        /// 是否有相同的图层
        /// </summary>
        /// <param name="MyMap"></param>
        /// <param name="strLyrID"></param>
        /// <returns></returns>
         public bool HaveSameLayer(ESRI.ArcGIS.Client.Map MyMap, string strLyrID)
         {
             for (int i = 0; i < MyMap.Layers.Count; i++)
             {
                 if (MyMap.Layers[i].ID == strLyrID)
                 {
                     return true;
                 }
             }

             return false;
         }

         /// <summary>
         /// 是否有相同的图层
         /// </summary>
         /// <param name="MyMap"></param>
         /// <param name="strLyrID"></param>
         /// <returns></returns>
         public int getLayerID(ESRI.ArcGIS.Client.Map MyMap, string strLyrID)
         {
             int iTemp = 0;
             for (int i = 0; i < MyMap.Layers.Count; i++)
             {
                 if (MyMap.Layers[i].ID == strLyrID)
                 {
                     return i;
                 }
             }

             return iTemp;
         }

        /// <summary>
        /// 弹出窗口订住功能
        /// </summary>
        /// <param name="sender"></param>
         public void clickPinButton(object sender)
         {
             System.Windows.Controls.Image img = sender as System.Windows.Controls.Image;
             img.Visibility = Visibility.Collapsed;
             string imgName = img.Name;

             Grid grd = img.Parent as Grid;

             if (imgName == "imgUnpin")
             {

                 System.Windows.Controls.Image imgPined = grd.FindName("imgPined") as System.Windows.Controls.Image;
                 imgPined.Visibility = Visibility.Visible;
             }
             else
             {
                 System.Windows.Controls.Image imgUnpin = grd.FindName("imgUnpin") as System.Windows.Controls.Image;
                 imgUnpin.Visibility = Visibility.Visible;
             }
         }



         /// <summary>
         /// 获取选择行政区的地图编号
         /// author:du
         /// date:20130506
         /// </summary>
         /// <param name="sender"></param>
         public string getHighlightMapNo(string strRegion)
         {
             string strMapNo = "0x123";
             //定义一个字典集合存储地图号参数
            Dictionary<string, string> MapNoDic = new Dictionary<string, string>();
            MapNoDic.Clear();
            MapNoDic.Add("浙江省", "0x34491234a50accbf:0x81ef71c536187cb7");
            MapNoDic.Add("杭州市", "0x344bb629439aaa99:0xa7bfd183824de83a");
            MapNoDic.Add("宁波市", "0x344d6354630858f7:0x948723f846ccf173");
            MapNoDic.Add("温州市", "0x3445f230098bb0b1:0xb2351c1358b45a1c");
            MapNoDic.Add("嘉兴市", "0x35b32508c20d9ca1:0x4e17bcf1a95ead9c");
            MapNoDic.Add("湖州市", "0x344b4b68f92db705:0x34467013b412f4f0");
            MapNoDic.Add("绍兴市", "0x344c42f9ba150bdb:0x1859ede150b9ddce");
            MapNoDic.Add("金华市", "0x34491234a50accbf:0x53326144ecc53f61");
            MapNoDic.Add("衢州市", "0x344827915f400b99:0xd6032d37d18e92b8");
            MapNoDic.Add("舟山市", "0x3452c5c61b6c087f:0xa95ffbbca9c810a6");
            MapNoDic.Add("台州市", "0x344e1c7e2712e183:0x427808e0127c6805");
            MapNoDic.Add("丽水市", "0x34488284f2f1714d:0xab228cfd30a86d4e");

            strMapNo=MapNoDic[strRegion];

            return strMapNo;


         }



         /// <summary>
         /// 获取最小的点和最大的点
         /// author:du
         /// date:20130801
         /// </summary>
         /// <param name="sender"></param>
         public void getMinMaxXY(GraphicsLayer gl, out double dMinX,out double dMinY,out double dMaxX,out double dMaxY)
         {

             //double dMinX, dMinY, dMaxX, dMaxY;
             dMinX=gl.Graphics[0].Geometry.Extent.XMin;
             dMinY=gl.Graphics[0].Geometry.Extent.YMin;
             dMaxX=gl.Graphics[0].Geometry.Extent.XMax;
             dMaxY=gl.Graphics[0].Geometry.Extent.YMax;

             for (int i = 1; i < gl.Graphics.Count; i++)
             {
                 if (gl.Graphics[i].Geometry.Extent.XMin < dMinX)
                 {
                     dMinX = gl.Graphics[i].Geometry.Extent.XMin;
                 }
                 if (gl.Graphics[i].Geometry.Extent.YMin < dMinY)
                 {
                     dMinY = gl.Graphics[i].Geometry.Extent.YMin;
                 }

                 if (gl.Graphics[i].Geometry.Extent.XMax > dMaxX )
                 {
                     dMaxX = gl.Graphics[i].Geometry.Extent.XMax;
                 }
                 if (gl.Graphics[i].Geometry.Extent.YMax > dMaxY)
                 {
                     dMaxY = gl.Graphics[i].Geometry.Extent.YMax;
                 }
 
             }

         }


         
    }
}
