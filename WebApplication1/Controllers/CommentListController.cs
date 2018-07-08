using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CommentListController : Controller
    {
        private CommentListService commentList;
        public CommentListController()
        {
            commentList = new CommentListService();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var comments = commentList.GetCommentList(id);
            return View(comments);
        }
    }
}