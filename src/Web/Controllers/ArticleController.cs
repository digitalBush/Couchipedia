using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using Couchipedia.Domain;
using Web.Helpers;

namespace Web.Controllers
{
    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        [Timer]
        public ActionResult Index(string id)
        {
            var client = new WebClient();
            var s = client.DownloadString(string.Format("http://127.0.0.1:5984/couchipedia/" + HttpUtility.UrlEncode(id)));

            return View(JsonConvert.DeserializeObject<Page>(s));
        }

    }
}
