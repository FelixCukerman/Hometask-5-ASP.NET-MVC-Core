using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PostService
    {
        private static List<Post> posts;
        private static CommentService commentService;
        public PostService()
        {
            commentService = new CommentService();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://5b128555d50a5c0014ef1204.mockapi.io/posts").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                var json = responseContent.ReadAsStringAsync().Result;

                posts = JsonConvert.DeserializeObject<List<Post>>(json);
                var comments = commentService.GetComments();

                foreach (var post in posts)
                {
                    post.Comments = new List<Comment>();

                    foreach (var comment in comments)
                    {
                        if (comment.PostId == post.Id)
                        {
                            post.Comments.Add(comment);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Bad request!");
            }
        }
        public List<Post> GetPosts()
        {
            if (posts != null)
                return posts;
            else
                return new List<Post> { new Post { Id = -1, Body = "null", Likes = 0, Comments = null, CreatedAt = DateTime.MinValue, Title = "null", UserId = -1 } };
        }

        public Post GetPostById(int id)
        {
            return posts.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
