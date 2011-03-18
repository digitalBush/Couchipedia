using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Importer {
    class Program {
        static void Main(string[] args) {

            if (args.Length == 0 || !File.Exists(args[0])) {
                Console.WriteLine("Please supply an argument pointing to a wikipedia xml export");
                Environment.Exit(1);
            }

            new BulkLoader("localhost:5984/couchipedia").Load(args[0]);
        }
    }
}
