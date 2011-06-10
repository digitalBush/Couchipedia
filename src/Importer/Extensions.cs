using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Importer {
    public static class Extensions {

        public static XElement Named(this XElement elm, string name) {
            var newElm = elm.Element("{http://www.mediawiki.org/xml/export-0.4/}" + name);
            if (newElm == null)
                newElm = new XElement("dummy");
            return newElm;
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> pages, int count) {
            List<T> chunk = new List<T>();
            foreach (var page in pages) {
                chunk.Add(page);

                if (chunk.Count == count) {
                    yield return chunk.ToList();
                    chunk.Clear();
                }
            }
            yield return chunk.ToList();
        }

        public static string ToJson<T>(this T value) {                    
           return JsonConvert.SerializeObject(value);        
        }

        public static T FromJson<T>(this string value) {
            return JsonConvert.DeserializeObject<T>(value);
        }

    }
}
