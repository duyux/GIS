using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Toolkit.DataSources;
using System;
using ESRI.ArcGIS.Client.Portal;
//using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ESRI.ArcGIS.Client;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace HeatMap
{
    public partial class HeapMap : UserControl
    {
        public HeapMap()
        {
            InitializeComponent();
           // MyMap.Layers.LayersInitialized += Layers_LayersInitialized;

            LoadHeatMap();
        }

        void Layers_LayersInitialized(object sender, EventArgs args)
        {
            //Add 1000 random points to the heat map layer
            //Replace this with "real" data points that you want to display
            //in the heat map.
            //HeatMapLayer layer = MyMap.Layers["RandomHeatMapLayer"] as HeatMapLayer;
            //Random rand = new Random();
            //layer.Gradient = getGColor();
       
            //for (int i = 0; i < 1000; i++)
            //{
            //    double x = rand.NextDouble() * MyMap.Extent.Width - MyMap.Extent.Width / 2;
            //    double y = rand.NextDouble() * MyMap.Extent.Height - MyMap.Extent.Height / 2;
            //    MapPoint mp = new MapPoint();
            //    mp.X = x;
            //    mp.Y = y;
            //    mp.M = 57;
            //    layer.HeatMapPoints.Add(new ESRI.ArcGIS.Client.Geometry.MapPoint(x, y));
              


          

            //}
        }

        private void LoadHeatMap()
        {

           GraphicsLayer layer = MyMap.Layers["states"] as GraphicsLayer;

            HeatMapLayer heat = MyMap.Layers["heat"] as HeatMapLayer;

            heat.HeatMapPoints.Clear();

            List<HeatPointSource> list = new List<HeatPointSource>();
            heat.Gradient = getGColor();
            Random rand = new Random();
            for (int i = 0; i < 200; i++)
            {
                double x = rand.NextDouble() * MyMap.Extent.Width - MyMap.Extent.Width / 2;
                double y = rand.NextDouble() * MyMap.Extent.Height - MyMap.Extent.Height / 2;
                //MapPoint mp = new MapPoint();
                //mp.X = x;
                //mp.Y = y;
                //layer.Graphics.Add(mp);
                HeatPointSource hp = new HeatPointSource()
                {

                    X = x,

                    Y = y,
                    I = 78+i

                    //I = (double)cv.WhitePopulation / (double)cv.TotalPopulation

                };
                list.Add(hp);


            }

            // Add values

            //foreach (Graphic g in layer.Graphics)
            //{

            //    MapPoint p = (MapPoint)g.Geometry;
            //    //CensusValue cv = g.Attributes["census"] as CensusValue;
            //    HeatPointSource hp = new HeatPointSource()
            //    {

            //        X = p.X,

            //        Y = p.Y,
            //        I=78

            //        //I = (double)cv.WhitePopulation / (double)cv.TotalPopulation

            //    };

            //}



            // Normalize
            
            double mini = list.Min(h => h.I);

            double maxi = list.Max(h => h.I);

            for (int i = 0; i < list.Count; i++)
            {

                HeatPointSource h = list[i];
                h.I = (h.I - mini) / (maxi - mini);
            }
            heat.HeatMapPoints = new ObservableCollection<HeatPointSource>(list);

        }
        private GradientStopCollection getGColor()
        {
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

            return stops;

        }

    }
}
