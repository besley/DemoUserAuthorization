using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUtility;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    public class ProductController : ApiControllerBase
    {
        /// <summary>
        /// 根据产品id，获取产品数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductEntity Get(int id)
        {
            ProductManager pm = new ProductManager();
            return pm.Get(id);
        }

        [HttpPost]
        public void Insert()
        {

        }
    }
}
