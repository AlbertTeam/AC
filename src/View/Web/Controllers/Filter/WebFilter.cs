using CommonTool.Converts;
using Core.IData.Log;
using System.ComponentModel.Composition;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Web.Filters
{
    [Export]
    public class WebFilter : AuthorizeAttribute
    {
        string cookieIDField = "d*2#!";
        string cookieNameField = "";

        [Import]
        protected ILogDataAccess DataAccess { set; get; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpRequestBase request = httpContext.Request;
            
            string cookieID = request.Cookies[cookieIDField]?.Value;
            string cookieName = request.Cookies[cookieNameField]?.Value;
            //WebLogEntity logEntity = new WebLogEntity();
            //logEntity.URL= request.RawUrl;
            //logEntity.IPAddress = request.UserHostAddress;
            //logEntity.UserID = cookieID.TryType<int>(0);
            //StreamReader stream = new StreamReader(request.InputStream);
            //logEntity.Content = stream.ReadToEnd();
            //request.InputStream.Seek(0, SeekOrigin.Begin);//将流指针初始化 
            //LogService.InsertWebLog(logEntity);
            return true;
        }


        /// <summary>
        /// 未登录，跳转登录
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            if (AjaxRequestExtensions.IsAjaxRequest(filterContext.RequestContext.HttpContext.Request))//判断是不是ajax请求
            {

            }
            filterContext.HttpContext.Response.Redirect("~/Login/UserLogin", true);
        }
    }
}