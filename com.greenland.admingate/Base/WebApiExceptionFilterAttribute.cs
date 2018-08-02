using com.greenland.enums.Common;
using com.greenland.log.Normal;
using com.greenland.model.AdminModel;
using com.greenland.tool.BizException;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace com.greenland.admingate.Base
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //重写基类的异常处理方法
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
            else if (actionExecutedContext.Exception is TimeoutException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.RequestTimeout);
            }
            else if(actionExecutedContext.Exception is BizException)
            {
                var exception = actionExecutedContext.Exception as BizException;
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new VResponse { header = new VHeader { rspCode = exception.BizRspCode } }))
                };
                LogService.GetLogService().SavaLogAsync(new LogEntity
                {
                    LogType = LogTypeEnum.Error,
                    Function = exception.FunctionName,
                    RequestInfo = exception.Input,
                    ResponseInfo = exception.Output,
                    OtherInfo = exception.StackTrace,
                    SearchText1 = exception.SearchKey
                });
            }
            else
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(new VResponse { header = new VHeader { rspCode = (int)RspCodeEnum.RspCode_0005 } }))
                };
                LogService.GetLogService().SavaLogAsync(new LogEntity
                {
                    LogType = LogTypeEnum.Error,
                    Function = actionExecutedContext.Exception.Source,
                    OtherInfo = actionExecutedContext.Exception.StackTrace,
                    SearchText1 = "InterfaceError"
                });
            }

            base.OnException(actionExecutedContext);
        }
    }
}