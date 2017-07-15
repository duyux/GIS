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
using ESRI.ArcGIS.Client.Tasks;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using System.Net.Browser;

namespace DZXSLGP
{
    public partial class MainPageTest2 : UserControl
    {
        Geoprocessor geoprocessorTask;
        FeatureSet featureset = new FeatureSet();
        Geoprocessor _Jobprocessor;
        List<GPParameter> Jobgpparameter = new List<GPParameter>();
        public MainPageTest2()
        {
            bool registerResult = WebRequest.RegisterPrefix("http://", WebRequestCreator.ClientHttp);
            bool httpsResult = WebRequest.RegisterPrefix("https://", WebRequestCreator.ClientHttp); 
            InitializeComponent();
            
        }
        private void geoprocessorTask_JobCompleted(object sender, JobInfoEventArgs e)
        {
            Geoprocessor geoprocessorTask = sender as Geoprocessor;
            geoprocessorTask.GetResultImageLayerCompleted += new EventHandler<GetResultImageLayerEventArgs>(geoprocessorTask_GetResultImageLayerCompleted);

            geoprocessorTask.GetResultImageLayerAsync(e.JobInfo.JobId, "Extract_Krig1");
            //geoprocessorTask.GetResultImageLayerAsync(e.JobInfo.JobId, "idw_1");
        }
        void _Jobprocessor_Failed(object sender, TaskFailedEventArgs e)
        {
            MessageBox.Show("错误：" + e.Error.ToString());
        }

      
       private void geoprocessorTask_GetResultImageLayerCompleted(object sender, GetResultImageLayerEventArgs e)
        {
   
            //找到显示等值线图层并清空，然后再次加载
            GPResultImageLayer gpr = e.GPResultImageLayer;
            gpr.ImageFormat = GPResultImageLayer.RestImageFormat.PNG24;//???
            gpr.Opacity = 0.79;
            gpr.ID = "GPContour";


            if (MyMap.Layers["GPContour"] != null)
            {
                MyMap.Layers.Remove(MyMap.Layers["GPContour"]);
            }

            MyMap.Layers.Add(gpr);
            gpr.Visible = true;


        }
       

       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
         
           // geoprocessorTask = new Geoprocessor("http://101.231.214.178:8082/arcgis/rest/services/ContourServiceToolPM10/GPServer/ContourServicePM10");
            geoprocessorTask = new Geoprocessor("http://101.231.214.178:8082/arcgis/rest/services/ContourServiceToolSO2/GPServer/ContourServiceSO2");
            geoprocessorTask.UpdateDelay = 10000;
           geoprocessorTask.OutputSpatialReference = MyMap.SpatialReference;
            //geoprocessorTask.OutputSpatialReference = new SpatialReference(4214);
            List<GPParameter> parameters = new List<GPParameter>();
            parameters.Add(new GPFeatureRecordSetLayer("Input_point_features", featureset));
           // geoprocessorTask.SubmitJobAsync(parameters);
            geoprocessorTask.JobCompleted += new EventHandler<JobInfoEventArgs>(geoprocessorTask_JobCompleted);
            geoprocessorTask.Failed += new EventHandler<TaskFailedEventArgs>(_Jobprocessor_Failed);
            geoprocessorTask.SubmitJobAsync(parameters);
           
        }

        private void MyMap_MouseClick(object sender, Map.MouseEventArgs e)
        {
             ESRI.ArcGIS.Client.Projection.WebMercator mercator =new ESRI.ArcGIS.Client.Projection.WebMercator();

            GraphicsLayer gplayer = MyMap.Layers["MyGraphicsLayer"] as GraphicsLayer;
            Graphic[] gps = new Graphic[10];
            //featureset.SpatialReference = new SpatialReference(102100);
            //featureset.SpatialReference = new SpatialReference(4214);
            for (int i = 0; i < gps.Length; i++)
            {
                Graphic gp = new Graphic()
                {
                    //Geometry = new MapPoint(e.MapPoint.X + 100 * i, e.MapPoint.Y + 100 * i),
                  // Geometry = new MapPoint(e.MapPoint.X + 0.13 * i, e.MapPoint.Y + 0.15 * i),
                  Geometry = mercator.FromGeographic(new MapPoint(e.MapPoint.X + 0.73 * i, e.MapPoint.Y + 0.15 * i)),
                

                    Symbol = new SimpleMarkerSymbol()
                    {
                        Size = 9,
                        Color = new SolidColorBrush(Colors.Red),
                        Style = SimpleMarkerSymbol.SimpleMarkerStyle.Circle
                    }
                };
               // string Location = string.Format("x:{0},y:{1}", e.MapPoint.X + 100 * i, e.MapPoint.Y + 100 * i);
               // gp.Attributes.Add("Location", Location);
                
                gp.Attributes.Add("YL", i*9);
               
                gplayer.Graphics.Add(gp);
                featureset.Features.Add(gp);


            }

            gplayer.Visible = true;
        }



