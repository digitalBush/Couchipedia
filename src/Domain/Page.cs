using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Couchipedia.Domain {
    public class Page{
        public string _id { get; set; }
        public string Title { get; set; }
        public string Redirect { get; set; }
        public Revision Revision {get;set;}
    }   
}
