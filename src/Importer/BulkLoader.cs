using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;
using Couchipedia.Domain;

namespace Importer {
    public class BulkLoader {
        Uri uri;
        public BulkLoader(string database) {
            uri = new Uri("http://"+database+"/_bulk_docs"); 
        }

        public int Count { get; set; }

        public void Load(string filename) {
            Action<IEnumerable<Page>> saveAction = Save;
           
            var file = new WikiFileParser(filename);

            var workers = file
                .GetPages()
                .Chunk(800)
                .Select(x => saveAction.BeginInvoke(x, null, null))
                .Aggregate(new Queue<IAsyncResult>(),
                           (queue, item) => {
                               queue.Enqueue(item);
                               if (queue.Count > 4)
                                   queue.Dequeue().AsyncWaitHandle.WaitOne();
                               return queue;
                           });

            //Wait for the last bit to finish
            workers.All(x => x.AsyncWaitHandle.WaitOne());
        }

        void Save<T>(IEnumerable<T> elms) {
            var json = new { all_or_nothing=true, docs = elms }.ToJson();
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

        
    }
}
