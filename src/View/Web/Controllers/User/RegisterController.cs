using Application.IService;
using Application.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.User
{
    [Export]
    public class RegisterController :BaseController
    {
        [Import]
        protected IApplicationService ApplicationService { set; get; }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            ApplicationUsers data = new ApplicationUsers();
            data.Phone = "34242";
            ApplicationService.InSert(data);
            return Json("");
        }
    }
}