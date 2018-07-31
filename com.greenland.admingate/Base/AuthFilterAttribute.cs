using com.greenland.adminservice.Cache;
using com.greenland.enums.Common;
using com.greenland.model.AdminModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace com.greenland.admingate.Base
{
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //如果用户方位的Action带有AllowAnonymousAttribute，则不进行授权验证
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return;
            }
            else
            {
                if(actionContext.ActionArguments == null || actionContext.ActionArguments.Count == 0 || !actionContext.ActionArguments.ContainsKey("req"))
                {
                    actionContext.Response = new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(new VResponse { header = new VHeader { rspCode = (int)RspCodeEnum.RspCode_0002 }}),Encoding.UTF8)
                    };
                    return;
                }
                else
                {
                    var req = actionContext.ActionArguments["req"];
                    var loginKeyPro = req.GetType().GetProperty("loginKey");
                    var sessionCodePro = req.GetType().GetProperty("sessionCode");

                    if (loginKeyPro == null || sessionCodePro == null)
                    {
                        actionContext.Response = new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(new VResponse { header = new VHeader { rspCode = (int)RspCodeEnum.RspCode_0002 } }), Encoding.UTF8)
                        };
                        return;
                    }

                    var loginKey = loginKeyPro.GetValue(req).ToString();
                    var sessionCode = sessionCodePro.GetValue(req).ToString();

                    if (string.IsNullOrWhiteSpace(sessionCode) || string.IsNullOrWhiteSpace(loginKey))
                    {
                        actionContext.Response = new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(new VResponse { header = new VHeader { rspCode = (int)RspCodeEnum.RspCode_0003 } }), Encoding.UTF8)
                        };
                        return;
                    }
                    else if(CommonCache.GetAuthCache(loginKey) != sessionCode)
                    {
                        actionContext.Response = new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(new VResponse { header = new VHeader { rspCode = (int)RspCodeEnum.RspCode_0004 } }), Encoding.UTF8)
                        };
                        return;
                    }
                }

            }
        }
    }
}