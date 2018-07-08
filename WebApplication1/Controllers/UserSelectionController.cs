using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class UserSelectionController : Controller
    {
        private UserSelectionService userSelection;
        public UserSelectionController()
        {
            userSelection = new UserSelectionService();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var item = userSelection.GetUserSelections(id);
            return View(item);
        }
    }
}