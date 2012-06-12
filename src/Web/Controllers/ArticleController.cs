using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Domain;
using Newtonsoft.Json;
using Web.Helpers;

namespace Web.Controllers {
    public class ArticleController : Controller {
        [Timer]
        public ActionResult Index(string id, string redirectFrom) {
            var articleJson = Couch.Uri.Get(Page.GenerateIdHash(id));
            var article = JsonConvert.DeserializeObject<Page>(articleJson);
            if (article.Redirect != null)
                return RedirectToAction("Index", new {id = article.Redirect, redirectFrom = id});
            return View(article);
        }

    }
}
