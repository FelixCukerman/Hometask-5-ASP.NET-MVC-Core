using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
        private static List<User> users;
        public UserService()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/users").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = responseContent.ReadAsStringAsync().Result;

                users = JsonConvert.DeserializeObject<List<User>>(json);
                var posts = new PostService().GetPosts();
                var todos = new TodoService().GetTodos();

                foreach (var user in users)
                {
                    user.Posts = new List<Post>();
                    user.Todos = new List<Todo>();

                    foreach (var post in posts)
                    {
                        if (post.UserId == user.Id)
                        {
                            user.Posts.Add(post);
                        }
                    }

                    foreach (var todo in todos)
                    {
                        if (todo.UserId == user.Id)
                        {
                            user.Todos.Add(todo);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Bad request!");
            }
        }
        public List<User> GetUsers()
        {
            if (users != null)
                return users;
            else
                return new List<User> { new User { Id = -1, Avatar = "null", Name = "null", Email = "null", CreatedAt = DateTime.MinValue, Posts = null, Todos = null } };
        }

        public User GetUserById(int id)
        {
            return users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}