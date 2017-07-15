using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
using GDEIC.AppFx.GIS.Layers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace HeatMap
{
    public class HeatPointSource
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double I { get; set; }
    }
    public class HeatMapLayer : DynamicLayer {

        // Background thread used for generating the heat map

        private BackgroundWorker _renderThread = null ;
        private ObservableCollection < HeatPointSource > _points = null ;
        // Cached value of the calculated full extent
        private Envelope _fullExtent = null ;
        private DynamicLayer . ImageParameters _onExport = null ;
        private DynamicLayer . OnImageComplete _onComplete = null ;
        private DispatcherTimer _timer = null ;

        private struct HeatPoint {
            public int X;
            public int Y;
            public double I;
        }

        private struct ThreadSafeGradientStop {
            public double Offset;
            public Color Color;
        }

        public HeatMapLayer() {
            GradientStopCollection stops = new GradientStopCollection ();
            stops.Add( new GradientStop () { Color = Colors .Transparent, Offset = 0 });
            stops.Add( new GradientStop () { Color = Colors .Blue, Offset = .5 });
            stops.Add( new GradientStop () { Color = Colors .Red, Offset = .75 });
            stops.Add( new GradientStop () { Color = Colors .Yellow, Offset = .8 });
            stops.Add( new GradientStop () { Color = Colors .White, Offset = 1 });
            this .Gradient = stops;
            this .HeatMapPoints = new ObservableCollection < HeatPointSource >();
            // Create a separate thread for rendering the heatmap layer.
            this ._renderThread = new BackgroundWorker () {
                WorkerReportsProgress = true ,
                WorkerSupportsCancellation = true
            };
            this ._renderThread.ProgressChanged +=
                new ProgressChangedEventHandler ( this .RenderThread_ProgressChanged);
            this ._renderThread.RunWorkerCompleted +=
             new RunWorkerCompletedEventHandler ( this .RenderThread_RunWorkerCompleted);
            this ._renderThread.DoWork +=
                new DoWorkEventHandler ( this .renderThread_DoWork);
        }

        public override Envelope FullExtent {
            get {
                if ( this ._fullExtent == null &&
                    this ._points != null &&
                    this ._points.Count > 0) {
                    this ._fullExtent = new Envelope ();
                    foreach ( HeatPointSource p in this ._points) {
                        this ._fullExtent = this ._fullExtent.Union(
                            new Envelope (p.X, p.Y, p.X, p.Y)
                        );
                    }
                }
                return this ._fullExtent;
            }

            protected set { throw new NotSupportedException (); }
        }

        public static readonly DependencyProperty IntensityProperty =
            DependencyProperty .Register(
            "Intensity" ,
            typeof ( double ),
            typeof ( HeatMapLayer ), 
            new PropertyMetadata (10d, HeatMapLayer .OnIntensityPropertyChanged)
        );

        public double Intensity {
            get { return ( double ) this .GetValue( HeatMapLayer .IntensityProperty); }
            set { this .SetValue( HeatMapLayer .IntensityProperty, value ); }
        }

        private static void OnIntensityPropertyChanged(
            DependencyObject d, DependencyPropertyChangedEventArgs e) {
            HeatMapLayer dp = d as HeatMapLayer ;
            dp.StartTimer();
        }

        private void StartTimer() {
            if ( this .IsInitialized) {
                if ( this ._timer == null ) {
                    this ._timer = new DispatcherTimer () {
                        Interval = TimeSpan .FromMilliseconds(50)
                    };

                    this ._timer.Tick += (s, e2) => {
                        this ._timer.Stop();
                        this .OnLayerChanged();
                    };
                }

                this ._timer.Stop();
                this ._timer.Start();
            }
        }

        public ObservableCollection < HeatPointSource > HeatMapPoints {
            get { return this ._points; }
            set {
                if ( this._points != null ) {
                    this._points.CollectionChanged-=this.heatMapPoints_CollectionChanged;
                }
                this ._points = value ;
                if ( this ._points != null ) {
                    this ._points.CollectionChanged +=
                        this .heatMapPoints_CollectionChanged;
                }
                this ._fullExtent = null ;
                this .OnLayerChanged();
            }
        }

        private void heatMapPoints_CollectionChanged( object sender,
                                            NotifyCollectionChangedEventArgs e) {

            this ._fullExtent = null ;
            this .OnLayerChanged();
        }

        public static readonly DependencyProperty GradientProperty =
            DependencyProperty .Register(
            "Gradient" ,
            typeof ( GradientStopCollection ),
            typeof ( HeatMapLayer ),
            new PropertyMetadata ( null , HeatMapLayer .OnGradientPropertyChanged)
        );

        public GradientStopCollection Gradient {
            get { return ( GradientStopCollection ) this .GetValue(GradientProperty); }
            set { this .SetValue(GradientProperty, value ); }
        }

        private static void OnGradientPropertyChanged( DependencyObject d,
            DependencyPropertyChangedEventArgs e) {
            HeatMapLayer dp = d as HeatMapLayer ;
            dp.OnLayerChanged();
        }

        protected override void GetSource( DynamicLayer . ImageParameters properties,
            DynamicLayer . OnImageComplete onComplete) {
            if (! this .IsInitialized || this .HeatMapPoints == null ||
                 this .HeatMapPoints.Count == 0) {
                onComplete( null , null );
                return ;
            }

            Envelope extent = properties.Extent;
            int width = properties.Width;
            int height = properties.Height;
            if ( this ._renderThread != null && _renderThread.IsBusy) {
                this ._renderThread.CancelAsync();
                // Render already running. Cancel current process, and queue up new
                this ._onExport = new ImageParameters (extent, width, height);
                this ._onComplete = onComplete;
                return ;
            }
            // Accessing a GradientStop collection from a non-UI thread is not
            // allowed, so we used a private class gradient collection
            List < ThreadSafeGradientStop > stops =
                new List < ThreadSafeGradientStop >(Gradient.Count);
            foreach ( GradientStop stop in Gradient) {
                stops.Add( new ThreadSafeGradientStop () {
                    Color = stop.Color,
                    Offset = stop.Offset }
                );

            }

            // Gradients must be sorted by offset

            stops.Sort(

                ( ThreadSafeGradientStop g1, ThreadSafeGradientStop g2) => {

                    return g1.Offset.CompareTo(g2.Offset);

                }

            );

 

            List < HeatPoint > points = new List < HeatPoint >();

            double res = extent.Width / width;

             // Adjust extent to include points slightly outside the view so pan

            // won't affect the outcome

            Envelope extent2 = new Envelope (

                extent.XMin - Intensity * res, extent.YMin - Intensity * res,

                extent.XMax + Intensity * res, extent.YMax + Intensity * res

            );

 

            // get points within the extent and transform them to pixel space

            foreach ( HeatPointSource p in this .HeatMapPoints) {

                if ( this .Map != null && this .Map.WrapAroundIsActive) {

                    // Note : this should work even if WrapAround is not active

                    // but it's probably less performant

                    if (p.Y >= extent2.YMin && p.Y <= extent2.YMax) {

                        Point screenPoint = this .Map.MapToScreen(

                            new MapPoint (p.X, p.Y), true );

                        if (! double .IsNaN(width) &&

                            this .Map.FlowDirection == FlowDirection .RightToLeft) {

                            screenPoint.X = width - screenPoint.X;

                        }

                        if (screenPoint.X >= - this .Intensity &&

                            screenPoint.X <= width + this .Intensity) {

                            points.Add(

                                new HeatPoint () {

                                    X = ( int ) Math .Round(screenPoint.X),

                                    Y = ( int ) Math .Round(screenPoint.Y),

                                    I = p.I

                                }

                            );

                        }

                    }

                }

                else {

                    if (p.X >= extent2.XMin && p.Y >= extent2.YMin &&

                        p.X <= extent2.XMax && p.Y <= extent2.YMax) {

                        points.Add(

                            new HeatPoint () {

                                X = ( int ) Math .Round((p.X - extent.XMin) / res),

                                Y = ( int ) Math .Round((extent.YMax - p.Y) / res),

                                I = p.I

                            }

                         );

                    }

                }

            }

            // Start the render thread

            //renderThread.RunWorkerAsync(
            _renderThread.RunWorkerAsync(

                new object [] {

                extent,

                width,

                height,

                ( int ) Math .Round( this .Intensity),

                stops,

                points,

                onComplete

            }

            );

        }

        protected override void Cancel() {

            this ._onExport = null ;

            this ._onComplete = null ;

            if ( this ._renderThread != null && this ._renderThread.IsBusy) {

                this ._renderThread.CancelAsync();

            }

            base .Cancel();

        }

        private void renderThread_DoWork( object sender, DoWorkEventArgs e) {

            BackgroundWorker worker = ( BackgroundWorker )sender;

            object [] args = ( object [])e.Argument;

            Envelope extent = ( Envelope )args[0];

            int width = ( int )args[1];

            int height = ( int )args[2];

            int intensity = ( int )args[3];

            List < ThreadSafeGradientStop > stops =

                ( List < ThreadSafeGradientStop >)args[4];

            List < HeatPoint > points = ( List < HeatPoint >)args[5];

            OnImageComplete onComplete = ( OnImageComplete )args[6];

 

            intensity = intensity * 2 + 1;

            ushort [] matrix = HeatMapLayer .CreateDistanceMatrix(intensity);

            double [] output = new double [width * height];

            foreach ( HeatPoint p in points) {

                HeatMapLayer .AddPoint(matrix, intensity, p.X, p.Y, p.I, output,

                    width);

                if (worker.CancellationPending) {

                    e.Cancel = true ;

                    e.Result = null ;

                    return ;

                }

            }

            matrix = null ;

            double max = 0;

            // Find max - used for scaling the intensity

            foreach ( int val in output) {

                if (max < val) { max = val; }

            }

 

            // If we only have single points in the view, don't show them with

            // too much intensity.

            if (max < 2) { max = 2; }

 

            PngEncoder ei = new PngEncoder(width, height);

 

            // Height (y)

            for ( int idx = 0; idx < height; idx++) {

                int rowstart = ei.GetRowStart(idx);

                // Width (x)

                for ( int jdx = 0; jdx < width; jdx++) {

                    Color c = HeatMapLayer .InterpolateColor(

                        output[idx * width + jdx] / max, stops);

                    ei.SetPixelAtRowStart(jdx, rowstart, c.R, c.G, c.B, c.A);

                }

                if (worker.CancellationPending) {

                    e.Cancel = true ;

                    e.Result = null ;

                    output = null ;

                     ei = null ;

                    return ;

                }

                // Raise the progress event for each line rendered

                worker.ReportProgress((idx + 1) * 100 / height);

            }

            stops.Clear();

            output = null ;

 

            // Get stream and set image source

            e.Result = new object [] { ei, width, height, extent, onComplete };

        }

        private void RenderThread_RunWorkerCompleted( object sender,

            RunWorkerCompletedEventArgs e) {

            if (e.Cancelled) {

                // Cancelled because new image was requested. Create new image

                if ( this ._onExport != null ) {

                    this .GetSource(_onExport, _onComplete);

                    this ._onExport = null ;

                    this ._onComplete = null ;

                }

                return ;

            }

            this ._onExport = null ;

            this ._onComplete = null ;

            if (e.Result == null ) { return ; }

            object [] result = ( object [])e.Result;

 

            int width = ( int )result[1];

            int height = ( int )result[2];

            Envelope extent = ( Envelope )result[3];

            OnImageComplete onComplete = ( OnImageComplete )result[4];

 

            BitmapImage image = new BitmapImage ();

            PngEncoder ei = ( PngEncoder )result[0];

            image.SetSource(ei.GetImageStream());

 

            onComplete(image, new ImageResult (extent));

        }

        private void RenderThread_ProgressChanged( object sender,

            ProgressChangedEventArgs e) {

            // Raise the layer progress event

            this .OnProgress(e.ProgressPercentage);

        }

        private static Color InterpolateColor( double value,

            List < ThreadSafeGradientStop > stops) {

            if (value < 1d / 255d) {

                return Colors .Transparent;

            }

            if (stops == null || stops.Count == 0) {

                return Colors .Black;

            }

            if (stops.Count == 1) {

                return stops[0].Color;

            }

 

            // clip to bottom

            if (stops[0].Offset >= value) {

                return stops[0].Color;

            }

            else if (stops[stops.Count - 1].Offset <= value) {

                // clip to top

                return stops[stops.Count - 1].Color;

            }

            int i = 0;

            for (i = 1; i < stops.Count; i++) {

                if (stops[i].Offset > value) {

                    Color start = stops[i - 1].Color;

                    Color end = stops[i].Color;

                    double frac = (value - stops[i - 1].Offset) /

                                    (stops[i].Offset - stops[i - 1].Offset);

                    byte R = ( byte ) Math .Round((start.R * (1 - frac) + end.R * frac));

                    byte G = ( byte ) Math .Round((start.G * (1 - frac) + end.G * frac));

                    byte B = ( byte ) Math .Round((start.B * (1 - frac) + end.B * frac));

                    byte A = ( byte ) Math .Round((start.A * (1 - frac) + end.A * frac));

                    return Color .FromArgb(A, R, G, B);

                }

            }

            return stops[stops.Count - 1].Color; //should never happen

        }

        private static void AddPoint( ushort [] distanceMatrix, int size, int x, int y,

            double z, double [] intensityMap, int width) {

            for ( int i = 0; i < size * 2 - 1; i++) {

                int start = (y - size + 1 + i) * width + x - size;

                for ( int j = 0; j < size * 2 - 1; j++) {

                    if (j + x - size < 0 || j + x - size >= width) { continue ; }

                    int idx = start + j;

                    if (idx < 0 || idx >= intensityMap.Length) { continue ; }

                    ushort dm = distanceMatrix[i * (size * 2 - 1) + j];

                     intensityMap[idx] += z * dm;

                }

            }

        }

        private static ushort [] CreateDistanceMatrix( int size) {

            int width = size * 2 - 1;

            ushort [] matrix = new ushort [( int ) Math .Pow(width, 2)];

            for ( int i = 0; i < width; i++) {

                for ( int j = 0; j < width; j++) {

                    matrix[i * width + j] = ( ushort ) Math .Max(

                        (size - ( Math .Sqrt( Math .Pow(i - size + 1, 2) +

                            Math .Pow(j - size + 1, 2)))),

                        0

                    );

                }

            }

            return matrix;

        }

    }
}
