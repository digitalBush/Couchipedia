using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace Web.Helpers
{
    public static class ViewHelpers
    {
        static Dictionary<Regex, MatchEvaluator> matchers;
        static ViewHelpers()
        {
            var regexMap=new Dictionary<string,MatchEvaluator>(){
                {@"(={2,})(.*?)(={2,})",m =>String.Format("<h{0}>{1}</h{0}>", m.Groups[1].Length, m.Groups[2])}, //Headings
                {@"\[\[(File|Image):.*?]]",m=>""}, //Images (ignore these)
                {@"\[\[(.*?)(\|(.*?))?]]",m=>String.Format("<a href='{0}'>{1}</a>", m.Groups[1], String.IsNullOrEmpty(m.Groups[3].Value)?m.Groups[1].Value:m.Groups[3].Value)} //Links
            };
            matchers = regexMap.ToDictionary(x => new Regex(x.Key, RegexOptions.Compiled), x => x.Value);
        }

        public static MvcHtmlString RenderMarkdown(this HtmlHelper helper, string input)
        {
            var output = matchers.Aggregate(input, (value, pair) => pair.Key.Replace(value, pair.Value));
            return MvcHtmlString.Create(output);
        } 
    }
}