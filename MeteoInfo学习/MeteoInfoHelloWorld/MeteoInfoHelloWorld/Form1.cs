using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MeteoInfoC.Layer;
using MeteoInfoC.Data.MapData;
using MeteoInfoC.Map;
using MeteoInfoC.Layout;
using MeteoInfoC.Global;
using MeteoInfoC.Legend;
using MeteoInfoC.Data.MeteoData;
using MeteoInfoC.Data;
using MeteoInfoC.Shape;

namespace MeteoInfoHelloWorld
{
    public partial class Form1 : Form
    {

        ToolStripButton _currentTool;
        public Form1()
        {
            InitializeComponent();
            mapView1.MouseTool = MouseTools.Pan;

            mapLayout1.MouseMode = MouseMode.Select;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
 
                if (tabControl1.SelectedIndex == 1)    //Map Layout
 
                {
 
                        layersLegend1.IsLayoutView = true;               
 

                         mapLayout1.PaintGraphics();
 
                         mapLayout1.Refresh();
 
                  }
 
                 else if (tabControl1.SelectedIndex == 0)    //Map view
 
                {
 
                         layersLegend1.IsLayoutView = false;
 

                         mapView1.IsLayoutMap = false;
 
                         mapView1.ZoomToExtent(mapView1.ViewExtent);
 
                 }
 
      
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                   
 
                OpenFileDialog aDlg = new OpenFileDialog();
 
                aDlg.Filter = "Supported Formats|*.shp;*.wmp;*.bln;*.bmp;*.gif;*.jpg;*.tif;*.png|Shape File     (*.shp)|*.shp|WMP File (*.wmp)|*.wmp|BLN File (*.bln)|*.bln|" +
 
                "Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|Jpeg Image (*.jpg)|*.jpg|Tif Image (*.tif)|*.tif|Png Iamge (*.png)|*.png|All Files (*.*)|*.*";
 

                if (aDlg.ShowDialog() == DialogResult.OK)
 
                {
 
                        string aFile = aDlg.FileName;
 
                        MapLayer aLayer = MapDataManage.OpenLayer(aFile);
 
                        layersLegend1.ActiveMapFrame.AddLayer(aLayer);
 
                        layersLegend1.Refresh();
 
                }


        }

        private void SetCurrentTool(ToolStripButton currentTool)
        {

            if (!(_currentTool == null))
            {

                _currentTool.Checked = false;

            }

            _currentTool = currentTool;

            _currentTool.Checked = true;

            statusStrip1.Text = _currentTool.ToolTipText;

        }

        private void TSB_ZoomIn_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.Zoom_In;

            mapLayout1.MouseMode = MouseMode.Map_ZoomIn;
         
 
            SetCurrentTool((ToolStripButton)sender);

        }

        private void TSB_ZoomOut_Click(object sender, EventArgs e)
        {
             mapView1.MouseTool = MouseTools.Zoom_Out;
             mapLayout1.MouseMode = MouseMode.Map_ZoomOut;
             SetCurrentTool((ToolStripButton)sender);

        }

        private void TSB_Pan_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.Pan;
 
            mapLayout1.MouseMode = MouseMode.Map_Pan;
 
