using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Couchipedia.Domain {
    public class Page{
        public string _id { get; set; }
        public string Title { get; set; }
        public Revision Revision {get;set;}
    }   
}
