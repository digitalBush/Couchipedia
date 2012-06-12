using System;

namespace Importer.Models {
    public class Revision {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public Contributor Contributor { get; set; }
        public string Minor { get; set; }
        public string Comment { get; set; }
        public string Text { get; set; }
    }
}
