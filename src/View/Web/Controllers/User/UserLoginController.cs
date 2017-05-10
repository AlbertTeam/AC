using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.User
{
    public class UserLoginController : UserController
    {
        // GET: UserLogin
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginOut()
        {
            return View();
        }
    }
}