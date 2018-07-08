using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TodoListService
    {
        public List<TodoList> GetTodosList(int id)
        {
            List<TodoList> todoLists = new List<TodoList>();
            var alltodos = new TodoService().GetTodos();
            alltodos = alltodos.Where(x => x.UserId == id).ToList<Todo>();

            foreach (var todo in alltodos)
                todoLists.Add(new TodoList { Id = todo.Id, Name = todo.Name });

            return todoLists;
        }
    }
}
