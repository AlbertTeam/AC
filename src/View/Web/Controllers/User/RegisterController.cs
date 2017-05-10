using Core.IService.User;
using System.ComponentModel.Composition;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Controllers.User
{
    [Export]
    public class RegisterController :UserController
    {
        [Import]
        protected IUserDataAccess ApplicationService { set; get; }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {
            ApplicationService.DeleteCollect(111);
            return Json("");
        }
    }
}