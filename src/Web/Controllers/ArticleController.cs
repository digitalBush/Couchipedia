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
            var article = Couch.Uri.Get<Page>(Page.GenerateIdHash(id));
            if (article.Redirect != null)
                return RedirectToAction("Index", new {id = article.Redirect, redirectFrom = id});
            return View(article);
        }

    }
}
