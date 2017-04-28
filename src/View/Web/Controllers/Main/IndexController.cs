using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;
using Web.LanguagesView;

namespace Web.Controllers.Main
{
    public class IndexController : BaseController
    {
        // GET: Index
        public ActionResult Index()
        {

           


            return View();
        }


        public ActionResult ChangeCulture(string ddlCulture)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(ddlCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ddlCulture);
            HttpCookie cookieLange = new HttpCookie("CurrentCulture", ddlCulture);
            Response.AppendCookie(cookieLange); 
            return Redirect(Request.UrlReferrer.AbsolutePath);
        }
        //[HttpGet]
        //[Route("{email}/{password}/")]
        //FormCollection 
        [HttpPost]
        public ActionResult Add(UserViewModel user)
        {

            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}