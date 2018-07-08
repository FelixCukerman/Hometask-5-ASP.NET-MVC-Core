using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class PostSelectionService
    {
        public PostSelection GetPostSelections(int id)
        {
            List<PostSelection> postSelections = new List<PostSelection>();
            var allposts = new PostService().GetPosts();
            foreach (var item in allposts.Where(x => x.Id == id))
            {
                var comment = item.Comments.Where(x => x.Likes == 0 || x.Body.Length > 80).ToList<Comment>();
                postSelections.Add(new PostSelection
                {
                    post = item,
                    LongestComment = item.Comments.OrderByDescending(x => x.Body.Length).First(),
                    CommentByMostLike = item.Comments.OrderByDescending(x => x.Likes).First(),
                    CommentAmount = (uint)comment.Count
                });
            }
            return postSelections.FirstOrDefault();
        }
    }
}
