using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace com.greenland.admingate.Controllers
{
    public class BaseController : ApiController
    {
        protected HttpResponseMessage WriteResponse<T>(T t, HttpStatusCode statusCode = HttpStatusCode.OK) where T : new()
        {
            var response = new HttpResponseMessage(statusCode);
            response.Content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8);
            return response;
        }
    }
}
