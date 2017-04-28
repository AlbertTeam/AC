using CommonTool.Base64;
using CommonTool.Converts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers.Base
{
    public class BaseController : Controller
    {
        protected int UserID
        {
            get
            {
                if (Request.Cookies["userID"] == null || Request.Cookies["userID"].Value == null)
                {
                    return 0;
                }
                string cookie = Request.Cookies["userID"].Value.TryType<string>(null);
                if (string.IsNullOrEmpty(cookie))
                {
                    return 0;
                }
                else
                {
                    cookie = Base64Helper.DecodeBase64(cookie);
                    return cookie.TryType<int>(0);
                }
            }
        }

        protected string UserName
        {
            get
            {
                if (Request.Cookies["name"] == null || Request.Cookies["name"].Value == null)
                {
                    return string.Empty;
                }
                string cookie = Request.Cookies["name"].Value.TryType<string>(null);
                if (string.IsNullOrEmpty(cookie))
                {
                    return string.Empty;
                }
                else
                {
                    cookie = Base64Helper.DecodeBase64(cookie);
                    return cookie.TryType<string>(string.Empty);
                }
            }
        }

        protected JsonResult JsonBase(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["CurrentCulture"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["CurrentCulture"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["CurrentCulture"].ToString());
            }
            else
            {
                Session["CurrentCulture"] = "zh-CN";
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            if (AjaxRequestExtensions.IsAjaxRequest(filterContext.RequestContext.HttpContext.Request))//判断是不是ajax请求
            {

            }
            else
            {               

                throw filterContext?.Exception??new Exception("  dadas");                
                //filterContext.Result = new RedirectResult(Url.Action("Error500", "Error"));
            }           
        }
    }
}