using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Web.Helpers;

namespace Web.Controllers
{
    public class Page {
        static Regex _redirectRegex = new Regex(@"^#REDIRECT \[\[(.*?)]]", RegexOptions.Compiled);
        public string _id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        
        public string Redirect {
            get {
                var match = _redirectRegex.Match(Text);
                if (match.Success)
                    return match.Groups[1].Value;
                else
                    return null;
            }
        }
    }   

    public class ArticleController : Controller
    {

        public static string sha1(string value) {
            var bytes = Encoding.UTF8.GetBytes(value);
            using (var provider = new SHA1CryptoServiceProvider()) {
                var hash = provider.ComputeHash(bytes);

                return hash.Aggregate(
                    new StringBuilder(),
                    (s, b) => {
                        s.Append(b.ToString("x2"));
                        return s;
                    }).ToString();
            }
        }


        [Timer]
        public ActionResult Index(string id,string redirectFrom)
        {
            var articleJson = Couch.Uri.Get(HttpUtility.UrlEncode(sha1(id.ToLower())));
            var article = JsonConvert.DeserializeObject<Page>(articleJson);
            if (article.Redirect != null)
                return RedirectToAction("Index", new { id = article.Redirect,redirectFrom=id });
            return View(article);
        }

    }
}
