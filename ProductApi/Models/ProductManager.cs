using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApi.Models
{
    public class ProductManager
    {
        public ProductEntity Get(int id)
        {
            //retrive product entity from database
            var product = new ProductEntity { ID = 100, ProductName = "Sharlock", ProductType = "Book"};
            return product;
        }
    }
}