namespace StaticMaps
{
    /// <summary>
    /// Details of a map, used to generate a Uri for the static map
    /// </summary>
    public class MapDetails
    {
        /// <summary>
        /// Width in pixels of the desired image
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Height in pixels of the desired image
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Center point of the map
        /// </summary>
        public Coordinate Center { get; set; }

        /// <summary>
        /// Zoom level between 0 and 1 of the map
        /// </summary>
        public double? Zoom { get; set; }

        /// <summary>
        /// An encoded polyline for the route (see https://developers.google.com/maps/documentation/utilities/polylinealgorithm)
        /// </summary>
        public string EncodedPolyline { get; set; }
    }
}
