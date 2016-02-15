using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace StaticMaps
{
    [TemplatePart(Name = ImagePartName, Type = typeof(Image))]
    public class StaticMap : Control
    {
        private const string ImagePartName = "Image";
        private Image image;

        public StaticMap()
        {
            DefaultStyleKey = typeof(StaticMap);
            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateMap();
        }

        public IMapProvider MapProvider
        {
            get { return (IMapProvider)GetValue(MapProviderProperty); }
            set { SetValue(MapProviderProperty, value); }
        }

        public static readonly DependencyProperty MapProviderProperty =
            DependencyProperty.Register("MapProvider", typeof(IMapProvider), typeof(StaticMap), new PropertyMetadata(null, OnMapProviderPropertyChanged));

        private static void OnMapProviderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = (StaticMap)d;
            sender.UpdateMap();
        }

        public Coordinate Center
        {
            get { return (Coordinate)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Center", typeof(Coordinate), typeof(StaticMap), new PropertyMetadata(null, OnCenterPropertyChanged));

        private static void OnCenterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = (StaticMap)d;
            sender.UpdateMap();
        }

        public string EncodedPolyline
        {
            get { return (string)GetValue(EncodedPolylineProperty); }
            set { SetValue(EncodedPolylineProperty, value); }
        }

        public static readonly DependencyProperty EncodedPolylineProperty =
            DependencyProperty.Register("EncodedPolyline", typeof(string), typeof(StaticMap), new PropertyMetadata(null, OnEncodedPolylinePropertyChanged));

        private static void OnEncodedPolylinePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = (StaticMap)d;
            sender.UpdateMap();
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            image = GetTemplateChild(ImagePartName) as Image;

            UpdateMap();
        }

        private void UpdateMap()
        {
            if (MapProvider == null) return;
            if (image == null) return;

            var mapDetails = GetMapDetails();
            var mapSource = MapProvider.GetStaticMap(mapDetails);

            image.Source = new BitmapImage(mapSource);
        }

        private MapDetails GetMapDetails()
        {
            return new MapDetails
            {
                Height = Height,
                Width = Width,
                Center = Center,
                EncodedPolyline = EncodedPolyline,
            };
        }
    }
}
