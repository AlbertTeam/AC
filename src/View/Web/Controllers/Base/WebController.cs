using CommonTool;
using CommonTool.Base64;
using CommonTool.Converts;
using Core.IData.Log;
using Core.Model.Log;
using System.ComponentModel.Composition;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Web.Filters;

namespace Web.Controllers.Base
{
    [Export]
    [WebFilter]
    
    public class WebController : Controller
    {

        [Import]
        protected ILogDataAccess DataAccess { set; get; }
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

        /// <summary>
        /// 定义异步的时候json输出消息格式
        /// </summary>
        protected ResPonseMessage Message = new ResPonseMessage();

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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WebLog logEntity = new WebLog();
            logEntity.URL = Request.RawUrl;
            logEntity.IPAddress = Request.UserHostAddress;
            logEntity.UserID = UserID;
            StreamReader stream = new StreamReader(Request.InputStream);
            logEntity.Content = stream.ReadToEnd();
            Request.InputStream.Seek(0, SeekOrigin.Begin);//将流指针初始化 
            DataAccess.InsertWebLog(logEntity);
        }

        protected JsonResult JsonBase(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 国际化
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {


            base.Initialize(requestContext);
            if (Request.Cookies != null && Request.Cookies["CurrentCulture"]?.Value != null)
            {
                string lang = Request.Cookies["CurrentCulture"].Value;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(lang);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
                if (Request.Cookies["CurrentCulture"].Value.Equals("zh-CN"))
                {
                    ViewBag.Otherlanguage = "en-US";
                }
                else
                {
                    ViewBag.Otherlanguage = "zh-CN";
                }
            }
            else
            {
                HttpCookie cookieLange = new HttpCookie("CurrentCulture", "zh-CN");
                ViewBag.Otherlanguage = "en-US";
                Response.AppendCookie(cookieLange);
            }
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            if (AjaxRequestExtensions.IsAjaxRequest(filterContext.RequestContext.HttpContext.Request))//判断是不是ajax请求
            {
                Message.result.errCode = 500;
                Message.result.msg = filterContext.Exception.Message;
                filterContext.Result = JsonBase(Message);
            }
            else
            {
                Logger.GetLogger(filterContext.Exception.Source).Error(filterContext.Exception.ToString());
                throw filterContext.Exception;
                //filterContext.Result = new RedirectResult(Url.Action("Error500", "Error"));
            }
        }

    }
}