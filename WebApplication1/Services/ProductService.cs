using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductService
    {
        private List<Product> products;

        public ProductService()
        {
            products = new List<Product>
            {
                new Product { Name = "Product1", Price = 12, Vendor = "China"},
                new Product { Name = "Product2", Price = 13, Vendor = "USA" },
                new Product { Name = "Product3", Price = 14, Vendor = "Mexico" }
            };
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
