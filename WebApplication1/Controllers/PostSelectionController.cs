using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PostSelectionController : Controller
    {
        private PostSelectionService postSelection;
        public PostSelectionController()
        {
            postSelection = new PostSelectionService();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            var item = postSelection.GetPostSelections(id);
            return View(item);
        }
    }
}