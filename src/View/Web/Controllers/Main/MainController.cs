using Core.IData.Log;
using Core.Model.Log;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;
using Web.LanguagesView;

namespace Web.Controllers.Main
{
    [Export]
    public class MainController : WebController
    {
        
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
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