using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MeteoInfoDemo.Forms;
using MeteoInfoC.Layer;
using MeteoInfoC.Data;
using MeteoInfoC.Data.MapData;
using MeteoInfoC.Data.MeteoData;
using MeteoInfoC.Map;
using MeteoInfoC.Layout;
using MeteoInfoC.Global;
using MeteoInfoC.Legend;
using MeteoInfoC.Shape;
using MeteoInfoC.Drawing;

namespace MeteoInfoDemo
{
    public partial class frmMain : Form
    {
        ToolStripButton _currentTool;

        public frmMain()
        {
            InitializeComponent();
        }

        private void TSB_AddLayer_Click(object sender, EventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog();
            aDlg.Filter = "Supported Formats|*.shp;*.wmp;*.bln;*.bmp;*.gif;*.jpg;*.tif;*.png|Shape File (*.shp)|*.shp|WMP File (*.wmp)|*.wmp|BLN File (*.bln)|*.bln|" +
                "Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|Jpeg Image (*.jpg)|*.jpg|Tif Image (*.tif)|*.tif|Png Iamge (*.png)|*.png|All Files (*.*)|*.*";

            if (aDlg.ShowDialog() == DialogResult.OK)
            {
                string aFile = aDlg.FileName;
                MapLayer aLayer = MapDataManage.OpenLayer(aFile);
                layersLegend1.ActiveMapFrame.AddLayer(aLayer);
                layersLegend1.Refresh();
            }
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

        private void SetCurrentTool(ToolStripButton currentTool)
        {
            if (!(_currentTool == null))
            {
                _currentTool.Checked = false;
            }
            _currentTool = currentTool;
            _currentTool.Checked = true;
            TSSL_Status.Text = _currentTool.ToolTipText;
        }

        private void TSB_Select_Click(object sender, EventArgs e)
        {
            mapView1.MouseTool = MouseTools.SelectElements;
            mapLayout1.MouseMode = MouseMode.Select;

            SetCurrentTool((ToolStripButton)sender);
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Set width and height
            this.Width = 1000;
            this.Height = 625;

            //Load layers
            LoadLayers();

            //Add title
            AddTitle();

            //Add South China Sea map frame
            AddMapFrame_ChinaSouthSea();

            //Add ActiveMapFrameChanged event
            layersLegend1.ActiveMapFrameChanged += new EventHandler(ActiveMapFrameChanged);

            //Set initial tool
            TSB_Pan.PerformClick();            
        }

        private void LoadLayers()
        {            
            layersLegend1.ActiveMapFrame.MapView.LockViewUpdate = true;

            //Load country layer
            string aFile = Application.StartupPath + "\\Map\\country1.shp";
            MapLayer aLayer = MapDataManage.OpenLayer(aFile);
            //aLayer.LegendScheme.breakList[0].Color = Color.WhiteSmoke;
            PolygonBreak aPGB = (PolygonBreak)aLayer.LegendScheme.breakList[0];
            aPGB.DrawFill = false;
            aPGB.OutlineColor = Color.Black;
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
            cityLayer.LabelSet.YOffset = 0;
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
            layersLegend1.ActiveMapFrame.MapView.ZoomToExtent(78, 130, 16, 55);
            //layersLegend1.Refresh();
        }

        private void AddTitle()
        {
            LayoutGraphic title = mapLayout1.AddText("MeteoInfo Class Library Demo", mapLayout1.Width / 2, 20, 12);
        }

        private void AddMapFrame_ChinaSouthSea()
        {
            //Add an empty map frame
            MapFrame aMF = new MapFrame();
            aMF.Text = "China South Sea";
            layersLegend1.AddMapFrame(aMF);

            //Add a layer to this map frame
            string aFile = Application.StartupPath + "\\Map\\country1.shp";
            MapLayer aLayer = MapDataManage.OpenLayer(aFile);
            //aLayer.LegendScheme.breakList[0].Color = Color.WhiteSmoke;
            PolygonBreak aPGB = (PolygonBreak)aLayer.LegendScheme.breakList[0];
            aPGB.DrawFill = false;
            aPGB.OutlineColor = Color.Black;
            aMF.AddLayer(aLayer);

            //Set layout map property
            LayoutMap aLM = mapLayout1.LayoutMaps[1];
            aLM.DrawGridLabel = false;
            aLM.Left = 550;
            aLM.Top = 330;
            aLM.Width = 80;
            aLM.Height = 100;
            aMF.MapView.ZoomToExtent(105, 120, 0, 20);

            layersLegend1.Refresh();
        }

        private void TSMI_ExportFigure_Click(object sender, EventArgs e)
        {
            SaveFileDialog aDlg = new SaveFileDialog();
            aDlg.Filter = "Png Image (*.png)|*.png|Gif Image (*.gif)|*.gif|Jpeg Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|Tif Image (*.tif)|*.tif|Windows Meta File (*.wmf)|*.wmf";
            if (aDlg.ShowDialog() == DialogResult.OK)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    mapView1.ExportToPicture(aDlg.FileName);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    mapLayout1.ExportToPicture(aDlg.FileName);
                }
            }
        }

