﻿using Flurl;
using System;

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

            var url = new Url(GoogleMapsEndPoint);

            url.SetQueryParam("size", string.Format("{0}x{1}", mapDetails.Width, mapDetails.Height));

            if (string.IsNullOrEmpty(mapDetails.EncodedPolyline))
            {
                if (mapDetails.Center != null) url.SetQueryParam("center", string.Format("{0},{1}", mapDetails.Center.Latitude, mapDetails.Center.Longitude));
                url.SetQueryParam("zoom", ConvertZoomToRange(mapDetails.Zoom).ToString());
            }
            else
            {
                url.SetQueryParam("path", "enc:" + mapDetails.EncodedPolyline);
            }

            return new Uri(url, UriKind.Absolute);
        }

        private static int ConvertZoomToRange(double? zoom)
        {
            if (zoom == null) return 15;
            return (int)(zoom.Value * 21);
        }
    }
}