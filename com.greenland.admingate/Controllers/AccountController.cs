using com.greenland.tool.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace com.greenland.admingate.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public HttpResponseMessage Users()
        {         
            try
            {
                return WriteResponse("");
            }
            catch(Exception ex)
            {
                return WriteResponse(ex.Message);
            }
        }
    }
}
