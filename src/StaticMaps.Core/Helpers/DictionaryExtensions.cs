using System.Collections.Generic;
using System.Linq;

namespace StaticMaps.Helpers
{
    public static class DictionaryExtensions
    {
        public static string ToQueryString(this IDictionary<string, string> dictionary)
        {
            return "?" + string.Join("&", dictionary.Select(x => string.Format("{0}={1}", x.Key, x.Value)));
        }
    }
}
