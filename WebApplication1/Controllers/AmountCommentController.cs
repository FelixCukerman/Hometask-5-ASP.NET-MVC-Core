using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class AmountCommentController : Controller
    {
        private AmountCommentService amountComment;
        public AmountCommentController()
        {
            amountComment = new AmountCommentService();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var comment = amountComment.GetAmountComment(id);
            return View(comment);
        }
    }
}