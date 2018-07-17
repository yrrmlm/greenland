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
        protected HttpResponseMessage WriteResponse(string content, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var response = new HttpResponseMessage(statusCode);
            response.Content = new StringContent(content, Encoding.UTF8);
            return response;
        }
    }
}