        ///// <summary>
        ///// 实现IDW插值方法计算类等值面--色斑图
        ///// </summary>
        ///// <param name="featureSet"></param>
        //private void InvokeGPService(FeatureSet featureSet)
        //{
          
        //    geoprocessorTask = new Geoprocessor("http://dyx/ArcGIS/rest/services/IDW/GPServer/模型");
        //    geoprocessorTask.UpdateDelay = 5000;
        //    geoprocessorTask.OutputSpatialReference = MyMap.SpatialReference;

        //    List<GPParameter> parameters = new List<GPParameter>();
        //    parameters.Add(new GPFeatureRecordSetLayer("points", featureSet));
        //    //parameters.Add(new GPString("Z_value_field", "Rvalue"));
        //    geoprocessorTask.SubmitJobAsync(parameters);

        //    geoprocessorTask.JobCompleted += new EventHandler<JobInfoEventArgs>(geoprocessorTask_JobCompleted);
        //    geoprocessorTask.Failed += new EventHandler<TaskFailedEventArgs>(geoprocessorTask_Failed);

        //    //geoprocessorTask.SubmitJobAsync(parameters);
        //}

        //void geoprocessorTask_Failed(object sender, TaskFailedEventArgs e)
        //{
        //    MessageBox.Show(e.Error.ToString());
        //}

        //void geoprocessorTask_JobCompleted(object sender, JobInfoEventArgs e)
        //{
        //    HttpWebRequest.RegisterPrefix("http://", System.Net.Browser.WebRequestCreator.ClientHttp);
        //    Geoprocessor geoprocessorTask = sender as Geoprocessor;
        //    geoprocessorTask.GetResultDataCompleted += new EventHandler<GPParameterEventArgs>(geoprocessorTaskGetResultDataCompleted);
        //    geoprocessorTask.GetResultDataAsync(e.JobInfo.JobId, "result1_shp");
        //}

        //void geoprocessorTaskGetResultDataCompleted(object sender, GPParameterEventArgs e)
        //{
        //    GraphicsLayer graphicsLayer = MyMap.Layers["MyGraphicsLayer"] as GraphicsLayer;

        //    GPFeatureRecordSetLayer gpLayer = e.Parameter as GPFeatureRecordSetLayer;
        //    foreach (Graphic gp in gpLayer.FeatureSet.Features)
        //    {
        //        gp.Symbol = LayoutRoot.Resources["DefaultFillSymbol"] as ESRI.ArcGIS.Client.Symbols.Symbol;

        //        graphicsLayer.Graphics.Add(gp);
        //    }

        //    MessageBox.Show("Graphics Added to Graphics Layer");
        //}    
        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    //QueryTask queryTask = new QueryTask("http://yzserver02/ArcGIS/rest/services/testjpmap/MapServer/0");
        //    QueryTask queryTask = new QueryTask("http://dyx/ArcGIS/rest/services/testgpmap/MapServer/0");
        //    ESRI.ArcGIS.Client.Tasks.Query query = new ESRI.ArcGIS.Client.Tasks.Query();
        //    //query.OutFields.Add("ID");

        //    queryTask.ExecuteCompleted += AcidRainLevelTask_ExecuteCompleted;


        //    queryTask.Failed += QueryTask_Failed;

        //    query.ReturnGeometry = true;

        //    //if (PointGrade == "-1")
        //    //{
        //    //    //query.Where = "cast (cityID as character) like " + "'" + _paramerDic["CityCode"] + "%'";
        //    //}
        //    //else
        //    //{
        //    //    query.Where = strGradeField + " =" + PointGrade + " and cast (cityID as character) like " + "'" + _paramerDic["CityCode"] + "%'";
        //    //}

        //    ESRI.ArcGIS.Client.Geometry.Envelope displayExtent = new ESRI.ArcGIS.Client.Geometry.Envelope(MyMap.Extent.XMax, MyMap.Extent.YMax, MyMap.Extent.XMin, MyMap.Extent.YMin);
        //    query.Geometry = displayExtent;
        //    queryTask.ExecuteAsync(query);
        //}
        //private void QueryTask_Failed(object sender, TaskFailedEventArgs args)
        //{
        //    MessageBox.Show("Query failed: " + args.Error);
        //}
        //private void AcidRainLevelTask_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        //{
        //    FeatureSet featureSet = args.FeatureSet;
        //    //调用GP服务                 
        //    InvokeGPService(featureSet);
        //}


    }
}
