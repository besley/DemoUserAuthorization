using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using ServiceStack.Text;
using WebUtility;
using WebUtility.Security;

namespace ProductWeb.Controllers
{
    public class ProductController : WebControllerBase
    {
        public ProductController()
        {
            base.ApiUrl = "http://localhost/ProductApi/api/Product";
        }


        /// <summary>
        /// 列表产品数据fsdfds
        /// </summary>
        /// <returns></returns>
        //[AllowAnonymous]
        public ActionResult List()
        {
            return View();        
        }

        //[AllowAnonymous]
        [RequireAuthorize]
        public ActionResult Detail(string id)
        {
            return View();
        }

        [RequireAuthorize]
        public ActionResult Price(string id)
        {
            return View();
        }
    }
}
