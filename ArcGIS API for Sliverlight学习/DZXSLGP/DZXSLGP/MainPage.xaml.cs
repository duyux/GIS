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

namespace DZXSLGP
{
    public partial class MainPage : UserControl
    {
        Geoprocessor geoprocessorTask;
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 实现IDW插值方法计算类等值面--色斑图
        /// </summary>
        /// <param name="featureSet"></param>
        private void InvokeGPService(FeatureSet featureSet)
        {
          
            geoprocessorTask = new Geoprocessor("http://dyx/ArcGIS/rest/services/IDW/GPServer/模型");
            geoprocessorTask.UpdateDelay = 5000;
            geoprocessorTask.OutputSpatialReference = MyMap.SpatialReference;

            List<GPParameter> parameters = new List<GPParameter>();
            parameters.Add(new GPFeatureRecordSetLayer("points", featureSet));
            //parameters.Add(new GPString("Z_value_field", "Rvalue"));
            geoprocessorTask.SubmitJobAsync(parameters);

            geoprocessorTask.JobCompleted += new EventHandler<JobInfoEventArgs>(geoprocessorTask_JobCompleted);
            geoprocessorTask.Failed += new EventHandler<TaskFailedEventArgs>(geoprocessorTask_Failed);

            //geoprocessorTask.SubmitJobAsync(parameters);
        }

        void geoprocessorTask_Failed(object sender, TaskFailedEventArgs e)
        {
            MessageBox.Show(e.Error.ToString());
        }

        void geoprocessorTask_JobCompleted(object sender, JobInfoEventArgs e)
        {
            HttpWebRequest.RegisterPrefix("http://", System.Net.Browser.WebRequestCreator.ClientHttp);
            Geoprocessor geoprocessorTask = sender as Geoprocessor;
            geoprocessorTask.GetResultDataCompleted += new EventHandler<GPParameterEventArgs>(geoprocessorTaskGetResultDataCompleted);
            geoprocessorTask.GetResultDataAsync(e.JobInfo.JobId, "result1_shp");
        }

        void geoprocessorTaskGetResultDataCompleted(object sender, GPParameterEventArgs e)
        {
            GraphicsLayer graphicsLayer = MyMap.Layers["MyGraphicsLayer"] as GraphicsLayer;

            GPFeatureRecordSetLayer gpLayer = e.Parameter as GPFeatureRecordSetLayer;
            foreach (Graphic gp in gpLayer.FeatureSet.Features)
            {
                gp.Symbol = LayoutRoot.Resources["DefaultFillSymbol"] as ESRI.ArcGIS.Client.Symbols.Symbol;

                graphicsLayer.Graphics.Add(gp);
            }

            MessageBox.Show("Graphics Added to Graphics Layer");
        }    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //QueryTask queryTask = new QueryTask("http://yzserver02/ArcGIS/rest/services/testjpmap/MapServer/0");
            QueryTask queryTask = new QueryTask("http://dyx/ArcGIS/rest/services/testgpmap/MapServer/0");
            ESRI.ArcGIS.Client.Tasks.Query query = new ESRI.ArcGIS.Client.Tasks.Query();
            //query.OutFields.Add("ID");

            queryTask.ExecuteCompleted += AcidRainLevelTask_ExecuteCompleted;


            queryTask.Failed += QueryTask_Failed;

            query.ReturnGeometry = true;

            //if (PointGrade == "-1")
            //{
            //    //query.Where = "cast (cityID as character) like " + "'" + _paramerDic["CityCode"] + "%'";
            //}
            //else
            //{
            //    query.Where = strGradeField + " =" + PointGrade + " and cast (cityID as character) like " + "'" + _paramerDic["CityCode"] + "%'";
            //}

            ESRI.ArcGIS.Client.Geometry.Envelope displayExtent = new ESRI.ArcGIS.Client.Geometry.Envelope(MyMap.Extent.XMax, MyMap.Extent.YMax, MyMap.Extent.XMin, MyMap.Extent.YMin);
            query.Geometry = displayExtent;
            queryTask.ExecuteAsync(query);
        }
        private void QueryTask_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageBox.Show("Query failed: " + args.Error);
        }
        private void AcidRainLevelTask_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            FeatureSet featureSet = args.FeatureSet;
            //调用GP服务                 
            InvokeGPService(featureSet);
        }


    }
}
