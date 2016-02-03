using System;
using Xunit;

namespace StaticMaps.Core.Test
{
    public class GoogleMapsProviderTests
    {
        [Fact]
        public void GetMapSource_NullParameters_Throws()
        {
            var sut = new GoogleMapsProvider();
            Assert.Throws<ArgumentNullException>("mapDetails", () => sut.GetStaticMap(null));
        }

        [Fact]
        public void GetMapSource_EmptyParameters_ReturnsUrlWithZeroSize()
        {
            var sut = new GoogleMapsProvider();
            var mapDetails = new MapDetails();

            var actual = sut.GetStaticMap(mapDetails);

            Assert.Contains("size=0x0", actual.ToString());
        }

        [Fact]
        public void GetMapSource_NoCenter_ReturnsUrlWithoutCenter()
        {
            var sut = new GoogleMapsProvider();
            var mapDetails = new MapDetails { Center = null };

            var actual = sut.GetStaticMap(mapDetails);

            Assert.DoesNotContain("center", actual.ToString());
        }

        [Fact]
        public void GetMapSource_Center_ReturnsUrlWithCenter()
        {
            var sut = new GoogleMapsProvider();
            var mapDetails = new MapDetails { Center = new Coordinate { Latitude = 1, Longitude = 2 } };

            var actual = sut.GetStaticMap(mapDetails);

            Assert.Contains("center=1,2", actual.ToString());
        }
    }
}
