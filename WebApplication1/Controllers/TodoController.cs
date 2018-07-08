using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class TodoController : Controller
    {
        private TodoService todoService;
        public TodoController()
        {
            todoService = new TodoService();
        }
        public IActionResult Index()
        {
            var todos = todoService.GetTodos();
            return View(todos);
        }
        public IActionResult TodoID(int id)
        {
            var todo = todoService.GetTodos().Where(x => x.Id == id).FirstOrDefault();
            return View(todo);
        }
    }
}