using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using Importer.Models;

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
                               if (queue.Count > 8)
                                   queue.Dequeue().AsyncWaitHandle.WaitOne();
                               return queue;
                           });

            //Wait for the last bit to finish
            workers.All(x => x.AsyncWaitHandle.WaitOne());
        }

        public static string sha1(string value) {
            var bytes = Encoding.UTF8.GetBytes(value);
            using(var provider=new SHA1CryptoServiceProvider()) {
                var hash = provider.ComputeHash(bytes);
            
            return hash.Aggregate(
                new StringBuilder(),
                (s, b) => {
                    s.Append(b.ToString("x2"));
                    return s;
                }).ToString();
           }
        }

        void Save(IEnumerable<Page> elms) {
            var json = new {
                all_or_nothing = true,
                docs = elms.Select(x => new Domain.Page() {
                    _id = Domain.Page.GenerateIdHash(x.Title),
                    Title = x.Title,
                    Text = x.Revision.Text
                })
            }.ToJson();
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
