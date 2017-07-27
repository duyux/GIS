namespace MeteoInfoHelloWorld
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            MeteoInfoC.Legend.LabelBreak labelBreak2 = new MeteoInfoC.Legend.LabelBreak();
            MeteoInfoC.Legend.PointBreak pointBreak2 = new MeteoInfoC.Legend.PointBreak();
            MeteoInfoC.Legend.PolygonBreak polygonBreak2 = new MeteoInfoC.Legend.PolygonBreak();
            MeteoInfoC.Legend.PolyLineBreak polyLineBreak2 = new MeteoInfoC.Legend.PolyLineBreak();
            MeteoInfoC.Layer.LayerCollection layerCollection1 = new MeteoInfoC.Layer.LayerCollection();
            MeteoInfoC.Map.ProjectionSet projectionSet1 = new MeteoInfoC.Map.ProjectionSet();
            MeteoInfoC.Projections.ProjectionInfo projectionInfo1 = new MeteoInfoC.Projections.ProjectionInfo();
            MeteoInfoC.Projections.GeographicInfo geographicInfo1 = new MeteoInfoC.Projections.GeographicInfo();
            MeteoInfoC.Projections.Datum datum1 = new MeteoInfoC.Projections.Datum();
            MeteoInfoC.Projections.Spheroid spheroid1 = new MeteoInfoC.Projections.Spheroid();
            MeteoInfoC.Projections.Meridian meridian1 = new MeteoInfoC.Projections.Meridian();
            MeteoInfoC.Projections.AngularUnit angularUnit1 = new MeteoInfoC.Projections.AngularUnit();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            MeteoInfoC.Projections.LongLat longLat1 = new MeteoInfoC.Projections.LongLat();
            MeteoInfoC.Projections.LinearUnit linearUnit1 = new MeteoInfoC.Projections.LinearUnit();
            MeteoInfoC.Legend.MapFrame mapFrame1 = new MeteoInfoC.Legend.MapFrame();
            MeteoInfoC.Legend.LabelBreak labelBreak3 = new MeteoInfoC.Legend.LabelBreak();
            MeteoInfoC.Legend.PointBreak pointBreak3 = new MeteoInfoC.Legend.PointBreak();
            MeteoInfoC.Legend.PolygonBreak polygonBreak3 = new MeteoInfoC.Legend.PolygonBreak();
            MeteoInfoC.Legend.PolyLineBreak polyLineBreak3 = new MeteoInfoC.Legend.PolyLineBreak();
            this.mapView1 = new MeteoInfoC.Map.MapView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_AddLayer = new System.Windows.Forms.ToolStripButton();
            this.TSB_ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.TSB_ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.TSB_Pan = new System.Windows.Forms.ToolStripButton();
            this.TSB_Identifer = new System.Windows.Forms.ToolStripButton();
            this.TSB_FullExent = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.layersLegend1 = new MeteoInfoC.Legend.LayersLegend();
            this.mapLayout1 = new MeteoInfoC.Layout.MapLayout();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TSMI_GrADSContour = new System.Windows.Forms.ToolStripButton();
            this.TSMI_GrADSGrid_Fill = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
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
            labelBreak2.AlignType = MeteoInfoC.Legend.AlignType.Center;
            labelBreak2.Angle = 0F;
            labelBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.LabelBreak;
            labelBreak2.Caption = "";
            labelBreak2.Color = System.Drawing.Color.Black;
            labelBreak2.DrawShape = true;
            labelBreak2.EndValue = 0;
            labelBreak2.Font = new System.Drawing.Font("Arial", 10F);
            labelBreak2.IsNoData = false;
            labelBreak2.StartValue = 0;
            labelBreak2.Text = "Text";
            labelBreak2.YShift = 0F;
            this.mapView1.DefLabelBreak = labelBreak2;
            pointBreak2.Angle = 0F;
            pointBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PointBreak;
            pointBreak2.Caption = "";
            pointBreak2.CharIndex = 0;
            pointBreak2.Color = System.Drawing.Color.Red;
            pointBreak2.DrawFill = true;
            pointBreak2.DrawOutline = true;
            pointBreak2.DrawShape = true;
            pointBreak2.EndValue = 0;
            pointBreak2.FontName = "Arial";
            pointBreak2.ImagePath = null;
            pointBreak2.IsNoData = false;
            pointBreak2.MarkerType = MeteoInfoC.Drawing.MarkerType.Simple;
            pointBreak2.OutlineColor = System.Drawing.Color.Black;
            pointBreak2.Size = 10F;
            pointBreak2.StartValue = 0;
            pointBreak2.Style = MeteoInfoC.Drawing.PointStyle.Circle;
            this.mapView1.DefPointBreak = pointBreak2;
            polygonBreak2.BackColor = System.Drawing.Color.Transparent;
            polygonBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PolygonBreak;
            polygonBreak2.Caption = "";
            polygonBreak2.Color = System.Drawing.Color.LightYellow;
            polygonBreak2.DrawFill = true;
            polygonBreak2.DrawOutline = true;
            polygonBreak2.DrawShape = true;
            polygonBreak2.EndValue = 0;
            polygonBreak2.IsMaskout = false;
            polygonBreak2.IsNoData = false;
            polygonBreak2.OutlineColor = System.Drawing.Color.Black;
            polygonBreak2.OutlineSize = 1F;
            polygonBreak2.StartValue = 0;
            polygonBreak2.Style = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            polygonBreak2.TransparencyPercent = 50;
            polygonBreak2.UsingHatchStyle = false;
            this.mapView1.DefPolygonBreak = polygonBreak2;
            polyLineBreak2.BreakType = MeteoInfoC.Legend.BreakTypes.PolylineBreak;
            polyLineBreak2.Caption = "";
            polyLineBreak2.Color = System.Drawing.Color.Red;
            polyLineBreak2.DrawPolyline = true;
            polyLineBreak2.DrawShape = true;
            polyLineBreak2.DrawSymbol = false;
            polyLineBreak2.EndValue = 0;
            polyLineBreak2.IsNoData = false;
            polyLineBreak2.Size = 2F;
            polyLineBreak2.StartValue = 0;
            polyLineBreak2.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            polyLineBreak2.SymbolColor = System.Drawing.Color.Red;
            polyLineBreak2.SymbolInterval = 1;
            polyLineBreak2.SymbolSize = 8F;
            polyLineBreak2.SymbolStyle = MeteoInfoC.Drawing.PointStyle.UpTriangle;
            this.mapView1.DefPolylineBreak = polyLineBreak2;
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
            datum1.Name = "D_WGS_1984";
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
            geographicInfo1.Name = "GCS_WGS_1984";
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
            this.mapView1.Size = new System.Drawing.Size(587, 342);
            this.mapView1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.mapView1.TabIndex = 0;
            this.mapView1.XGridStrs = ((System.Collections.Generic.List<string>)(resources.GetObject("mapView1.XGridStrs")));
            this.mapView1.XYScaleFactor = 1.2D;
            this.mapView1.YGridStrs = ((System.Collections.Generic.List<string>)(resources.GetObject("mapView1.YGridStrs")));
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(825, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_AddLayer,
            this.TSB_ZoomIn,
            this.TSB_ZoomOut,
            this.TSB_Pan,
            this.TSB_Identifer,
            this.TSB_FullExent,
            this.TSMI_GrADSContour,
            this.TSMI_GrADSGrid_Fill,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(825, 25);
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
            this.TSB_AddLayer.Text = "toolStripButton1";
            this.TSB_AddLayer.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // TSB_ZoomIn
            // 
            this.TSB_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("TSB_ZoomIn.Image")));
            this.TSB_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ZoomIn.Name = "TSB_ZoomIn";
            this.TSB_ZoomIn.Size = new System.Drawing.Size(23, 22);
            this.TSB_ZoomIn.Text = "toolStripButton1";
            this.TSB_ZoomIn.Click += new System.EventHandler(this.TSB_ZoomIn_Click);
            // 
            // TSB_ZoomOut
            // 
            this.TSB_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("TSB_ZoomOut.Image")));
            this.TSB_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ZoomOut.Name = "TSB_ZoomOut";
            this.TSB_ZoomOut.Size = new System.Drawing.Size(23, 22);
            this.TSB_ZoomOut.Text = "toolStripButton2";
            this.TSB_ZoomOut.Click += new System.EventHandler(this.TSB_ZoomOut_Click);
            // 
            // TSB_Pan
            // 
            this.TSB_Pan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Pan.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Pan.Image")));
            this.TSB_Pan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Pan.Name = "TSB_Pan";
            this.TSB_Pan.Size = new System.Drawing.Size(23, 22);
            this.TSB_Pan.Text = "toolStripButton3";
            this.TSB_Pan.Click += new System.EventHandler(this.TSB_Pan_Click);
            // 
            // TSB_Identifer
            // 
            this.TSB_Identifer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Identifer.Image = ((System.Drawing.Image)(resources.GetObject("TSB_Identifer.Image")));
            this.TSB_Identifer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Identifer.Name = "TSB_Identifer";
            this.TSB_Identifer.Size = new System.Drawing.Size(23, 22);
            this.TSB_Identifer.Text = "toolStripButton4";
            this.TSB_Identifer.Click += new System.EventHandler(this.TSB_Identifer_Click);
            // 
            // TSB_FullExent
            // 
            this.TSB_FullExent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_FullExent.Image = ((System.Drawing.Image)(resources.GetObject("TSB_FullExent.Image")));
            this.TSB_FullExent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_FullExent.Name = "TSB_FullExent";
            this.TSB_FullExent.Size = new System.Drawing.Size(23, 22);
            this.TSB_FullExent.Text = "toolStripButton5";
            this.TSB_FullExent.Click += new System.EventHandler(this.TSB_FullExent_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 423);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(825, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.layersLegend1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(825, 374);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 1;
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
            this.layersLegend1.Size = new System.Drawing.Size(220, 374);
            this.layersLegend1.TabIndex = 6;
            // 
            // mapLayout1
            // 
            this.mapLayout1.AutoResize = false;
            this.mapLayout1.BackColor = System.Drawing.Color.DarkGray;
            labelBreak3.AlignType = MeteoInfoC.Legend.AlignType.Center;
            labelBreak3.Angle = 0F;
            labelBreak3.BreakType = MeteoInfoC.Legend.BreakTypes.LabelBreak;
            labelBreak3.Caption = "";
            labelBreak3.Color = System.Drawing.Color.Black;
            labelBreak3.DrawShape = true;
            labelBreak3.EndValue = 0;
            labelBreak3.Font = new System.Drawing.Font("Arial", 10F);
            labelBreak3.IsNoData = false;
            labelBreak3.StartValue = 0;
            labelBreak3.Text = "Text";
            labelBreak3.YShift = 0F;
            this.mapLayout1.DefLabelBreak = labelBreak3;
            pointBreak3.Angle = 0F;
            pointBreak3.BreakType = MeteoInfoC.Legend.BreakTypes.PointBreak;
            pointBreak3.Caption = "";
            pointBreak3.CharIndex = 0;
            pointBreak3.Color = System.Drawing.Color.Red;
            pointBreak3.DrawFill = true;
            pointBreak3.DrawOutline = true;
            pointBreak3.DrawShape = true;
            pointBreak3.EndValue = 0;
            pointBreak3.FontName = "Arial";
            pointBreak3.ImagePath = null;
            pointBreak3.IsNoData = false;
            pointBreak3.MarkerType = MeteoInfoC.Drawing.MarkerType.Simple;
            pointBreak3.OutlineColor = System.Drawing.Color.Black;
            pointBreak3.Size = 10F;
            pointBreak3.StartValue = 0;
            pointBreak3.Style = MeteoInfoC.Drawing.PointStyle.Circle;
            this.mapLayout1.DefPointBreak = pointBreak3;
            polygonBreak3.BackColor = System.Drawing.Color.Transparent;
            polygonBreak3.BreakType = MeteoInfoC.Legend.BreakTypes.PolygonBreak;
            polygonBreak3.Caption = "";
            polygonBreak3.Color = System.Drawing.Color.LightYellow;
            polygonBreak3.DrawFill = true;
            polygonBreak3.DrawOutline = true;
            polygonBreak3.DrawShape = true;
            polygonBreak3.EndValue = 0;
            polygonBreak3.IsMaskout = false;
            polygonBreak3.IsNoData = false;
            polygonBreak3.OutlineColor = System.Drawing.Color.Black;
            polygonBreak3.OutlineSize = 1F;
            polygonBreak3.StartValue = 0;
            polygonBreak3.Style = System.Drawing.Drawing2D.HatchStyle.Horizontal;
            polygonBreak3.TransparencyPercent = 50;
            polygonBreak3.UsingHatchStyle = false;
            this.mapLayout1.DefPolygonBreak = polygonBreak3;
            polyLineBreak3.BreakType = MeteoInfoC.Legend.BreakTypes.PolylineBreak;
            polyLineBreak3.Caption = "";
            polyLineBreak3.Color = System.Drawing.Color.Red;
            polyLineBreak3.DrawPolyline = true;
            polyLineBreak3.DrawShape = true;
            polyLineBreak3.DrawSymbol = false;
            polyLineBreak3.EndValue = 0;
            polyLineBreak3.IsNoData = false;
            polyLineBreak3.Size = 2F;
            polyLineBreak3.StartValue = 0;
            polyLineBreak3.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            polyLineBreak3.SymbolColor = System.Drawing.Color.Red;
            polyLineBreak3.SymbolInterval = 1;
            polyLineBreak3.SymbolSize = 8F;
            polyLineBreak3.SymbolStyle = MeteoInfoC.Drawing.PointStyle.UpTriangle;
            this.mapLayout1.DefPolylineBreak = polyLineBreak3;
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
            this.mapLayout1.Size = new System.Drawing.Size(587, 342);
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
            this.tabControl1.Size = new System.Drawing.Size(601, 374);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mapView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(593, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Map";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mapLayout1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(593, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Layout";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TSMI_GrADSContour
            // 
            this.TSMI_GrADSContour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSMI_GrADSContour.Image = ((System.Drawing.Image)(resources.GetObject("TSMI_GrADSContour.Image")));
            this.TSMI_GrADSContour.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSMI_GrADSContour.Name = "TSMI_GrADSContour";
            this.TSMI_GrADSContour.Size = new System.Drawing.Size(23, 22);
            this.TSMI_GrADSContour.Text = "toolStripButton1";
            this.TSMI_GrADSContour.Click += new System.EventHandler(this.TSMI_GrADSContour_Click);
            // 
            // TSMI_GrADSGrid_Fill
            // 
            this.TSMI_GrADSGrid_Fill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSMI_GrADSGrid_Fill.Image = ((System.Drawing.Image)(resources.GetObject("TSMI_GrADSGrid_Fill.Image")));
            this.TSMI_GrADSGrid_Fill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSMI_GrADSGrid_Fill.Name = "TSMI_GrADSGrid_Fill";
            this.TSMI_GrADSGrid_Fill.Size = new System.Drawing.Size(23, 22);
            this.TSMI_GrADSGrid_Fill.Text = "toolStripButton1";
            this.TSMI_GrADSGrid_Fill.Click += new System.EventHandler(this.TSMI_GrADSGrid_Fill_Click_1);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 445);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
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
        private System.Windows.Forms.ToolStripButton TSB_AddLayer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MeteoInfoC.Legend.LayersLegend layersLegend1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MeteoInfoC.Layout.MapLayout mapLayout1;
        private MeteoInfoC.Map.MapView mapView1;
        private System.Windows.Forms.ToolStripButton TSB_ZoomIn;
        private System.Windows.Forms.ToolStripButton TSB_ZoomOut;
        private System.Windows.Forms.ToolStripButton TSB_Pan;
        private System.Windows.Forms.ToolStripButton TSB_Identifer;
        private System.Windows.Forms.ToolStripButton TSB_FullExent;
        private System.Windows.Forms.ToolStripButton TSMI_GrADSContour;
        private System.Windows.Forms.ToolStripButton TSMI_GrADSGrid_Fill;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

