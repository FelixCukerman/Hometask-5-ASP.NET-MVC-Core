using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        public IActionResult Index()
        {
            var items = userService.GetUsers();
            return View(items);
        }
        public IActionResult UserID(int id)
        {
            var user = userService.GetUserById(id);
            return View(user);
        }
    }
}