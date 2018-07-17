using com.greenland.admingate.Base;
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
    public class HomeController : BaseController
    {
        public static List<Product>  products = new List<Product> { new Product { id = 1, name = "book" }, new Product { id = 2, name = "food" } };

        [HttpGet]
        public HttpResponseMessage Test()
        {
            try
            {
                return WriteResponse(JsonConvert.SerializeObject(products));
            }
            catch(Exception ex)
            {
                return WriteResponse("系统异常", HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public HttpResponseMessage Test(int id)
        {
            try
            {
                var product = products.Find(p => p.id == id);
                if (product == null)
                {
                    return WriteResponse("空空如也");
                }
                return WriteResponse(JsonConvert.SerializeObject(product));
            }
            catch (Exception ex)
            {
                return WriteResponse("系统异常", HttpStatusCode.InternalServerError);
            }
        }
    }

    public class Product
    {
        public int id { get; set; }

        public string name {get;set;}
    }

}
