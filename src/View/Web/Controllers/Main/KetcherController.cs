using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers.Main
{
    public class KetcherController : Controller
    {
        // GET: Ketcher
        public ActionResult Index()
        {
            return View();
        }
    }
}