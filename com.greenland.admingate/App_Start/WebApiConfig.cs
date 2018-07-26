using com.greenland.admingate.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace com.greenland.admingate
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.Filters.Add(new AuthFilterAttribute());
            config.Filters.Add(new WebApiExceptionFilterAttribute());
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "v1_Api",
                routeTemplate: "api/v1/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
