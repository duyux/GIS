using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
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

namespace BufferGP
{
    public partial class MainPage : UserControl
    {
        GraphicsLayer pGraphicsLayer2 = null;
        Geoprocessor pTask2 = new Geoprocessor();
        
        public MainPage()
        {
            InitializeComponent();

            pGraphicsLayer2 = MyMap.Layers["GraphicsLayer2"] as GraphicsLayer;

            HttpWebRequest.RegisterPrefix("http://", System.Net.Browser.WebRequestCreator.ClientHttp);
            //initGP(pTask2, "http://101.231.214.178:8082/arcgis/rest/services/MyBuff/GPServer/MyBuff"); 
            initGP(pTask2, "http://192.168.1.102/arcgis/rest/services/MyBuff/GPServer/MyBuff"); 

        }

        private void MyMap_MouseClick(object sender, ESRI.ArcGIS.Client.Map.MouseEventArgs e)
        {
             FeatureSet pFeature = new FeatureSet();  
             Graphic pGraphic = new Graphic();  
             pGraphic.Geometry = e.MapPoint;  
             pFeature.Features.Add(pGraphic);  
            pGraphicsLayer2.Graphics.Add(pGraphic);  
 
            List<GPParameter> parameters = new List<GPParameter>();  
            parameters.Add(new GPFeatureRecordSetLayer("Input_Features", e.MapPoint));  
            parameters.Add(new  GPLinearUnit("Distance__value_or_field_",esriUnits.esriMeters, 1000));  
        
            pTask2.SubmitJobAsync(parameters);
        }

       void initGP(Geoprocessor pGpro,string pUrl)  
      {  
          pGpro.Url = pUrl;  

         pGpro.UpdateDelay = 5000;
         pGpro.JobCompleted += geoprocessorTask_JobCompleted;
          pGpro.Failed += new System.EventHandler<TaskFailedEventArgs>(pTask_Failed);  
     }  
        void pTask_Failed(object sender, TaskFailedEventArgs e)  
       {
            MessageBox.Show("有错误信息"+e.Error.Message);
            return;  
       }  
 
        void geoprocessorTask_JobCompleted(object sender, JobInfoEventArgs e)
        {
            //MessageBox.Show("OK=" + e.JobInfo.ToString());
            Geoprocessor geoprocessorTask = sender as Geoprocessor;
            geoprocessorTask.GetResultImageLayerCompleted += new EventHandler<GetResultImageLayerEventArgs>(geoprocessorTask_GetResultImageLayerCompleted);

            geoprocessorTask.GetResultImageLayerAsync(e.JobInfo.JobId, "Output_Feature_Class");
        }

        void geoprocessorTask_GetResultImageLayerCompleted(object sender, GetResultImageLayerEventArgs e)
        {
            GPResultImageLayer gpr = e.GPResultImageLayer;
            gpr.ID = "graphic1";
            //gpr.ImageFormat =GPResultImageLayer.RestImageFormat.PNG24;//???

            //gpr.Opacity = 0.5;
            // gpr.Opacity = 1;

            MyMap.Layers.Add(gpr);
            //MyMap.Layers.Insert(0, gpr);
            gpr.Visible = true;
            //pGCommon.SetLayer(0, 2, MyMap, "StreetMapLayer");
            //pGCommon.SetLayer(1, 2, MyMap, "StreetMapLayer");
        }
      
    }
}
