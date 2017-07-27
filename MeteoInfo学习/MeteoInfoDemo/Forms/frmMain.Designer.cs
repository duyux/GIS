namespace MeteoInfoDemo
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MeteoInfoC.Legend.LabelBreak labelBreak1 = new MeteoInfoC.Legend.LabelBreak();
            MeteoInfoC.Legend.PointBreak pointBreak1 = new MeteoInfoC.Legend.PointBreak();
            MeteoInfoC.Legend.PolygonBreak polygonBreak1 = new MeteoInfoC.Legend.PolygonBreak();
            MeteoInfoC.Legend.PolyLineBreak polyLineBreak1 = new MeteoInfoC.Legend.PolyLineBreak();
            MeteoInfoC.Layer.LayerCollection layerCollection1 = new MeteoInfoC.Layer.LayerCollection();
            MeteoInfoC.Map.ProjectionSet projectionSet1 = new MeteoInfoC.Map.ProjectionSet();
            MeteoInfoC.Projections.ProjectionInfo projectionInfo1 = new MeteoInfoC.Projections.ProjectionInfo();
            MeteoInfoC.Projections.GeographicInfo geographicInfo1 = new MeteoInfoC.Projections.GeographicInfo();
            MeteoInfoC.Projections.Datum datum1 = new MeteoInfoC.Projections.Datum();
            MeteoInfoC.Projections.Spheroid spheroid1 = new MeteoInfoC.Projections.Spheroid();
            MeteoInfoC.Projections.Meridian meridian1 = new MeteoInfoC.Projections.Meridian();
            MeteoInfoC.Projections.AngularUnit angularUnit1 = new MeteoInfoC.Projections.AngularUnit();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            MeteoInfoC.Projections.LongLat longLat1 = new MeteoInfoC.Projections.LongLat();
            MeteoInfoC.Projections.LinearUnit linearUnit1 = new MeteoInfoC.Projections.LinearUnit();
            MeteoInfoC.Legend.MapFrame mapFrame1 = new MeteoInfoC.Legend.MapFrame();
            MeteoInfoC.Legend.LabelBreak labelBreak2 = new MeteoInfoC.Legend.LabelBreak();
            MeteoInfoC.Legend.PointBreak pointBreak2 = new MeteoInfoC.Legend.PointBreak();
            MeteoInfoC.Legend.PolygonBreak polygonBreak2 = new MeteoInfoC.Legend.PolygonBreak();
            MeteoInfoC.Legend.PolyLineBreak polyLineBreak2 = new MeteoInfoC.Legend.PolyLineBreak();
            this.mapView1 = new MeteoInfoC.Map.MapView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMI_File = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_ExportFigure = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_MeteoData = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_GridData = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_GridContour = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_GridShaded = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_GridFill = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Grid_Point = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Raster = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_GridVector = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_GridBarb = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_GridStreamline = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_StationData = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_StationPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_StationModel = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_WeatherSymbol = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_StationVector = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_StationShaded = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_AddLayer = new System.Windows.Forms.ToolStripButton();
            this.TSB_RemoveDataLayers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_Select = new System.Windows.Forms.ToolStripButton();
            this.TSB_ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.TSB_ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.TSB_Pan = new System.Windows.Forms.ToolStripButton();
            this.TSB_FullExent = new System.Windows.Forms.ToolStripButton();
            this.TSB_Identifer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_About = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSSL_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.layersLegend1 = new MeteoInfoC.Legend.LayersLegend();
            this.mapLayout1 = new MeteoInfoC.Layout.MapLayout();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapView1
            // 
            this.mapView1.BackColor = System.Drawing.Color.White;
            this.mapView1.Cursor = System.Windows.Forms.Cursors.Default;
            labelBreak1.AlignType = MeteoInfoC.Legend.AlignType.Center;
            labelBreak1.Angle = 0F;
            labelBreak1.BreakType = MeteoInfoC.Legend.BreakTypes.LabelBreak;
            labelBreak1.Caption = null;
            labelBreak1.Color = System.Drawing.Color.Black;
            labelBreak1.DrawShape = true;
            labelBreak1.EndValue = null;
            labelBreak1.Font = new System.Drawing.Font("Arial", 10F);
            labelBreak1.IsNoData = false;
            labelBreak1.StartValue = null;
            labelBreak1.Text = "Text";
            labelBreak1.YShift = 0F;
            this.mapView1.DefLabelBreak = labelBreak1;
            pointBreak1.Angle = 0F;
            pointBreak1.BreakType = MeteoInfoC.Legend.BreakTypes.PointBreak;
            pointBreak1.Caption = null;
            pointBreak1.CharIndex = 0;
            pointBreak1.Color = System.Drawing.Color.Red;
            pointBreak1.DrawFill = true;
            pointBreak1.DrawOutline = true;
            pointBreak1.DrawShape = true;
            pointBreak1.EndValue = null;
            pointBreak1.FontName = "Arial";
            pointBreak1.ImagePath = null;
            pointBreak1.IsNoData = false;
            pointBreak1.MarkerType = MeteoInfoC.Drawing.MarkerType.Simple;
            pointBreak1.OutlineColor = System.Drawing.Color.Black;
            pointBreak1.Size = 10F;
            pointBreak1.StartValue = null;
            pointBreak1.Style = MeteoInfoC.Drawing.PointStyle.Circle;
            this.mapView1.DefPointBreak = pointBreak1;
            polygonBreak1.BackColor = System.Drawing.Color.Transparent;
            polygonBreak1.BreakType = MeteoInfoC.Legend.BreakTypes.PolygonBreak;
            polygonBreak1.Caption = null;
            polygonBreak1.Color = System.Drawing.Color.LightYellow;
            polygonBreak1.DrawFill = true;
            polygonBreak1.DrawOutline = true;
            polygonBreak1.DrawShape = true;
            polygonBreak1.EndValue = null;
            polygonBreak1.IsMaskout = false;
            polygonBreak1.IsNoData = false;
            polygonBreak1.OutlineColor = System.Drawing.Color.Black;
            polygonBreak1.OutlineSize = 1F;
            polygonBreak1.StartValue = null;
            polygonBreak1.Style = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            polygonBreak1.TransparencyPercent = 50;
            polygonBreak1.UsingHatchStyle = false;
            this.mapView1.DefPolygonBreak = polygonBreak1;
            polyLineBreak1.BreakType = MeteoInfoC.Legend.BreakTypes.PolylineBreak;
            polyLineBreak1.Caption = null;
            polyLineBreak1.Color = System.Drawing.Color.Red;
            polyLineBreak1.DrawPolyline = true;
            polyLineBreak1.DrawShape = true;
            polyLineBreak1.DrawSymbol = false;
            polyLineBreak1.EndValue = null;
            polyLineBreak1.IsNoData = false;
            polyLineBreak1.Size = 2F;
            polyLineBreak1.StartValue = null;
            polyLineBreak1.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            polyLineBreak1.SymbolColor = System.Drawing.Color.Red;
            polyLineBreak1.SymbolInterval = 1;
            polyLineBreak1.SymbolSize = 8F;
            polyLineBreak1.SymbolStyle = MeteoInfoC.Drawing.PointStyle.UpTriangle;
            this.mapView1.DefPolylineBreak = polyLineBreak1;
            this.mapView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapView1.DrawGridLine = false;
            this.mapView1.DrawGridTickLine = false;
            this.mapView1.DrawIdentiferShape = false;
            this.mapView1.DrawNeatLine = false;
            this.mapView1.ForeColor = System.Drawing.Color.Black;
            this.mapView1.GridLineColor = System.Drawing.Color.Black;
            this.mapView1.GridLineSize = 1;
            this.mapView1.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.mapView1.GridXDelt = 10D;
            this.mapView1.GridXOrigin = 0D;
            this.mapView1.GridYDelt = 10D;
            this.mapView1.GridYOrigin = 0D;
            this.mapView1.IsGeoMap = true;
            this.mapView1.IsLayoutMap = false;
            this.mapView1.IsPaint = true;
            this.mapView1.IsSelectedInLayout = false;
            layerCollection1.LayerNum = 0;
            layerCollection1.SelectedLayer = -1;
            this.mapView1.LayerSet = layerCollection1;
            this.mapView1.Location = new System.Drawing.Point(3, 3);
            this.mapView1.LockViewUpdate = false;
            this.mapView1.LonLatProjLayer = null;
            this.mapView1.MouseTool = MeteoInfoC.Map.MouseTools.None;
            this.mapView1.Name = "mapView1";
            this.mapView1.NeatLineColor = System.Drawing.Color.Black;
            this.mapView1.NeatLineSize = 1;
            projectionInfo1.CentralMeridian = null;
            projectionInfo1.FalseEasting = null;
            projectionInfo1.FalseNorthing = null;
            projectionInfo1.Geoc = false;
            datum1.DatumType = MeteoInfoC.Projections.DatumTypes.WGS84;
            datum1.Description = "WGS 1984";
            datum1.NadGrids = null;
            datum1.Name = null;
            spheroid1.EquatorialRadius = 6378137D;
            spheroid1.KnownEllipsoid = MeteoInfoC.Projections.Proj4Ellipsoids.WGS_1984;
            spheroid1.Name = "WGS_1984";
            spheroid1.PolarRadius = 6356752.3142451793D;
            datum1.Spheroid = spheroid1;
            datum1.ToWGS84 = new double[] {
        0D,
        0D,
        0D};
            geographicInfo1.Datum = datum1;
            meridian1.Longitude = 0D;
            meridian1.Name = null;
            geographicInfo1.Meridian = meridian1;
            geographicInfo1.Name = null;
            angularUnit1.Name = null;
            angularUnit1.Radians = 0.0174532925D;
            geographicInfo1.Unit = angularUnit1;
            projectionInfo1.GeographicInfo = geographicInfo1;
            projectionInfo1.IsGeocentric = false;
            projectionInfo1.IsLatLon = false;
            projectionInfo1.IsSouth = false;
            projectionInfo1.LatitudeOfOrigin = null;
            projectionInfo1.Name = null;
            projectionInfo1.NoDefs = false;
            projectionInfo1.Over = false;
            projectionInfo1.Parameters = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("projectionInfo1.Parameters")));
            projectionInfo1.ScaleFactor = 1D;
            projectionInfo1.StandardParallel1 = null;
            projectionInfo1.StandardParallel2 = null;
            longLat1.ProjectionName = MeteoInfoC.Projections.ProjectionNames.Lon_Lat;
            projectionInfo1.Transform = longLat1;
            linearUnit1.Meters = 1D;
            linearUnit1.Name = null;
            projectionInfo1.Unit = linearUnit1;
            projectionInfo1.Zone = null;
            projectionSet1.ProjInfo = projectionInfo1;
            projectionSet1.ProjStr = " +proj=lonlat +ellps=WGS84 +datum=WGS84 +no_defs= +k=1";
            projectionSet1.RefCutLon = 0D;
            projectionSet1.RefLon = 0D;
            this.mapView1.Projection = projectionSet1;
            this.mapView1.SelectColor = System.Drawing.Color.Yellow;
            this.mapView1.SelectedLayer = 0;
            this.mapView1.Size = new System.Drawing.Size(571, 308);
            this.mapView1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.mapView1.TabIndex = 0;
            this.mapView1.XGridStrs = ((System.Collections.Generic.List<string>)(resources.GetObject("mapView1.XGridStrs")));
            this.mapView1.XYScaleFactor = 1.2D;
            this.mapView1.YGridStrs = ((System.Collections.Generic.List<string>)(resources.GetObject("mapView1.YGridStrs")));
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_File,
            this.TSMI_MeteoData});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMI_File
            // 
            this.TSMI_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_ExportFigure});
            this.TSMI_File.Name = "TSMI_File";
            this.TSMI_File.Size = new System.Drawing.Size(39, 21);
            this.TSMI_File.Text = "File";
            // 
            // TSMI_ExportFigure
            // 
            this.TSMI_ExportFigure.Name = "TSMI_ExportFigure";
            this.TSMI_ExportFigure.Size = new System.Drawing.Size(154, 22);
            this.TSMI_ExportFigure.Text = "Export Figure";
            this.TSMI_ExportFigure.Click += new System.EventHandler(this.TSMI_ExportFigure_Click);
            // 
            // TSMI_MeteoData
            // 
            this.TSMI_MeteoData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_GridData,
            this.TSMI_StationData});
            this.TSMI_MeteoData.Name = "TSMI_MeteoData";
            this.TSMI_MeteoData.Size = new System.Drawing.Size(85, 21);
            this.TSMI_MeteoData.Text = "MeteoData";
            // 
            // TSMI_GridData
            // 
            this.TSMI_GridData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_GridContour,
            this.TSMI_GridShaded,
            this.TSMI_GridFill,
            this.TSMI_Grid_Point,
            this.TSMI_Raster,
            this.TSMI_GridVector,
            this.TSMI_GridBarb,
            this.TSMI_GridStreamline});
            this.TSMI_GridData.Name = "TSMI_GridData";
            this.TSMI_GridData.Size = new System.Drawing.Size(147, 22);
            this.TSMI_GridData.Text = "Grid Data";
            // 
            // TSMI_GridContour
            // 
            this.TSMI_GridContour.Name = "TSMI_GridContour";
            this.TSMI_GridContour.Size = new System.Drawing.Size(137, 22);
            this.TSMI_GridContour.Text = "Contour";
            this.TSMI_GridContour.Click += new System.EventHandler(this.TSMI_GridContour_Click);
            // 
            // TSMI_GridShaded
            // 
            this.TSMI_GridShaded.Name = "TSMI_GridShaded";
            this.TSMI_GridShaded.Size = new System.Drawing.Size(137, 22);
            this.TSMI_GridShaded.Text = "Shaded";
            this.TSMI_GridShaded.Click += new System.EventHandler(this.TSMI_GridShaded_Click);
            // 
            // TSMI_GridFill
            // 
            this.TSMI_GridFill.Name = "TSMI_GridFill";
            this.TSMI_GridFill.Size = new System.Drawing.Size(137, 22);
            this.TSMI_GridFill.Text = "Grid_Fill";
            this.TSMI_GridFill.Click += new System.EventHandler(this.TSMI_Grid_Fill_Click);
            // 
            // TSMI_Grid_Point
            // 
            this.TSMI_Grid_Point.Name = "TSMI_Grid_Point";
            this.TSMI_Grid_Point.Size = new System.Drawing.Size(137, 22);
            this.TSMI_Grid_Point.Text = "Grid_Point";
            this.TSMI_Grid_Point.Click += new System.EventHandler(this.TSMI_Grid_Point_Click);
            // 
            // TSMI_Raster
            // 
            this.TSMI_Raster.Name = "TSMI_Raster";
            this.TSMI_Raster.Size = new System.Drawing.Size(137, 22);
            this.TSMI_Raster.Text = "Raster";
            this.TSMI_Raster.Click += new System.EventHandler(this.TSMI_Raster_Click);
            // 
            // TSMI_GridVector
            // 
            this.TSMI_GridVector.Name = "TSMI_GridVector";
            this.TSMI_GridVector.Size = new System.Drawing.Size(137, 22);
            this.TSMI_GridVector.Text = "Vector";
            this.TSMI_GridVector.Click += new System.EventHandler(this.TSMI_GridVector_Click);
            // 
            // TSMI_GridBarb
            // 
            this.TSMI_GridBarb.Name = "TSMI_GridBarb";
            this.TSMI_GridBarb.Size = new System.Drawing.Size(137, 22);
            this.TSMI_GridBarb.Text = "Barb";
            this.TSMI_GridBarb.Click += new System.EventHandler(this.TSMI_GridBarb_Click);
            // 
            // TSMI_GridStreamline
            // 
            this.TSMI_GridStreamline.Name = "TSMI_GridStreamline";
            this.TSMI_GridStreamline.Size = new System.Drawing.Size(137, 22);
            this.TSMI_GridStreamline.Text = "Streamline";
            this.TSMI_GridStreamline.Click += new System.EventHandler(this.TSMI_GridStreamline_Click);
            // 
            // TSMI_StationData
            // 
            this.TSMI_StationData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_StationPoint,
            this.TSMI_StationModel,
            this.TSMI_WeatherSymbol,
            this.TSMI_StationVector,
            this.TSMI_StationShaded});
            this.TSMI_StationData.Name = "TSMI_StationData";
            this.TSMI_StationData.Size = new System.Drawing.Size(147, 22);
            this.TSMI_StationData.Text = "Station Data";
            // 
            // TSMI_StationPoint
            // 
            this.TSMI_StationPoint.Name = "TSMI_StationPoint";
            this.TSMI_StationPoint.Size = new System.Drawing.Size(172, 22);
            this.TSMI_StationPoint.Text = "Station Point";
            this.TSMI_StationPoint.Click += new System.EventHandler(this.TSMI_StationPoint_Click);
            // 
            // TSMI_StationModel
            // 
            this.TSMI_StationModel.Name = "TSMI_StationModel";
            this.TSMI_StationModel.Size = new System.Drawing.Size(172, 22);
            this.TSMI_StationModel.Text = "Station Model";
            this.TSMI_StationModel.Click += new System.EventHandler(this.TSMI_StationModel_Click);
            // 
            // TSMI_WeatherSymbol
            // 
            this.TSMI_WeatherSymbol.Name = "TSMI_WeatherSymbol";
            this.TSMI_WeatherSymbol.Size = new System.Drawing.Size(172, 22);
            this.TSMI_WeatherSymbol.Text = "Weather Symbol";
            this.TSMI_WeatherSymbol.Click += new System.EventHandler(this.TSMI_WeatherSymbol_Click);
            // 
            // TSMI_StationVector
            // 
            this.TSMI_StationVector.Name = "TSMI_StationVector";
            this.TSMI_StationVector.Size = new System.Drawing.Size(172, 22);
            this.TSMI_StationVector.Text = "Vector";
            this.TSMI_StationVector.Click += new System.EventHandler(this.TSMI_StationVector_Click);
            // 
            // TSMI_StationShaded
            // 
            this.TSMI_StationShaded.Name = "TSMI_StationShaded";
            this.TSMI_StationShaded.Size = new System.Drawing.Size(172, 22);
            this.TSMI_StationShaded.Text = "Shaded";
            this.TSMI_StationShaded.Click += new System.EventHandler(this.TSMI_StationShaded_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_AddLayer,
            this.TSB_RemoveDataLayers,
            this.toolStripSeparator1,
            this.TSB_Select,
            this.TSB_ZoomIn,
            this.TSB_ZoomOut,
            this.TSB_Pan,
            this.TSB_FullExent,
            this.TSB_Identifer,
            this.toolStripSeparator2,
            this.TSB_About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSB_AddLayer
            // 
            this.TSB_AddLayer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_AddLayer.Image = ((System.Drawing.Image)(resources.GetObject("TSB_AddLayer.Image")));
            this.TSB_AddLayer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_AddLayer.Name = "TSB_AddLayer";
            this.TSB_AddLayer.Size = new System.Drawing.Size(23, 22);
            this.TSB_AddLayer.Text = "Add Layer";
            this.TSB_AddLayer.Click += new System.EventHandler(this.TSB_AddLayer_Click);
            // 
            // TSB_RemoveDataLayers
            // 
            this.TSB_RemoveDataLayers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_RemoveDataLayers.Image = ((System.Drawing.Image)(resources.GetObject("TSB_RemoveDataLayers.Image")));
            this.TSB_RemoveDataLayers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_RemoveDataLayers.Name = "TSB_RemoveDataLayers";
            this.TSB_RemoveDataLayers.Size = new System.Drawing.Size(23, 22);
            this.TSB_RemoveDataLayers.Text = "toolStripButton1";
            this.TSB_RemoveDataLayers.Click += new System.EventHandler(this.TSB_RemoveDataLayers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_Select
            // 
            this.TSB_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Select.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Select.Image")));
            this.TSB_Select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Select.Name = "TSB_Select";
            this.TSB_Select.Size = new System.Drawing.Size(23, 22);
            this.TSB_Select.Text = "Select Elements";
            this.TSB_Select.Click += new System.EventHandler(this.TSB_Select_Click);
            // 
            // TSB_ZoomIn
            // 
            this.TSB_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("TSB_ZoomIn.Image")));
            this.TSB_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ZoomIn.Name = "TSB_ZoomIn";
            this.TSB_ZoomIn.Size = new System.Drawing.Size(23, 22);
            this.TSB_ZoomIn.Text = "Zoom In";
            this.TSB_ZoomIn.Click += new System.EventHandler(this.TSB_ZoomIn_Click);
            // 
            // TSB_ZoomOut
            // 
            this.TSB_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("TSB_ZoomOut.Image")));
            this.TSB_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ZoomOut.Name = "TSB_ZoomOut";
            this.TSB_ZoomOut.Size = new System.Drawing.Size(23, 22);
            this.TSB_ZoomOut.Text = "Zoom Out";
            this.TSB_ZoomOut.Click += new System.EventHandler(this.TSB_ZoomOut_Click);
            // 
            // TSB_Pan
            // 
            this.TSB_Pan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Pan.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Pan.Image")));
            this.TSB_Pan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Pan.Name = "TSB_Pan";
            this.TSB_Pan.Size = new System.Drawing.Size(23, 22);
            this.TSB_Pan.Text = "Pan";
            this.TSB_Pan.Click += new System.EventHandler(this.TSB_Pan_Click);
            // 
            // TSB_FullExent
            // 
            this.TSB_FullExent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_FullExent.Image = ((System.Drawing.Image)(resources.GetObject("TSB_FullExent.Image")));
            this.TSB_FullExent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_FullExent.Name = "TSB_FullExent";
            this.TSB_FullExent.Size = new System.Drawing.Size(23, 22);
            this.TSB_FullExent.Text = "Full Extent";
            this.TSB_FullExent.Click += new System.EventHandler(this.TSB_FullExent_Click);
            // 
            // TSB_Identifer
            // 
            this.TSB_Identifer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Identifer.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Identifer.Image")));
            this.TSB_Identifer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Identifer.Name = "TSB_Identifer";
            this.TSB_Identifer.Size = new System.Drawing.Size(23, 22);
            this.TSB_Identifer.Text = "Identifer";
            this.TSB_Identifer.Click += new System.EventHandler(this.TSB_Identifer_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_About
            // 
            this.TSB_About.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_About.Image = ((System.Drawing.Image)(resources.GetObject("TSB_About.Image")));
            this.TSB_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_About.Name = "TSB_About";
            this.TSB_About.Size = new System.Drawing.Size(23, 22);
            this.TSB_About.Text = "About";
            this.TSB_About.Click += new System.EventHandler(this.TSB_About_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSSL_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(782, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSSL_Status
            // 
            this.TSSL_Status.Name = "TSSL_Status";
            this.TSSL_Status.Size = new System.Drawing.Size(43, 17);
            this.TSSL_Status.Text = "Status";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.layersLegend1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(782, 340);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 3;
            // 
            // layersLegend1
            // 
            this.layersLegend1.AllowDrop = true;
            this.layersLegend1.BackColor = System.Drawing.Color.White;
            this.layersLegend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layersLegend1.Font = new System.Drawing.Font("Arial", 8F);
            this.layersLegend1.ForeColor = System.Drawing.Color.Black;
            this.layersLegend1.IsLayoutView = false;
            this.layersLegend1.Location = new System.Drawing.Point(0, 0);
            mapFrame1.Active = true;
            mapFrame1.BackColor = System.Drawing.Color.White;
            mapFrame1.Checked = true;
            mapFrame1.DrawGridLabel = true;
            mapFrame1.DrawGridLine = false;
            mapFrame1.DrawGridTickLine = false;
            mapFrame1.DrawNeatLine = true;
            mapFrame1.ForeColor = System.Drawing.Color.Black;
            mapFrame1.GridFont = new System.Drawing.Font("Arial", 8F);
            mapFrame1.GridLabelPosition = MeteoInfoC.Legend.GridLabelPosition.LeftBottom;
            mapFrame1.GridLineColor = System.Drawing.Color.Black;
            mapFrame1.GridLineSize = 1;
            mapFrame1.GridLineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            mapFrame1.GridXDelt = 10D;
            mapFrame1.GridXOrigin = 0D;
            mapFrame1.GridYDelt = 10D;
            mapFrame1.GridYOrigin = 0D;
            mapFrame1.Height = 15;
            mapFrame1.IsFireMapViewUpdate = false;
            mapFrame1.LayoutBounds = new System.Drawing.Rectangle(100, 100, 300, 200);
            mapFrame1.Legend = null;
            mapFrame1.MapFrameName = "New Map Frame";
            mapFrame1.MapView = this.mapView1;
            mapFrame1.NeatLineColor = System.Drawing.Color.Black;
            mapFrame1.NeatLineSize = 1;
            mapFrame1.NodeType = MeteoInfoC.Legend.NodeTypes.MapFrameNode;
            mapFrame1.Order = 0;
            mapFrame1.Selected = false;
            mapFrame1.SelectedLayer = 0;
            mapFrame1.Text = "New Map Frame";
            mapFrame1.Top = 0;
            this.layersLegend1.MapFrames.Add(mapFrame1);
            this.layersLegend1.MapLayout = this.mapLayout1;
            this.layersLegend1.Name = "layersLegend1";
            this.layersLegend1.SelectedNode = null;
            this.layersLegend1.Size = new System.Drawing.Size(193, 340);
            this.layersLegend1.TabIndex = 4;
            // 
            // mapLayout1
            // 
            this.mapLayout1.AutoResize = false;
            this.mapLayout1.BackColor = System.Drawing.Color.DarkGray;
            labelBreak2.AlignType = MeteoInfoC.Legend.AlignType.Center;
            labelBreak2.Angle = 0F;
            labelBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.LabelBreak;
            labelBreak2.Caption = null;
            labelBreak2.Color = System.Drawing.Color.Black;
            labelBreak2.DrawShape = true;
            labelBreak2.EndValue = null;
            labelBreak2.Font = new System.Drawing.Font("Arial", 10F);
            labelBreak2.IsNoData = false;
            labelBreak2.StartValue = null;
            labelBreak2.Text = "Text";
            labelBreak2.YShift = 0F;
            this.mapLayout1.DefLabelBreak = labelBreak2;
            pointBreak2.Angle = 0F;
            pointBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PointBreak;
            pointBreak2.Caption = null;
            pointBreak2.CharIndex = 0;
            pointBreak2.Color = System.Drawing.Color.Red;
            pointBreak2.DrawFill = true;
            pointBreak2.DrawOutline = true;
            pointBreak2.DrawShape = true;
            pointBreak2.EndValue = null;
            pointBreak2.FontName = "Arial";
            pointBreak2.ImagePath = null;
            pointBreak2.IsNoData = false;
            pointBreak2.MarkerType = MeteoInfoC.Drawing.MarkerType.Simple;
            pointBreak2.OutlineColor = System.Drawing.Color.Black;
            pointBreak2.Size = 10F;
            pointBreak2.StartValue = null;
            pointBreak2.Style = MeteoInfoC.Drawing.PointStyle.Circle;
            this.mapLayout1.DefPointBreak = pointBreak2;
            polygonBreak2.BackColor = System.Drawing.Color.Transparent;
            polygonBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PolygonBreak;
            polygonBreak2.Caption = null;
            polygonBreak2.Color = System.Drawing.Color.LightYellow;
            polygonBreak2.DrawFill = true;
            polygonBreak2.DrawOutline = true;
            polygonBreak2.DrawShape = true;
            polygonBreak2.EndValue = null;
            polygonBreak2.IsMaskout = false;
            polygonBreak2.IsNoData = false;
            polygonBreak2.OutlineColor = System.Drawing.Color.Black;
            polygonBreak2.OutlineSize = 1F;
            polygonBreak2.StartValue = null;
            polygonBreak2.Style = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            polygonBreak2.TransparencyPercent = 50;
            polygonBreak2.UsingHatchStyle = false;
            this.mapLayout1.DefPolygonBreak = polygonBreak2;
            polyLineBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PolylineBreak;
            polyLineBreak2.Caption = null;
            polyLineBreak2.Color = System.Drawing.Color.Red;
            polyLineBreak2.DrawPolyline = true;
            polyLineBreak2.DrawShape = true;
            polyLineBreak2.DrawSymbol = false;
            polyLineBreak2.EndValue = null;
            polyLineBreak2.IsNoData = false;
            polyLineBreak2.Size = 2F;
            polyLineBreak2.StartValue = null;
            polyLineBreak2.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            polyLineBreak2.SymbolColor = System.Drawing.Color.Red;
            polyLineBreak2.SymbolInterval = 1;
            polyLineBreak2.SymbolSize = 8F;
            polyLineBreak2.SymbolStyle = MeteoInfoC.Drawing.PointStyle.UpTriangle;
            this.mapLayout1.DefPolylineBreak = polyLineBreak2;
            this.mapLayout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapLayout1.Landscape = true;
            this.mapLayout1.Location = new System.Drawing.Point(3, 3);
            this.mapLayout1.MapFrames.Add(mapFrame1);
            this.mapLayout1.MouseMode = MeteoInfoC.Layout.MouseMode.Default;
            this.mapLayout1.Name = "mapLayout1";
            this.mapLayout1.PageBackColor = System.Drawing.Color.White;
            this.mapLayout1.PageBounds = new System.Drawing.Rectangle(0, 0, 720, 480);
            this.mapLayout1.PageForeColor = System.Drawing.Color.Black;
            this.mapLayout1.PageLocation = ((System.Drawing.PointF)(resources.GetObject("mapLayout1.PageLocation")));
            this.mapLayout1.PaperSize = ((System.Drawing.Printing.PaperSize)(resources.GetObject("mapLayout1.PaperSize")));
            this.mapLayout1.PrinterSetting = null;
            this.mapLayout1.Size = new System.Drawing.Size(572, 310);
            this.mapLayout1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.mapLayout1.TabIndex = 0;
            this.mapLayout1.Zoom = 1F;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 340);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mapView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(577, 314);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mapLayout1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(577, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Layout";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 412);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "MeteoInfo Demo";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton TSB_AddLayer;
        private MeteoInfoC.Legend.LayersLegend layersLegend1;
        private MeteoInfoC.Map.MapView mapView1;
        private MeteoInfoC.Layout.MapLayout mapLayout1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_Select;
        private System.Windows.Forms.ToolStripButton TSB_ZoomIn;
        private System.Windows.Forms.ToolStripButton TSB_ZoomOut;
        private System.Windows.Forms.ToolStripButton TSB_Pan;
        private System.Windows.Forms.ToolStripButton TSB_FullExent;
        private System.Windows.Forms.ToolStripButton TSB_Identifer;
        private System.Windows.Forms.ToolStripStatusLabel TSSL_Status;
        private System.Windows.Forms.ToolStripMenuItem TSMI_File;
        private System.Windows.Forms.ToolStripMenuItem TSMI_ExportFigure;
        private System.Windows.Forms.ToolStripMenuItem TSMI_MeteoData;
        private System.Windows.Forms.ToolStripMenuItem TSMI_GridData;
        private System.Windows.Forms.ToolStripMenuItem TSMI_GridContour;
        private System.Windows.Forms.ToolStripMenuItem TSMI_GridShaded;
        private System.Windows.Forms.ToolStripMenuItem TSMI_GridVector;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Grid_Point;
        private System.Windows.Forms.ToolStripMenuItem TSMI_GridBarb;
        private System.Windows.Forms.ToolStripMenuItem TSMI_GridStreamline;
        private System.Windows.Forms.ToolStripMenuItem TSMI_GridFill;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Raster;
        private System.Windows.Forms.ToolStripButton TSB_RemoveDataLayers;
        private System.Windows.Forms.ToolStripMenuItem TSMI_StationData;
        private System.Windows.Forms.ToolStripMenuItem TSMI_StationPoint;
        private System.Windows.Forms.ToolStripMenuItem TSMI_StationModel;
        private System.Windows.Forms.ToolStripMenuItem TSMI_WeatherSymbol;
        private System.Windows.Forms.ToolStripMenuItem TSMI_StationVector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TSB_About;
        private System.Windows.Forms.ToolStripMenuItem TSMI_StationShaded;
    }
}

