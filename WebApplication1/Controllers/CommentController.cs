using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CommentController : Controller
    {
        private CommentService commentService;
        public CommentController()
        {
            commentService = new CommentService();
        }
        public IActionResult Index()
        {
            var items = commentService.GetComments();
            return View(items);
        }
    }
}