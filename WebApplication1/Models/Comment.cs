﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public uint Likes { get; set; }
    }
}
