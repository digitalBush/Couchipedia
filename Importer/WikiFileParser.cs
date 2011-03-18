using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace Importer {
    public class WikiFileParser {
        string fileName;

        public WikiFileParser(string fileName) {
            this.fileName = fileName;
        }

        public IEnumerable<XElement> GetPages() {
            var file = new StreamReader(fileName);
            var reader = XmlReader.Create(file);
            reader.MoveToContent();

            while (reader.Read()) {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "page") {
                    XElement x = XNode.ReadFrom(reader) as XElement;
                    if (x != null)
                        yield return x;
                }
            }
        }
    }
}
