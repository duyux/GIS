using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace wContourToSliverlight
{
    /// <summary>
    /// 地表水的GIS相关内容，如河段功能图
    /// author:du
    /// date;20130827
    /// </summary>
    public partial class MainPageForGIS : UserControl
    {


        #region 开始生成河流渲染图
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>
        private void DoWaterGraphics()
        {
            gstrLayerType = "河流";            
            ClearWaterObjects();


            
            PaintWaterGraphics();//开始画等值线
        }
        #endregion

        #region 读取坐标文件
        /// <summary>
        /// 加载普通格式的文本文件
        /// </summary>
        //void LoadCoordsTxt(string strRName)
        //{
        //    Uri serviceUri = new Uri("http://localhost:9827/mapLatLon/river/浙江/"+strRName+".txt");
        //    WebClient downloader = new WebClient();
        //    downloader.OpenReadCompleted += new OpenReadCompletedEventHandler(LoaddCoordsCompleted);
        //    downloader.OpenReadAsync(serviceUri);
        //}

        //void LoaddCoordsCompleted(object sender, OpenReadCompletedEventArgs e)
        //{
        //    if (e.Error == null)
        //    {
        //        StreamReader _Reader = new StreamReader(e.Result);
        //        this.txtBlank.Text = _Reader.ReadToEnd();
        //    }
        //    else
        //    {
               
        //    }
        //}
        #endregion


        private void AddPLineGraphics(Point[] points,Color pColor)
        {
           
            ESRI.ArcGIS.Client.Projection.WebMercator mercator =new ESRI.ArcGIS.Client.Projection.WebMercator();

            ESRI.ArcGIS.Client.Geometry.Polyline polyline = new ESRI.ArcGIS.Client.Geometry.Polyline();
            ESRI.ArcGIS.Client.Geometry.PointCollection pointCollection = new ESRI.ArcGIS.Client.Geometry.PointCollection();
            pointCollection.Clear();
            for (int i = 0; i < points.Length; i++)
            {
                pointCollection.Add(new MapPoint(points[i].X,points[i].Y));
 
            }

            polyline.Paths.Add(pointCollection);

            SimpleLineSymbol pSymbol = LayoutRoot.Resources["DefaultLineSymbol"] as SimpleLineSymbol;
            pSymbol.Color =  new SolidColorBrush(pColor);
            
            SimpleLineSymbol ls = new SimpleLineSymbol(Colors.Black,2);
           

                Graphic graphic = new Graphic()
                {
                    //Geometry = mercator.FromGeographic(polyline),
                    Geometry = mercator.ToGeographic(polyline),
                    Symbol=pSymbol
                    //Symbol = LayoutRoot.Resources["DefaultLineSymbol"] as Symbol
                };
                gcontourGraphicsLayer.Graphics.Add(graphic);
           

        }

        //从坐标对获取Point[]
       private Point[] getPoints(string strCoords)
       {
           string[] arrSplit = strCoords.Split(new Char[] { ';' });


           Point[] arrPoints = new Point[arrSplit.Length];


           string[] arrCoord = null;
           for (int i = 0; i < arrSplit.Length; i++)
           {
               arrCoord = arrSplit[i].Split(new Char[] { ',' });

               ESRI.ArcGIS.Client.Geometry.Geometry pPoint = mercator.FromGeographic(new MapPoint(System.Convert.ToDouble(arrCoord[0].ToString()), System.Convert.ToDouble(arrCoord[1].ToString())));

               Point pt = new Point();
               pt.X = pPoint.Extent.XMin;
               pt.Y = pPoint.Extent.YMin;


               arrPoints[i] = pt;
           }
           return arrPoints;
       }

        private Color getRiverColor(double dLowValue,double dHighValue)
        {
            Color aColor = Colors.Black;

            if (dHighValue >= 0 && dHighValue <= 50)
            {
                aColor = Color.FromArgb((byte)255, (byte)0, (byte)228, (byte)0);
            }

            if (dHighValue >=51 && dHighValue <= 100)
            {
                aColor = Color.FromArgb((byte)255, (byte)255, (byte)255, (byte)0);
            }

            if (dHighValue >= 101 && dHighValue <= 150)
            {
                aColor = Color.FromArgb((byte)255, (byte)255, (byte)126, (byte)0);
            }

            if (dHighValue >= 151 && dHighValue <= 200)
            {
                aColor = Color.FromArgb((byte)255, (byte)255, (byte)0, (byte)0);
            }

            if (dHighValue >= 201 && dHighValue <= 300)
            {
                aColor = Color.FromArgb((byte)255, (byte)153, (byte)0, (byte)76);
            }

            if (dHighValue >= 301)
            {
                aColor = Color.FromArgb((byte)255, (byte)126, (byte)0, (byte)35);
            }

            return aColor;
        }
       
        /// <summary>
        /// 画河流渲染图到地图上
        /// author:du
        /// date;20130827
        /// </summary>
        private void PaintWaterGraphics()
        {
            int i = 0;
            int j = 0;
           
            Color aColor = default(Color);
       
            wContour.PointD aPoint = default(wContour.PointD);
            Point[] Points = null;
            int sX = 0;
            int sY = 0;

            //object strRiverCoords = HtmlPage.Window.Invoke("getRiverCoords", "上塘河");
            //Point[] arrPoint=getPoints(strRiverCoords.ToString());
            Point[] arrPoint = getPoints(上塘河);
                //for (i = 0; i <= drawLines.Count - 1; i++)
                //{

            aColor = Colors.Red;
            AddRiverPLineGraphics(arrPoint, aColor);
                //}
            
        }

        //增加河流线渲染到GraphicLayer
        void AddRiverPLineGraphics(Point[] points, Color pColor)
        {

            ESRI.ArcGIS.Client.Projection.WebMercator mercator = new ESRI.ArcGIS.Client.Projection.WebMercator();

            ESRI.ArcGIS.Client.Geometry.Polyline polyline = new ESRI.ArcGIS.Client.Geometry.Polyline();
            ESRI.ArcGIS.Client.Geometry.PointCollection pointCollection = new ESRI.ArcGIS.Client.Geometry.PointCollection();
            pointCollection.Clear();
            for (int i = 0; i < points.Length; i++)
            {
                pointCollection.Add(new MapPoint(points[i].X, points[i].Y));

            }

            polyline.Paths.Add(pointCollection);

            SimpleLineSymbol pSymbol = LayoutRoot.Resources["DefaultLineSymbol"] as SimpleLineSymbol;
            pSymbol.Color = new SolidColorBrush(pColor);

            SimpleLineSymbol ls = new SimpleLineSymbol(pColor, 2);


            Graphic graphic = new Graphic()
            {
                //Geometry = mercator.FromGeographic(polyline),
                Geometry = mercator.ToGeographic(polyline),
                Symbol = ls
                //Symbol = LayoutRoot.Resources["DefaultLineSymbol"] as Symbol
            };
            gWaterLineGraphicsLayer.Graphics.Add(graphic);


        }
        
        private void ClearWaterObjects()
        {
            gcontourGraphicsLayer.Graphics.Clear();


        }

      
    }
    
}