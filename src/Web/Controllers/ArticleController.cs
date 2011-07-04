using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Couchipedia.Domain;
using Web.Helpers;

namespace Web.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult Search(string text)
        {
            return RedirectToAction("View", new { id=text });
        }

        [Timer]
        public ActionResult View(string id,string redirectFrom)
        {
            var articleJson = Couch.Uri.Get(HttpUtility.UrlEncode(id.ToLower()));
            var article = JsonConvert.DeserializeObject<Page>(articleJson);
            if (article.Redirect != null)
                return RedirectToAction("View", new { id = article.Redirect,redirectFrom=id });
            return View(article);
        }

    }
}
