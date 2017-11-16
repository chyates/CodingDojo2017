using System;
using System.Collections.Generic;

namespace csharpWall2.Models
{
    public class Post : BaseEntity
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public List<Comment> Comments { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
        }
    }

}