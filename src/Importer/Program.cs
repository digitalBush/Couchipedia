using System;
using System.IO;

namespace Importer {
    class Program {
        static void Main(string[] args) {
            var db = "localhost:5984/couchipedia";
            if (args.Length == 0 || !File.Exists(args[0])) {
                Console.WriteLine("Please supply an argument pointing to a wikipedia xml export");
                Environment.Exit(1);
            }
            DateTime start=DateTime.Now;
            var watcher = new CouchDatabaseWatcher(db);
            watcher.OnUpdate = stats => Console.WriteLine("{0} - {1} documents", DateTime.Now - start, stats.DocumentCount);
            watcher.Start(1000 * 60);
            new BulkLoader(db).Load(args[0]);
        }
    }
}
