using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using Importer.Models;

namespace Importer {
    public class WikiFileParser {
        string fileName;

        public WikiFileParser(string fileName) {
            this.fileName = fileName;
        }

        public IEnumerable<Page> GetPages() {
            var file = new StreamReader(fileName);
            var reader = XmlReader.Create(file);
            reader.MoveToContent();

            while (reader.Read()) {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "page") {
                    XElement x = XNode.ReadFrom(reader) as XElement;
                    if (x != null)
                        yield return MakePage(x);
                }
            }
        }

        Page MakePage(XElement x) {
            var rev = x.Named("revision");
            var who = rev.Named("contributor");
            return new Page() {
                Title = x.Named("title").Value,
                _id = x.Named("title").Value,
                Revision = new Revision() {
                    Id = rev.Named("id").Value,
                    Timestamp = Convert.ToDateTime(rev.Named("timestamp").Value),
                    Contributor = new Contributor() {
                        Id = who.Named("id").Value,
                        Username = who.Named("username").Value,
                        Ip = who.Named("ip").Value
                    },
                    Minor = rev.Named("minor").Value,
                    Comment = rev.Named("comment").Value,
                    Text = rev.Named("text").Value,
                }
            };
        }
    }
}
