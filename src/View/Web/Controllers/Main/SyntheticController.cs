using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.Main
{
    [Export]
    public class SyntheticController : WebController
    {
        // GET: Synthetic
        public ActionResult Index()
        {
            

            return View("2121212");
        }
    }
}