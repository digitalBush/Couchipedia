using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;
using Importer.Domain;

namespace Importer {
    public class BulkLoader {
        string uri;
        public BulkLoader(string uri) { this.uri = "http://"+uri+"/_bulk_docs"; }

        public int Count { get; set; }

        public void Load(string filename) {
            Action<IEnumerable<XElement>> saveAction = Save;
           
            var file = new WikiFileParser(filename);

            var workers = file
                .GetPages()
                .Chunk(1000)
                .Select(x => saveAction.BeginInvoke(x, null, null))
                .Aggregate(new Queue<IAsyncResult>(),
                           (queue, item) => {
                               queue.Enqueue(item);
                               if (queue.Count > 5)
                                   queue.Dequeue().AsyncWaitHandle.WaitOne();
                               return queue;
                           });

            //Wait for the last bit to finish
            workers.All(x => x.AsyncWaitHandle.WaitOne());
        }

        void Save(IEnumerable<XElement> elms) {
            var json = new { docs = elms.Select(x => MakePage(x)) }.ToJson();
            var request = WebRequest.Create(uri);
            request.Method = "POST";
            request.Timeout = 90000;

            var bytes = UTF8Encoding.UTF8.GetBytes(json);
            request.ContentType = "application/json; charset=utf-8";
            request.ContentLength = bytes.Length;

            using (var writer = request.GetRequestStream()) {
                writer.Write(bytes, 0, bytes.Length);
                request.GetResponse().Close();
            }
        }

        Page MakePage(XElement x) {
            var rev = x.Named("revision");
            var who = rev.Named("contributor");
            return new Page() {
                Title = x.Named("title").Value,
                Redirect = x.Named("redirect").Value,
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
