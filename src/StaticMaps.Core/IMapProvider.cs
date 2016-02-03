using System;

namespace StaticMaps.Core
{
    /// <summary>
    /// Base interface for a map provider
    /// </summary>
    public interface IMapProvider
    {
        /// <summary>
        /// Gets a Uri for the given map details
        /// </summary>
        /// <param name="mapDetails"></param>
        /// <returns>Uri of static map</returns>
        Uri GetStaticMap(MapDetails mapDetails);
    }
}
