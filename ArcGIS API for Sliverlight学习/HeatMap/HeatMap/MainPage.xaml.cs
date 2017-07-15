using ESRI.ArcGIS.Client.Toolkit.DataSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GDEIC.AppFx.GIS.Layers;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client;

namespace HeatMap
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            MyMap.Layers.LayersInitialized += Layers_LayersInitialized;
           
        }

     
        void Layers_LayersInitialized(object sender, EventArgs args)
        {
            //Add 1000 random points to the heat map layer
            //Replace this with "real" data points that you want to display
            //in the heat map.

            //////////////////////////
            GradientStopCollection stops = new GradientStopCollection();
            //stops.Add(new GradientStop() { Color = Colors.Transparent, Offset = 0 });
            //stops.Add(new GradientStop() { Color = Colors.Blue, Offset = .5 });
            //stops.Add(new GradientStop() { Color = Colors.Red, Offset = .75 });
            //stops.Add(new GradientStop() { Color = Colors.Yellow, Offset = .8 });
            //stops.Add(new GradientStop() { Color = Colors.White, Offset = 1 });

            stops.Add(new GradientStop() { Color = Colors.Transparent, Offset = 0 });
            stops.Add(new GradientStop() { Color = Colors.Green, Offset = 0.25 });
            stops.Add(new GradientStop() { Color = Colors.Yellow, Offset = .5 });
            stops.Add(new GradientStop() { Color = Colors.Orange, Offset = .75 });
            stops.Add(new GradientStop() { Color = Colors.Red, Offset = .8 });
            stops.Add(new GradientStop() { Color = Colors.Purple, Offset = 1 });



            /////////////////////////


            //GDEIC.AppFx.GIS.Layers.HeatMapLayer layer = MyMap.Layers["RandomHeatMapLayer"] as HeatMapLayer;
            GDEIC.AppFx.GIS.Layers.HeatMapLayer layer = new GDEIC.AppFx.GIS.Layers.HeatMapLayer();

            layer.Gradient = stops;

            GDEIC.AppFx.GIS.Layers.HeatMapPoint hmp = new HeatMapPoint();

            Random rand = new Random();
            for (int i = 0; i < 230; i++)
            {
                double x = rand.NextDouble() * MyMap.Extent.Width - MyMap.Extent.Width / 2;
                double y = rand.NextDouble() * MyMap.Extent.Height - MyMap.Extent.Height / 2;

                hmp.mapPoint = new ESRI.ArcGIS.Client.Geometry.MapPoint(x, y);
                hmp.value = i + 12;
                //layer.HeatMapPoints.Add(new ESRI.ArcGIS.Client.Geometry.MapPoint(x, y));
                layer.HeatMapPoints.Add(hmp);

            }

            MyMap.Layers.Add(layer);
        }
        //void Layers_LayersInitialized(object sender, EventArgs args)
        //{
        //    //Add 1000 random points to the heat map layer
        //    //Replace this with "real" data points that you want to display
        //    //in the heat map.

        //    //////////////////////////
        //    GradientStopCollection stops = new GradientStopCollection();
        //    //stops.Add(new GradientStop() { Color = Colors.Transparent, Offset = 0 });
        //    //stops.Add(new GradientStop() { Color = Colors.Blue, Offset = .5 });
        //    //stops.Add(new GradientStop() { Color = Colors.Red, Offset = .75 });
        //    //stops.Add(new GradientStop() { Color = Colors.Yellow, Offset = .8 });
        //    //stops.Add(new GradientStop() { Color = Colors.White, Offset = 1 });

        //    stops.Add(new GradientStop() { Color = Colors.Transparent, Offset = 0 });
        //    stops.Add(new GradientStop() { Color = Colors.Green, Offset = 0.25 });
        //    stops.Add(new GradientStop() { Color = Colors.Yellow, Offset = .5 });
        //    stops.Add(new GradientStop() { Color = Colors.Orange, Offset = .75 });
        //    stops.Add(new GradientStop() { Color = Colors.Red, Offset = .8 });
        //    stops.Add(new GradientStop() { Color = Colors.Purple, Offset = 1 });



        //    /////////////////////////


        //    //GDEIC.AppFx.GIS.Layers.HeatMapLayer layer = MyMap.Layers["RandomHeatMapLayer"] as HeatMapLayer;
        //    GDEIC.AppFx.GIS.Layers.HeatMapLayer layer = new GDEIC.AppFx.GIS.Layers.HeatMapLayer();
           
        //    layer.Gradient = stops;

        //    GDEIC.AppFx.GIS.Layers.HeatMapPoint hmp = new HeatMapPoint();

        //    Random rand = new Random();
        //    for (int i = 0; i < 230; i++)
        //    {
        //        double x = rand.NextDouble() * MyMap.Extent.Width - MyMap.Extent.Width / 2;
        //        double y = rand.NextDouble() * MyMap.Extent.Height - MyMap.Extent.Height / 2;

        //        hmp.mapPoint = new ESRI.ArcGIS.Client.Geometry.MapPoint(x, y);
        //        hmp.value = i + 12;
        //        //layer.HeatMapPoints.Add(new ESRI.ArcGIS.Client.Geometry.MapPoint(x, y));
        //        layer.HeatMapPoints.Add(hmp);
                
        //    }

        //    MyMap.Layers.Add(layer);
        //}
        //void Layers_LayersInitialized(object sender, EventArgs args)
        //{
        //    //Add 1000 random points to the heat map layer
        //    //Replace this with "real" data points that you want to display
        //    //in the heat map.

        //    //////////////////////////
        //    GradientStopCollection stops = new GradientStopCollection();
        //    //stops.Add(new GradientStop() { Color = Colors.Transparent, Offset = 0 });
        //    //stops.Add(new GradientStop() { Color = Colors.Blue, Offset = .5 });
        //    //stops.Add(new GradientStop() { Color = Colors.Red, Offset = .75 });
        //    //stops.Add(new GradientStop() { Color = Colors.Yellow, Offset = .8 });
        //    //stops.Add(new GradientStop() { Color = Colors.White, Offset = 1 });

        //    stops.Add(new GradientStop() { Color = Colors.Transparent, Offset = 0 });
        //    stops.Add(new GradientStop() { Color = Colors.Green, Offset = 0.25 });
        //    stops.Add(new GradientStop() { Color = Colors.Yellow , Offset = .5 });
        //    stops.Add(new GradientStop() { Color = Colors.Orange, Offset = .75 });
        //    stops.Add(new GradientStop() { Color = Colors.Red, Offset = .8 });
        //    stops.Add(new GradientStop() { Color = Colors.Purple, Offset = 1 });
           


        //    /////////////////////////


        //    HeatMapLayer layer = MyMap.Layers["RandomHeatMapLayer"] as HeatMapLayer;
        //    layer.Gradient = stops;
            
        //    Random rand = new Random();
        //    for (int i = 0; i < 230; i++)
        //    {
        //        double x = rand.NextDouble() * MyMap.Extent.Width - MyMap.Extent.Width / 2;
        //        double y = rand.NextDouble() * MyMap.Extent.Height - MyMap.Extent.Height / 2;
        //        layer.HeatMapPoints.Add(new ESRI.ArcGIS.Client.Geometry.MapPoint(x, y));
        //    }
        //}

    }
}