            SetCurrentTool((ToolStripButton)sender);
        }

        private void TSB_FullExent_Click(object sender, EventArgs e)
        {
             Extent aExtent = mapView1.Extent;      
 
             mapView1.ZoomToExtent(aExtent);

        }

        private void TSB_Identifer_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.Identifer;
 
           mapLayout1.MouseMode = MouseMode.Map_Identifer;
 

 
            SetCurrentTool((ToolStripButton)sender);

        }
        private void LoadLayers()
        {

            layersLegend1.ActiveMapFrame.MapView.LockViewUpdate = true;


            //Load country layer

            string aFile = Application.StartupPath + "\\Map\\country1.shp";

            MapLayer aLayer = MapDataManage.OpenLayer(aFile);

            aLayer.LegendScheme.breakList[0].Color = Color.WhiteSmoke;

            layersLegend1.ActiveMapFrame.AddLayer(aLayer);


            //Load river layer

            aFile = Application.StartupPath + "\\Map\\rivers.shp";

            aLayer = MapDataManage.OpenLayer(aFile);

            aLayer.LegendScheme.breakList[0].Color = Color.Aqua;

            ((PolyLineBreak)aLayer.LegendScheme.breakList[0]).Size = 2;

            layersLegend1.ActiveMapFrame.AddLayer(aLayer);


            //Load city layer

            aFile = Application.StartupPath + "\\Map\\CITIES.shp";

            aLayer = MapDataManage.OpenLayer(aFile);

            ((PointBreak)aLayer.LegendScheme.breakList[0]).Color = Color.Red;

            aLayer.Expanded = true;

            layersLegend1.ActiveMapFrame.AddLayer(aLayer);

            //Label city name

            VectorLayer cityLayer = (VectorLayer)aLayer;

            cityLayer.LabelSet.FieldName = "NAME";

            cityLayer.LabelSet.AvoidCollision = true;

            cityLayer.LabelSet.LabelAlignType = MeteoInfoC.Legend.AlignType.Center;

           // cityLayer.LabelSet.Offset = 0;

            cityLayer.LabelSet.LabelFont = new Font("Arial", 8);

            cityLayer.LabelSet.LabelColor = Color.Red;

            cityLayer.LabelSet.DrawShadow = false;

            cityLayer.LabelSet.ShadowColor = Color.White;

            cityLayer.LabelSet.ColorByLegend = false;

            cityLayer.AddLabels();


            //Set layout map size

            mapLayout1.ActiveLayoutMap.Left = 40;

            mapLayout1.ActiveLayoutMap.Top = 40;

            mapLayout1.ActiveLayoutMap.Width = 600;

            mapLayout1.ActiveLayoutMap.Height = 400;


            //Refresh

            layersLegend1.ActiveMapFrame.MapView.LockViewUpdate = false;

            layersLegend1.ActiveMapFrame.MapView.ZoomToExtent(70, 140, 10, 60);

            layersLegend1.Refresh();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Set width and height

            this.Width = 1000;

            this.Height = 625;



            //Load layers

            LoadLayers();



            //Set initial tool

            TSB_Pan.PerformClick();            

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void TSMI_GrADSContour_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();
            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\GrADS\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            GridData press = aDataInfo.GetGridData("PS");
            //Create a legend scheme
            bool hasUndefData = false;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(press,

                        LegendType.UniqueValue, ShapeTypes.Polyline, ref hasUndefData);


            //Create a contour layer
           
            //VectorLayer aLayer = DrawMeteoData.CreateContourLayer(press, aLS, "Contour_PS");
            VectorLayer aLayer = DrawMeteoData.CreateContourLayer(press, aLS, "Contour_PS","XDelt");
            
 //Create a contour layer


            //VectorLayer aLayer = DrawMeteoData.CreateGridFillLayer(press, aLS, "GridFill_PS", "XDelt");



            //Add layer

            layersLegend1.ActiveMapFrame.AddLayer(aLayer);

            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 2);

            layersLegend1.Refresh();


            //Change title of the layout

            //LayoutGraphic aTitle = mapLayout1.GetTexts()[0];

            //aTitle.SetLabelText("MeteoInfo Class Library Demo - Contour Layer");


            //Add a legend in layout

            LayoutLegend aLegend = mapLayout1.AddLegend(650, 100);

            aLegend.LegendStyle = LegendStyleEnum.Normal;

            aLegend.LegendLayer = aLayer;

            mapLayout1.PaintGraphics();

        }



private void TSMI_GrADSGrid_Fill_Click_1(object sender, EventArgs e)
{
    //Create a MeteoDataInfo object


    MeteoDataInfo aDataInfo = new MeteoDataInfo();





    //Open GrADS data file


    string aFile = Application.StartupPath + "\\Sample\\GrADS\\model.ctl";


    aDataInfo.OpenGrADSData(aFile);





    //Get GridData


    GridData press = aDataInfo.GetGridData("PS");





    //Create a legend scheme


    bool hasUndefData = false;


    LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(press,


                LegendType.GraduatedColor, ShapeTypes.Polygon, ref hasUndefData);





    //Create a contour layer


    VectorLayer aLayer = DrawMeteoData.CreateGridFillLayer(press, aLS, "GridFill_PS", "XDelt");





    //Add layer


    layersLegend1.ActiveMapFrame.AddLayer(aLayer);


    layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 0);


    layersLegend1.Refresh();





    //Change title of the layout


    //LayoutGraphic aTitle = mapLayout1.GetTexts()[0];


    //aTitle.SetLabelText("MeteoInfo Class Library Demo - Grid_Fill Layer");





    //Add or change the legend in layout


    LayoutLegend aLegend;


    if (mapLayout1.GetLegends().Count > 0)


        aLegend = mapLayout1.GetLegends()[0];


    else


        aLegend = mapLayout1.AddLegend(650, 100);


    aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;


    aLegend.LegendLayer = aLayer;


    mapLayout1.PaintGraphics();

}

private void toolStripButton1_Click_1(object sender, EventArgs e)
{
    
 //Create a MeteoDataInfo object


            MeteoDataInfo aDataInfo = new MeteoDataInfo();





            //Open GrADS data file


            string aFile = Application.StartupPath + "\\Sample\\GrADS\\model.ctl";


            aDataInfo.OpenGrADSData(aFile);





            //Get GridData


            GridData press = aDataInfo.GetGridData("PS");





            //Create a legend scheme


            bool hasUndefData = false;


            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(press,


                        LegendType.GraduatedColor, ShapeTypes.Polygon, ref hasUndefData);





            //Create a contour layer


            VectorLayer aLayer = DrawMeteoData.CreateShadedLayer(press, aLS, "Shaded_PS","XDelt");





            //Add layer


            layersLegend1.ActiveMapFrame.AddLayer(aLayer);


            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 0);


            layersLegend1.Refresh();





            //Change title of the layout


            //LayoutGraphic aTitle = mapLayout1.GetTexts()[0];


            //aTitle.SetLabelText("MeteoInfo Class Library Demo - Shaded Layer");





            //Add or change the legend in layout


            LayoutLegend aLegend;


            if (mapLayout1.GetLegends().Count > 0)


                aLegend = mapLayout1.GetLegends()[0];


            else


                aLegend = mapLayout1.AddLegend(650, 100);


            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;


            aLegend.LegendLayer = aLayer;


            mapLayout1.PaintGraphics();

}


      
    }
}
