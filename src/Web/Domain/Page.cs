using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Couchipedia.Domain {
    public class Page{
        static Regex _redirectRegex=new Regex(@"^#REDIRECT \[\[(.*?)]]",RegexOptions.Compiled);
        public string _id { get; set; }
        public string Title { get; set; }
        public string Redirect
        {
            get
            {
                var match = _redirectRegex.Match(Revision.Text);
                if (match.Success)
                    return match.Groups[1].Value;
                else
                    return null;
            }
        }
        public Revision Revision {get;set;}
    }   
}
