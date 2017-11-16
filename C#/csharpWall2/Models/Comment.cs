using System;
using System.Collections.Generic;

namespace csharpWall2.Models{
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}