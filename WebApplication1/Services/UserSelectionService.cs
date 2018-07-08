using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserSelectionService
    {
        public UserSelection GetUserSelections(int id)
        {
            List<UserSelection> userSelections = new List<UserSelection>();
            var allusers = new UserService().GetUsers();

            foreach (var item in allusers.Where(x => x.Id == id))
            {
                Post last = item.Posts.OrderByDescending(x => x.CreatedAt).First();
                uint amountComment = 0;
                uint amountTask = 0;

                foreach (var post in item.Posts.Where(x => x.CreatedAt == last.CreatedAt))
                {
                    foreach (var comment in post.Comments)
                        amountComment++;
                }

                foreach (var task in item.Todos)
                {
                    if (task.IsComplete == false)
                        amountTask++;
                }

                userSelections.Add(new UserSelection
                {
                    user = item,
                    lastPost = last,
                    commentByLastPost = amountComment,
                    unrealizedTask = amountTask,
                    mostCommentedPost = item.Posts.OrderByDescending(x => x.Comments.Count).First(),
                    postByMostLike = item.Posts.OrderByDescending(x => x.Likes).First()
                });
            }
            return userSelections.FirstOrDefault();
        }
    }
}