        private void SetMapView()
        {
            //Add map view 
            tabControl1.TabPages[0].Controls.Clear();
            tabControl1.TabPages[0].Controls.Add(mapView1);
            mapView1.Dock = DockStyle.Fill;
            //mapView1.MouseMove += new MouseEventHandler(this.MapView_MouseMove);
            //mapView1.MouseDown += new MouseEventHandler(this.MapView_MouseDown);
            //mapView1.GraphicSeleted += new EventHandler(this.MapView_GraphicSelected);            
        }

        private void ActiveMapFrameChanged(object sender, EventArgs e)
        {
            mapView1 = layersLegend1.ActiveMapFrame.MapView;
            SetMapView();
            if (tabControl1.SelectedIndex == 0)
                mapView1.PaintLayers();
        }

        private void TSMI_GridContour_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            GridData press = aDataInfo.GetGridData("PS");

            //Create a legend scheme
            bool hasUndefData = false;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(press,
                        LegendType.UniqueValue, ShapeTypes.Polyline, ref hasUndefData);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateContourLayer(press, aLS, "Contour_PS", "PS");

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 2);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Contour Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Normal;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();      
        }

        private void TSMI_GridShaded_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            GridData press = aDataInfo.GetGridData("PS");

            //Create a legend scheme
            bool hasUndefData = false;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(press,
                        LegendType.GraduatedColor, ShapeTypes.Polygon, ref hasUndefData);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateShadedLayer(press, aLS, "Shaded_PS", "PS");

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 0);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Shaded Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();
        }

        private void TSMI_GridVector_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            aDataInfo.TimeIndex = 2;
            aDataInfo.LevelIndex = 3;
            GridData tData = aDataInfo.GetGridData("T");
            GridData uData = aDataInfo.GetGridData("U");
            GridData vData = aDataInfo .GetGridData ("V");

            //Create a legend scheme
            bool hasUndefData = false;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(tData,
                        LegendType.GraduatedColor, ShapeTypes.Point, ref hasUndefData);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateGridVectorLayer(uData, vData, tData, aLS, true, "Vector_T", true);

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 2);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Wind Vector Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();
        }

        private void TSMI_Grid_Fill_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            GridData press = aDataInfo.GetGridData("PS");

            //Create a legend scheme
            bool hasUndefData = false;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(press,
                        LegendType.GraduatedColor, ShapeTypes.Polygon, ref hasUndefData);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateGridFillLayer(press, aLS, "GridFill_PS", "PS");

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 0);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Grid_Fill Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();
        }

        private void TSMI_Grid_Point_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            GridData press = aDataInfo.GetGridData("PS");

            //Create a legend scheme
            bool hasUndefData = false;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(press,
                        LegendType.GraduatedColor, ShapeTypes.Point, ref hasUndefData);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateGridPointLayer(press, aLS, "GridPoint_PS", "PS");

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 2);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Shaded Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();
        }

        private void TSB_RemoveDataLayers_Click(object sender, EventArgs e)
        {
            layersLegend1.ActiveMapFrame.RemoveMeteoLayers();
            layersLegend1.Refresh();
        }

        private void TSMI_Raster_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            GridData press = aDataInfo.GetGridData("PS");

            //Create a legend scheme
            bool hasUndefData = false;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(press,
                        LegendType.GraduatedColor, ShapeTypes.Polygon, ref hasUndefData);

            //Create a contour layer
            RasterLayer aLayer = DrawMeteoData.CreateRasterLayer(press, "Raster_PS", aLS);

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 0);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Raster Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();
        }

        private void TSMI_GridBarb_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            aDataInfo.TimeIndex = 2;
            aDataInfo.LevelIndex = 3;
            GridData uData = aDataInfo.GetGridData("U");
            GridData vData = aDataInfo.GetGridData("V");

            //Create a legend scheme
            LegendScheme aLS = LegendManage.CreateSingleSymbolLegendScheme(ShapeTypes.Point, Color.Blue, 10);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateGridBarbLayer(uData, vData, uData, aLS, true, "Barb_UV", true);

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 2);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Wind Barb Layer");            
        }

        private void TSMI_GridStreamline_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open GrADS data file
            string aFile = Application.StartupPath + "\\Sample\\model.ctl";
            aDataInfo.OpenGrADSData(aFile);

            //Get GridData
            aDataInfo.TimeIndex = 2;
            aDataInfo.LevelIndex = 3;
            GridData uData = aDataInfo.GetGridData("U");
            GridData vData = aDataInfo.GetGridData("V");

            //Create a legend scheme
            LegendScheme aLS = LegendManage.CreateSingleSymbolLegendScheme(ShapeTypes.Polyline, Color.Blue, 1);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateStreamlineLayer(uData, vData, 4, aLS, "Streamline_UV", true);

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 2);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Wind Streamline Layer");  
        }

        private void TSB_About_Click(object sender, EventArgs e)
        {
            frmAbout aFrm = new frmAbout();
            aFrm.ShowDialog();
        }

        private void TSMI_StationPoint_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open SYNOP data file
            string aFile = Application.StartupPath + "\\Sample\\12010615.syn";
            string stFile = Application.StartupPath + "\\Sample\\SYNOP_Stations.csv";
            aDataInfo.OpenSYNOPData(aFile, stFile);

            //Get StationData
            StationData visData = aDataInfo.GetStationData("Visibility");

            //Create a legend scheme
            bool hasUndefData = false;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromStationData(visData, LegendType.GraduatedColor,
                ShapeTypes.Point, ref hasUndefData);
            for (int i = 0; i < aLS.BreakNum; i++)
                ((PointBreak)aLS.breakList[i]).Size = 8;

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateSTPointLayer(visData, aLS, "StationPoint_Vis", "Vis");

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Station Point Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();
        }
        
        private void TSMI_StationModel_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open SYNOP data file
            string aFile = Application.StartupPath + "\\Sample\\12010615.syn";
            string stFile = Application.StartupPath + "\\Sample\\SYNOP_Stations.csv";
            aDataInfo.OpenSYNOPData(aFile, stFile);

            //Create a legend scheme
            LegendScheme aLS = LegendManage.CreateSingleSymbolLegendScheme(ShapeTypes.Point, Color.Blue, 12);

            //Get station model data
            double[,] stationModelData = new double[10, 1];
            Extent aExtent = new Extent();
            stationModelData = aDataInfo.GetStationModelData(ref aExtent);

            VectorLayer aLayer = new VectorLayer(ShapeTypes.Point);
            aLayer = DrawMeteoData.CreateStationModelLayer(stationModelData,
                    aDataInfo.UNDEF, aLS, "StationModel", true);            

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Station Model Layer");
        }

        private void TSMI_WeatherSymbol_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open SYNOP data file
            string aFile = Application.StartupPath + "\\Sample\\12010615.syn";
            string stFile = Application.StartupPath + "\\Sample\\SYNOP_Stations.csv";
            aDataInfo.OpenSYNOPData(aFile, stFile);

            //Get StationData
            StationData wData = aDataInfo.GetStationData("Weather");

            //Create a legend scheme
            LegendScheme aLS = LegendManage.CreateSingleSymbolLegendScheme(ShapeTypes.Point, Color.Blue, 15);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateWeatherSymbolLayer(wData, aLS, "Weather");

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Weather Symbol Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();
        }

        private void TSMI_StationVector_Click(object sender, EventArgs e)
        {
            //Create a MeteoDataInfo object
            MeteoDataInfo aDataInfo = new MeteoDataInfo();

            //Open SYNOP data file
            string aFile = Application.StartupPath + "\\Sample\\12010615.syn";
            string stFile = Application.StartupPath + "\\Sample\\SYNOP_Stations.csv";
            aDataInfo.OpenSYNOPData(aFile, stFile);

            //Get StationData
            StationData wdData = aDataInfo.GetStationData("WindDirection");
            StationData wsData = aDataInfo.GetStationData("WindSpeed");

            //Create a legend scheme
            LegendScheme aLS = LegendManage.CreateSingleSymbolLegendScheme(ShapeTypes.Point, Color.Blue, 15);

            //Create a contour layer
            VectorLayer aLayer = DrawMeteoData.CreateSTVectorLayer(wdData, wsData, wdData, aLS, false, "StationVector", false);

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Station Wind Vector Layer");
        }

        private void TSMI_StationShaded_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            //Read data info
            MeteoDataInfo aDataInfo = new MeteoDataInfo();
            string aFile = Application.StartupPath + "\\Sample\\rain_2008072220.csv";
            aDataInfo.OpenLonLatData(aFile);

            //Get station data
            StationData stationData = aDataInfo.GetStationData("Precipitation6h");

            //Interpolate
            GridDataPara aGDP = new GridDataPara();
            aGDP.dataExtent.minX = 60;
            aGDP.dataExtent.maxX = 140;
            aGDP.dataExtent.minY = -20;
            aGDP.dataExtent.maxY = 60;
            aGDP.xNum = 80;
            aGDP.yNum = 80;
            GridInterpolation gridInterp = new GridInterpolation();
            gridInterp.GridDataParaV = aGDP;

            gridInterp.GridInterMethodV = GridInterMethod.IDW_Radius;
            gridInterp.Radius = 2;
            gridInterp.MinPointNum = 1;

            double[] X = new double[1];
            double[] Y = new double[1];
            ContourDraw.CreateGridXY(gridInterp.GridDataParaV, ref X, ref Y);
            double[,] S = stationData.Data;
            S = ContourDraw.FilterDiscreteData_Radius(S, gridInterp.Radius,
                gridInterp.GridDataParaV.dataExtent, stationData.UNDEF);
            GridData gridData = ContourDraw.InterpolateDiscreteData_Radius(S,
                X, Y, gridInterp.MinPointNum, gridInterp.Radius, stationData.UNDEF);

            //Create legend scheme
            bool hasNoData = true;
            LegendScheme aLS = LegendManage.CreateLegendSchemeFromGridData(gridData, LegendType.GraduatedColor,
                ShapeTypes.Polygon, ref hasNoData);
            ((PolygonBreak)aLS.breakList[0]).DrawFill = false;

            //Create layer
            VectorLayer aLayer = new VectorLayer(ShapeTypes.Polygon);
            aLayer = DrawMeteoData.CreateShadedLayer(gridData, aLS, "Rain", "Rain");
            aLayer.IsMaskout = true;

            //Add layer
            layersLegend1.ActiveMapFrame.AddLayer(aLayer);
            layersLegend1.ActiveMapFrame.MoveLayer(aLayer.Handle, 0);
            layersLegend1.Refresh();

            //Change title of the layout
            LayoutGraphic aTitle = mapLayout1.GetTexts()[0];
            aTitle.SetLabelText("MeteoInfo Class Library Demo - Station Shaded Layer");

            //Add or change the legend in layout
            LayoutLegend aLegend;
            if (mapLayout1.GetLegends().Count > 0)
                aLegend = mapLayout1.GetLegends()[0];
            else
                aLegend = mapLayout1.AddLegend(650, 100);
            aLegend.LegendStyle = LegendStyleEnum.Bar_Vertical;
            aLegend.LegendLayer = aLayer;
            if (tabControl1.SelectedIndex == 1)
                mapLayout1.PaintGraphics();

            this.Cursor = Cursors.Default;
        }
    }
}
