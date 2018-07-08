using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SortingUsersService
    {
        public List<User> GetUserByAlphabets()
        {
            var allusers = new UserService().GetUsers();
            allusers = allusers.OrderBy(x => x.Name).ToList<User>();

            foreach (var item in allusers)
            {
                item.Todos = item.Todos.OrderByDescending(x => x.Name.Length).ToList<Todo>();
            }
            return allusers;
        }
    }
}
