using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CommentListService
    {
        public List<Comment> GetCommentList(int id)
        {
            var allcomment = new CommentService().GetComments();
            return allcomment.Where(x => x.UserId == id && x.Body.Length < 50).ToList<Comment>();
        }
    }
}