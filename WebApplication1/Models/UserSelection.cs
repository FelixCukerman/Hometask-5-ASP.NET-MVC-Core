using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class UserSelection
    {
        public User user { get; set; }
        public Post lastPost { get; set; }
        public uint commentByLastPost { get; set; }
        public uint unrealizedTask { get; set; }
        public Post mostCommentedPost { get; set; }
        public Post postByMostLike { get; set; }
    }
}
