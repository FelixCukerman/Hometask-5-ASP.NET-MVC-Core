using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PostSelection
    {
        public Post post { get; set; }
        public Comment LongestComment { get; set; }
        public Comment CommentByMostLike { get; set; }
        public uint CommentAmount { get; set; }
    }
}