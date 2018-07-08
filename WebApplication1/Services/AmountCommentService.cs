using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AmountCommentService
    {
        public List<AmountComment> GetAmountComment(int id)
        {
            List<AmountComment> amountComments = new List<AmountComment>();
            var allposts = new PostService().GetPosts();
            allposts = allposts.Where(x => x.UserId == id).ToList<Post>();

            foreach (var posts in allposts)
            {
                uint i = 0;
                foreach (var comment in posts.Comments)
                {
                    i++;
                }
                amountComments.Add(new AmountComment { post = posts, count = i });
            }
            return amountComments;
        }
    }
}
