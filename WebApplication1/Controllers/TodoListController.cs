using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class TodoListController : Controller
    {
        private TodoListService todoList;
        public TodoListController()
        {
            todoList = new TodoListService();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var items = todoList.GetTodosList(id);
            return View(items);
        }
    }
}