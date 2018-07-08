using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TodoService
    {
        private static List<Todo> todos;
        public TodoService()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/todos").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = responseContent.ReadAsStringAsync().Result;
                todos = JsonConvert.DeserializeObject<List<Todo>>(json);
            }
            else
            {
                throw new Exception("Bad request!");
            }
        }
        public List<Todo> GetTodos()
        {
            if (todos != null)
                return todos;
            else
                return new List<Todo> { new Todo { Id = -1, Name = "null", CreatedAt = DateTime.MinValue, IsComplete = false, UserId = -1 } };
        }
    }
}
