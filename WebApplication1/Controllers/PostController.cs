using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PostController : Controller
    {
        private PostService postService;
        public PostController()
        {
            postService = new PostService();
        }
        public IActionResult Index()
        {
            var posts = postService.GetPosts();
            return View(posts);
        }
    }
}