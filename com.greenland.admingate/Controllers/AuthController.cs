using com.greenland.model.AdminModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace com.greenland.admingate.Controllers
{
    public class AuthController : BaseController
    {
        public HttpResponseMessage Login(LoginReq req)
        {
            return WriteResponse("No implement...");
        }
    }
}
