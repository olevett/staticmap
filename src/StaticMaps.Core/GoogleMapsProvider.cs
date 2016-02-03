using StaticMaps.Helpers;
using System;
using System.Collections.Generic;

namespace StaticMaps.Core
{
    /// <summary>
    /// Google Maps provider, using the public facing static maps API
    /// </summary>
    public class GoogleMapsProvider : IMapProvider
    {
        private const string GoogleMapsEndPoint = "http://maps.googleapis.com/maps/api/staticmap";

        /// <summary>
        /// Generates a map Uri for the given map details
        /// </summary>
        /// <param name="mapDetails"></param>
        /// <returns>Uri of a map image</returns>
        public Uri GetStaticMap(MapDetails mapDetails)
        {
            if (mapDetails == null) throw new ArgumentNullException("mapDetails");

            var queryStringParameters = MapToParameters(mapDetails).ToQueryString();
            var completeUrl = string.Format("{0}{1}", GoogleMapsEndPoint, queryStringParameters);

            return new Uri(completeUrl, UriKind.Absolute);
        }

        private static IDictionary<string, string> MapToParameters(MapDetails mapDetails)
        {
            var dictionary = new Dictionary<string, string>();

            dictionary.Add("size", string.Format("{0}x{1}", mapDetails.Width, mapDetails.Height));

            if (mapDetails.Center != null) dictionary.Add("center", string.Format("{0},{1}", mapDetails.Center.Latitude, mapDetails.Center.Longitude));

            dictionary.Add("zoom", ConvertZoomToRange(mapDetails.Zoom).ToString());

            return dictionary;
        }

        private static int ConvertZoomToRange(double? zoom)
        {
            if (zoom == null) return 15;
            return (int)(zoom.Value * 21);
        }
    }
}