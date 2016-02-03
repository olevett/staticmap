using StaticMaps.Helpers;
using System.Collections.Generic;
using Xunit;

namespace StaticMaps.Core.Test.Helpers
{
    public class DictionaryExtensionTests
    {
        [Theory, MemberData("QueryStringData")]
        public void CanMapDictionaryToQueryString(IDictionary<string, string> input, string expected)
        {
            var actual = input.ToQueryString();

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> QueryStringData
        {
            get
            {
                return new[]
                {
                    new object[] { new Dictionary<string, string>() { { "x", "y" } } , "?x=y"},
                    new object[] { new Dictionary<string, string>() { { "x", "y" }, { "a", "b" } } , "?x=y&a=b"},
                };
            }
        }
    }
}
