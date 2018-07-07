using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CommentService
    {
        private static List<Comment> comments;
        public CommentService()
        {
            comments = new List<Comment>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/comments").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = responseContent.ReadAsStringAsync().Result;
                comments = JsonConvert.DeserializeObject<List<Comment>>(json);
            }
            else
            {
                throw new Exception("Bad request!");
            }
        }

        public List<Comment> GetComments()
        {
            if (comments != null)
                return comments;
            else
                return new List<Comment> { new Comment { Id = -1, Body = "null", CreatedAt = DateTime.MinValue, Likes = 0, PostId = -1 } };
        }
    }
}
