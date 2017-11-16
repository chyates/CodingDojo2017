using System;
using System.Collections.Generic;

namespace csharpWall2.Models{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }

        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }

        public User()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
    }
}