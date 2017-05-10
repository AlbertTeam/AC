using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Controllers.Base
{
    public class ResPonseMessage
    {
        public ResPonseMessage()
        {
            result = new ResponseResult();
        }
        /// <summary>
        /// 响应头
        /// </summary>
        public ResponseHeader header
        { get; set; }
        /// <summary>
        /// 响应结果
        /// </summary>
        public ResponseResult result
        { get; set; }
        /// <summary>
        /// 响应内容
        /// </summary>
        public object body
        { get; set; }
    }
    public class ResponseHeader
    {
        /// <summary>
        /// 响应状态
        /// <para>200：响应正常</para>
        /// <para>500：系统错误</para>
        /// <para>501：验签失败</para>
        /// </summary>
        public int statusCode { get; set; }
        /// <summary>
        /// 响应格式
        /// 目前只支持 Json,XML
        /// </summary>
        public string resType { get; set; }
    }
    public class ResponseResult
    {
        /// <summary>
        /// 返回错误代码【业务定义】
        /// </summary>
        public int errCode
        { get; set; }

        /// <summary>
        /// 返回消息【业务定义】
        /// </summary>
        public string msg
        { get; set; }

        /// <summary>
        /// 服务时间【框架提供】
        /// </summary>
        public string serTime
        { get { return DateTime.Now.ToString(); } }
        /// <summary>
        /// 需要携带的其他信息
        /// </summary>
        public object info { set; get; }

        /// <summary>
        /// 缓存是否过期
        /// <para>0：已过期</para>
        /// <para>1：未过期，Body内容为Null</para>
        /// </summary>
        public int cacheStatus
        { get; set; }
    }
    public class ItemResult
    {
        public ItemResult()
        {
            results = new List<Result>();
        }
        public List<Result> results { set; get; }
    }
    public class Result
    {
        public int code { set; get; }

        public string msg { set; get; }
    }
}