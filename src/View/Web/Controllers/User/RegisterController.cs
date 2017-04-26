using Application.IService;
using Application.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers.User
{
    public class RegisterController : Controller
    {
        [Import]
        protected IApplication Application { set; get; }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            ApplicationUsers data = new ApplicationUsers();
            Application.InSert(data);
            return Json("");
        }
    }
}