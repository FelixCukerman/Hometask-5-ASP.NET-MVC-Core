using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}