using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using TwinkleStar.Common.Base64;

namespace MrHai.BMS.Filters
{
    public class UserCenterFilter : AuthorizeAttribute
    {
        string cookieIDField = "";
        string cookieNameField = "";
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpRequestBase request = httpContext.Request;
            if (request.Cookies[cookieIDField] == null || request.Cookies[cookieIDField].Value == null)
            {
                return false;
            }
            if (request.Cookies[cookieNameField] == null || request.Cookies[cookieNameField].Value == null)
            {
                return false;
            }
            string cookieID = request.Cookies[cookieIDField].Value;
            string cookieName = request.Cookies[cookieNameField].Value;

            if (string.IsNullOrEmpty(cookieID) || string.IsNullOrEmpty(cookieName))
            {
                return false;
            }
            //cookieID = Base64Helper.DecodeBase64(cookieID);
            //cookieName = Base64Helper.DecodeBase64(cookieName);
            if (string.IsNullOrEmpty(cookieID) || string.IsNullOrEmpty(cookieName))
            {
                return false;
            }
            int id = 0;
            if (int.TryParse(cookieID, out id))
            {
                //if (UserStatus(cookieName, id) > 0)
                //{
                //    string url = request.RawUrl;
                //    StreamReader stream = new System.IO.StreamReader(request.InputStream);
                //    string content = stream.ReadToEnd();
                //    request.InputStream.Seek(0, SeekOrigin.Begin);//将流指针初始化                    
                //    string ip = request.UserHostAddress;
                //    ModelData.InsertIntoUserLog(url, content, id, ip);//异步存储用户操作信息
                return true;
                //}
            }
            return false;
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