using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class SortingUsersController : Controller
    {
        private SortingUsersService sortingUsers;
        public SortingUsersController()
        {
            sortingUsers = new SortingUsersService();
        }
        public IActionResult Index()
        {
            var users = sortingUsers.GetUserByAlphabets();
            return View(users);
        }
    }
}