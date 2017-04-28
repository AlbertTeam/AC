using CommonTool;
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
            if (Request.Cookies != null && Request.Cookies["CurrentCulture"].Value != null)
            {
                string lang = Request.Cookies["CurrentCulture"].Value;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
     
            }
            else
            {
                HttpCookie cookieLange = new HttpCookie("CurrentCulture", "zh-CN");
                Response.AppendCookie(cookieLange);
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
                Logger.GetLogger(filterContext.Exception.Source).Error(filterContext.Exception.ToString());            
                filterContext.Result = new RedirectResult(Url.Action("Error500", "Error"));
            }           
        }
    }
}