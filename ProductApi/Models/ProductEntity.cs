using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductApi.Models
{
    public class ProductEntity
    {
        public int ID
        {
            get;
            set;
        }

        public string ProductName
        {
            get;
            set;
        }

        public string ProductType
        {
            get;
            set;
        }

    }
}